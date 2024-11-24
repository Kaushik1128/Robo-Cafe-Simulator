using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Disable_Grabing_Hand_Model : MonoBehaviour
{
    public GameObject LefthandModel;
    public GameObject RightHandModel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(HideGrabbingHand);
        grabInteractable.selectExited.AddListener(ShowGrabingHand);
    }

    public void HideGrabbingHand(SelectEnterEventArgs args)
    {
        if(args.interactorObject.transform.tag == "Left Hand")
        {
            LefthandModel.SetActive(false);
        }
        else if(args.interactorObject.transform.tag == "Right Hand")
        {
            RightHandModel.SetActive(false);
        }
    }

    public void ShowGrabingHand(SelectExitEventArgs args)
    {
        if(args.interactorObject.transform.tag == "Left Hand")
        {
            LefthandModel.SetActive(true);
        }
        else if(args.interactorObject.transform.tag == "Right Hand")
        {
            RightHandModel.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
