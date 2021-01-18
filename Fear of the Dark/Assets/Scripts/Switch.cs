using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

    public Text prompt;
    public bool active = false;
    public GameObject Light;

    void Start()
    {
        Light.SetActive(active);
    }

    public void OnStartHover()
    {
        prompt.text = "Interact (E)";
    }
    public void OnInteract()
    {
        active=!active;
        Light.SetActive(active);
    }
    public void OnEndHover()
    {
        prompt.text = "";
    }
}
