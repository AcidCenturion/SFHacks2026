using UnityEngine;
using System.Collections;

public class Kraken : MonoBehaviour
{
    // Trash Variables
    public GameObject trashManager;
    private TrashManager tm;
    public int minimumTrashToDestroy = 5;
    public int attackCooldown = 10;

    // Warning Variables
    public GameObject warningSign;
    public float warningTime = 2f;      // how long warning sign is present
    public float warningDistanceY = 1f; // offset of where sign is from trash


    // Speed
    public float riseSpeed = 6f;        // how fast the tentacle rises up
    public float fallSpeed = 5f;        // how fast the tentacle goes back down
    public float stationaryTime = 2f;   // how long it idles when it goes up
    public float launchMaxHeight = 1f; // height it will stop at
    public float launchMinHeight = -9f; // height it will start at

    IEnumerator Start()
    {
        tm = trashManager.GetComponent<TrashManager>();

        while (true)
        {
            
            int trashCount = tm.TrashListSize();
            while (trashCount < minimumTrashToDestroy)
            {
                yield return null; // Wait until the next frame before checking again
                trashCount = tm.TrashListSize();
            }

            int randomIndex = Random.Range(0, trashCount);
            GameObject trashToDestroy = tm.GetTrash(randomIndex);
            Vector2 trashLocation = trashToDestroy.transform.position;

            yield return StartCoroutine(WarningAndDestroy(trashToDestroy));
            yield return StartCoroutine(Launch(trashLocation));

            yield return new WaitForSeconds(attackCooldown);
        }
    }

    IEnumerator IndicateDanger(GameObject trash)
    {
        // position to place warning sign
        Vector2 warningPosition = (Vector2)trash.transform.position;
        warningPosition.y += warningDistanceY;
        warningSign.transform.position = warningPosition;

        // enable warning sign
        warningSign.SetActive(true);

        yield return new WaitForSeconds(warningTime);

        warningSign.SetActive(false);
    }

    IEnumerator WarningAndDestroy(GameObject trash)
    {
        Debug.Log("WarnignAndDestroyed Function hit");
        yield return StartCoroutine(IndicateDanger(trash));
        tm.DestroyTrash(trash);
    }

    IEnumerator Launch(Vector2 trashPosition)
    {
        // set tentacle position
        Vector2 newPosition = new Vector2(trashPosition.x, launchMinHeight);
        this.transform.position = newPosition;

        // launch up
        Vector2 RiseTargetPosition = trashPosition;
        RiseTargetPosition.y = launchMaxHeight;
        while (this.transform.position.y < RiseTargetPosition.y) {
            LaunchUp(RiseTargetPosition);
            yield return null;
        }

        // be stationary
        yield return new WaitForSeconds(stationaryTime);

        // launch down
        while (this.transform.position.y > newPosition.y)
        {
            ReturnDownwards(newPosition);
            yield return null;
        }

    }

    void LaunchUp(Vector2 location)
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, location, riseSpeed * Time.deltaTime);        
    }

    void ReturnDownwards(Vector2 location)
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, location, fallSpeed * Time.deltaTime);        
    }


}
