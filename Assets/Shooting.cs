using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // movement variables
    public Transform player;
    public Transform bulletPrefab;
    public float speed;
    private Vector3 translation;

    public float rateOfFire = 1f;
    private float cooldownTimer = 0;

    // our field of view
    private float fieldOfViewAngle = 20f;

    // prefab variables
   // public GameObject shootPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // every frame subtract the passed time to our cooldown
        cooldownTimer -= Time.deltaTime;

        // once the cooldown gets below 0
        if (cooldownTimer <= 0)
        {
            // we reset the cooldown with the established rate of fire
            cooldownTimer = rateOfFire;


            if (CheckVisionAngle()) { 
                // SHOOT SPHERE
                ShootEnemy();
                Debug.Log("oi");
            }

        }

    }

    private void ShootEnemy()
    {
        // every time we press the button "Shoot" we instantiate a new bullet
        /*if (Input.GetButtonDown("Jump"))
        {*/


        //Instantiate(shootPrefab, transform.position, Quaternion.Euler(-50, transform.eulerAngles.y, transform.eulerAngles.z));
        // we instantiate the bullet (it has a script of its own to deal with the movement)
        Transform instance = Instantiate(bulletPrefab);

        // set the rotation and position to be the same as the enemy
        instance.rotation = transform.rotation;
        instance.position = transform.position;


        //}

    }

    private bool CheckVisionAngle()
    {
        bool canShoot = false;

        // this will get us a vector from the enemy towards the player
        Vector3 targetDir = player.position - transform.position;
        float dis = Vector3.Distance(player.position, transform.position);
        //Debug.Log("distancia: " + dis);
        

        // we use "Vector3.Angle" to calculate angles between vectors, 
        //in this case we calculate the angle between the enemy "transform.up" (where he is facing) and the vector that faces the player
        // to check if the enemy is seeing the player
        float angle = Vector3.Angle(targetDir, transform.forward);

        // if the angle between them is less than half the enemy field of view, then he can see the player
        if (angle < fieldOfViewAngle * 0.5f)
        {
            // a debug ray, so we can see the raycast
            Debug.DrawRay(transform.position, targetDir.normalized * Mathf.Infinity, Color.green);
            
            // then we raycast... It has the purpose to check if there's no obstacles between him and the player
            // if there is any obstacle, that means the enemy can't shoot the player because he can't see him
            Ray ray = new Ray(transform.position, targetDir.normalized);
            if (Physics.Raycast(ray, out RaycastHit hit, 10.95f))
            {
                // if the object that is hit, is the player, that means the enemy is seeing him, so now he can shoot
                if (hit.collider.transform == player)
                {
                    //Debug.Log("hit");
                    canShoot = true;
                }
            }
        }
        // this method "CheckVisionAngle()" returns a boolean with the value of our "canShoot" value
        // informing our Update() directly, if the enemy can fire or not
        return canShoot;
    }
}
