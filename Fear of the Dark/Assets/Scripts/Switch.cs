using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

    public bool active = false;
    public GameObject Light;

    void Start()
    {
        Light.SetActive(active);
    }

    public void OnStartHover()
    {
        Debug.Log("Press E to interact");
    }
    public void OnInteract()
    {
        active=!active;
        Light.SetActive(active);
    }
    public void OnEndHover()
    {
        Debug.Log("Switch out of range");
    }
}
