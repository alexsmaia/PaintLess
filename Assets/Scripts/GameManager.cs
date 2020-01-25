﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Create the Singleton Object
    public static GameManager instance;

    // GLOBAL VARIABLES
    
    public int startHealth = 100;
    public int startScore = 0;
    public float pHealth = 100;
    public int pScore = 0;

    private const float time = 0.6f;

    // Actions Boll Variables
    [HideInInspector]
    public bool canJump = false;
    [HideInInspector]
    bool gameEnd = false;
    [HideInInspector]
    bool gameOver = false;

    // Create Singleton when awake
    void Awake()
    {
        MakeSingleton();
    }

    // End Level Function
    public void EndLevel()
    {
        // Set score
        pScore += (int)pHealth;
        // Set full Health
        pHealth = startHealth;


        // Get next lvl after some time
        Invoke("changeLevel", time: time);
    }

    // Change Game Level
    public void changeLevel()
    {
        // Check if there are more levels
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            // Next Level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            // Finish Game no more lvls
            gameEnd = true;
        }
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(SceneManager.sceneCountInBuildSettings);
    }



    // Game Over funtion
    public void GameOver()
    {
        if (!gameOver)
        {
            // Set Game Over
            gameOver = true;
            Debug.Log("game Over");
            // Restart Game
            Restart();
        }

    }

    // Restart Game function
    void Restart()
    {
        //SceneManager.LoadScene("GameOver");
    }


    // Function create Singleton
    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Remap Function
    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    
}
