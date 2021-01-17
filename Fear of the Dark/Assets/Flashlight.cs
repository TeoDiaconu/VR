using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool active = false;
    public GameObject Light;
    //public AudioSource clickSound;

    void Start()
    {
        Light.SetActive(active);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Flashlight")){
            active=!active;
            Light.SetActive(active);
            //clickSound.Play();
        }
    }
}
