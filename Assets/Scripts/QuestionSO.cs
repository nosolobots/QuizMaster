using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Scriptable Objects/Quiz Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] 
    string question = "Introduce el texto de la pregunta aquí";
}
