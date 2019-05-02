using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialBuilding : Building
{
    public int incomeIncrease;

    public override void Emit()
    {
        resourceKeeper.emission += emission;
        resourceKeeper.income += incomeIncrease;
    }
}
