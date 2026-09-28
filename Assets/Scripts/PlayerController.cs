using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;

    [Header("Movement Settings")]
    public float moveSpeed = 6.0f;
    public float gravity = -20.0f;
    
    [Header("Coyote Time Settings")]
    public float coyoteTime = 0.2f; 
    private float coyoteTimeCounter = 0f;
    public float direct = 1f;

    [Header("Variable Jump Settings")]
    public float jumpHeight = 2.0f;
    [Tooltip("Multiplier applied to gravity when releasing the jump button early for a short hop.")]
    public float jumpCancelMultiplier = 2.5f; 
    
    private Vector3 velocity;
    private bool isGrounded;
    public float pushpower = 10.0f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check using CharacterController's built-in flag
        isGrounded = controller.isGrounded;
        
        // --- 1. COYOTE TIME TIMER LOGIC ---
        if (isGrounded)
        {
            // Reset the timer when touching the ground
            coyoteTimeCounter = coyoteTime; 
            
            if (velocity.y < 0)
            {
                velocity.y = -2f; // Small downward force to keep grounded state sticky
            }
        }
        else
        {
            // Count down the timer when falling off a ledge
            coyoteTimeCounter -= Time.deltaTime; 
        }

        // Horizontal Movement (WASD / Left Stick)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = 0f;
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;
        
        controller.Move(move * moveSpeed * Time.deltaTime);
        
        if (moveX > 0)
        {
            direct = 1f;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        } 
        else if (moveX < 0)
        {
            direct = -1f;
            // --- 2. ROTATION FIX ---
            // Y-axis must be 180 to face left. Z-axis flips the character upside down.
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); 
        }
        
        // Variable Jump Logic
        // --- 3. COYOTE TIME JUMP CONDITION ---
        // Ask if the timer is greater than 0, NOT if we are grounded
        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
        {
            // Physics formula to calculate initial velocity based on target jump height
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
            
            // Instantly set timer to 0 so the player can't double-jump in the air
            coyoteTimeCounter = 0f; 
        }

        // Release jump button early to cut the jump short (variable height)
        if (Input.GetButtonUp("Jump") && velocity.y > 0)
        {
            velocity.y *= 0.5f; // Damp upward velocity immediately upon release
        }

        // Apply gravity with variable fall multiplier if the player is releasing early
        float currentGravity = gravity;
        if (!isGrounded && !Input.GetButton("Jump") && velocity.y > 0)
        {
            currentGravity *= jumpCancelMultiplier;
        }

        // Vertical Movement Application
        velocity.y += currentGravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        void OnControllerColliderHit(ControllerColliderHit hit)
        {
            Rigidbody hitRigidbody = hit.collider.attachedRigidbody;
            if (hitRigidbody == null || hitRigidbody.isKinematic)
            {
                return;
            }
            if (hit.moveDirection.y < -0.3f)
            {
                return;
            }
            Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, 0);
            hitRigidbody.AddForce(pushDirection * pushpower, ForceMode.Force);
            Debug.Log("Pushed object: " + hitRigidbody.name);
        }
    }
}