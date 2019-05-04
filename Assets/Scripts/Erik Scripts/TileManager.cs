using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    private const int rowNumber = 3;
    private const int colNumber = 3;
    public GameObject[,] tiles = new GameObject[rowNumber, colNumber];
    public bool[,] shownTiles = new bool[rowNumber, colNumber];

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
        {   if (!tile.name.Equals("LevelOneLayout"))
            {
                tile.SetActive(false);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showTiles()
    {

        for(int row = 0; row < rowNumber; row++)
        {
            for (int col = 0; col < colNumber; col++)
            {
                if (tiles[row, col].activeSelf)
                {
                    shownTiles[row, col] = true;
                }
            }
        }
        foreach (bool shownTile in shownTiles)
        {
            Debug.Log(shownTile);
        }
        Debug.Log(shownTiles);
        checkNeighbours(1, 1);
        //for(int i = 0; i < rowNumber; i++)
        //{
        //    for(int j = 0; j < colNumber; j++)
        //    {
        //        if(shownTiles[i,j])
        //        {
        //            checkNeighbours(i, j);
        //            Debug.Log(i);
        //            Debug.Log(j);
        //        }
        //    }
        //}
    }
    private void checkNeighbours(int row, int col)
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
}
