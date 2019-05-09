using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTileMenu : MonoBehaviour
{
    private WorldTile worldTile;
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
    public void SetSelectedTile(WorldTile tile)
    {
        worldTile = tile;
    }
    public void ConvertTile()
    {
        if (forestTile.finished)
        {
            forestTile.TurnIntoPlot();
        }
    }
    public void BuyTile()
    {
        forestTile.BuyForest();       

    }
    public void BuyNewTile()
    {
        Vector2 index = TileManager.findTile(worldTile.gameObject);
        GameObject newTile = worldTile.createNewTile();
        TileManager.tiles[(int)index.x, (int)index.y] = newTile;
        TileManager.shownTiles[(int)index.x, (int)index.y] = true;
        TileManager.showTiles();
        Destroy(worldTile.gameObject);

    }
}
