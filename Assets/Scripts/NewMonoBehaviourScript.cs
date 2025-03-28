using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource audio = Camera.main.GetComponent<AudioSource>();
        audio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
