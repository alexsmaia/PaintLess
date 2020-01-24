using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    // Set Variables
    public Rigidbody player;
    public Text healthTxt;



    void FixedUpdate()
    {

        // Lose health while moving
        Singletons.instance.pHealth -= player.velocity.magnitude * 0.01f;

        // Change Health text value
        healthTxt.text = Singletons.instance.pHealth.ToString();

        if(Singletons.instance.pHealth <= 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        

    }
}
