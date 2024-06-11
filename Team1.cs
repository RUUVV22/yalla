using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Team1 : MonoBehaviour
{
    //animation
    //[SerializeField] private AnimatorController animatorscoore1, animatorscore2;
    [SerializeField] private GameObject scoreanim1;
    [SerializeField] private Animator animator;


    public void hide()
    {
       scoreanim1.SetActive(false);        
    }
    
}
