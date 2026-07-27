using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public float speed = 10f;
    public float hAxis = 0f;
    private Rigidbody RB;

    public bool playerDirect = true;
    public float movespeed = 2f;
    public float direct = 1f;
    public FollowLightDir FLD;
    public float jumpVelo = 0f;
    public float jumpForce = 0.5f;
    public float jumpFall = -0.5f;

    public float peake = 0f;
    public GrabElig OrbLight;

    public TouchGrass grassTouch;
    public GlobalLightActivation Sunlight;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        FLD = GetComponent<FollowLightDir>();
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))
        {
            playerDirect = false;
            direct = -1.2f;
            OrbLight.flipOrbDirection();
     
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            playerDirect = true;
            direct = 1.2f;
            OrbLight.flipOrbDirection();

        }
    
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && !grassTouch.hasJumped)
        {
            grassTouch.hasJumped = true;
            peake = transform.position.y + 1f;
            jumpVelo = jumpForce;
        }
        
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Sunlight.ActivateSun();
        }

        // Stop rising once the peak is reached
        if (grassTouch.hasJumped && transform.position.y >= peake)
        {
            jumpVelo = jumpFall;
        }

        // Short hop when the jump key is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpVelo = jumpFall;
        }
    }

    void FixedUpdate()
    {
        Vector3 move = transform.right * hAxis;
        move *= movespeed;

        RB.linearVelocity = new Vector3(
            move.x,
            RB.linearVelocity.y + jumpVelo,
            0
        );
    }
}