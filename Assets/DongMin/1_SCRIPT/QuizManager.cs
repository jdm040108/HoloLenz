using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QNA> Qna;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI ScoreText;

    int totalQuestions = 0;
    public int score;
    private void Start()
    {
        totalQuestions = Qna.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = score + "/" + totalQuestions;
    }

    public void correct()
    {
        score += 1;
        Qna.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        Qna.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for(int i=0;i<options.Length;i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            /*options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Qna[currentQuestion].Answers[i];*/

            if(Qna[currentQuestion].CorrectAnswer==i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (Qna.Count > 0)
        {
            currentQuestion = Random.Range(0, Qna.Count);
            QuestionText.text = Qna[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            GameOver();
        }
    }

}
