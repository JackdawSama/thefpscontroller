using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRig : MonoBehaviour
{
    [Header("Camera Rig References")]
    [SerializeField] private PlayerController playerController = null;
    
    void LateUpdate()
    {
        if(playerController)
        {
            transform.position = playerController.transform.position;
        }
    }
}
