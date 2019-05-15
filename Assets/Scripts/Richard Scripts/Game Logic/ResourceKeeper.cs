using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceKeeper : MonoBehaviour
{
    GameObject[] buildingList;
    //The Big 4
    public static int money = 10000;
    public static int emission = 0;
    public static int population = 0;
    public static int wood = 1000;
    public static int ecoScore = 0;
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
    } 
    //public void emitMonthy()
    //{
    //    buildingList = GameObject.FindGameObjectsWithTag("Building");
    //    foreach (GameObject building in buildingList)
    //    {
    //        Building buildingType = building.GetComponent<Building>();
    //        buildingType.ResourcePop(buildingType);
    //    }
    //    }

    }
