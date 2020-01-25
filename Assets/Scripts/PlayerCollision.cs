using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Game Manager instance
    GameManager instance = GameManager.instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // Check Collision Enter
    void OnCollisionEnter(Collision colEnter)
    {
        //health = health - rb.velocity.magnitude * 0.8f;

        if (colEnter.collider.CompareTag("Ground") || colEnter.collider.CompareTag("Platform"))
        {
            // Enable Jump
            instance.canJump = true;
        }
    }

    // Check Collision Exit
    void OnCollisionExit(Collision colExit)
    {
        if (colExit.collider.CompareTag("Ground") || colExit.collider.CompareTag("Platform"))
        {
            // Disable Jump
            instance.canJump = false;
        }
    }

    // Check Trigger Enter
    private void OnTriggerEnter(Collider colTriger)
    {
        if (colTriger.CompareTag("Bucket"))
        {
            Destroy(colTriger.gameObject);
            instance.pHealth += 20;
        }
    }

}
