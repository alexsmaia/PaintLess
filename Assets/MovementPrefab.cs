using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPrefab : MonoBehaviour
{

    Rigidbody rb;
    private Vector3 translation;
    public Transform player;
    // Start is called before the first frame update


    void Start()
    {
        float dis = Vector3.Distance(player.position, transform.position);
        Debug.Log("dis2: " + dis);
        if(dis > 0 && dis <= 5.42)
        {
            rb = GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * dis * 1.55f, ForceMode.Impulse);
        }
        else if(dis > 5.42 && dis <= 7.52)
        {
            rb = GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * dis * 1.25f, ForceMode.Impulse);
        }
        else if (dis > 7.52 && dis <= 8.96)
         {

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward* dis * 1.1f, ForceMode.Impulse);
        }
        else if (dis > 8.96 && dis <= 9.73)
         {
            rb = GetComponent<Rigidbody>();
         rb.AddForce(transform.forward* dis * 1.05f, ForceMode.Impulse);
        }
        else if (dis > 9.73 && dis <= 10.95)
         {
            rb = GetComponent<Rigidbody>();
             rb.AddForce(transform.forward* dis, ForceMode.Impulse);
        }
        else
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
