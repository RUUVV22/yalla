using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Actpart : MonoBehaviour
{
    [SerializeField] private AudioSource timer10s;
    [SerializeField] private Teamsinfo info;
    [SerializeField] private TextMeshProUGUI roundnumber,timer;
    [SerializeField] private Image photo;
    [SerializeField] private Button nextquestion;
    private int currentindex;
    public int roundnum = 1;
    bool ispress=false;
    /// <summary>
    /// //////team 1 info

    [SerializeField] private GameObject[] Strikes1;
    public int strkieindex1 = 0;
    public int increasecount1 = 0;

    /// <summary>
    /// //////team 2 info

    [SerializeField] private GameObject[] Strikes2;
    public int strkieindex2 = 0;
    public int increasecount2 = 0;

    /// <summary>
    /// Buttons 
    [SerializeField] private Button startbutton, Strike1, Strike2;
    /// </summary>
    /// 
    private float TimeRemaining = 3f;
    private bool timerIsRunninng;
    public List<Sprite> photos;


    void Start()
    {
        ChooseRandomImages();
        desabledbuttons();
    }

    void Update()
    {
        roundnumber.text = "#" + roundnum;
        RoundNumber();
        Timer();
        if (ispress&&TimeRemaining==0)
        {
            desabledbuttons();
        }
        if (TimeRemaining == 0)
        {
            timer10s.Stop();
        }
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
                TimeRemaining = 0f;
                UpdateTimerText();
                timerIsRunninng = false;
                Debug.Log("Time's up!");
            }
        }
    }
    void UpdateTimerText()
    {
        int seconds = Mathf.RoundToInt(TimeRemaining);
        timer.text = seconds.ToString();
    }
    public void NextQuestion()
    {
        timer10s.Play();
        ispress = true;
        enabledbuttons();
        TimeRemaining = 60f;
        timerIsRunninng = true;
    }
    void RoundNumber()
    {
        if (roundnum == 6)
        {
            ////////////////load the new scene
            roundnum = 5;
            desabledbuttons();
            Invoke("loadascene", .11f);// load scene after 3s
        }
    }
    void loadascene()
    {
        SceneManager.LoadScene(3);
    }
    void enabledbuttons()
    {
        Strike1.enabled = true;
        Strike2.enabled = true;
    }
    public void desabledbuttons()
    {
        Strike1.enabled = false;
        Strike2.enabled = false;
    }
    public IEnumerator ChangeQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Change the question text after 3 seconds
        TimeRemaining = 0;
        roundnum++;
        if (strkieindex1 == 3 || strkieindex2 == 3)
        {
            info.fillstrikes(Strikes1, Strikes2);
        }
        strkieindex1 = 0;
        strkieindex2 = 0;
        ChooseRandomImages();
    }
    IEnumerator replaceQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ChooseRandomImages();
    }
    public void Replace()
    {
        desabledbuttons();
        StartCoroutine(replaceQuestionAfterDelay(1.5f));
    }
    private void ChooseRandomImages()
    {
        currentindex = Random.Range(0, photos.Count);
        photo.sprite = photos[currentindex];
    }
    public void strike1()
    {
        info.strikesactpart(Strikes2, Strikes1, strkieindex1, 1);
        strkieindex1++;
        if (strkieindex1 == 3)
        {
            TimeRemaining = 0;
            desabledbuttons();
        }
    }
    public void strike2()
    {
        info.strikesactpart(Strikes1, Strikes2, strkieindex2, 2);
        strkieindex2++;
        if (strkieindex2 == 3)
        {
            TimeRemaining = 0;
            desabledbuttons();
        }
    }
}
