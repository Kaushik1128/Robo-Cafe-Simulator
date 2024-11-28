using UnityEngine;

public class RobotPathing : MonoBehaviour
{
    public Transform middlePoint; // Middle waypoint
    public Transform finalDestination; // Final target
    public float moveSpeed = 2f; // Movement speed

    private int movementStage = 0; // 0 = to middle point, 1 = rotate, 2 = to final destination
    private bool isMoving = false; // Movement flag

    



    void Update()
    {
        if (isMoving)
        {
            switch (movementStage)
            {
                case 0: // Move to the middle point
                    MoveToTarget(middlePoint);
                    break;
                case 1: // Move to the final destination
                    MoveToTarget(finalDestination);
                    break;
            }
        }
    }

    public void StartMoving()
    {
        if (middlePoint != null && finalDestination != null)
        {
            isMoving = true; // Start movement
            Debug.Log("Robot started moving!");
        }
        else
        {
            Debug.LogError("Middle point or final destination not assigned!");
        }
    }

    private void MoveToTarget(Transform target)
    {
        // Move the robot towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        // Check if the robot has reached the target
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            Debug.Log($"Reached: {target.name}");
            movementStage++; // Move to the next stage
        }
    }

    // private void RotateTowards(Vector3 direction)
    // {
    //     Quaternion targetRotation = Quaternion.Euler(0, transform.eulerAngles.y - 90f, 0);

    //     // Smoothly rotate towards the target rotation
    //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    //     // Check if rotation is complete
    //     if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
    //     {
    //         Debug.Log("Rotation complete.");
    //         movementStage++; // Move to the next stage (final destination)
    //     }
    // }
}
