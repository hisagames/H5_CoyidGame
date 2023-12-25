using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScripts : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager[] qm;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct");
            qm[QuestManager.instance.currentQuestid].correct();
            QuestManager.instance.finalPointResult++;
        }
        else
        { 
            Debug.Log("False");
            qm[QuestManager.instance.currentQuestid].correct();
        }
    }
}
