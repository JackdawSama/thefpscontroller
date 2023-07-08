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
    private float forwardAxis;
    private float sideAxis;
    Vector3 move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }
}
