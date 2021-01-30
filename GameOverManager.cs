using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;
    public GameObject Player;
    private GameObject player;

    public float currentHealth;
    public bool isGameOver;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isGameOver = false;
        player = GameObject.FindGameObjectWithTag("Player");
        currentHealth = Player.GetComponent<HP>().currentHealth;
    }
   
    public void GameEnded()
    {
        Debug.Log("GameOver");
        //Object.Destroy(player);
        SceneManager.LoadScene(3);
        Cursor.visible = true;
    }

    //void RestartGame()
    //{     
    //        SceneManager.LoadScene(0);
    //}
}


