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
    public float jumpHeight = 10f;

    [Header("Gravity Variables")]
    public float gravity = -9.81f;

    [Header("Key Binds")]
    public KeyCode Jump = KeyCode.Space;

    //PLAYER MOVEMENT
    private float forwardAxis;
    private float sideAxis;
    Vector3 move;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleMoveInput();
    }

    void HandleMoveInput()
    {
        forwardAxis = Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime;
        sideAxis = Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime;

    }

    public void MovePlayer()
    {
        move = transform.forward * forwardAxis + transform.right * sideAxis;

        controller.Move(move);
    }
}
