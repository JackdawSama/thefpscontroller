using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Mouse Look References")]
    [SerializeField] private Transform playerBody = null;

    [Header("Mouse Look Settings")]
    [SerializeField] private float mouseSensitivity = 3.5f;
    [SerializeField] [Range(0.0f, 90.0f)] private float verticalLookLimits = 90.0f;

    [Header("Mouse Cursor Settings")]
    [SerializeField] private bool lockCursor = true;

    //MouseLook Input Variables
    Vector2 sens;
    float xRot = 0f;


    void Start()
    {
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        HandleMouseInput();
    }

    void LateUpdate()
    {
        HandleMouseLook();
    }

    /*
    Splitting Camera rotation and Player Rotation. Late Update on Camera
    ensures that there is no jitter on camera due to competing transform
    updates. Player Input being handled in Update ensures that input is
    registered every frame.
    */

    void HandleMouseInput()
    {
        //Raw Input from Mouse
        sens.x = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        sens.y = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //Clamp Vertical Rotation
        xRot -= sens.y;
        xRot = Mathf.Clamp(xRot, -verticalLookLimits, verticalLookLimits);

        //Player Body Rotation Horizontally
        playerBody.Rotate(Vector3.up * sens.x);
    }

    void HandleMouseLook()
    {
        //Function to update camera vertical look rotation
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}
