using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Transitions : MonoBehaviour
{
    [SerializeField] private int scenenum;
    [SerializeField] private GameObject DevInfo,homepage,Pause,game;

    public void NextScene()
    {
        SceneManager.LoadScene(scenenum);
    }
    public void ShowDevInfo()
    {
        DevInfo.SetActive(true);
        homepage.SetActive(false);
    }
    public void HideDevInfo()
    {
        DevInfo.SetActive(false);
        homepage.SetActive(true);
    }
    public void PauseGame()
    {
        Pause.SetActive(true);
        //game.SetActive(false);
    }
    public void ResumeGame()
    {
        Pause.SetActive(false );
        //game.SetActive(true);
    }
    public void EndGame()
    {
        SceneManager.LoadScene(scenenum);
    }
}
