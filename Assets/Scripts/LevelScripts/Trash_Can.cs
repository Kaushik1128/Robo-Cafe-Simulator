using Unity.VisualScripting;
using UnityEngine;

public class Trash_Can : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Trigger_Zone>().OnEnterEvent.AddListener(InsideTrash);
    }
    public void InsideTrash(GameObject go)
    {
        go.SetActive(false);
    }
}
