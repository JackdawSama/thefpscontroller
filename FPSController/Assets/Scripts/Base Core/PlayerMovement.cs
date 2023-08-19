using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;

    [Header("Movement Settings")]
    public float speed = 12f;

    [Header("Gravity Variables")]
    public float gravity = -9.81f;

    //PLAYER MOVEMENT
    private float forwardAxis;
    private float sideAxis;
    Vector3 move;

    void Start()
    {
        
    }

    void Update()
    {
        HandleMoveInput();
    }

    void HandleMoveInput()
    {
        forwardAxis = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        sideAxis = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

        JumpInput();
    }

    void JumpInput()
    {

    }

    public void MovePlayer()
    {
        move = transform.forward * forwardAxis + transform.right * sideAxis;

        transform.position += move;
    }
}
