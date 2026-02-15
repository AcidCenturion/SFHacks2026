using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject[] TrashPrefabs;
    public GameObject trashManager;
    //public GameObject player;
    
    // Object Creation Variables
    public float ySpawnPosition = 0.5f;
    public float xSpawnRange = 2f;
    private bool isCreating = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
   

    public void CreateTrash()
    {
        if (isCreating) return; // Prevent multiple spawns at the same time

        int randomIndex = Random.Range(0, TrashPrefabs.Length);
        bool spawnOnLeft = this.GetComponent<HumanMovement>().facing == HumanMovement.Direction.Left;

        Vector3 spawnPosition;
        if (spawnOnLeft)
        {
            spawnPosition = new Vector3(this.transform.position.x - xSpawnRange, ySpawnPosition, 0);
        }
        else
        {
            spawnPosition = new Vector3(this.transform.position.x + xSpawnRange, ySpawnPosition, 0);
        } 

        GameObject newTrash = Instantiate(TrashPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        trashManager.GetComponent<TrashManager>().AddTrash(newTrash);

        isCreating = false;
    }

   
}
