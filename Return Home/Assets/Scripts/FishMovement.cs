using UnityEngine;
using UnityEngine.InputSystem;

public class FishMovement : MonoBehaviour
{
    // FIELDS
    public float moveSpd;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpd;
    }

    // Called by the Player Input component
    /*
    Gets the direction of the input 
    based on bindings connected to the Move action in the Input System asset
    */
    private void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
}
