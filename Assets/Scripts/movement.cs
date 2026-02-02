using UnityEngine;
using UnityEngine.InputSystem;

public class Example : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float playerSpeed = 5.0f;    // Horizontal movement speed
    [SerializeField] private float jumpHeight = 1.5f;     // Jump height
    [SerializeField] private float gravityValue = -9.81f; // Gravity force

    private CharacterController controller;   // Unity CharacterController component
    private Vector3 playerVelocity;           // Vertical velocity (Y axis)
    private bool groundedPlayer;               // Is the player grounded?

    [Header("Input Actions")]
    public InputActionReference moveAction; // Movement input (Vector2)
    public InputActionReference jumpAction; // Jump input (Button)

    private Transform cam; // Camera transform (controlled by Cinemachine)

    private void Awake()
    {
        controller = gameObject.AddComponent<CharacterController>(); // Add CharacterController
        cam = Camera.main.transform; // Get main camera transform
    }

    private void OnEnable()
    {
        moveAction.action.Enable(); // Enable movement input
        jumpAction.action.Enable(); // Enable jump input
    }

    private void OnDisable()
    {
        moveAction.action.Disable(); // Disable movement input
        jumpAction.action.Disable(); // Disable jump input
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded; // Check if player is on the ground

        // Keep the controller grounded when walking on slopes
        if (groundedPlayer && playerVelocity.y < 0f)
        {
            playerVelocity.y = -2f;
        }

        // Read movement input
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        // Calculate camera-relative movement direction
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0f; // Remove vertical influence
        camRight.y = 0f;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 move = camForward * input.y + camRight * input.x;
        move = Vector3.ClampMagnitude(move, 1f); // Prevent faster diagonal movement

        // Rotate player toward movement direction
        if (move.sqrMagnitude > 0.001f)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(move),
                10f * Time.deltaTime
            );
        }

        // Jump (only when grounded)
        if (jumpAction.action.triggered && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Combine horizontal movement and vertical velocity
        Vector3 finalMove =
            move * playerSpeed +
            Vector3.up * playerVelocity.y;

        controller.Move(finalMove * Time.deltaTime); // Move the player
    }
}
