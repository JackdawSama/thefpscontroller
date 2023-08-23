using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsChecks : MonoBehaviour
{
    //Write Box Cast for Ground Check
    //Write Raycast for Step and Slope Check
    //Write Sphere Cast for Wall Check

    [Header("Ground Check Variables")]
    [SerializeField] float GroundCheckDistance = 1f;
    [SerializeField] private LayerMask groundMask = 0;
    [SerializeField] private Vector3 boxSize = Vector3.zero;

    [Header("Step/Slope Check Variables")]
    [SerializeField] float StepCheckDistance = 1f;

    [Header("Wall Check Variables")]
    [SerializeField] float WallCheckDistance = 1f;

    void Update()
    {
        GroundCheck();
    }

    public bool GroundCheck()
    {
        if(Physics.BoxCast(transform.position, boxSize, - Vector3.up, transform.rotation, GroundCheckDistance, groundMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
