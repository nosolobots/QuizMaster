using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Preguntas")]
    //[SerializeField] List<QuestionSO> questionList = new List<QuestionSO>();
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI scoreText;

    // Sprites de las respuestas
    [Header("Botones")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] GameObject[] answerButtons;

    // Game Manager
    [Header("Game Manager")]
    [SerializeField] GameManager gameManager;

    // Slider
    [Header("Barra de Progreso")]
    [SerializeField] Slider progressBar;


    Timer timer;    
    bool gotAnswered;
    QuestionSO question;
    Score score;
    
    List<QuestionSO> questionList;

    //QuestionLoader questionLoader;

    void Start()
    {
        questionList = gameManager.GetQuestions();
        
        timer = GetComponent<Timer>();  
        score = GetComponent<Score>();

        SetProgressBar();

        StartQuestion();
    }

    void SetProgressBar()
    {
        progressBar.maxValue = questionList.Count;
        progressBar.value = 0;
    }

    void StartQuestion()
    {
        GetNextQuestion();
        
        timer.StartTimer();

        gotAnswered = false;
    }

    void Update()
    {
        if (!gotAnswered && timer.State == Timer.TimerState.Reviewing)
        {
            questionText.text = "¡Tiempo finalizado!";
            
            ShowCorrectAnswer();

            SetButtonState(false);

            ShowScore();
        }
        else if (timer.State == Timer.TimerState.ReviewEnded)
        {
            StartQuestion();
        }
    }

    public void OnAnswerSelected(int index)
    {
        // Cambiar el estado de la pregunta
        gotAnswered = true;

        GameObject button = answerButtons[index];

        if (index == question.CorrectAnswerIndex)
        {
            // Respuesta correcta
            questionText.text = "¡Respuesta correcta!";
            score.AddCorrectAnswer();
        }
        else
        {
            // Respuesta incorrecta
            questionText.text = "Ohhh... Respuesta incorrecta";
        }

        // Mostrar la respuesta correcta
        ShowCorrectAnswer();

        SetButtonState(false);

        ShowScore();

        // Desactivar el temporizador
        timer.CancelTimer();
    }

    void ShowCorrectAnswer()
    {
        answerButtons[question.CorrectAnswerIndex].GetComponent<Image>().sprite = correctAnswerSprite;

        gotAnswered = true;
    }

    void GetNextQuestion()
    {
        if (questionList.Count > 0)
        {
            GetRandomQuestion();

            DisplayQuestion();
            score.AddQuestionVisited();
            ShowScore();

            SetButtonState(true);
            SetDefaultAnswerSprites();
            progressBar.value = score.QuestionsVisited;
        }
        else
        {
            // No hay más preguntas, finalizar el juego o reiniciar
            gameManager.EndGame();
        }
    }

    QuestionSO GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionList.Count);
        question = questionList[randomIndex];
        questionList.RemoveAt(randomIndex);

        return question;
    }

    void DisplayQuestion()
    {
        questionText.text = question.Question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.GetAnswer(i);
        }
    }

    void SetButtonState(bool state)
    {
        foreach (GameObject button in answerButtons)
        {
            button.GetComponent<Button>().interactable = state;
        }
    }

    void SetDefaultAnswerSprites()
    {
        foreach (GameObject button in answerButtons)
        {
            button.GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }

    void ShowScore()
    {
        scoreText.text = "Puntuación: " + score.CorrectAnswers + "/" + score.QuestionsVisited;
    }
}
