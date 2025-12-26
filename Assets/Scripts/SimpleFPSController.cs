using UnityEngine;



// public class SimpleFPSController : MonoBehaviour
// {
//     void Update()
//     {
//         Debug.Log("SCRIPT IS RUNNING");
//     }
// }


public class SimpleFPSController : MonoBehaviour

{
    public float moveSpeed = 5f;
    public float lookSpeed = 300f;
    public Transform cameraTransform;

    float xRotation = 0f;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()

    
    {
        Debug.Log("SCRIPT IS RUNNING");
        HandleMovement();
        HandleLook();
    }

    void HandleMovement()
    {
        // float moveX = Input.GetAxis("Horizontal"); // A / D
        // float moveZ = Input.GetAxis("Vertical");   // W / S

        // Vector3 move = transform.right * moveX + transform.forward * moveZ;
        // controller.Move(move * moveSpeed * Time.deltaTime);

            Vector3 move = Vector3.zero;

    if (Input.GetKey(KeyCode.W)) move += transform.forward;
    if (Input.GetKey(KeyCode.S)) move -= transform.forward;
    if (Input.GetKey(KeyCode.D)) move += transform.right;
    if (Input.GetKey(KeyCode.A)) move -= transform.right;

    controller.Move(move.normalized * moveSpeed * Time.deltaTime);
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
