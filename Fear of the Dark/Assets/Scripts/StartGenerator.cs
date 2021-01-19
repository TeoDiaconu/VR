using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGenerator : MonoBehaviour, IInteractable
{
    public float maxRange = 100f;
    public float MaxRange{get{return maxRange;}}

    public List<int> inventory = new List<int>();
    public List<int> Inventory{ get{return inventory;} set{inventory=value;} }
    
    Text prompt;
    GameObject[] lights;

    // Start is called before the first frame update
    void Start()
    {
        prompt = GameObject.Find("Text").GetComponent<Text>();
        lights = GameObject.FindGameObjectsWithTag("willdie");
    }

    public void OnStartHover()
    {
        if(gameObject.GetComponent<StartGenerator>().enabled == true)
        {
            prompt.text = "Start generator (E)";
        }
    }
    public void OnInteract()
    {
        if(gameObject.GetComponent<StartGenerator>().enabled == true)
        {
            GameObject.Find("chandelierSwitch").GetComponent<Switch>().enabled = true;

            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
            prompt.text = "";
        }
    }
    public void OnEndHover()
    {
        prompt.text = "";
    }
}
