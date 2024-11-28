using UnityEngine;

public class RobotOrderAI : MonoBehaviour
{
    public GameObject Robot;
    public Transform orderPosition; // Where the robot will stand to place the order
    public string[] possibleTags;   // List of tags representing orders
    public float patience = 10.0f;  // Time robot will wait before leaving
    public string orderTag;
    public RobotExit robotExit;
    private bool orderFulfilled = false;

    void Update()
    {
        // if (!orderFulfilled)
        // {
        //     patience -= Time.deltaTime;
        //     if (patience <= 0)
        //     {
        //         LeaveCafe();
        //     }
        // }
        if (Vector3.Distance(Robot.transform.position, orderPosition.position) < 0.1f)
        {
            PlaceOrder();
            Debug.Log("Reached Position");
        }
        
    }

    void PlaceOrder()
    {
        // Randomly pick a tag from possibleTags
        orderTag = possibleTags[Random.Range(0, possibleTags.Length)];
        Debug.Log($"{gameObject.name} orders something tagged: {orderTag}");

        // Search for a GameObject with this tag (if needed)
        GameObject orderObject = GameObject.FindGameObjectWithTag(orderTag);
        if (orderObject != null)
        {
            Debug.Log($"Found an object with the tag: {orderTag}");
        }
        else
        {
            Debug.LogWarning($"No object found with the tag: {orderTag}");
        }
    }

    public void FulfillOrder()
    {
        orderFulfilled = true;
        Debug.Log($"{gameObject.name} is happy!");
        LeaveCafe();
    }

    void LeaveCafe()
    {
        // Debug.Log($"{gameObject.name} is leaving.");
        // Destroy(gameObject); // Or move the robot out of the café
        if (robotExit != null)
        {
            robotExit.StartMoving(); // Trigger the robot to start moving
        }
        else
        {
            Debug.LogError("RobotMovement script is not assigned!");
        }
    }
}
