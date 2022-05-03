using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answersscripts : MonoBehaviour
{
   public bool isCorrect = false;
    public Quizmanager1 quizManager;

    public void Answers()
    {
        if(isCorrect)
        { 
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            Debug.Log("Wroong Answer");
            quizManager.wrong();
        }
    }
}
