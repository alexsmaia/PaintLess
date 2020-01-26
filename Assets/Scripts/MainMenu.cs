using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GameManager.instance.Restart();
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
