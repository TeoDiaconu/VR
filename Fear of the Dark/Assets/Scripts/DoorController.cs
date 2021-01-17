using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    Animator _doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _doorAnimator = door.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _doorAnimator.SetBool("IsOpening", true);
    }

    private void OnTriggerExit(Collider other)
    {
        _doorAnimator.SetBool("IsOpening", false);
    }
}
