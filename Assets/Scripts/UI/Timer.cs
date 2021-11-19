using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Image background;
    [SerializeField]
    private Image fill;
    public Slider timerSlider;
    private float timeRemaining;
    private bool running;

    private void Update() => Tick();

    private void Tick()
    {
        if (!running)
            return;
        timeRemaining -= Time.deltaTime;
        timerSlider.value = timeRemaining;
        if (timeRemaining <= 0f)
        {
            StopCountDown();
        }
    }
    
    public void StartCountDown(float countDownTime)
    {
        running = true;
        background.enabled = true;
        fill.enabled = true;
        timerSlider.maxValue = countDownTime;
        timerSlider.value = countDownTime;
        timeRemaining = countDownTime;
    }    
    public void StopCountDown()
    {
        running = false;
        background.enabled = false;
        fill.enabled = false;
    }
}
