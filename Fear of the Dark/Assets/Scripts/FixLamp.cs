using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixLamp : MonoBehaviour, IInteractable
{
    public float maxRange = 100f;
    public float MaxRange{get{return maxRange;}}

    public List<int> inventory = new List<int>();
    public List<int> Inventory{ get{return inventory;} set{inventory=value;} }

    Text prompt;
    Light lampLight;
    GameObject[] lights;

    // Start is called before the first frame update
    void Start()
    {
        prompt = GameObject.Find("Text").GetComponent<Text>();
        lampLight = (Light)gameObject.GetComponentInChildren(typeof(Light));
        lights = GameObject.FindGameObjectsWithTag("willdie");
    }

    public void OnStartHover()
    {
        if(gameObject.GetComponent<FixLamp>().enabled == true && !lampLight.enabled)
        {
            if (inventory.Contains(3) && !lampLight.enabled)
            {
                prompt.text = "Fix lamp (E)";
            }
            else
            {
                prompt.text = "Find a spare lightbulb!";
            }
        }
    }

    public void OnInteract()
    {
        if(gameObject.GetComponent<FixLamp>().enabled == true && !lampLight.enabled)
        {
            if (inventory.Contains(3))
            {
                lampLight.enabled = true;
                prompt.text = "";
                StartCoroutine(lightsOut());
            }
        }
    }

    public void OnEndHover()
    {
        prompt.text = "";
    }

    IEnumerator lightsOut()
    {
        yield return new WaitForSeconds(10);

        GameObject.Find("chandelierSwitch").GetComponent<Switch>().enabled = false;

        bool status=false;

        for( int flicker = 0; flicker < 4; flicker++ ){
            yield return new WaitForSeconds(0.1f);

            foreach (GameObject light in lights)
            {
                light.SetActive(status);
            }

            status = !status;
        }

        yield return new WaitForSeconds(1f);

        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }

        GameObject.Find("generator").GetComponent<StartGenerator>().enabled = true;
    }
}
