using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    // Set Variables
    public Rigidbody player;

    void FixedUpdate()
    {

        // Lose health while moving
        Singletons.instance.pHealth -= player.velocity.magnitude * 0.01f;

        if(Singletons.instance.pHealth <= 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }

        float scaleValue = Singletons.instance.Remap(Singletons.instance.pHealth, 0, 100, 0.4f, 2);
        transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        Debug.Log(scaleValue);

    }
}
