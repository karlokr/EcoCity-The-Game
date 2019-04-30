using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialBuilding : Building
{
    public int woodIncomeBonus;

    public override void Emit()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        matchTimer.emission += totalEmission;
        matchTimer.woodIncome += woodIncomeBonus;
        matchTimer.availiablePopulation -= populationCost;
    }
}
