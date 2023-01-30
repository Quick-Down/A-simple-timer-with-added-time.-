using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime;        // Основное время float
    public float balltime;         // Для заполнения
    public Text timeTex;           // Текст времени.
    public Image timerImage;       // Шкала заполения;

    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            startTime = 120f;
            AgainTimer();
        }
        if (startTime > 0) startTime -= Time.deltaTime;         // Сам таймер
        if (Input.GetKeyDown(KeyCode.Minus)) { 
            startTime -= 60; balltime = startTime; }
        if (Input.GetKeyDown(KeyCode.Equals)) { 
            startTime += 60; balltime = startTime; }
        UpdateTimeText();
    }
    public void UpdateTimeText()
    {
        if (startTime < 0) { startTime = 0; gameObject.SetActive(false); }

        float minutes = Mathf.FloorToInt(startTime / 60);
        float seconds = Mathf.FloorToInt(startTime % 60);
        var normalizedValue = Mathf.Clamp(startTime / balltime, 0.0f, 1.0f);
        timerImage.fillAmount = normalizedValue;
        timeTex.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    public void AgainTimer() { startTime = 121; balltime = startTime;}
}