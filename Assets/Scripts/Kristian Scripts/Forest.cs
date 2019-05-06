using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Forest : Plot
{
    private float buildTime = .5f;
    private ResourceKeeper rk;
    private MatchTimer mt;
    public TextMeshPro progress;
    public static Material forestDefaultMaterial;

    public Plot prefabToBuild;

    private bool building;
    public bool finished;
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
        Destroy(gameObject);
    }
}
