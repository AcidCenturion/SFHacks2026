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
        Instantiate(debrisParticles, spawnLoc, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
