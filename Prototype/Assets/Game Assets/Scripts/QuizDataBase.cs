using UnityEngine;
using System;


[System.Serializable]
public class QuizDataBase 
{
    public string Question;
    public Sprite[] Answers;
    public Boolean isTeks;
    public string[] AnswerTeks;
    public int CorrectAnswer;
    public float timer;    
}
