using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Game Manager instance
    GameManager instance = GameManager.instance;

    // Movement variables
    public float force;
    private bool isMoving = false;
    public float jumpForce;
    public ParticleSystem Splash;
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
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource.loop = true;
        audioSource.clip = clip;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // MOVEMENT
        MovePlayer();
        // JUMP
        Jump();

        SetParticle();

    }

    // Move Function
    private void MovePlayer()
    {

        // Get the Axis value of input buttons
        float hor = Input.GetAxis("Horizontal");
        // Setup a translation for the movement
        translation = new Vector3(0, 0, hor);

        // Applies a continous force on Player Movement
        rb.AddForce(translation * force, ForceMode.Force);

        // Check if Moving
        if (rb.velocity.magnitude >= 0.2f)
        {

            isMoving = true;
          
            // Set sound Movement by the movement magnitude
            audioSource.volume = instance.Remap(rb.velocity.magnitude, 0.2f, 3.5f, 0, 1);
            // Check if audio is playing
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (isMoving && rb.velocity.magnitude <= 0.2f)
        {
            isMoving = false;
            
            if (co != null)
                StopCoroutine(co);

            co = StartCoroutine(WaitForAudioToEnd());
        }


    }

    // Jump Function
    private void Jump()
    {

        // Check if can Jump
        if (instance.canJump)
        {
            // Jump
            if (Input.GetButtonDown("Jump"))
            {
                // once we jump, we add a force vertically
                rb.velocity = Vector3.up * jumpForce;

            }
        }
    }


    private void SetParticle()
    {
        if (isMoving)
        {
            if (!Splash.isPlaying)
            {
                // Ative Particle
                Splash.Play();
            }
        }
        else
        {
            // Stop Particle
            Splash.Stop();
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

}
