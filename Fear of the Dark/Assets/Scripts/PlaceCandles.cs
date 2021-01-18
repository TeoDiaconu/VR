using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceCandles : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

    public Text prompt;
    public GameObject candles;
    public GameObject candlesLight;
    bool placed = false;

    // Start is called before the first frame update
    void Start()
    {
        candles.SetActive(placed);
        candlesLight.SetActive(placed);
    }

    public void OnStartHover()
    {
        if(!placed){
            prompt.text = "Place (E)";
        }
    }
    public void OnInteract()
    {
        if(!placed){
            placed=true;
            candles.SetActive(placed);
            candlesLight.SetActive(placed);
        }
        prompt.text = "";
    }
    public void OnEndHover()
    {
        prompt.text = "";
    }
}
