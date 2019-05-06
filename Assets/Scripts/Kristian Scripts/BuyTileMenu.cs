using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTileMenu : MonoBehaviour
{
    private Forest forestTile;
    public GameObject[] buildButtons;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetSelectedTile(Forest tile)
    {
        forestTile = tile;
    }

    public void ConvertTile()
    {
        Debug.Log("Clicked");
        if (forestTile.finished)
        {
            forestTile.TurnIntoPlot();
        }
    }
    public void BuyTile()
    {
        forestTile.BuyForest();       

    }
}
