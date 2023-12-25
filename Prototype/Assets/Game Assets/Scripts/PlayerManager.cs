using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed;
    private float moveHorizontal =0;
    public float jump;
    public bool isGrounded;
    public bool isNearNpc , isTriggeredNpcQuest , isPlayerHaveQuest;
    private Vector3 tempos;
    public GameObject panel;
    public Image imageChar;
    public GameObject npcNearMe;
    private bool moveLeft;
    private bool moveRight;
    public int temp;
    private bool actionBtn = false;
    private Rigidbody2D mybody;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public GameObject charaObject;
    public Animator charaAnimator;

    // Start is called before the first frame update
   
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        isNearNpc = false;
        moveSpeed = 5f;
        actionBtn = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        tempos = transform.position;
        tempos.x += moveHorizontal * moveSpeed * Time.deltaTime;
        transform.position = tempos;
        if (moveHorizontal > 0)
        {
            charaAnimator.SetBool("isRun", true);
            charaObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (moveHorizontal < 0)
        {
            charaAnimator.SetBool("isRun", true);
            charaObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }


        // HandleAnimation();
        //HandleFacingDirection();
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.59f, 0.32f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (isGrounded)
        {
            charaAnimator.SetTrigger("isLand");
        }

        if (actionBtn)
        {
            if (isNearNpc == true)
            {
                if (isTriggeredNpcQuest)
                {
                    if (QuestManager.instance.isQuestFinished)
                    {
                        QuestManager.instance.SetStoryData();
                        QuestManager.instance.ShowStoryPanel();
                        QuestManager.instance.SetQuiz();
                        //QuestManager.instance.endQuest(); dipindahkan ke quiz manager
                        isTriggeredNpcQuest = false;
                        isPlayerHaveQuest = false;
                        actionBtn = false;
                    }
                    else
                    {
                        if (isPlayerHaveQuest)
                        {
                            QuestManager.instance.ShowQuestPanel();
                            actionBtn = false;
                           
                        }
                        else
                        {
                            QuestManager.instance.SetQuestData();
                            QuestManager.instance.ShowQuestPanel();
                            actionBtn = false;
                            isPlayerHaveQuest = true;
                        }
    
                    }
                  
                }
                else
                {
                    temp = npcNearMe.GetComponent<NpcChatScripts>().chatId;
                    int tempo = npcNearMe.GetComponent<NpcChatScripts>().indexChar;
                    imageChar.sprite = npcNearMe.GetComponent<NpcChatScripts>().charImage[tempo];
                    panel.SetActive(true);
                    DialogStory tempDialogStory = panel.GetComponentInChildren<DialogStory>();
                    StartCoroutine(tempDialogStory.TypeDialog(npcNearMe.GetComponent<NpcChatScripts>().chatTeks[temp]));
                    tempDialogStory.skipText(npcNearMe.GetComponent<NpcChatScripts>().chatTeks[temp]);
                    temp = temp + 1;

                    if (temp >= npcNearMe.GetComponent<NpcChatScripts>().chatTeks.Length)
                        temp = 0;

                    npcNearMe.GetComponent<NpcChatScripts>().chatId = temp;
                    actionBtn = false;
                }
            }
            else
            {
                actionBtn = false;
            }
            
        }
        MovePlayerbutton();
    }
    
    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        { 
            isNearNpc = true;
            npcNearMe = collision.gameObject;
            isTriggeredNpcQuest = collision.gameObject.GetComponent<NpcChatScripts>().isHaveQuest;
        }
        else if (collision.gameObject.tag == "Objective")
        {
            QuestManager.instance.addPoint(1);
            QuestManager.instance.SetActiveQuestData();
            QuestManager.instance.CekStatus();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            isNearNpc = false;
            npcNearMe = null;
            actionBtn = false;
            isTriggeredNpcQuest = false;
        }
    }
   /* void HandleAnimation()
    {
        if (Mathf.Abs(moveHorizontal) > 0)
        {
            anim.PlayAnimation(TagManager.Walk);
        }

       // else
            //anim.PlayAnimation(TagManager.Idle);
    }*/
   /* void HandleFacingDirection()
    {
        if (moveHorizontal > 0)
            anim.SetFacingDirection(true);
        else if (moveHorizontal < 0)
            anim.SetFacingDirection(false);
    }*/
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }

    private void MovePlayerbutton()
    {
        if (moveLeft)
        {
           // anim.PlayAnimation(TagManager.Walk);
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            // anim.SetFacingDirection(false);
            charaAnimator.SetBool("isRun", true);
            charaObject.transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else if (moveRight)
        {
           // anim.PlayAnimation(TagManager.Walk);
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            // anim.SetFacingDirection(true);
            charaAnimator.SetBool("isRun", true);
            charaObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            moveHorizontal = 0;
            // anim.PlayAnimation(TagManager.Idle);
            charaAnimator.SetBool("isRun", false);
        }

    }
    public void jumpController()
    {
        if (isGrounded)
        {
            isGrounded = false;
            charaAnimator.SetTrigger("isJump");
            mybody.AddForce(new Vector2(mybody.velocity.x, jump));
            // anim.PlayAnimation(TagManager.Jump);
        }
    }
   public void actionButton()
    {
        actionBtn = true;
    }
   
}
