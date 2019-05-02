using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceKeeper : MonoBehaviour
{
    //The Big 4
    public int money;
    public int emission;
    public int population;
    public int wood;
    public int ecoScore;
    //Accumulators
    public int income = 5;
    public int woodIncome = 5;

    // Start is called before the first frame update
    void Start()
    {
        population = 0;
        emission = 0;
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
}
