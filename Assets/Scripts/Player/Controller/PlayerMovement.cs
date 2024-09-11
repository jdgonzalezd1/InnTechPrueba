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

    private void Awake()
    {        
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 move = InputManager.Instance.GetPlayerMovement();
        movement = new Vector3(move.x, 0, move.y);
        rb.velocity = movement * moveSpeed;
    }


}
