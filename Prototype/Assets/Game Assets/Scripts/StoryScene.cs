using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoryScene : MonoBehaviour
{
    [SerializeField] Text dialogText;

    [SerializeField] GameObject skipButton;
    [SerializeField] GameObject nextButton;

    IEnumerator myCoroutine;
    [SerializeField] int letterPerSeconds;
    [SerializeField] [TextArea] string text = "";

    void Start()
    {
        myCoroutine = TypeDialog(text);
        StartCoroutine(myCoroutine);  
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";

        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }
        skipButton.SetActive(false);
        nextButton.SetActive(true);
    }
    public void skip()
    {
        dialogText.text = text;
        StopCoroutine(myCoroutine);
    }
}
