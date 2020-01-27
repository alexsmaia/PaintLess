using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    Rigidbody rb;

    public float speed;
    public Transform enemy;
    private bool movingRight = true;
    public float distance;

    public Transform ground;

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        rb = GetComponent<Rigidbody>();
        Debug.Log(transform.position.z);

        if(transform.position.z == 46 && movingRight == true)
        {
            Debug.Log("hello");
            transform.eulerAngles = new Vector3(0, 0, -180);
            movingRight = false;
            //transform.Rotate(enemy.position.x, 180, enemy.position.z);
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
        

    }
}
