using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public float maxRange = 100f;
    public float MaxRange{get{return maxRange;}}

    public void OnStartHover()
    {
        Debug.Log("ready to pick up");
    }
    public void OnInteract()
    {
        Debug.Log("interacted");
    }
    public void OnEndHover()
    {
        Debug.Log("out");
    }
}
