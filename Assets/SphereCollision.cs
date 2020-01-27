using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCollision : MonoBehaviour
{
    // Check Trigger Enter
    private void OnTriggerEnter(Collider colTrigerEnter)
    {
        /*if (colTrigerEnter.CompareTag("Bucket"))
        {
            Destroy(colTrigerEnter.gameObject);
            instance.pHealth += 20;
        }

        if (colTrigerEnter.CompareTag("Water"))
        {
            instance.onWater = true;
        }*/
        Destroy(colTrigerEnter.gameObject);
        Debug.Log("destroid");
    }
}
