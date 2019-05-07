using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialBuilding : Building
{
    public override void Emit()
    {
        ResourceKeeper.emission += emission;
        ResourceKeeper.income += incomeIncrease;
    }
}
