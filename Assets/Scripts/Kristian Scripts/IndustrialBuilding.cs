using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialBuilding : Building
{


    public override void Emit()
    {
        ResourceKeeper resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
        resourceKeeper.emission += emission;
        resourceKeeper.woodIncome += woodIncomeIncrease;
    }
}
