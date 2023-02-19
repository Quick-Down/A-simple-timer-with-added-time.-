using UnityEngine;
using UnityEngine.UI;
using System;

public class NewTimer : MonoBehaviour
{
    public TimeSpan startTime = TimeSpan.FromMinutes(2); // Start time as a TimeSpan
    public TimeSpan balltime;                            // Duration of time to fill the timer bar
    public Text timeTex;                                 // Text displaying the time
    public Text speedTex;                                // Text displaying the current speed
    public Image timerImage;                             // Timer bar

    void Update()
    {
        // Subtract elapsed time from the start time
        startTime -= TimeSpan.FromSeconds(Time.deltaTime);

        // Adjust the start time based on user input
        if (Input.GetKeyDown(KeyCode.Minus)) startTime -= TimeSpan.FromMinutes(1);
        if (Input.GetKeyDown(KeyCode.Equals)) startTime += TimeSpan.FromMinutes(1);

        UpdateTimeText();
    }
    void UpdateTimeText()
    {
        // Ensure the start time is not negative
        if (startTime < TimeSpan.Zero)
        {
            startTime = TimeSpan.Zero;
            gameObject.SetActive(false);
        }

        // Update the timer bar
        var normalizedValue = Mathf.Clamp((float)(startTime.TotalSeconds / balltime.TotalSeconds), 0f, 1f);
        timerImage.fillAmount = normalizedValue;

        // Update the time text
        timeTex.text = string.Format("{0:mm} : {0:ss}", startTime);
    }
    public void AgainTimer()
    {
        startTime = TimeSpan.FromMinutes(2);
        balltime = startTime;
        Debug.Log(balltime);
    }
}
