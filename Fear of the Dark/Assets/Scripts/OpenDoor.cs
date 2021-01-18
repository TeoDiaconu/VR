using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

    public Text prompt;
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
        prompt.text = "Interact (E)";
    }
    public void OnInteract()
    {
        isOpening=!isOpening;
        _doorAnimator.SetBool("IsOpening", isOpening);
    }
    public void OnEndHover()
    {
        prompt.text = "";
    }
}
