using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance;
    public GameObject deliveryArea;

    void Awake()
    {
        Instance = this;
    }

    public bool CheckOrder(GameObject robot, string deliveredItem)
    {
        RobotOrderAI robotAI = robot.GetComponent<RobotOrderAI>();
        if (robotAI != null && deliveredItem == robotAI.possibleTags[0]) // Example match
        {
            robotAI.FulfillOrder();
            return true;
        }
        return false;
    }
}
