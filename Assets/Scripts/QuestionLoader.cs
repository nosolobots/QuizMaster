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

    // Nombre del archivo JSON
    [SerializeField] string jsonFileName = "questions.json"; 

    private void Awake()
    {
        LoadQuestionsFromJSON();
    }
    private void LoadQuestionsFromJSON()
    {

        // Cargar archivo JSON
        string jsonFilePath = Path.Combine(Application.dataPath, jsonFileName);

        Debug.Log($"Ruta del archivo JSON: {jsonFilePath}");

        // Verificar si el archivo existe
        if (!File.Exists(jsonFilePath))
        {
            Debug.LogError($"El archivo JSON no se encuentra en la ruta: {jsonFilePath}");
            //Application.Quit();
            return;
        }

        Debug.Log("El archivo JSON se ha encontrado.");

        // Leer el contenido del archivo JSON
        string jsonContent = File.ReadAllText(jsonFilePath);
        if (string.IsNullOrEmpty(jsonContent))
        {
            Debug.LogError("El archivo JSON está vacío.");
            return;
        }

        Debug.Log("El archivo JSON se ha leído correctamente.");

        // Convertir JSON a objetos en memoria
        QuestionList questionList = JsonUtility.FromJson<QuestionList>(jsonContent);

        if (questionList == null || questionList.questions.Count == 0)
        {
            Debug.LogError("El JSON está vacío o mal formado.");
            return;
        }

        Debug.Log("El JSON se ha convertido a objetos en memoria.");

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
