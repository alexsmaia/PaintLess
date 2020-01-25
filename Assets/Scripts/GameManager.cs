using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const float time = 0.6f;
    bool gameEnd = false;
    Singletons instance = Singletons.instance;

    // Change Level function
    public void EndLevel()
    {
        // Set score
        instance.pScore += (int)instance.pHealth;
        // Set full Health
        instance.pHealth = instance.startHealth;

        Debug.Log(Singletons.instance.pScore);

        // Get next lvl after some time
        Invoke("changeLevel", time: time);
    }

    public void changeLevel()
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
