using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Forest : Plot
{
    private float buildTime = 10;
    private float buildStartTime;
    private ResourceKeeper rk;
    private MatchTimer mt;
    public TextMeshPro progress;
    public static Material forestDefaultMaterial;

    private bool building;
    void Awake()
    {
        mt = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
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
            buildStartTime = mt.levelTimeInSeconds;
            building = true;
        }
        
    }
    private void BuildForest()
    {
        buildTime -= Time.deltaTime;
        buildTime = Mathf.Max(0, buildTime);
        progress.text = (buildTime.ToString("F2"));
        if (buildTime == 0.0)
          {
            progress.text = "Done";
            building = false;
          }
       
        
    }
}
