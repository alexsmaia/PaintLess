using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Create the Singleton Object
    public static GameManager instance;

    // GLOBAL VARIABLES
    public int startHealth = 100;
    public int startScore = 0;
    public int bucketHealth = 20;
    public int jumpLoseHealth = 5;
    public float pHealth = 100;
    public int pScore = 0;

    private const float time = 0.6f;

    // Actions Boll Variables
    [HideInInspector]
    public bool canJump = false;
    [HideInInspector]
    public bool onWater = false;

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

            // Set full Health
            pHealth = startHealth;
        }
        else
        {
            // Finish Game no more lvls
            SceneManager.LoadScene("Victory");
        }
    }

    // Game Over funtion
    public void GameOver()
    {
        // Open Game Over
        SceneManager.LoadScene("GameOver");
    }

    // Restart Game function
    public void Restart()
    {
        // Reset Variables
        pScore = startScore;
        pHealth = startHealth;
        // Satar Game Level 1
        SceneManager.LoadScene("Level1");

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
