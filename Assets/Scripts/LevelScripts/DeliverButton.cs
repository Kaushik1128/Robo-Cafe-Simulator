using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class DeliverButton : MonoBehaviour
{
    public RobotExit robotExit;
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => OrderStart());
    }

    public void OrderStart()
    {
        //bool isWalking = animator.GetBool(boolName);

        //animator.SetBool(boolName, !isWalking);

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
