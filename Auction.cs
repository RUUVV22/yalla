using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Auction : MonoBehaviour
{
    [SerializeField] private AudioSource timer10s;
    [SerializeField] private Teamsinfo info;
    [SerializeField] private TextMeshProUGUI Question, answer,auction,timer,RoundNumber;
    [SerializeField] private GameObject ansewrs,nextpart,allrounds;
    private int roundnumber=1;
    private int AuctionCounter=0;
    private int CurrentIndex;
    /// timer athribute
    private float TimeRemaining = 3f;
    private bool timerIsRunninng;
    /// <summary> buttons
    public static bool Player1 = false;
    public static bool Player2 = false;
    [SerializeField]private Button Correct1;
    [SerializeField]private Button Correct2,right,faul;
    [SerializeField]private GameObject choosetheplayer,thetimer;
    /// </summary>

    /// <summary>
    /// Button color change
    [SerializeField]private Color disabledcolor,enabledcolor;
    [SerializeField]Button Starttimer;
    public Selectable selectable;
    /// </summary>

    private List<string> questions = new List<string> {
    "Who can mention more types of fruit in 30 seconds?",
    "Who can mention more car brands in 30 seconds?",
    "Who can mention more sports in 30 seconds?",
    "Who can mention more movie titles in 30 seconds?",
    "Who can mention more video game titles in 30 seconds?",
    "Who can mention more famous singers in 30 seconds?",
    "Who can mention more professional football players in 30 seconds?",
    "Who can mention more songs by Taylor Swift in 30 seconds?",
    "Who can mention more countries in Asia in 30 seconds?",
    "Who can mention more types of trees in 30 seconds?",
    "Who can mention more popular social media platforms in 30 seconds?",
    "Who can mention more famous actors in 30 seconds?",
    "Who can mention more FIFA World Cup host countries in 30 seconds?",
    "Who can mention more football managers who have won the UEFA Champions League in 30 seconds?",
    "Who can mention more prophets mentioned in the Quran in 30 seconds?",
    "Who can mention more Islamic holidays in 30 seconds?",
    "Who can mention more Islamic countries in 30 seconds?"
    };

    private List<string> answers = new List<string>
    {
        "ar",
        "alen",
        "messi",
        "idk",
        "1986",
        "real",
        "messi",
        "german",
        "messi",
        "camp no"
    };

    void Start()
    {
        ChooseRandomQuestion();
        Starttimer.interactable = false;
    }
    void Update()
    {
        Timer();
        RoundNumberfun();
        if(TimeRemaining == 0)
            timer10s.Stop();
        RoundNumber.text = "#" + roundnumber.ToString();
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
                timerIsRunninng = false;
                Debug.Log("Time's up!");
            }
        }
    }
    void RoundNumberfun()
    {
        if (roundnumber ==6)
        {
            roundnumber = 5;
            Invoke("loadascene", .11f);// load scene after 3s
        }
    }
    void loadascene()
    {
        this.gameObject.SetActive(false);
        allrounds.SetActive(false);
        nextpart.SetActive(true);
    }
    public void StartTimer()// yalla
    {
        timer10s.Play();
        if (AuctionCounter != 0)
        {
            if (Player1 || Player2)
            {
                thetimer.SetActive(true);
                choosetheplayer.SetActive(false);
                right.enabled = true;
                faul.enabled = true;
                timerIsRunninng = true;
                //yalla = true;
                ansewrs.SetActive(true);
                TimeRemaining = 30f;
            }
            else
            {
                Debug.Log("try again");
                
            }
        }
    }
    void afterscore()
    {
        buttonColorwithoutclick(Correct1);
        buttonColorwithoutclick(Correct2);
        right.enabled = false;
        faul.enabled = false;
        AuctionCounter = 0;
        auction.text = AuctionCounter.ToString();
        StartCoroutine(ChangeQuestionAfterDelay(2.5f));
    }
    public void Right()
    {
        Starttimer.interactable = false;
        info.Right(Player1,Player2);
        TimeRemaining = 0;
        afterscore();
    }
    public void Faul()
    {
        Starttimer.interactable = false;
        info.Right(Player2,Player1);
        TimeRemaining = 0;
        afterscore();
    }
    IEnumerator ChangeQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Change the question text after 3 seconds
        roundnumber ++;
        ChooseRandomQuestion();
        ansewrs.SetActive(false);
        choosetheplayer.SetActive(true);
        thetimer.SetActive(false);
    }
    IEnumerator replaceQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ChooseRandomQuestion();
    }
    
    private void buttonColoronclick(Button button)
    {
        ColorBlock buttoncolor = button.colors;
        buttoncolor.normalColor = Color.red;
        button.colors = buttoncolor;
    }
    private void buttonColorwithoutclick(Button button)
    {
        ColorBlock buttoncolor = button.colors;
        buttoncolor.normalColor = Color.white;
        button.colors = buttoncolor;
    }
    public void correct1()
    {
        buttonColoronclick(Correct1);
        buttonColorwithoutclick(Correct2);
        Player1 = true;
        Player2 = false;
    }

    public void correct2()
    {
        buttonColoronclick(Correct2);
        buttonColorwithoutclick(Correct1);
        Player2 = true;
        Player1 = false;
    }
    public void Increase()
    {
        if (AuctionCounter < 40)
        {
            Starttimer.interactable = true;
            AuctionCounter++;
            auction.text = AuctionCounter.ToString();
        }
    }
    public  void Decrease()
    {
        if(AuctionCounter >0)
        {
            if (AuctionCounter == 1)
            {
                Starttimer.interactable = false;
            }
            AuctionCounter--;
            auction.text = AuctionCounter.ToString();
        }
    }
    public void Replace()
    {
        StartCoroutine(replaceQuestionAfterDelay(1.5f));
    }
    private void ChooseRandomQuestion()
    {
        CurrentIndex = Random.Range(0, questions.Count);
        Question.text = questions[CurrentIndex];
        //answer.text = answers[CurrentIndex];
    }
    void UpdateTimerText()
    {
        int seconds = Mathf.RoundToInt(TimeRemaining);
        timer.text = seconds.ToString();
    }
}
