﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceKeeper : MonoBehaviour
{
    public Upgrade[] upgrades;
    public Renderer visualModel;
    
    //The Big 4
    public static int money = 150;
    public static int emission = 0;
    public static int population = 0;
    public static int wood = 150;
    public static int ecoScore = 0;
    public static int buildingSizeTotal;
    public static int upgradeMaterial = 0;
    //Accumulators
    public static int income = 5;
    public static int woodIncome = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyMonthlyNumbers()
    {
        money += income;
        wood += woodIncome;
        ecoScore = buildingSizeTotal - emission;
        emitMonthly();
       // Debug.Log(ecoScore);
    }
    public void emitMonthly()
    {
        Building[] buildingList;
        buildingList = GameObject.FindObjectsOfType<Building>();

        for(int i = 0; i < buildingList.Length; i++)
        {
            switch (buildingList[i].buildingType)
            {
                case "Industrial":
                    buildingList[i].EmitResources(0, 0, 1);
                    break;
                case "Residential":
                    buildingList[i].EmitResources(1, 0, 0);
                    break;
                case "Commercial":
                    buildingList[i].EmitResources(0, 1, 0);
                    break;
                default:
                    break;
            }

        }
    }
    public void ResetResourceKeeper()
    {
        money = 150;
        emission = 0;
        population = 0;
        wood = 150;
        ecoScore = 0;
        buildingSizeTotal = 0;
        upgradeMaterial = 0;
        income = 5;
        woodIncome = 5;

    }

}
