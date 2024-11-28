using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float speed = 3.0f; // Speed of the robot
    private Vector3 targetPosition; // The target position to move toward
    private bool isMoving = false;

    private void Update()
    {
        if (isMoving)
        {
            MoveRobot();
        }
    }

    public void MoveTo(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
        isMoving = true; // Start moving
    }

    private void MoveRobot()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Stop moving when close enough
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
    }
}
