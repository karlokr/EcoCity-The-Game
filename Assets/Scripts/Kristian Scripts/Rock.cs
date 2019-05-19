using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rock : MonoBehaviour
{
    public Image progressBar;
    public float elapsedTime = 0f;
    public float buildTime = 10f;
    public int moneyGained;
    public int upgradeMaterialGained;
    public int cost;
    public int woodCost;
    public int popCost;
    public string title = "Rock";
    public string description = "Purchasing a Rock tile will give you bonus Money and lots of Upgrade Materials";

    public Plot prefabToBuild;

    private BuyTileMenu buyTileMenu;

    public bool building;
    public bool finished;
    
    void Awake()
    {

    }
    private void Start()
    {
        buyTileMenu = GameObject.FindGameObjectWithTag("BuyTileMenu").GetComponent<BuyTileMenu>();
    }
    void Update()
    {
        if (building)
        {
            BuildRock();
        }
    }

    public void BuyRock()
    {
        if (ResourceKeeper.money < cost)
        {
            GameObject.FindGameObjectWithTag("CreditNotif").GetComponent<Animator>().SetTrigger("Notify");
            GameObject.FindGameObjectWithTag("CreditPanel").GetComponentInChildren<Image>().color = Color.red;
            GameObject.FindGameObjectWithTag("CreditNotifTitle").GetComponent<TextMeshProUGUI>().text = "NOT ENOUGH MONEY";
        }
        if (ResourceKeeper.wood < woodCost)
        {
            GameObject.FindGameObjectWithTag("WoodNotif").GetComponent<Animator>().SetTrigger("Notify");
            GameObject.FindGameObjectWithTag("WoodPanel").GetComponentInChildren<Image>().color = Color.red;
            GameObject.FindGameObjectWithTag("WoodNotifTitle").GetComponent<TextMeshProUGUI>().text = "NOT ENOUGH WOOD";
        }
        else if (ResourceKeeper.money >= cost && ResourceKeeper.wood >= woodCost)
        {
            ResourceKeeper.money -= cost;
            ResourceKeeper.wood -= woodCost;
            building = true;
            buyTileMenu.buildButtons[3].SetActive(false);
        }

    }
    private void BuildRock()
    {

        elapsedTime += Time.deltaTime;
        progressBar.GetComponent<Image>().fillAmount = elapsedTime / buildTime;

        if (elapsedTime >= buildTime)
        {
            finished = true;
            building = false;
        }
        else
        {
        }
    }

    public void TurnIntoPlot()
    {
        Plot newPlot = Instantiate(prefabToBuild, transform.position, transform.rotation);
        newPlot.transform.SetParent(GameObject.FindGameObjectWithTag("WorldTile").transform);
        newPlot.transform.Translate(Vector3.up * 7.125f);
        newPlot.transform.Translate(Vector3.left * 7.4f);
        newPlot.transform.Translate(Vector3.forward * 2.5f);
        newPlot.transform.localScale = new Vector3(0.02f, 1f, 0.02f);
        ResourceKeeper.money += moneyGained;
        ResourceKeeper.upgradeMaterial += upgradeMaterialGained;
        Destroy(gameObject);
        buyTileMenu.buildButtons[4].SetActive(false);
    }

}
