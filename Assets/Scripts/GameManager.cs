using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const float time = 0.6f;
    bool gameEnd = false;

    // Change Level function
    public void EndLevel()
    {
        Debug.Log("endlevel");
        Invoke("nextLevel", time: time);
    }

    public void nextLevel()
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
