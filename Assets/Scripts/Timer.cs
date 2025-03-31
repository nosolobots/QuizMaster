
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   
    [SerializeField] float answerTime;
    [SerializeField] float reviewTime;
    [SerializeField] Image timerImage;
    [SerializeField] Sprite reviewTimerSprite;
    [SerializeField] Sprite defaultTimerSprite;

    float timeLeft;
    float totalTime;

    public enum TimerState 
    {
        NotStarted,
        Answering,
        Reviewing,
        ReviewEnded
    }
    TimerState timerState;
    public TimerState State => timerState;

    void Awake()
    {
        timerState = TimerState.NotStarted;
    }

    public void StartTimer()
    {
        timerState = TimerState.Answering;

        timerImage.sprite = defaultTimerSprite;

        ResetTimer(answerTime);
    }

    void ResetTimer(float time)
    {
        totalTime = time;
        timeLeft = time;
        timerImage.fillAmount = 1f;
    }

    public void CancelTimer()
    {
        timeLeft = 0;
    }

    void Update()
    {
        if (timerState == TimerState.NotStarted)
            return;

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
        float fillAmount = timeLeft / totalTime;
        if (timerState == TimerState.Reviewing)
        {
            fillAmount = 1 - fillAmount;
        }
        timerImage.fillAmount = fillAmount;
    }

    void UpdateState()  
    {
        if (timeLeft == 0)
        {
            if (timerState == TimerState.Answering)
            {
                // Fin del tiempo de respuesta

                // Cambiar la imagen del temporizador a la de revisión
                timerImage.sprite = reviewTimerSprite;

                // Reiniciar el temporizador para la revisión
                ResetTimer(reviewTime);

                // Cambiar el estado a revisión
                timerState = TimerState.Reviewing;
            }
            else
            {
                // Cambiar el estado a revisión finalizada
                timerState = TimerState.ReviewEnded;
            }            
        }
    }

}
