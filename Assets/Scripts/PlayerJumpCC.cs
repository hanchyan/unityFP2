using UnityEngine;

public class PlayerJumpCC : MonoBehaviour
{
    public float jumpHeight = 1.8f;
    public float gravity = -20f;

    CharacterController controller;
    float yVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool grounded = controller.isGrounded;

        if (grounded && yVelocity < 0)
        {
            yVelocity = -2f; // stick to ground
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("JUMP!");
            yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        yVelocity += gravity * Time.deltaTime;

        controller.Move(Vector3.up * yVelocity * Time.deltaTime);
    }
}
