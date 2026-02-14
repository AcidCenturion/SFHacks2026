using UnityEngine;

public class Piranha : MonoBehaviour
{
    public int damageAmt = 1;
    [SerializeField] private float jumpForce = 0.5f;

    private Rigidbody2D rb;
    private Vector3 initPosition;
    public float jumpHeight = 2f;
    private bool reachedTop = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject piranha = GameObject.FindGameObjectWithTag("Piranha");
        initPosition = transform.position;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!reachedTop)
        {
            Jump();
        }
        else
        {
            if (transform.position.y <= initPosition.y)
            {
                reachedTop = false;
            }
        }


    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        if (transform.position.y > initPosition.y + jumpHeight)
        {
            reachedTop = true;
            rb.linearVelocity = Vector2.zero;
        }

    }


    
}
