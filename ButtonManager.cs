using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void LoadPlayScene()
    {
        SceneManager.LoadScene(1);              
    }
   
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);              
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene(4);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
