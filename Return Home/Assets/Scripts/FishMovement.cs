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
    private SpriteRenderer sr;
    private Vector2 moveInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //change direction of the player
        //+ if right
        if(moveInput.x > 0)
        {
            sr.flipX = false; //sprite facing right, default is flipped already
            facing = Direction.Right;
        }
        else if(moveInput.x < 0)
        {
            sr.flipX = true;
            facing = Direction.Left;
        }
        //else, which is no move input, do nothing to save last direction

        //apply movement
        rb.linearVelocity = moveInput * moveSpd;
    }


    // ACTION INPUT SYSTEM FUNCTIONS

    private void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
}
