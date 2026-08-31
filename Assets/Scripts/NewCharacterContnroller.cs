using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerControllerWithVariableJump : MonoBehaviour
{
    private CharacterController controller;

    [Header("Movement Settings")]
    public float moveSpeed = 6.0f;
    public float gravity = -20.0f;

    [Header("Variable Jump Settings")]
    public float jumpHeight = 2.0f;
    [Tooltip("Multiplier applied to gravity when releasing the jump button early for a short hop.")]
    public float jumpCancelMultiplier = 2.5f; 
    
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check using CharacterController's built-in flag
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to keep grounded state sticky
        }

        // Horizontal Movement (WASD / Left Stick)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Variable Jump Logic
        // 1. Press jump button to start the jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Physics formula to calculate initial velocity based on target jump height
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        // 2. Release jump button early to cut the jump short (variable height)
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
    }
}