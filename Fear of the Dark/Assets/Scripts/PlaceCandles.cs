using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCandles : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

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
        Debug.Log("Press E to place");
    }
    public void OnInteract()
    {
        if(!placed){
            placed=true;
            candles.SetActive(placed);
            candlesLight.SetActive(placed);
        }
    }
    public void OnEndHover()
    {
        Debug.Log("Candle spot out of range");
    }
}
