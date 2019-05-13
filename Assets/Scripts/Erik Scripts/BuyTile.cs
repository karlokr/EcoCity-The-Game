using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTile : MonoBehaviour
{
    //private TileManager tilemanager;
    GameObject randomTile;
    void Start()
    {
       //tilemanager = GameObject.Find
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void handleClick(WorldTile selectedTile)
    {
        SelectRandomTile();
        Vector2 index = TileManager.findTile(selectedTile.gameObject);
        GameObject newTile = selectedTile.createNewTile(randomTile);
        TileManager.tiles[(int)index.x, (int)index.y] = newTile;
        TileManager.shownTiles[(int)index.x, (int)index.y] = true;
        TileManager.showTiles();
        Destroy(selectedTile.gameObject);
    }

    private void SelectRandomTile()
    {
        int randomNumber = Random.Range(0, 1);
        randomTile = (GameObject) Resources.Load("Prefabs/WorldTile" + randomNumber);
    }
}
