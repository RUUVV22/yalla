using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingPage : MonoBehaviour
{
    bool timerIsRunninng = false;
    private float TimeRemaining = 0;
    private int loadTime = 0;
    private void Start()
    {
        timerIsRunninng = true;
        TimeRemaining = 5f;
    }
    void Update()
    {
        //loadTime++;
        //if (loadTime == 1000)
        //{
        //    part.SetActive(true);
        //    loadpage.SetActive(false);
        //}
        Timer();
    }
    private void Timer()
    {
        if (timerIsRunninng)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                SceneManager.LoadScene(1);
                TimeRemaining = 0f;
                timerIsRunninng = false;
            }
        }
    }
    void UpdateTimerText()
    {
        int seconds = Mathf.RoundToInt(TimeRemaining);
        //timer.text = seconds.ToString();
    }
}
