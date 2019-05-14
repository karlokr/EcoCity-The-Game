using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTileMenu : MonoBehaviour
{
    private WorldTile worldTile;
    private ModelPicker pick;
    private Forest forestTile;
    public GameObject[] buildButtons;
    private BuyTileMenu buyTileMenu;

    private void Awake()
    {
        buyTileMenu = GameObject.FindGameObjectWithTag("BuyTileMenu").GetComponent<BuyTileMenu>();
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
    IEnumerator BuyNewTileRoutine()
    {
        if (ResourceKeeper.wood >= 1000)
        {
            ResourceKeeper.wood -= 1000;
            Vector2 index = TileManager.findTile(worldTile.gameObject);
            GameObject newTile = worldTile.createNewTile();
            TileManager.tiles[(int)index.x, (int)index.y] = newTile;
            TileManager.shownTiles[(int)index.x, (int)index.y] = true;
            TileManager.showTiles();
            Destroy(worldTile.gameObject);
            buyTileMenu.buildButtons[2].SetActive(false);
            yield return null;
        }
        
    }

    public void BuyNewTile()
    {
        StartCoroutine(BuyNewTileRoutine());
    }
}
