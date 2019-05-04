using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTile : MonoBehaviour
{
    private const int rowNumber = 3;
    private const int colNumber = 3;
    private GameObject[,] tiles = new GameObject[rowNumber, colNumber];

    public GameObject[] hiddenTiles;
    // Start is called before the first frame update
    void Start()
    {
        hiddenTiles = GameObject.FindGameObjectsWithTag("WorldTile");
        foreach (GameObject hiddenTile in hiddenTiles)
        {
            hiddenTile.SetActive(false);
        }

        foreach (GameObject hiddenTile in hiddenTiles) { 
        for (int row = 0; row < rowNumber; row++)
        {
            for (int col = 0; col < colNumber; col++)
            {
                tiles[row, col] = hiddenTile;;
                }
        }
            foreach (GameObject tile in tiles)
            {
                Debug.Log(tile);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void handleClick()
    {
        foreach (GameObject hiddenTile in hiddenTiles)
        {
            hiddenTile.SetActive(false);
        }
    }
}
