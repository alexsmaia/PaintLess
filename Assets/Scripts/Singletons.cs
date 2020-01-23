using UnityEngine;

public class Singletons : MonoBehaviour
{

    // Create the Singleton Object
    public static Singletons instance;

    [HideInInspector]
    public float pHealth = 100;

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


}
