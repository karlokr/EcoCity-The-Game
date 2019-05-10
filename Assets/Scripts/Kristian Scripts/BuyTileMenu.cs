using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTileMenu : MonoBehaviour
{
    private WorldTile worldTile;
    private Forest forestTile;
    public GameObject[] buildButtons;

    private GameObject randomTile;

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
        SelectRandomTile();
        ResourceKeeper.wood -= 1000;
        Vector2 index = TileManager.findTile(worldTile.gameObject);
        GameObject newTile = worldTile.createNewTile(randomTile);
        TileManager.tiles[(int)index.x, (int)index.y] = newTile;
        TileManager.shownTiles[(int)index.x, (int)index.y] = true;
        TileManager.showTiles();
        Destroy(worldTile.gameObject);

    }
    private void SelectRandomTile()
    {
        int randomNumber = Random.Range(0, 2);
        randomTile = Resources.Load("Prefabs/WorldTile" + randomNumber) as GameObject;

    }
}
