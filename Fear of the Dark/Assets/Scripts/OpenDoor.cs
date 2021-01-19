using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

    public List<int> inventory = new List<int>();
    public List<int> Inventory{ get{return inventory;} set{inventory=value;} }

    Text prompt;
    public GameObject door;
    Animator _doorAnimator;
    bool isOpening = false;

    // Start is called before the first frame update
    void Start()
    {
        prompt = GameObject.Find("Text").GetComponent<Text>();
        _doorAnimator = door.GetComponent<Animator>();
    }

    public void OnStartHover()
    {
        if(!isOpening)
        {
            prompt.text = "Open (E)";
        }
        else
        {
            prompt.text = "Close (E)";
        }
    }
    public void OnInteract()
    {
        isOpening=!isOpening;
        _doorAnimator.SetBool("IsOpening", isOpening);

        OnStartHover();
    }
    public void OnEndHover()
    {
        prompt.text = "";
    }
}
