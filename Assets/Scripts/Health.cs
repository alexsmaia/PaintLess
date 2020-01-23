using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Rigidbody player;
    public Text healthTxt;


    // Update is called once per frame
    void Update()
    {
        healthTxt.text = Singletons.instance.pHealth.ToString();
    }

    void FixedUpdate()
    {

        // Lose health while moving
        Singletons.instance.pHealth -= player.velocity.magnitude * 0.01f;

        Debug.Log(Singletons.instance.pHealth);

    }
}
