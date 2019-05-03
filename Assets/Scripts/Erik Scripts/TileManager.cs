using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private const int rowNumber = 3;
    private const int colNumber = 3;
    public GameObject[,] tiles = new GameObject[rowNumber, colNumber];

    public GameObject[] worldTiles;
    // Start is called before the first frame update
    void Start()
    {
        worldTiles = GameObject.FindGameObjectsWithTag("WorldTile");
        int count = 0;
        for (int row = 0; row < rowNumber; row++)
        {
            for (int col = 0; col < colNumber; col++)
            {
                tiles[row, col] = worldTiles[count];
                count++;
            }
        }
        foreach (GameObject tile in tiles)
        {
            Debug.Log(tile);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
