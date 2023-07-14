using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("Mouse Look References")]
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private Transform playerBody = null;

    [Header("Mouse Look Settings")]
    [SerializeField] private float mouseSensitivity = 3.5f;
    
    [SerializeField] [Range(0.0f, 90.0f)] private float verticalLookLimits = 90.0f;

    [Header("Mouse Cursor Settings")]
    [SerializeField] private bool lockCursor = true;

    //MouseLook Input Variables
    Vector2 sens;
    float xRot = 0f;
    float yRot = 0f;


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

    void HandleMouseInput()
    {
        //Raw Input from Mouse
        sens.x = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        sens.y = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yRot += sens.x;

        //Clamp Vertical Rotation
        xRot -= sens.y;
        xRot = Mathf.Clamp(xRot, -verticalLookLimits, verticalLookLimits);

        // //Player Body Rotation Horizontally
        // playerBody.Rotate(Vector3.up * sens.x);
    }

    public void HandleMouseLook()
    {
        //Player Body Rotation Horizontally
        //playerBody.Rotate(Vector3.up * sens.x);
        playerBody.transform.rotation = Quaternion.Euler(0f, yRot, 0f);
        
        //Function to update camera vertical look rotation
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}
