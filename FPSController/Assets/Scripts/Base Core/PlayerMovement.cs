using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public CharacterController controller;

    [Header("Movement Settings")]
    public float movementSpeed = 12f;
    public Vector3 playerVelocity;
    public float jumpHeight = 10f;

    [Header("Gravity Variables")]
    public float gravity = -9.81f;
    public float gravityScale = 1f;

    [Header("Key Binds")]
    public KeyCode Jump = KeyCode.Space;

    //PLAYER MOVEMENT
    private float forwardAxis;
    private float sideAxis;
    Vector3 move;

    private float jumpVelocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMoveInput();
    }
    
    //Functions accessible to other scripts outside of this script will be added below this comment
    public void MovePlayer()
    {
        move = transform.forward * forwardAxis + transform.right * sideAxis;

        HandleJump();

        controller.Move(move);
    }

    //Functions running in this script will be added below this comment
    void HandleMoveInput()
    {
        forwardAxis = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        sideAxis = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;

    }

    void HandleGravity()
    {
        jumpVelocity += gravity * gravityScale * Time.deltaTime;
    }

    void HandleJump()
    {
        if(Input.GetKeyDown(Jump) && controller.isGrounded)
        {
            Debug.Log("Jumping");
            jumpVelocity = Mathf.Sqrt(jumpHeight * -2f * (gravity * gravityScale));
        }

        HandleGravity();
        move.y += jumpVelocity * Time.deltaTime;

    }
}
