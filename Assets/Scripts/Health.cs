using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    // Set Variables
    public Rigidbody player;
    GameManager instance = GameManager.instance;

    void FixedUpdate()
    {

        // Lose health while moving
        instance.pHealth -= player.velocity.magnitude * 0.01f;

        // ToDo Loose helth jump and collide

        // If helth is 0 Game Over
        if(instance.pHealth <= 0)
        {
            instance.GameOver();
        }

        // 
        float scaleValue = instance.Remap(instance.pHealth, 0, 100, 0.4f, 2);
        transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
        //Debug.Log(scaleValue);

    }
}
