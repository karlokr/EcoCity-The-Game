﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public PlotSize size;
    public enum PlotSize { Small, Medium, Large };

    public Material debugMaterial;
    public static Material defaultMaterial;
    public Renderer[] rends;
    

    private MatchTimer matchTimer;

    private void Awake()
    {
        rends = GetComponentsInChildren<Renderer>();
        defaultMaterial = GetComponentInChildren<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBuilding(GameObject prefabToBuild)
    {
        Building building = prefabToBuild.GetComponent<Building>();
        if (matchTimer.money >= building.buildingCost && matchTimer.wood >= building.woodCost)
        {
            GameObject newBuilding = Instantiate(prefabToBuild, transform.position, transform.rotation);
            newBuilding.transform.Translate(Vector3.up * 35f);
            building.Emit();
            matchTimer.money -= building.buildingCost;
            matchTimer.wood -= building.woodCost;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }


    /// <summary>
    /// Debug function that sets the mesh color to magenta.
    /// </summary>
    public void ActivateDebugColor()
    {
        foreach (Renderer r in rends)
        {
            r.material = debugMaterial;
        }
        
        Plot[] p = GameObject.FindObjectsOfType<Plot>();
        foreach (Plot obj in p)
        {
            if (obj != this)
            {
                foreach(Renderer r in obj.rends)
                {
                    r.material = defaultMaterial;
                }
            }
        }
    }

    public static void ClearDebugColor()
    {
        Plot[] p = GameObject.FindObjectsOfType<Plot>();
        foreach (Plot obj in p)
        {
            foreach (Renderer r in obj.rends)
            {
                r.material = defaultMaterial;
            }
        }
    }


}
