using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Forest : Plot
{
    public Image progressBar;
    public float elapsedTime = 0f;
    public float buildTime = 10f;
    public int woodGained;

    public BuyTileMenu buyMenu;
    public static Material forestDefaultMaterial;

    public Plot prefabToBuild;

    public bool building;
    public bool finished;
    void Awake()
    {

    }
    void Update()
    {
        if (building)
        {
            BuildForest();
        }
    }

    public void BuyForest()
    {
        if (ResourceKeeper.money >= 100)
        {
            ResourceKeeper.money -= 100;
            building = true;
        }

    }
    private void BuildForest()
    {
        elapsedTime += Time.deltaTime;
        progressBar.GetComponent<Image>().fillAmount = elapsedTime / buildTime;

        if (elapsedTime >= buildTime)
        {
            finished = true;
            building = false;

        }
       
        
    }

    public void TurnIntoPlot()
    {
        Plot newPlot = Instantiate(prefabToBuild, transform.position, transform.rotation);
        newPlot.transform.SetParent(GameObject.FindGameObjectWithTag("WorldTile").transform);
        newPlot.transform.Translate(Vector3.up * 7.125f);
        newPlot.transform.Translate(Vector3.left * 7.4f);
        newPlot.transform.Translate(Vector3.forward * 2.5f);
        ResourceKeeper.wood += woodGained;
        Destroy(gameObject);
    }

    public void GetComponents()
    {
        buyMenu = GameObject.FindGameObjectWithTag("BuyTileMenu").GetComponent<BuyTileMenu>();
        forestDefaultMaterial = GetComponentInChildren<Renderer>().material;
    }
}
