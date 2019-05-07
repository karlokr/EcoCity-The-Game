using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private const int rowNumber = 5;
    private const int colNumber = 5;
    public static GameObject[,] tiles = new GameObject[rowNumber, colNumber];
    public static bool[,] shownTiles = new bool[rowNumber, colNumber];

    public GameObject[] worldTiles;
    // Start is called before the first frame update
    private void Awake()
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
            if (!tile.name.Equals("LevelOneLayout"))
            {
                tile.SetActive(false);
            }
        }

    }
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
        // This sucks, fix later
        Vector2 badIndex = new Vector2(0, 0);
        return badIndex;


    }
}
