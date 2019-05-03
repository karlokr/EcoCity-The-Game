using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTile : MonoBehaviour
{
    public GameObject[] hiddenTiles;
    // Start is called before the first frame update
    void Start()
    {
        hiddenTiles = GameObject.FindGameObjectsWithTag("HiddenTile");
        foreach (GameObject hiddenTile in hiddenTiles)
        {
            hiddenTile.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
