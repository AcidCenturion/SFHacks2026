using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    // FIELDS

    public GameObject checkpoint;
    public GameObject switchTarget; //should always be the fish


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // FUNCTIONS

    void OnTriggerEnter2D(Collider2D other)
    {
        //Respawn function for the Human
        //select an object in inspector as respawn location
        if (this.CompareTag("Human") && other.CompareTag("Water"))
        {
            this.transform.position = checkpoint.transform.position;
        }

        //Switch to fish controls when reaching finish line
        if (this.CompareTag("Human") && other.CompareTag("Home"))
        {
            switchTarget.GetComponent<FishMovement>().enabled = true;
            GetComponent<HumanMovement>().enabled = false;
            GetComponent<Rigidbody2D>().linearVelocityX = 0;
            GetComponent<Rigidbody2D>().linearVelocityY = 0;
        }
    }
}
