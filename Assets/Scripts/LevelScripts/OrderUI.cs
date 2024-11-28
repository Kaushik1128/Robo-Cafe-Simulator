// using TMPro;
// using UnityEngine;
// using UnityEngine.UI; // Add this for UI elements

// public class InstantiateTextOnReach : MonoBehaviour
// {
//     public RobotOrderAI order;
//     public Transform targetPosition;   // The position to check against
//     public GameObject textPrefab;     // The UI Text prefab
//     public Transform uiParentCanvas;  // The parent canvas for the text (required for UI elements)
//     public float tolerance = 0.1f;    // Distance tolerance to consider "reached"

//     private bool textInstantiated = false;

//     void Update()
//     {
//         // Check if the GameObject is close to the target position
//         if (!textInstantiated && Vector3.Distance(transform.position, targetPosition.position) < tolerance)
//         {
//             InstantiateUIText();
//         }
//     }

//     void InstantiateUIText()
//     {
//         // Instantiate the text prefab
//         GameObject instantiatedText = Instantiate(textPrefab, uiParentCanvas);

//         TextMeshProUGUI textComponent = instantiatedText.GetComponent<TextMeshProUGUI>();
//         if (textComponent != null)
//         {
//             Debug.Log("Text found");
//             textComponent.text = "Sample ";
//         }
//         else
//         {
//             Debug.LogError("No Text component found on the prefab");
//         }

//         // Set the text position above the GameObject if it's in World Space
//         RectTransform rectTransform = instantiatedText.GetComponent<RectTransform>();
//         if (rectTransform != null)
//         {
//             // Offset position above the GameObject
//             rectTransform.position = transform.position + new Vector3(0, 1.4f, 0); // Adjust Y offset as needed
//         }

//         // Set the text content
//         // Text textComponent = instantiatedText.GetComponent<Text>();
//         // if (textComponent != null)
//         // {
//         //     Debug.LogError("Text not found");
//         //     textComponent.text = "Reached Target!";
//         // }

//         textInstantiated = true; // Prevent multiple instantiations
//     }
// }


using UnityEngine;
using UnityEngine.UI; // Add this for UI elements
using System.Collections;

public class InstantiateTextOnReach : MonoBehaviour
{
    public Transform targetPosition;   // The position to check against
    public GameObject textPrefab;     // The UI Text prefab
    public Transform uiParentCanvas;  // The parent canvas for the text (required for UI elements)
    public float tolerance = 0.1f;    // Distance tolerance to consider "reached"
    public float displayDuration = 10f;//UI display duration

    private bool textInstantiated = false;

    void Update()
    {
        // Check if the GameObject is close to the target position
        if (!textInstantiated && Vector3.Distance(transform.position, targetPosition.position) < tolerance)
        {
            InstantiateUIText();
        }
    }

    void InstantiateUIText()
    {
        // Instantiate the text prefab
        GameObject instantiatedText = Instantiate(textPrefab, uiParentCanvas);

        // Set the text position above the GameObject if it's in World Space
        RectTransform rectTransform = instantiatedText.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            // Offset position above the GameObject
            rectTransform.position = transform.position + new Vector3(0, 1f, 0); // Adjust Y offset as needed
        }

        // Set the text content
        Text textComponent = instantiatedText.GetComponent<Text>();
        if (textComponent != null)
        {
            textComponent.text = "Reached Target!";
        }

        textInstantiated = true; // Prevent multiple instantiations

        StartCoroutine(RemoveTextAfterDelay(instantiatedText, displayDuration));
    }

    IEnumerator RemoveTextAfterDelay(GameObject textObject, float delay)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(delay);

        // Destroy the UI element
        if (textObject != null)
        {
            Destroy(textObject);
        }
    }

    
    
}
