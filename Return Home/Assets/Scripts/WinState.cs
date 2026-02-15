using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    public GameObject trashManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fish"))
        {
            int finalTrashCount = trashManager.GetComponent<TrashManager>().totalTrashCreated;
            Debug.Log("Final Trash Count: " + finalTrashCount);

            if (finalTrashCount < 9)
            {
                SceneManager.LoadScene("GoodEnding");
            }
            else
            {
                SceneManager.LoadScene("BadEnding");
            }
        }
    }
}
