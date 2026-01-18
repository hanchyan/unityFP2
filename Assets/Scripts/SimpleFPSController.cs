// using UnityEngine;



// // public class SimpleFPSController : MonoBehaviour
// // {
// //     void Update()
// //     {
// //         Debug.Log("SCRIPT IS RUNNING");
// //     }
// // }


// public class SimpleFPSController : MonoBehaviour

// {
//     public float moveSpeed = 5f;
//     public float lookSpeed = 100f;
//     public Transform cameraTransform;

//     float xRotation = 0f;
//     CharacterController controller;

//     void Start()
//     {
//         controller = GetComponent<CharacterController>();
//     }

//     void Update()

    
//     {
//         Debug.Log("SCRIPT IS RUNNING");
//         HandleMovement();
//         HandleLook();
//     }

//     void HandleMovement()
//     {
//         // float moveX = Input.GetAxis("Horizontal"); // A / D
//         // float moveZ = Input.GetAxis("Vertical");   // W / S

//         // Vector3 move = transform.right * moveX + transform.forward * moveZ;
//         // controller.Move(move * moveSpeed * Time.deltaTime);

//             Vector3 move = Vector3.zero;

//     if (Input.GetKey(KeyCode.W)) move += transform.forward;
//     if (Input.GetKey(KeyCode.S)) move -= transform.forward;
//     if (Input.GetKey(KeyCode.D)) move += transform.right;
//     if (Input.GetKey(KeyCode.A)) move -= transform.right;

//     controller.Move(move.normalized * moveSpeed * Time.deltaTime);
//     }

// void HandleLook()
// {
//     float lookX = 0f;
//     float lookY = 0f;

//     if (Input.GetKey(KeyCode.LeftArrow))  lookX = -1f;
//     if (Input.GetKey(KeyCode.RightArrow)) lookX = 1f;
//     if (Input.GetKey(KeyCode.UpArrow))    lookY = 1f;
//     if (Input.GetKey(KeyCode.DownArrow))  lookY = -1f;

//     // Head pitch (up/down)
//     xRotation -= lookY * lookSpeed * Time.deltaTime;
//     xRotation = Mathf.Clamp(xRotation, -80f, 80f);
//     cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

//     // Body yaw (left/right)
//     transform.Rotate(Vector3.up * lookX * lookSpeed * Time.deltaTime);
// }

// }



using UnityEngine;

public class SimpleFPSController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeed = 100f;
    public float jumpHeight = 8.0f;
    public float gravity = -20f;
    public Transform cameraTransform;

    float xRotation = 0f;
    float verticalVelocity;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Debug.Log("SCRIPT IS RUNNING");

        HandleLook();
        HandleMovementAndJump();
    }

    void HandleMovementAndJump()
    {
        // --- Ground check ---
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; // stick to ground
        }

        // --- Jump ---
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            Debug.Log("JUMP");
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // --- Gravity ---
        verticalVelocity += gravity * Time.deltaTime;

        // --- Horizontal movement ---
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) move += transform.forward;
        if (Input.GetKey(KeyCode.S)) move -= transform.forward;
        if (Input.GetKey(KeyCode.D)) move += transform.right;
        if (Input.GetKey(KeyCode.A)) move -= transform.right;

        move = move.normalized * moveSpeed;

        // --- Final combined movement ---
        Vector3 velocity = move + Vector3.up * verticalVelocity;
        controller.Move(velocity * Time.deltaTime);
    }

    void HandleLook()
    {
        float lookX = 0f;
        float lookY = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))  lookX = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) lookX = 1f;
        if (Input.GetKey(KeyCode.UpArrow))    lookY = 1f;
        if (Input.GetKey(KeyCode.DownArrow))  lookY = -1f;

        // Head pitch (up/down)
        xRotation -= lookY * lookSpeed * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Body yaw (left/right)
        transform.Rotate(Vector3.up * lookX * lookSpeed * Time.deltaTime);
    }
}
