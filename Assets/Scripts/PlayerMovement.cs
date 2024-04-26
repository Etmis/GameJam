using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 cameraRotation;
    Vector3 rotation;

    private Rigidbody rb;
    private static Transform player;
    private bool isGrounded = false;
    [SerializeField] float sensitivity;
    [SerializeField] float baseSpeed;
    [SerializeField] float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        player = transform;
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();
    }

    private void DoMovement()
    {
        float side = Input.GetAxisRaw("Horizontal"); // od -1 do 1
        float forward = Input.GetAxisRaw("Vertical");
        float yMovement = rb.velocity.y;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            yMovement = jumpForce;
        }

        // (0,0,1), 0,0,0.2 
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

        cameraRotation.x -= yRot * sensitivity;
        rotation.y += xRot * sensitivity;

        transform.rotation = Quaternion.Euler(rotation);

        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -50, 80);
    }
}
