using UnityEngine;
using UnityEngine.InputSystem;

public class FishMovement : MonoBehaviour
{
    // FIELDS

    public float moveSpd;
    public enum Direction
    {
        Left,
        Right
    }
    public Direction facing;

    private Rigidbody2D rb;
    private Vector2 moveInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.enabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpd;
    }


    // ACTION INPUT SYSTEM FUNCTIONS

    private void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
}
