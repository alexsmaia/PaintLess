using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public Text scoreText;

    public void Start()
    {
        scoreText.text = GameManager.instance.pScore.ToString();
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
