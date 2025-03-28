using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Preguntas")]
    [SerializeField] QuestionSO[] questions;
    [SerializeField] TextMeshProUGUI questionText;
 
    // Sprites de las respuestas
    [Header("Botones")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] GameObject[] answerButtons;

    Timer timer;    
    bool gotAnswered;
    int currentQuestionIndex;
    QuestionSO question;

    //QuestionLoader questionLoader;

    void Start()
    {
        //questionLoader = GetComponent<QuestionLoader>();

        timer = GetComponent<Timer>();  
        
        StartQuestion();
    }

    void StartQuestion()
    {
        GetNextQuestion();
        
        timer.StartTimer();

        gotAnswered = false;
    }

    void Update()
    {
        if (!gotAnswered && !timer.IsAnsweringState)
        {
            questionText.text = "¡Tiempo finalizado!";
            
            ShowCorrectAnswer();

            SetButtonState(false);
        }

        if (timer.EndReviewState)
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
        }
        else
        {
            // Respuesta incorrecta
            questionText.text = "Ohhh... Respuesta incorrecta";
        }

        // Mostrar la respuesta correcta
        ShowCorrectAnswer();

        SetButtonState(false);

        // Desactivar el temporizador
        timer.CancelTimer();
    }

    void ShowCorrectAnswer()
    {
        answerButtons[question.CorrectAnswerIndex].GetComponent<Image>().sprite = correctAnswerSprite;
    }

    void GetNextQuestion()
    {
        //question = questionLoader.LoadedQuestions[Random.Range(0, questionLoader.LoadedQuestions.Count)];
        question = questions[currentQuestionIndex];
        currentQuestionIndex++;
        if (currentQuestionIndex >= questions.Length)
        {
            currentQuestionIndex = 0;
        }
        
        DisplayQuestion();
        SetButtonState(true);
        SetDefaultAnswerSprites();
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

}
