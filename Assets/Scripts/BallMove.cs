using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour {

    private bool canJump = false;

    // movement variables
    public float force;
    private bool isMoving = false;
    public float jumpForce;
    private Vector3 translation;

    private Rigidbody rb;

    private AudioSource audioSource;

    public AudioClip clip;

	private Coroutine co;


    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();
        audioSource.loop = true;
        audioSource.clip = clip;

        //audioSource.PlayOneShot

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // MOVEMENT
        MoveSphere();

        // JUMP
        Jump();

    }

    private void MoveSphere() {

        // get the Axis value of the virtual buttons
        float hor = Input.GetAxis("Horizontal");

        // setup a translation (direction) for the movement
        translation = new Vector3(0, 0, hor);

        // In this case, since we're constantly updating the force of the object its best to use "ForceMode.Force", which applies a continous force on our object
        rb.AddForce(translation * force, ForceMode.Force);

		//Debug.Log(rb.velocity.magnitude);


        //audioSource.volume = rb.velocity.normalized.magnitude;

        if (rb.velocity.magnitude != 0)
        {
            isMoving = true;

            audioSource.volume = Remap(rb.velocity.magnitude, 0.2f, 3.5f, 0, 1);
            //Debug.Log(audioSource.volume);

            if (!audioSource.isPlaying)
			{
				audioSource.Play();
			}
		}
		else if(isMoving && rb.velocity.magnitude < 0.2f)
        {
			isMoving = false;

			if (co != null)
				StopCoroutine(co);

			co = StartCoroutine(WaitForAudioToEnd());
        }
       

    }

    private void Jump() {

        // first, we check if our object is touching the ground.

        if (canJump)
        {
            //if (transform.position.y <= 1.2f) {

            // if it is, then we can jump (we're using the virtual button "Shoot" still, because its key is the spacebar)
            if (Input.GetButtonDown("Jump")) {
                // once we jump, we add a force vertically
                rb.velocity = Vector3.up * jumpForce;

                //audioSource.Stop();
            }
        }
    }

    private IEnumerator WaitForAudioToEnd()
    {
        // since our footsteps sound is on loop, we get the time where the footsteps sound is at:
        // - so we can wait until it finishes to stop the sound from playing again
        float time = audioSource.time;

        // so we wait until the time is equal to the footsteps clip length (then we know it finished playing)
        while (time < clip.length)
        {
            // but while the time is still smaller than the clip lentgh, we keep waiting
            time += Time.deltaTime;

            yield return null;
        }

        // once the time reaches the clip length (meaning this loop ended)
        // we can stop the sound
        audioSource.Stop();

		co = null;
	}

    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }


    // Check collision Enter
    void OnCollisionEnter(Collision colEnter)
    {

        //health = health - rb.velocity.magnitude * 0.8f;

        if (colEnter.collider.CompareTag("Ground") || colEnter.collider.CompareTag("Platform"))
        {
            
            canJump = true;
        }

        
    }

    void OnCollisionExit (Collision colExit)
    {
        if (colExit.collider.CompareTag("Ground") || colExit.collider.CompareTag("Platform"))
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider colTriger)
    {
        if (colTriger.CompareTag("Bucket"))
        {
            Destroy(colTriger.gameObject);
            //health = health + 20;
        }
    }

}
