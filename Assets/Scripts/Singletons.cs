using UnityEngine;

public class Singletons : MonoBehaviour
{

    // Create the Singleton Object
    public static Singletons instance;

    [HideInInspector]
    public int startHealth = 100;
    public int startScore = 0;
    public float pHealth = 100;
    public int pScore = 0;
    public bool canJump = false;

    public int StartScore { get => startScore; set => startScore = value; }

    // Create Singleton when awake
    void Awake()
    {
        MakeSingleton();
    }

    // Start is called before the first frame update
    void Start()
    {

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
