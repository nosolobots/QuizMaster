using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] TextMeshProUGUI message;

    void Start()
    {
        message.text = "Has respondido " + score.CorrectAnswers + " de " + score.QuestionsVisited + " preguntas correctamente.";
        if (score.CorrectAnswers == score.QuestionsVisited)
        {
            message.text += "\n¡Felicidades! Has respondido todas las preguntas correctamente.";
        }
        else if (score.CorrectAnswers == 0)
        {
            message.text += "\n¡No te preocupes! Puedes intentarlo de nuevo.";
        }
        else
        {
            message.text += "\n¡Buen trabajo! Puedes mejorar aún más.";
        }
    }

}
