using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float answerTime;
    [SerializeField] float reviewTime;
    [SerializeField] GameObject timerImage;
    float timeLeft;

    void Start()
    {
        timeLeft = answerTime;
        if (timerImage != null)
        {
            timerImage.GetComponent<UnityEngine.UI.Image>().fillAmount = 1f;
        }
    }

    void Update()
    {
        UpdateTimer();
        UpdateTimerImage();
    }

    void UpdateTimer()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                timeLeft = 0;
            }
        }
    }

    void UpdateTimerImage()
    {
        if (timerImage != null)
        {
            float fillAmount = timeLeft / answerTime;
            timerImage.GetComponent<UnityEngine.UI.Image>().fillAmount = fillAmount;
        }
    }

}
