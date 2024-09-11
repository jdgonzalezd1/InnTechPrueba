using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private InputManager inputManager;

    private Vector3 movement;

    private Rigidbody rb;

    private void Awake()
    {
        inputManager = InputManager.Instance;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 move = inputManager.GetPlayerMovement();
        movement = new Vector3(move.x, 0, move.y);
        rb.velocity = movement * moveSpeed;
    }


}
