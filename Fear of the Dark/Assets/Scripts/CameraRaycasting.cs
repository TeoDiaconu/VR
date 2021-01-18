using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycasting : MonoBehaviour
{
    public float range;
    private IInteractable currentTarget;
    public Camera mainCamera;
    private GameObject focus = null;
    private Light lampLight;
    private GameObject player;
    private List<int> inventory;
    private GameObject[] lights;
    private int i = 0;

    private void Start()
    {
     
        inventory = new List<int>();
        player = GameObject.Find("FirstPerson");
        player.GetComponent<Flashlight>().enabled = false;
        lights = GameObject.FindGameObjectsWithTag("willdie");
    }

    private void RaycastForInteractable(){
        RaycastHit hit;

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        
        if(Physics.Raycast(ray, out hit, range))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                if(hit.distance <= interactable.MaxRange)
                {
                    if(interactable == currentTarget)
                    {
                        return;
                    }
                    else
                    {
                        if(currentTarget!=null)
                        {
                            currentTarget.OnEndHover();
                        }
                        currentTarget = interactable;
                        focus = hit.transform.gameObject;
                        currentTarget.OnStartHover();
                        return;
                    }
                }
                return;
            }
        }

        if(currentTarget!=null)
        {
            currentTarget.OnEndHover();
            currentTarget=null;
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastForInteractable();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentTarget!=null)
            {
                if (focus != null)
                {
                    if (focus.tag == "small_lamp")
                    {
                        lampLight = (Light)focus.GetComponentInChildren(typeof(Light));
                        if (inventory.Contains(3))
                        {
                            if (!lampLight.enabled)
                            {
                                lampLight.enabled = !lampLight.enabled;
                                StartCoroutine(lightsOut());
                            }
                        }
                    }
                    else if (focus.tag == "generator") {
                        foreach (GameObject light in lights)
                        {
                            light.SetActive(true);
                        }
                    }
                    else if (focus.tag == "KitchenCandles")
                    {
                        if (inventory.Contains(1) && inventory.Contains(2))
                        {
                            currentTarget.OnInteract();
                        }
                    }
                    else if (focus.tag != "Untagged" && focus.tag != "switch")
                    {
                        addToInventory();
                    }
                    else
                    {
                        currentTarget.OnInteract();
                    }
                }
            }
        }
    }

    void addToInventory()
    {
        if (focus.tag == "matches")
        {
            inventory.Add(1);
            focus.SetActive(false);

        }
        else if (focus.tag == "candle")
        {
            inventory.Add(2);
            focus.SetActive(false);
        }
        else if (focus.tag == "bulb")
        {
            inventory.Add(3);
            focus.SetActive(false);
        }
        else if (focus.tag == "flash")
        {
            inventory.Add(4);
            focus.SetActive(false);
            player.GetComponent<Flashlight>().enabled = true;
        }
    }

    IEnumerator lightsOut()
    {
        yield return new WaitForSeconds(5);

        GameObject sw = GameObject.Find("switch_model");
        sw.GetComponent<Switch>().enabled = false;

        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }
    }
}
