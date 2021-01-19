using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

    public List<int> inventory = new List<int>();
    public List<int> Inventory{ get{return inventory;} set{inventory=value;} }

    Text prompt;
    public bool active = false;
    public GameObject Light;

    void Start()
    {
        prompt = GameObject.Find("Text").GetComponent<Text>();
        Light.SetActive(active);
    }

    public void OnStartHover()
    {
        if(gameObject.GetComponent<Switch>().enabled == true)
        {
            prompt.text = "Switch (E)";
        }
    }
    public void OnInteract()
    {
        if(gameObject.GetComponent<Switch>().enabled == true)
        {
            active=!active;
            Light.SetActive(active);
        }
    }
    public void OnEndHover()
    {
        prompt.text = "";
    }
}
