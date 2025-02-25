﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Forest : MonoBehaviour
{
    public Image progressBar;
    public float elapsedTime = 0f;
    public float buildTime = 10f;
    public int woodGained;
    private BuyTileMenu buyTileMenu;
    public int upgradeMaterialGained;
    public int cost;
    public int woodCost;
    public int popCost;
    public int emission;
    public string title = "Forest";
    public string description = "Purchasing a Forest tile will give you a lot of Wood and some Upgrade Materials";
    public static Material forestDefaultMaterial;

    public Plot prefabToBuild;

    public bool building;
    public bool finished;
    void Awake()
    {
        buyTileMenu = GameObject.FindGameObjectWithTag("BuyTileMenu").GetComponent<BuyTileMenu>();
    }
    private void Start()
    {
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
        if (ResourceKeeper.money < cost)
        {
            GameObject.FindGameObjectWithTag("CreditNotif").GetComponent<Animator>().SetTrigger("Notify");
            GameObject.FindGameObjectWithTag("CreditPanel").GetComponentInChildren<Image>().color = Color.red;
            GameObject.FindGameObjectWithTag("CreditNotifTitle").GetComponent<TextMeshProUGUI>().text = "NOT ENOUGH MONEY";
        }
        else if (ResourceKeeper.money >= cost)
        {
            ResourceKeeper.money -= cost;
            building = true;
            buyTileMenu.buildButtons[0].SetActive(false);
        }

    }
    private void BuildForest()
    {

        elapsedTime += Time.deltaTime;
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("Run");
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
        newPlot.transform.localScale = new Vector3(0.02f, 1f, 0.02f);
        ResourceKeeper.emission += emission;
        ResourceKeeper.wood += woodGained;
        ResourceKeeper.upgradeMaterial += upgradeMaterialGained;
        Destroy(gameObject);
        buyTileMenu.buildButtons[1].SetActive(false);

    }

}
