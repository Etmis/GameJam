using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 cameraRotation;
    Vector3 rotation;

    private Rigidbody rb;
    private bool isGrounded = false;
    public static float sensitivity;
    [SerializeField] float baseSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform groundChecker;

    // Start is called before the first frame update
    void Start()
    {
        sensitivity = 5;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();
        DoRotation();
        CheckGrounded();
    }

    private void DoMovement()
    {
        float side = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");
        float yMovement = rb.velocity.y;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            yMovement = jumpForce;
        }

        var dir = new Vector3(side, 0, forward).normalized;
        var transformedDir = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * dir;

        var runMult = Input.GetButton("Sprint") ? 1.5f : 1;

        var speed = baseSpeed * runMult;

        rb.velocity = new Vector3(transformedDir.x * speed, yMovement, transformedDir.z * speed);

    }

    private void DoRotation()
    {
        float xRot = Input.GetAxisRaw("Mouse X");
        float yRot = Input.GetAxisRaw("Mouse Y");

        rotation.y += xRot * sensitivity;
        transform.rotation = Quaternion.Euler(rotation);

        cameraRotation.x -= yRot * sensitivity;
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -50, 80);

        playerCamera.localRotation = Quaternion.Euler(cameraRotation);
    }

    void CheckGrounded()
    {
        if (Physics.Raycast(groundChecker.position, Vector3.down, 0.06f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
