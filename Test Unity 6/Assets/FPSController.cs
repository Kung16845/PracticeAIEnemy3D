using UnityEngine;

public class FPSController : MonoBehaviour
{
    // Movement settings
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float gravity = -9.8f;

    // Mouse look settings
    public float mouseSensitivity = 100f;
    public float lookXLimit = 45f;

    // Components
    private CharacterController characterController;
    public Transform cameraTransform;

    // Movement variables
    private float rotationX = 0f;
    private Vector3 velocity;

    void Start()
    {
        // Initialize components
        characterController = GetComponent<CharacterController>();

        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMouseLook();
        HandleMovement();
    }

    void HandleMouseLook()
    {
        // Horizontal rotation (Y-axis)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        // Vertical rotation (X-axis)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    void HandleMovement()
    {
        // Get input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Determine movement direction
        Vector3 moveDirection = transform.TransformDirection(new Vector3(horizontal, 0, vertical)).normalized;

        // Check for running
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float speed = isRunning ? runSpeed : walkSpeed;

        // Apply movement
        characterController.Move(moveDirection * speed * Time.deltaTime);

        // Apply gravity
        if (characterController.isGrounded)
        {
            velocity.y = 0; // Reset vertical velocity when grounded
        }
        else
        {
            velocity.y += gravity * Time.deltaTime; // Apply gravity
        }
        characterController.Move(velocity * Time.deltaTime);
    }
}