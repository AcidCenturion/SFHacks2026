using UnityEngine;

public class WaterDebris : MonoBehaviour
{
    // FIELDS

    public GameObject debrisParticles;
    public float debrisSpawnHeight;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 spawnLoc = new Vector2(this.transform.position.x, debrisSpawnHeight);
        Quaternion rotation = Quaternion.Euler(new Vector2(-270, 0));
        Instantiate(debrisParticles, spawnLoc, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
