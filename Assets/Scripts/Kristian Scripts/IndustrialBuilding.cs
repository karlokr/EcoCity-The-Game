using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialBuilding : Building
{
    public int woodIncomeBonus;

    public override void Emit()
    {
        resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
        resourceKeeper.emission += totalEmission;
        resourceKeeper.woodIncome += woodIncomeBonus;
        resourceKeeper.availablePopulation -= populationCost;
    }
}
