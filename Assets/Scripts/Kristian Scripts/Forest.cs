using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Forest : Plot
{
    public Image progressBar;
    public float buildTime = 0f;
    public float bt = 10f;
    public int woodGained;

    public BuyTileMenu buyMenu;
    public ResourceKeeper rk;
    public static Material forestDefaultMaterial;

    public Plot prefabToBuild;

    public bool building;
    public bool finished;
    void Awake()
    {
        buyMenu = GameObject.FindGameObjectWithTag("BuyTileMenu").GetComponent<BuyTileMenu>();
        rk = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
        forestDefaultMaterial = GetComponentInChildren<Renderer>().material;
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
        if (rk.money >= 100)
        {
            rk.money -= 100;
            building = true;
        }

    }
    private void BuildForest()
    {
        buildTime += Time.deltaTime;
        progressBar.GetComponent<Image>().fillAmount = buildTime / bt;
        if (buildTime >= bt)
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
        rk.wood += woodGained;
        Destroy(gameObject);
    }
}
