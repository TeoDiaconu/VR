using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

    public GameObject door;
    Animator _doorAnimator;
    bool isOpening = false;

    // Start is called before the first frame update
    void Start()
    {
        _doorAnimator = door.GetComponent<Animator>();
    }

    public void OnStartHover()
    {
        Debug.Log("Press E to interact");
    }
    public void OnInteract()
    {
        isOpening=!isOpening;
        _doorAnimator.SetBool("IsOpening", isOpening);
    }
    public void OnEndHover()
    {
        Debug.Log("Door out of range");
    }
}
