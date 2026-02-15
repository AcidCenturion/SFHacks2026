using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    // FIELDS

    public GameObject checkpoint;
    public GameObject switchTarget; //should always be the fish
    public int maxHP;
    public GameObject oldCamera;
    public GameObject newCamera;
    public GameObject Kraken;
    public GameObject trashManager;

    private int hp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = maxHP;
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
        if (this.CompareTag("Human") && (other.CompareTag("Water") || other.CompareTag("Piranha")))
        {
            this.transform.position = checkpoint.transform.position;
        }

        if (this.CompareTag("Fish") && other.CompareTag("Enemy"))
        {
            if(hp <= 1) //hit on last life
            {
                this.transform.position = checkpoint.transform.position;
                hp = maxHP;
            }
            else //hit but not on last life
            {
                hp--;
            }
        }

        //Switch to fish controls when reaching finish line
        if (this.CompareTag("Human") && other.CompareTag("Home"))
        {
            //disable the human movement and enable the fish movement
            switchTarget.GetComponent<FishMovement>().enabled = true;
            GetComponent<HumanMovement>().enabled = false;
            GetComponent<Rigidbody2D>().linearVelocityX = 0;
            GetComponent<Rigidbody2D>().linearVelocityY = 0;

            //change cameras
            oldCamera.SetActive(false);
            newCamera.SetActive(true);

            // Disable kraken
            if (Kraken != null) Kraken.SetActive(false);

            if (trashManager != null)
            {
                trashManager.GetComponent<TrashManager>().UpdateLevelByTrashAmount();
            }
        }
    }

    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Trigger");
        if(hp <= 1) //hit on last life
        {
            this.transform.position = checkpoint.transform.position;
            hp = maxHP;
        }
        else //hit but not on last life
        {
            hp--;
        }
    }
}
