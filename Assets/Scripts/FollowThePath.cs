using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;

    private int waypointIndex = 0;
    private Vector2 lastPosition;

    private void Start()
    {
        transform.position = waypoints[waypointIndex].position;
        lastPosition = transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 targetPos = waypoints[waypointIndex].position;
        Vector2 newPosition = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // Direction the enemy is moving
        Vector2 direction = (newPosition - (Vector2)transform.position).normalized;

        // Face the direction
        FaceDirection(direction);

        // Move the enemy
        transform.position = newPosition;

        // Check if reached waypoint
        if ((Vector2)transform.position == targetPos)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }

    private void FaceDirection(Vector2 direction)
    {
        if (direction == Vector2.zero) return;

        // Example logic for rotating sprite or changing animation depending on direction
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Moving horizontally
            if (direction.x > 0)
            {
                // Right
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                // Left
                transform.rotation = Quaternion.Euler(0, 180, 0); // Flip sprite horizontally
            }
        }
        else
        {
            // Moving vertically
            if (direction.y > 0)
            {
                // Up
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                // Down
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        }
    }
}

