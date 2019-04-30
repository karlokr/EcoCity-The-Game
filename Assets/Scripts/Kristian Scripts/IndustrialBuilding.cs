using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialBuilding : Building
{
    public int woodIncomeBonus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Emit()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        matchTimer.emission += totalEmission;
        matchTimer.woodIncome += woodIncomeBonus;
        matchTimer.availiablePopulation -= populationCost;
    }
}
