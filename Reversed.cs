using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reversed : MonoBehaviour
{
    [SerializeField] private AudioSource timer10s;
    [SerializeField] private Teamsinfo info; 
    [SerializeField] private Text originalword, guesswordtext;
    [SerializeField] private TextMeshProUGUI reversedwoord,RoundNumber,timer;
    [SerializeField] private GameObject chooseword, guessword,allrounds,nextpart;
    [SerializeField] private InputField Choooseinputfield,Guessinputfield ;
    [SerializeField] private Button teamm1, teamm2;
    private int roundnumber=1;
    private bool player1=false;
    private bool player2=false;
    private bool yalla=true;

    //timer
    private float TimeRemaining = 3f;
    private bool timerIsRunninng;


    void Start()
    {

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
                StartCoroutine(Backtochoose(1f));
                TimeRemaining = 0f;
                timerIsRunninng = false;
                if (guesswordtext.text != "")
                {
                    info.Right(player2, player1);
                }
                Debug.Log("Time's up!");
            }
        }
    }
    void UpdateTimerText()
    {
        int seconds = Mathf.RoundToInt(TimeRemaining);
        timer.text = seconds.ToString();
    }
    public void yallaBTN()
    {
        timer10s.Play();
        yalla=false;
        if (originalword.text != "")
        {
            if (player1 || player2)
            {
                chooseword.SetActive(false);
                guessword.SetActive(true);
                yalla = true;
                timerIsRunninng = true;
                TimeRemaining = 15f;
                reversedwoord.text = Reverseword(originalword.text).ToUpper();
            }
        }
    }
    private void buttonColoronclick(Button button)
    {
        ColorBlock buttoncolor = button.colors;
        buttoncolor.normalColor = Color.red;
        button.colors = buttoncolor;
    }
    private void buttonColorwithouclick(Button button)
    {
        ColorBlock buttoncolor = button.colors;
        buttoncolor.normalColor = Color.white;
        button.colors = buttoncolor;
    }
    public void team1()
    {
        buttonColoronclick(teamm1);
        buttonColorwithouclick(teamm2);
        player1 = true;
        player2=false;
    }
    public void team2()
    {
        buttonColoronclick(teamm2);
        buttonColorwithouclick(teamm1);
        player2 = true;
        player1 = false;
    }
    public void deselect()
    {
        if (!yalla) {
            player1 = false;
            player2 = false;
       }
    }
    string Reverseword(string originalword)
    {
        char[] charArray = new char[originalword.Length];
        int forwardIndex = 0;
        int backwardIndex = originalword.Length-1;
        string print="|";
        while (backwardIndex >= 0)
        {
            charArray[forwardIndex] = originalword[backwardIndex];//reverse algo
            print +=charArray[forwardIndex].ToString()+"|";//print each char
            forwardIndex++;
            backwardIndex--;
        }
        return print;
    }
    
    public void Guessword()
    {
        if(originalword.text == guesswordtext.text)
        {
            info.Right(player1,player2);
        }
        else
        {
            info.Right(player2, player1);
        }
        StartCoroutine(ChangeQuestionAfterDelay(1.5f));
    }
    IEnumerator ChangeQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        TimeRemaining = 0;
        buttonColorwithouclick(teamm1);
        buttonColorwithouclick(teamm2);
        roundnumber++;
        chooseword.SetActive(true);
        guessword.SetActive(false);
        Choooseinputfield.text = "";
        Guessinputfield.text = "";
        deselect();
    }
    IEnumerator Backtochoose(float delay)
    {
        yield return new WaitForSeconds(delay);

        buttonColorwithouclick(teamm1);
        buttonColorwithouclick(teamm2);
        chooseword.SetActive(true);
        guessword.SetActive(false);
        Choooseinputfield.text = "";
        Guessinputfield.text = "";
        TimeRemaining = 0f;
        deselect();
    }
    void Update()
    {
        Timer();
        RoundNumber.text = "#" + roundnumber.ToString();
        Debug.Log(RoundNumber.text);
        if(roundnumber > 5 )
        {
            this.gameObject.SetActive(false);
            allrounds.SetActive(false);
            nextpart.SetActive(true);
            roundnumber = 5;
        }
        if (TimeRemaining == 0)
        {
            timer10s.Stop();
        }
    }
}
