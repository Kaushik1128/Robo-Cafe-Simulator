using UnityEngine;

public class FoodDelivery : MonoBehaviour
{
    public RobotManager robotManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject); // Food delivered
            robotManager.MoveNextRobot();
        }
    }
}
