using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Security.Cryptography;

public class Questions : MonoBehaviour
{
    [SerializeField]private GameObject nextpart,allrounds;
    [SerializeField]private Teamsinfo info;
    [SerializeField]private TextMeshProUGUI Question,answer,roundnumber;
    [SerializeField] private Button nextquestion;
    private int currentindex;
    public int sumscore=1;
    public int roundnum=1;
    public static bool IsNext = false;

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
    [SerializeField]private Button startbutton,Strike1,Strike2;
    /// </summary>
    /// 




    private List<string> questions = new List<string> {
    "countries that start with the letter \"B\"?",
    "movie titles that start with the letter \"T\"?",
    "football players name starts with the letter \"m\"?",
    "villages in irbid?",
    "yalla fam names?",
    "boycott companies?",
    "palestinian cities?",
    "Country currencies?",
    "Capitals of Arab countries?",
    "countries in Africa?",
    "universities in the Jordan?",
    "programming languages?"
    ,"national dishes from around the MENA?",
    "superheroes from Marvel Comics?",
    "famous directors in Hollywood?",
    "teams in the English Premier League?",
    "clubs in La Liga?",
    "FIFA World Cup winners?",
    "cartoon characters?",
    "characters from the Harry Potter series?",
    "board games?"
    };

    HashSet<string> answers = new HashSet<string> {
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
    //hashSet.Add(1);
    //hashSet.Remove(1);
    //private List<string> answers = new List<string>
    //{
    //    "ar",
    //    "alen",
    //    "messi",
    //    "idk",
    //    "1986",
    //    "real",
    //    "messi",
    //    "german",
    //    "messi",
    //    "camp no"
    //};

    
    private void Start()
    {
        ChooseRandomQuestion();
        //Debug.Log(answers.Count);
    }

    public void NextQuestion()
    {
        info.next= true;
        StartCoroutine(ChangeQuestionAfterDelay(2f));
        desabledbuttons();
    }
    private void Update()
    {
        roundnumber.text="#"+roundnum.ToString();
        RoundNumber();
    }
    void RoundNumber()
    {
        if (roundnum ==6)
        {
            ////////////////load the new scene
            roundnum = 5;
            desabledbuttons();
            Invoke("loadascene", .11f);// load scene after 3s
        }
    }
    void loadascene()
    {
        this.gameObject.SetActive(false);
        allrounds.SetActive(false);
        nextpart.SetActive(true);
    }
    public void enabledbuttons()
    {
        startbutton.interactable = true;
        Strike1.enabled = true;
        Strike2.enabled = true;
    }
    public void desabledbuttons()
    {
        startbutton.interactable = false;
        Strike1.enabled = false;
        Strike2.enabled = false;
    }
    public IEnumerator ChangeQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Change the question text after 3 seconds
        if (strkieindex1 == 3|| strkieindex2==3)
        {
            info.fillstrikes(Strikes1, Strikes2);
        }
        strkieindex1 = 0;
        strkieindex2 = 0;
        roundnum++;
        enabledbuttons();
        ChooseRandomQuestion();
    }
    IEnumerator replaceQuestionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        enabledbuttons();
        ChooseRandomQuestion();
    }
    public void Replace()
    {
        desabledbuttons();
        StartCoroutine(replaceQuestionAfterDelay(1.5f));
    }
    private void ChooseRandomQuestion()
    {
        currentindex = Random.Range(0, questions.Count);
        Question.text = questions[currentindex];
        //answer.text = answers[currentindex];
    }
    public void strike1()
    {
        info.strikes(Strikes2, Strikes1, strkieindex1,1);
        strkieindex1++;
    }
    public void strike2()
    {
        info.strikes(Strikes1,Strikes2,strkieindex2,2);
        strkieindex2++;
    }
}
