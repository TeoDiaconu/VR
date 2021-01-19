using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoubleDoor : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

    public List<int> inventory = new List<int>();
    public List<int> Inventory{ get{return inventory;} set{inventory=value;} }

    Text prompt;
    public GameObject doorA;
    public GameObject doorB;
    Animator _doorAnimatorA;
    Animator _doorAnimatorB;
    bool isOpening = false;

    // Start is called before the first frame update
    void Start()
    {
        prompt = GameObject.Find("Text").GetComponent<Text>();
        _doorAnimatorA = doorA.GetComponent<Animator>();
        _doorAnimatorB = doorB.GetComponent<Animator>();
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
        _doorAnimatorA.SetBool("IsOpening", isOpening);
        _doorAnimatorB.SetBool("IsOpening", isOpening);

        OnStartHover();
    }
    public void OnEndHover()
    {
        prompt.text = "";
    }
}
