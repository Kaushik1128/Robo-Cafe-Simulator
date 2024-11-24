using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Trigger_Zone : MonoBehaviour
{
    public string targetTag;
    public UnityEvent<GameObject> OnEnterEvent;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == targetTag)
        {
            OnEnterEvent.Invoke(other.gameObject);
        }
    }
}
