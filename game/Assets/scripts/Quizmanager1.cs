using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quizmanager1 : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;
    public Color wrongcol, rightcol;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void map()
    {
        SceneManager.LoadScene("Quiz");
    }
    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }
    public void correct()
    {
        score += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

    }
    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }
    
    void  SetAnswers()
    {
        for(int i=0; i<options.Length;i++)
        {
            options[i].GetComponent<Answersscripts>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            if(QnA[currentQuestion].CorrectAnswer==i+1)
            {
                options[i].GetComponent<Answersscripts>().isCorrect = true;
                
            }
            else
            {
                options[i].GetComponent<Button>().image.color = wrongcol;
            }
            options[i].GetComponent<Button>().image.color = rightcol;
        }
    }
    void generateQuestion()
    {   if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("out of Question");
            GameOver();
        }
        
    }
}
