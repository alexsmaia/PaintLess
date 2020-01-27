using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRigidbodies_Exercise_1 : MonoBehaviour
{
    // movement variables
    public float speed;
    private Vector3 translation;

    // prefab variables
    public GameObject shootPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // MOVEMENT
        //MoveCube();

        // ROTATION
        //RotateCube(translation);

        // SHOOT SPHERE
        ShootSphere();
    }

    /*private void MoveCube()
    {
        // get the Axis value of the virtual buttons
        // returns a range of values from [-1, 1], depending of the pressed key
        // EXAMPLE for the "Horizontal" virtual button:
        // - if "left arrow" (the negative button) is pressed, value will gradually move to -1
        // - if "right arrow" (the positive button) is pressed, value will gradually move to 1
        // - if no button is pressed, value will return to 0
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        // setup a translation (direction) for the movement
        // since the values range from [-1, 1] they are a good way of setting our direction
        translation = new Vector3(hor, 0, ver);

        // apply the movement to this cube's transform
        transform.position += translation * speed;
    }*/

   /* private void RotateCube(Vector3 _translation)
    {
        // only rotate the cube if we're using the keys (so the cube doesn't rotate back to 0)
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            Quaternion targetRotation = Quaternion.LookRotation(translation);

            // apply the rotation
            // Quaternion.Slerp interpolates the rotation to our target rotation (cube's movement direction) by 15% (0.15f) every frame, smoothly rotating our cube
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f);
        }
    }*/

    private void ShootSphere()
    {
        // every time we press the button "Shoot" we instantiate a new bullet
       /* if (Input.GetButtonDown("Shoot"))
        {*/
            Instantiate(shootPrefab, transform.position, transform.rotation);
        //}
    }
}
