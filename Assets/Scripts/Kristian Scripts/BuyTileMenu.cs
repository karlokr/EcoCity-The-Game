using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyTileMenu : MonoBehaviour
{
    private WorldTile worldTile;
    private ModelPicker pick;
    private Forest forestTile;
    public GameObject[] buildButtons;
    private BuyTileMenu buyTileMenu;
    private Rock rockTile;

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
    public void ConvertRockTile()
    {
        if (rockTile.finished)
        {
            rockTile.TurnIntoPlot();
        }
    }
    public void SetSelectedTile(Rock tile)
    {
        rockTile = tile;
    }

    public void BuyRockTile()
    {
        rockTile.BuyRock();
    }
    public void BuyTile()
    {
        forestTile.BuyForest();       

    }
    IEnumerator BuyNewTileRoutine()
    {
        if (ResourceKeeper.money < worldTile.moneyCost)
        {
            GameObject.FindGameObjectWithTag("CreditNotif").GetComponent<Animator>().SetTrigger("Notify");
            GameObject.FindGameObjectWithTag("CreditPanel").GetComponentInChildren<Image>().color = Color.red;
            GameObject.FindGameObjectWithTag("CreditNotifTitle").GetComponent<TextMeshProUGUI>().text = "NOT ENOUGH MONEY";
        }
        if (ResourceKeeper.wood < worldTile.woodCost)
        {
            GameObject.FindGameObjectWithTag("WoodNotif").GetComponent<Animator>().SetTrigger("Notify");
            GameObject.FindGameObjectWithTag("WoodPanel").GetComponentInChildren<Image>().color = Color.red;
            GameObject.FindGameObjectWithTag("WoodNotifTitle").GetComponent<TextMeshProUGUI>().text = "NOT ENOUGH WOOD";
        }
        if (ResourceKeeper.population < worldTile.popCost)
        {
            GameObject.FindGameObjectWithTag("PopNotif").GetComponent<Animator>().SetTrigger("Notify");
        }
        else if (ResourceKeeper.wood >= worldTile.woodCost && ResourceKeeper.money >= worldTile.moneyCost && ResourceKeeper.population >= worldTile.popCost)
        {
            ResourceKeeper.wood -= worldTile.woodCost;
            ResourceKeeper.money -= worldTile.moneyCost;
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
