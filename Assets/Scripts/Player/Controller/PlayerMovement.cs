using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    
    private Vector3 movement;

    private Rigidbody rb;

    private Transform cameraOrientation;

    private void Awake()
    {        
        rb = GetComponent<Rigidbody>();
        cameraOrientation = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        Vector2 move = InputManager.Instance.GetPlayerMovement();        
        movement = new Vector3(move.x, 0, move.y);
        movement = cameraOrientation.forward * movement.z + cameraOrientation.right * movement.x;
        movement.y = 0f;
        rb.velocity = movement * moveSpeed;
        rb.MoveRotation(Quaternion.LookRotation(new Vector3(cameraOrientation.forward.x, 0 , cameraOrientation.forward.z)));
    }

    private void Movement()
    {

    }

    public void StopMovement()
    {
        moveSpeed = 0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }


}
