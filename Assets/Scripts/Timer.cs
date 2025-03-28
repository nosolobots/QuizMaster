
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float answerTime;
    [SerializeField] float reviewTime;
    [SerializeField] Image timerImage;
    float timeLeft;
    float totalTime;
    bool answeringState;
    public bool IsAnsweringState => answeringState;
    bool endReviewState;
    public bool EndReviewState => endReviewState;

    public void StartTimer()
    {
        ResetTimer(answerTime);

        answeringState = true;
        endReviewState = false;
    }

    public void CancelTimer()
    {
        timeLeft = 0;
    }

    void Update()
    {
        UpdateTimer();
        UpdateTimerImage();
        UpdateState();
    }

    void ResetTimer(float time)
    {
        totalTime = time;
        timeLeft = time;
        timerImage.fillAmount = 1f;
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
        float fillAmount = timeLeft / totalTime;
        timerImage.fillAmount = fillAmount;
    }

    void UpdateState()
    {
        if (timeLeft == 0)
        {
            if (answeringState)
            {
                // Fin del tiempo de respuesta
                answeringState = false;
                
                ResetTimer(reviewTime);
            }
            else
            {
                // Fin de la revisión
                Debug.Log("Fin de la revisión");
                endReviewState = true;
            }            
        }
    }

}
