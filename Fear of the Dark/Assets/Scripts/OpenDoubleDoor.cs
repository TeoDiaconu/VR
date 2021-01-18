using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoubleDoor : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

    public GameObject doorA;
    public GameObject doorB;
    Animator _doorAnimatorA;
    Animator _doorAnimatorB;
    bool isOpening = false;

    // Start is called before the first frame update
    void Start()
    {
        _doorAnimatorA = doorA.GetComponent<Animator>();
        _doorAnimatorB = doorB.GetComponent<Animator>();
    }

    public void OnStartHover()
    {
        Debug.Log("Press E to interact");
    }
    public void OnInteract()
    {
        isOpening=!isOpening;
        _doorAnimatorA.SetBool("IsOpening", isOpening);
        _doorAnimatorB.SetBool("IsOpening", isOpening);
    }
    public void OnEndHover()
    {
        Debug.Log("Double door out of range");
    }
}
