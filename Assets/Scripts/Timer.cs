
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float answerTime;
    [SerializeField] float reviewTime;
    [SerializeField] Image timerImage;
    float timeLeft;
    bool answeringState;

    void Start()
    {
        timeLeft = answerTime;
        timerImage.fillAmount = 1f;
        answeringState = true;
    }

    void Update()
    {
        UpdateTimer();
        UpdateTimerImage();
        UpdateState();
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
            timerImage.fillAmount = fillAmount;
        }
    }

    void UpdateState()
    {
        if (timeLeft == 0)
        {
            if (answeringState)
            {
                // Fin del tiempo de respuesta
                answeringState = false;
                timeLeft = reviewTime;
            }
            else
            {
                // Fin de la revisión

            }            
        }
    }

}
