using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour, IInteractable
{
    public float maxRange = 100f;
    public float MaxRange{get{return maxRange;}}

    public Text prompt;

    public void OnStartHover()
    {
        prompt.text = "Take (E)";
    }
    public void OnInteract()
    {
        prompt.text = "";
    }
    public void OnEndHover()
    {
        prompt.text = "";
    }
}
