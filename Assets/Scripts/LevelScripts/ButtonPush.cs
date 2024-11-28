using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ButtonPush : MonoBehaviour
{
    public RobotPathing robotMovement; // Reference to Robot Kyle's movement script
    //public Animator animator;
    //public string boolName = "isWalking";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => OrderStart());
    }

    public void OrderStart()
    {
        //bool isWalking = animator.GetBool(boolName);

        //animator.SetBool(boolName, !isWalking);

        if (robotMovement != null)
        {
            robotMovement.StartMoving(); // Trigger the robot to start moving
        }
        else
        {
            Debug.LogError("RobotMovement script is not assigned!");
        }
    }

    

}
