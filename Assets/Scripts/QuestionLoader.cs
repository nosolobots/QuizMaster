using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QuestionLoader : MonoBehaviour
{
    [System.Serializable]
    private class QuestionData
    {
        public string question;
        public string[] answers;
        public int correctAnswerIndex;
    }

    [System.Serializable]
    private class QuestionList
    {
        public List<QuestionData> questions;
    }

    public List<QuestionSO> LoadedQuestions { get; private set; } = new List<QuestionSO>();

    // Nombre del archivo JSON en la carpeta Resources (sin extensión)
    [SerializeField] private string jsonFileName; 

    private void Awake()
    {
        LoadQuestionsFromJSON();
    }
    private void LoadQuestionsFromJSON()
    {
        // Cargar archivo JSON
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFileName);

        if (jsonFile == null)
        {
            Debug.LogError("No se ha asignado un archivo JSON en el Inspector.");
            return;
        }

        // Convertir JSON a objetos en memoria
        QuestionList questionList = JsonUtility.FromJson<QuestionList>(jsonFile.text);

        if (questionList == null || questionList.questions.Count == 0)
        {
            Debug.LogError("El JSON está vacío o mal formado.");
            return;
        }

        // Crear los QuestionSO en memoria
        foreach (var data in questionList.questions)
        {
            QuestionSO newQuestion = ScriptableObject.CreateInstance<QuestionSO>();
            newQuestion.SetData(data.question, data.answers, data.correctAnswerIndex);
            LoadedQuestions.Add(newQuestion);
        }

        Debug.Log($"Se han cargado {LoadedQuestions.Count} preguntas en memoria.");
    }
}
