using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Quiz quiz;
    [SerializeField] EndGame endGame;
    [SerializeField] QuestionLoader questionLoader;

    void Awake()
    {
        StartGame();
    }

    void StartGame()
    {
        quiz.gameObject.SetActive(true);
        endGame.gameObject.SetActive(false);
    }

    public List<QuestionSO> GetQuestions()
    {
        return questionLoader.LoadedQuestions;
    }

    public void EndGame()
    {
        quiz.gameObject.SetActive(false);
        endGame.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
