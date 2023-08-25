using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Think what the PlayerController does. This has to integrate with Player Look, Player Movement and Player Health.
[RequireComponent(typeof(PlayerLook))]
[RequireComponent(typeof(PhysicsChecks))]
[RequireComponent(typeof(PlayerBehaviours))]
[RequireComponent(typeof(PlayerMovement))]

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerLook playerLook = null;
    [SerializeField] private PlayerMovement playerMovement = null;

    private void Start() 
    {
        playerLook = GetComponent<PlayerLook>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update() 
    {
        playerMovement.MovePlayer();
    }

    private void LateUpdate() 
    {
        playerLook.HandleMouseLook();
    }

}
