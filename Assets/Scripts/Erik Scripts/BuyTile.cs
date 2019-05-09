using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTile : MonoBehaviour
{
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void handleClick(WorldTile selectedTile)
    {
        Vector2 index = TileManager.findTile(selectedTile.gameObject);
        GameObject newTile = selectedTile.createNewTile();
        TileManager.tiles[(int)index.x, (int)index.y] = newTile;
        TileManager.shownTiles[(int)index.x, (int)index.y] = true;
        TileManager.showTiles();
        Destroy(selectedTile.gameObject);
    }
}
