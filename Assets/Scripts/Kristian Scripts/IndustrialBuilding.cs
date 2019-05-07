using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndustrialBuilding : Building
{


    public override void Emit()
    {
        ResourceKeeper.emission += emission;
        ResourceKeeper.woodIncome += woodIncomeIncrease;
    }
}
