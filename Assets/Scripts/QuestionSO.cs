using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Scriptable Objects/Quiz Question")]
public class QuestionSO : ScriptableObject
{
    // Pregunta
    [TextArea(2, 5)]
    [SerializeField] 
    string question = "Introduce el texto de la pregunta aquí";
    public string Question => question;

    // Respuestas
    [SerializeField]
    string[] answers = new string[4];
    public string[] Answers => answers;
    public string GetAnswer(int index) => answers[index];

    // Índice de la respuesta correcta
    [SerializeField]
    [Range(0, 3)]
    int correctAnswerIndex = 0;
    public int CorrectAnswerIndex => correctAnswerIndex;

    public void SetData(string question, string[] answers, int correctAnswerIndex)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswerIndex = correctAnswerIndex;
    }
}
