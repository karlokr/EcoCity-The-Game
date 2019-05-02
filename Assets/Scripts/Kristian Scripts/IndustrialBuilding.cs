using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialBuilding : Building
{
    public int woodIncomeIncrease;

    public override void Emit()
    {
        resourceKeeper.emission += emission;
        resourceKeeper.woodIncome += woodIncomeIncrease;
    }
}
