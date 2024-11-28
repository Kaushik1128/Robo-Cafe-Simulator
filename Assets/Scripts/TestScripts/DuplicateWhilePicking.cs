using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRPrefabSpawner : MonoBehaviour
{
    public GameObject prefab; // Stationary prefab in the scene
    public Transform spawnParent; // Optional: Parent for spawned objects (e.g., player's hand or environment)

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable; // Reference to the XR Grab Interactable component

    void Start()
    {
        if (prefab == null)
        {
            Debug.LogError("Prefab is not assigned!");
            return;
        }

        // Ensure the prefab has an XR Grab Interactable component
        grabInteractable = prefab.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        if (grabInteractable == null)
        {
            Debug.LogError("Prefab does not have an XR Grab Interactable component!");
        }
        else
        {
            // Subscribe to grab interaction events
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Spawn a duplicate of the prefab
        SpawnDuplicate(args.interactorObject.transform);
    }

    void SpawnDuplicate(Transform handTransform)
    {
        // Instantiate a new duplicate
        GameObject duplicate = Instantiate(prefab, handTransform.position, handTransform.rotation);

        // Optional: Attach the duplicate to the hand
        if (spawnParent != null)
        {
            duplicate.transform.parent = spawnParent;
        }

        // Ensure the duplicate has its own XR Grab Interactable component
        if (duplicate.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>() == null)
        {
            duplicate.AddComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        }

        duplicate.name = prefab.name + "_Duplicate";
    }

    void OnDestroy()
    {
        // Clean up listeners to prevent memory leaks
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }
}
