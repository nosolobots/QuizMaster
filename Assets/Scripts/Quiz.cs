using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject[] answerButtons;

    // Sprites de las respuestas
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    //QuestionLoader questionLoader;

    void Start()
    {
        //questionLoader = GetComponent<QuestionLoader>();

        GetNextQuestion();
    }

    public void OnAnswerSelected(int index)
    {
        GameObject button = answerButtons[index];

        if (index == question.CorrectAnswerIndex)
        {
            // Respuesta correcta
            questionText.text = "¡Respuesta correcta!";
            button.GetComponent<Image>().sprite = correctAnswerSprite;
        }
        else
        {
            // Respuesta incorrecta
            questionText.text = "Ohhh... Respuesta incorrecta";
            button.GetComponent<Image>().sprite = defaultAnswerSprite;
            answerButtons[question.CorrectAnswerIndex].GetComponent<Image>().sprite = correctAnswerSprite;
        }

        SetButtonState(false);
    }

    void GetNextQuestion()
    {
        //question = questionLoader.LoadedQuestions[Random.Range(0, questionLoader.LoadedQuestions.Count)];

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
