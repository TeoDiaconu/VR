using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorController : MonoBehaviour
{
    public GameObject doorA;
    public GameObject doorB;
    Animator _doorAnimatorA;
    Animator _doorAnimatorB;

    // Start is called before the first frame update
    void Start()
    {
        _doorAnimatorA = doorA.GetComponent<Animator>();
        _doorAnimatorB = doorB.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _doorAnimatorA.SetBool("IsOpening", true);
        _doorAnimatorB.SetBool("IsOpening", true);
    }

    private void OnTriggerExit(Collider other)
    {
        _doorAnimatorA.SetBool("IsOpening", false);
        _doorAnimatorB.SetBool("IsOpening", false);
    }
}
