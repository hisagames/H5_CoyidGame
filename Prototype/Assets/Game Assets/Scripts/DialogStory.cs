using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogStory : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] TextMeshProUGUI dialogText;
   
    [SerializeField] string text = "";
    [SerializeField] GameObject skip;
    [SerializeField] GameObject next;
    public Text textSkip;
    IEnumerator myCoroutine;
   
    public IEnumerator TypeDialog (string dialog)
    {
        dialogText.text = "";
       
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds) ;
        }
        skip.SetActive(false);
        next.SetActive(true); 
    }
    public void skipText(string dialog)
    {
        myCoroutine = TypeDialog(dialog);
        textSkip.text = dialog;
        StopCoroutine(myCoroutine);
    }
}
