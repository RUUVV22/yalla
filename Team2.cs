using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Team2 : MonoBehaviour
{
    [SerializeField] private GameObject scoreanim2;
    [SerializeField] private Animator animator;


    public void hide()
    {
        scoreanim2.SetActive(false);
    }
}
