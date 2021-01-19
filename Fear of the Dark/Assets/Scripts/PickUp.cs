using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour, IInteractable
{
    public float maxRange = 100f;
    public float MaxRange{get{return maxRange;}}

    public List<int> inventory = new List<int>();
    public List<int> Inventory{ get{return inventory;} set{inventory=value;} }

    Text prompt;

    // Start is called before the first frame update
    void Start()
    {
        prompt = GameObject.Find("Text").GetComponent<Text>();
    }

    public void OnStartHover()
    {
        prompt.text = "Take (E)";
    }

    public void OnInteract()
    {
        prompt.text = "";
        
        if (gameObject.tag == "matches")
        {
            inventory.Add(1);
        }
        else if (gameObject.tag == "candle")
        {
            inventory.Add(2);
        }
        else if (gameObject.tag == "bulb")
        {
            inventory.Add(3);
        }
        else if (gameObject.tag == "flash")
        {
            inventory.Add(4);
            GameObject.Find("FirstPerson").GetComponent<Flashlight>().enabled = true;
        }
        gameObject.SetActive(false);
    }
    
    public void OnEndHover()
    {
        prompt.text = "";
    }
}
