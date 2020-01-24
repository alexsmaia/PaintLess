using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameEnd = false;

    // Change Level function
    public void EndLevel()
    {
        Invoke("nextScene", 1f);
    }

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    // Game Over funtion
    public void GameOver ()
    {
        if (gameEnd == false)
        {
            // Set Game Over
            gameEnd = true;
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
}
