using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{

    private int score;
    private int score2;
    [SerializeField] private TextMeshProUGUI score1text, score2text;


    //public int Score1 { get => score; set => score = value; }
    public int get()
    {
        return score;
    }
    public int get2()
    {
        return score2;
    }
    public int increasescore1(int s)
    {
        return score += s;
    }
    public int increasescore2(int s)
    {
        return score2 += s++;
    }
    public string printscore(TextMeshProUGUI score)
    {
        return score.text;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
