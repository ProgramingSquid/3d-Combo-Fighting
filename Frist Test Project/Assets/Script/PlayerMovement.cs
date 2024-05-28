using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerData data;
    public float speed = 7;
    public float sprintModifier = 2;
    public float crouchModifier = 0.5f;
    public float rotationSpeed = 5;
    public bool rotationLocked = false;
    public Transform groundChecker;
    public float groundCheckRadius = 0.5f;
    public LayerMask groundMask;

    public float jumpSpeed = 10;
    public Rigidbody rb;
    public Vector3 tempVelocity;
    public Camera cam;

    private Vector3 camRight;
    private Vector3 camForward;
    private Vector2 moveInput;
    private float currentSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rotationLocked = !rotationLocked;
        }

        GroundCheck();
        tempVelocity = Vector3.zero;
        currentSpeed = speed;
        GetInput();

        HandleCrouch();
        HandleSprint();

        GetCamDirections();

        tempVelocity += camForward * moveInput.y * currentSpeed;
        tempVelocity += camRight * moveInput.x * currentSpeed;
        tempVelocity.y = rb.velocity.y;
        HandleJump();
        Vector3 direction = tempVelocity;
        direction.y = 0;

        rb.velocity = tempVelocity;
        if (direction.magnitude > 0.1f && !rotationLocked)
        {
            SmoothLookAt(direction);
        }
    }

    private void SmoothLookAt(Vector3 direction)
    {
        Vector3 targetDirection = direction.normalized;
        targetDirection.z *= -1;
        float angle = Mathf.Atan2(targetDirection.z, targetDirection.x) * Mathf.Rad2Deg + 90;
        float yRotation = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.y, angle, rotationSpeed * Time.deltaTime);

        //transform.forward = Vector3.Lerp(transform.forward, targetDirection, Time.deltaTime * rotationSpeed);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z);
    }

    public void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && data.grounded)
        {
            tempVelocity.y = jumpSpeed;
        }
    }

    public void GroundCheck()
    {
        if (Physics.CheckSphere(groundChecker.position, groundCheckRadius, groundMask))
        {
            data.grounded = true;
            data.airborne = false;
        }
        else
        {
            data.grounded = false;
            data.airborne = true;
        }
    }

    private void GetCamDirections()
    {
        camForward = cam.transform.forward;
        camRight = cam.transform.right;
        camForward.y = 0;
        camForward.Normalize();

        camRight.y = 0;
        camRight.Normalize();
    }

    private void HandleSprint()
    {
        if (data.sprinting) currentSpeed *= sprintModifier;
        
    }

    private void HandleCrouch()
    {
        if (data.crouching) { 
            transform.localScale = new Vector3(1, 0.5f, 1);
            currentSpeed *= crouchModifier;
        }
        else transform.localScale = new Vector3(1, 1, 1);
    }

    private void GetInput()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        data.crouching = Input.GetKey(KeyCode.C);
        data.sprinting = Input.GetKey(KeyCode.LeftShift);
    }
}
