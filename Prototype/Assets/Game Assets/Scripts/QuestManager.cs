using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance;
    public int currentQuestid = 0;
    public int currentPoint = 0;
    public int finalPointResult = 0;
    public int maxPoints = 15;
    public int finalStars = 0;
    public bool isQuestFinished;
    public bool isLevelFinished = false;

    public GameObject[] npcWithQuest;
    public GameObject panelController;
    public GameObject panelLevelFinished;
    public GameObject panelStars3;
    public GameObject panelStars2;
    public GameObject panelStars1;
    public GameObject panelQuest;
    public GameObject panelQuestDataObj;
    public GameObject panelQuestStory;
    public GameObject panelQuiz;

    public Text TextTitle;
    public Image imageQuest;
    public Image imageDataObj;
 
    public Text TextDeskripsiDataObj;
    public Text TextDeskripsiData;
    public Text TextTotalPoint;
    public Text TextcurrentPoint;

    public Text TextDeskripsiStory;
    public Image ImageStory;

    public Sprite[] SpritequestDataObj;
    public string[] titles;
    public int[] TextquestDatapointsObj;
    public string[] TextquestDeskripsiDataObj;
    public Sprite[] Spritequest;
  
    public string[] Textdeskripsi;

    public string[] TextDeskripsiStoryData;
    public Sprite[] SpriteStoryData;

    public GameObject[] objectives;
    public GameObject[] QuizHandler;
    
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        SetActiveNpcQuest();
    }
    private void Update()
    {
        if (isLevelFinished)
        {
            //string levelStarsSelected = "Level" + levelSelectedID.ToString() + "Stars";
            //int handleI = levelSelectedID + 1;
            //PlayerPrefs.SetInt("ColorLevel" + handleI, handleI);
            //PlayerPrefs.SetInt("CekEnsiklopedia", 1);

            int levelSelectedID = PlayerPrefs.GetInt("SelectedLevel");

            panelController.SetActive(false);
            panelLevelFinished.SetActive(true);

            Time.timeScale = 1f;

            int tempStar = 0;
            if (finalPointResult >= 10)
            {
                panelStars3.SetActive(true);
                tempStar = 3;
            }
            else if (finalPointResult >= 5)
            {
                panelStars2.SetActive(true);
                tempStar = 2;
            }
            else
            {
                panelStars1.SetActive(true);
                tempStar = 1;
            }

            PlayerPrefs.SetString("LevelLockStatus" + (levelSelectedID + 1), "unlocked");
            if (tempStar > PlayerPrefs.GetInt("LevelStarResult" + levelSelectedID))
                PlayerPrefs.SetInt("LevelStarResult" + levelSelectedID, tempStar);
        }
        isLevelFinished = false;
    }
    public void ShowQuestPanel()
    {
        panelQuest.SetActive(true);
    }
    public void SetQuestData()
    {
        isQuestFinished = false;
        currentPoint = 0;
        TextTitle.text = titles[currentQuestid];
        imageQuest.sprite = Spritequest[currentQuestid];
        TextDeskripsiData.text = Textdeskripsi[currentQuestid];
    }
    public void SetObjective()
    {
        objectives[currentQuestid].SetActive(true);
    }
    public void SetActiveNpcQuest()
    {
        npcWithQuest[currentQuestid].GetComponent<NpcChatScripts>().isHaveQuest = true;
    }
    public void SetOffNpcQuest()
    {
        npcWithQuest[currentQuestid].GetComponent<NpcChatScripts>().isHaveQuest = false;
    }
    public void addPoint (int addPoints)
    {
        currentPoint += addPoints;
    }
    public void SetActiveQuestData()
    {
        TextTotalPoint.text = "/"+ TextquestDatapointsObj[currentQuestid].ToString();
        imageDataObj.sprite = SpritequestDataObj[currentQuestid];
        TextDeskripsiDataObj.text = TextquestDeskripsiDataObj[currentQuestid];
        TextcurrentPoint.text = currentPoint.ToString() ;
    }
    public void ShowQuestPanelQuest()
    { 
        panelQuestDataObj.SetActive(true);
        SetActiveQuestData();
    }
    
    public void CekStatus()
    {
        if (currentPoint >= TextquestDatapointsObj[currentQuestid])
        {
            isQuestFinished = true;
        }
    }
    public void endQuest()
    {
        isQuestFinished = false;
        SetOffNpcQuest();
        if(currentQuestid < npcWithQuest.Length-1)
        {
            currentQuestid++;
            SetActiveNpcQuest();
        }
        else
        {
            isLevelFinished = true;
        }
        
        
    }

    public void SetStoryData()
    {
        ImageStory.sprite = SpriteStoryData[currentQuestid];
        TextDeskripsiStory.text = TextDeskripsiStoryData[currentQuestid];
    }
    public void ShowStoryPanel()
    {
        panelQuestStory.SetActive(true);
    }

    public void SetQuiz()
    {
        QuizHandler[currentQuestid].SetActive(true);
    }
    public void SetOffQuiz()
    {
        QuizHandler[currentQuestid].SetActive(false);
    }
    public void ShowQuizPanel()
    {
        panelQuestDataObj.SetActive(false);
        panelQuiz.SetActive(true);
    }
    public void TurnOffPanelQuiz()
    {
        panelQuiz.SetActive(false);
    }
   
}
