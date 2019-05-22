using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script handles the logic of the tile generation system
/// 
/// </summary>
[System.Serializable]
public class TileManager : MonoBehaviour
{
    private int dimension;
    private static int rowNumber;
    private static int colNumber;
    // Stores worldTile objects in 2D array.
    public static GameObject[,] tiles;
    // Stores boolean values denoting whether the tile is purchased or not.
    public static bool[,] shownTiles;
    // Stores all tiles in a public array.
    public GameObject[] worldTiles;
    
    // Populates all arrays at the start of the game.
    private void Awake()
    {
        dimension = (int) Mathf.Sqrt(worldTiles.Length);
        rowNumber = dimension;
        colNumber = dimension;
        tiles = new GameObject[rowNumber, colNumber];
        shownTiles = new bool[rowNumber, colNumber];

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
            if (!tile.name.Equals("WorldTile0"))
            {
                tile.SetActive(false);
            }
        }

    }
    // At the start of the game, populates the 2D array with
    // booleans which determine if the tile is visible to the player.
    void Start()
    {
        for (int row = 0; row < rowNumber; row++)
        {
            for (int col = 0; col < colNumber; col++)
            {
                if (tiles[row, col].activeSelf)
                {
                    shownTiles[row, col] = true;
                }
            }
        }
        showTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Iterates over the 2D array of tiles, checks to see if it is active
    // if it is, adds the index to the 2D boolean array, which is then 
    // checked and true indices have the surrounding indices set to active
    public static void showTiles()
    {

        
        for (int i = 0; i < rowNumber; i++)
        {
            for (int j = 0; j < colNumber; j++)
            {
                if (shownTiles[i, j])
                {
                    checkNeighbours(i, j);
                }
            }
        }
    }
    // Checks to see if surrounding tiles are empty, and 
    // also checks to see if its within the bounds of the array.
    public static void checkNeighbours(int row, int col)
    {
        if (col - 1 >= 0)
        {
            tiles[row, col - 1].SetActive(true);
        }
        if (col + 1 < tiles.GetLength(1))
        {
            tiles[row, col + 1].SetActive(true);
        }
        if (row - 1 >= 0)
        {
            tiles[row - 1, col].SetActive(true);
        }
        if (row + 1 < tiles.GetLength(0))
        {
            tiles[row + 1, col].SetActive(true);
        }
    }
    // Finds the index of the tile in the 2D array and returns it.
    public static Vector2 findTile(GameObject tile)
    {
        for (int row = 0; row < rowNumber; row++)
        {
            for (int col = 0; col < colNumber; col++)
            {   
                if (tiles[row, col].Equals(tile))
                {
                    Vector2 index = new Vector2(row, col);
                    return index;
                }
            }
        }
        Vector2 badIndex = new Vector2(0, 0);
        return badIndex;
    }
}
