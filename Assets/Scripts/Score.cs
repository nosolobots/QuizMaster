using UnityEngine;

public class Score : MonoBehaviour
{
    int correctAnswers = 0;
    public int CorrectAnswers => correctAnswers;
    public void AddCorrectAnswer()
    {
        correctAnswers++;
    }
    
    int questionsVisited = 0;
    public int QuestionsVisited => questionsVisited;
    public void AddQuestionVisited()
    {
        questionsVisited++;
    }

    public void ResetScore()
    {
        correctAnswers = 0;
        questionsVisited = 0;
    }
}
