using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public List<GameObject> BreakablePieces;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in BreakablePieces)
        {
            item.SetActive(false);
        }
    }

    public void Break()
    {
        foreach(var item in BreakablePieces)
        {
            item.SetActive(true);
            item.transform.parent = null;
        }
        
        gameObject.SetActive(false);
    }
}
