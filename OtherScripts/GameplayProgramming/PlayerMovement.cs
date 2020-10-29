using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody rb;
    private Animator anim;

    private Vector3 moveInput;
    private Vector3 moveVelocity; // helpful for pushing the character object forward

    private Camera mainCamera;

    void Start()
    {
        // initialize the rb
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        anim = GetComponent<Animator>();
    }

    void Update()
    { 
        float lh = Input.GetAxis("Horizontal"); // left stick horizontal
        float lv = Input.GetAxis("Vertical"); // left stick vertical

        // get the vector3 position of joystick input
        moveInput = new Vector3(lh, 0f, lv);

        // make the player rotate based on the camera
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0; // prevent the player from going up/down

        // quaternion hold rotational value that helps remove gimbal lock
        // gimbal lock is the loss of one degree of freedom in a three-dimensional

        // rotate the transform that makes one of its axes follow a target direction in world space
        Quaternion cameraRelativeRotation = Quaternion.FromToRotation(Vector3.forward, cameraForward);
        Vector3 lookToward = cameraRelativeRotation * moveInput;

        if (moveInput.sqrMagnitude > 0)
        {
            Ray lookRay = new Ray(transform.position, lookToward);
            transform.LookAt(lookRay.GetPoint(1));
        }

        moveVelocity = transform.forward * moveSpeed * moveInput.sqrMagnitude;

        // call animating method
        Animating();
    }

    // get called every 20m seconds, necessary for physics update, more consistent
    void FixedUpdate()
    {
        // pushing the object forward
        rb.velocity = moveVelocity;
    }

    void Animating()
    {
        anim.SetFloat("blendSpeed", rb.velocity.magnitude); // magnitude always returns positive value
    }
}
