using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    // FIELDS
    public GameObject Checkpoint;
    public float iFrameLeniency;

    private float iFrames;


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
        if (other.CompareTag("Water"))
        {
            Debug.Log("trigger");
        }
    }

}
