using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnername, score;
    string team1name,team2name;
    int team1score,team2score;

    void Start()
    {
        team1name = PlayerPrefs.GetString("teamone");
        team2name = PlayerPrefs.GetString("teamtwo");
        team1score = PlayerPrefs.GetInt("finalscore1");
        team2score = PlayerPrefs.GetInt("finalscore2");
        if (team1score > team2score)
        {
            winnername.text=team1name;
            score.text=team1score.ToString();
        }else if (team1score < team2score)
        {
            winnername.text=team2name;
            score.text="Score : "+team2score.ToString();
        }
        //score1.text = team1score.ToString();
        //score2.text = team2score.ToString();
    }

    
    void Update()
    {
        
    }
}
