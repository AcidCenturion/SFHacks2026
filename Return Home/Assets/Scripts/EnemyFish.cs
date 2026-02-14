using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemyFish : MonoBehaviour
{
    public enum PollutionLevel
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
    private PollutionLevel pollutionLevel = PollutionLevel.Medium;

    // Chase Variables
    private float chaseSpeed;
    public float defaultChaseSpeed = 2f;
    public float pollutedChaseSpeed = 3f;
    public float chaseDistance = 5f;
    public float returnSpeed = 1f;
    private bool isFacingLeft = true;
    private Vector3 initialPosition;

    public GameObject player;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
        chaseSpeed = defaultChaseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Only chase if pollution level is medium or high and the player is within a certain distance
        if (pollutionLevel == PollutionLevel.Low) return;
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(initialPosition, player.transform.position);
        Debug.Log($"Distance to player: {distanceToPlayer}");

        if (player.transform.position.x > transform.position.x && isFacingLeft)
        {
            Flip();
        }
        else if (player.transform.position.x < transform.position.x && !isFacingLeft)
        {
            Flip();
        }

        if (distanceToPlayer <= chaseDistance)
        {
            ChasePlayer();
        }
        else
        {
            if (transform.position != initialPosition)
            {
                ReturnToInitialPosition();
            }
        }

    }

    public bool setPollutionLevel(PollutionLevel newLevel)
    {
        if (newLevel == pollutionLevel) return true;
        pollutionLevel = newLevel;

        switch (newLevel)
        {
            case PollutionLevel.Low:
                chaseSpeed = 0f;
                break;
            case PollutionLevel.Medium:
                chaseSpeed = defaultChaseSpeed;
                break;
            case PollutionLevel.High:
                chaseSpeed = pollutedChaseSpeed;
                break;
        }

        return true;
    }

    void ReturnToInitialPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, returnSpeed * Time.deltaTime);
    }

    void ChasePlayer()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
        }
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


}
