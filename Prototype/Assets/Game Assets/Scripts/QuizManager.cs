using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
   
    public QuizDataBase[] quizDataBases;
    public GameObject[] options;
   // public int currentQuestions;
    public float currentTime = 0;
    public Text QuestionText;
    public Text countdownText;
    public int count = 0;

    private void Start()
    {
        currentTime = quizDataBases[count].timer;
        generateQuestions();
        
    }
    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        int tempCurrent = (int)Math.Round(currentTime);
        countdownText.text = "Time :" + tempCurrent.ToString();

        if (currentTime <= 0)
        {
            currentTime = 0;
            Debug.Log("False");
            correct();
        }
    }

    public void correct()
    {
         //quizDataBases.RemoveAt(currentQuestions);
        if (count < quizDataBases.Length - 1)
        {
            count++;
            currentTime = quizDataBases[count].timer;
            generateQuestions();
        }
        else
        {
            QuestManager.instance.TurnOffPanelQuiz();
            QuestManager.instance.SetOffQuiz();
            QuestManager.instance.endQuest();
        }
        
         
    }
    void SetAnswer()
    {
        for (int i = 0; i <= options.Length - 1; i++)
        {
            options[i].GetComponent<AnswerScripts>().isCorrect = false;

            if (quizDataBases[count].isTeks) // Jika isTeks bernilai true, gunakan AnswerTeks
            {
                options[i].transform.GetChild(1).GetComponent<Text>().enabled = true;
                options[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
                options[i].transform.GetChild(1).GetComponent<Text>().text = quizDataBases[count].AnswerTeks[i];
            }
            else // Jika isTeks bernilai false, tampilkan gambar
            {
                options[i].transform.GetChild(1).GetComponent<Text>().enabled = false;
                options[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                options[i].transform.GetChild(0).GetComponent<Image>().sprite = quizDataBases[count].Answers[i];
            }


            if (quizDataBases[count].CorrectAnswer == i)
            {
                options[i].GetComponent<AnswerScripts>().isCorrect = true;
            }
            else
            {
                options[i].GetComponent<AnswerScripts>().isCorrect = false;
            }
        }
    }

    void generateQuestions()
    {
       
        QuestionText.text = quizDataBases[count].Question;
        SetAnswer();
        
    }
}
