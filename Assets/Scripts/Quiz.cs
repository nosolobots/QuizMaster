using TMPro;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    [SerializeField]
    QuestionSO question;

    [SerializeField]
    TextMeshProUGUI questionText;
    
    [SerializeField]
    GameObject[] answerButtons;

    void Start()
    {
        // Mostrar la pregunta
        questionText.text = question.Question;

        // Mostrar las respuestas
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.GetAnswer(i);
        }
    }

}
