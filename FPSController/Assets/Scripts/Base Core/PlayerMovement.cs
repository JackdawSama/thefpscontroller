using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;

    [Header("Movement Settings")]
    public float speed = 12f;

    [Header("Gravity Variables")]

    //PLAYER MOVEMENT
    [SerializeField] private float forwardAxis;
    [SerializeField] private float sideAxis;
    Vector3 move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleMoveInput();
        MovePlayer();
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

    void MovePlayer()
    {
        move = transform.forward * forwardAxis + transform.right * sideAxis;

        transform.position += move;
    }
}
