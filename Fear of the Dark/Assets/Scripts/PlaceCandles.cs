using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceCandles : MonoBehaviour, IInteractable
{
    public float maxRange = 10f;
    public float MaxRange{get{return maxRange;}}

    public List<int> inventory = new List<int>();
    public List<int> Inventory{ get{return inventory;} set{inventory=value;} }

    Text prompt;
    public GameObject candles;
    public GameObject candlesLight;
    bool placed = false;

    // Start is called before the first frame update
    void Start()
    {
        prompt = GameObject.Find("Text").GetComponent<Text>();
        candles.SetActive(placed);
        candlesLight.SetActive(placed);
    }

    public void OnStartHover()
    {
        if(!placed)
        {
            if (inventory.Contains(1) && inventory.Contains(2))
            {
                prompt.text = "Place candles (E)";
            }
            else
            {
                prompt.text = "Find candles and matches!";
            }
        }
    }
    public void OnInteract()
    {
        if (!placed && inventory.Contains(1) && inventory.Contains(2))
        {
            placed=true;
            candles.SetActive(placed);
            candlesLight.SetActive(placed);
            prompt.text = "";
        }
    }
    public void OnEndHover()
    {
        prompt.text = "";
    }
}
