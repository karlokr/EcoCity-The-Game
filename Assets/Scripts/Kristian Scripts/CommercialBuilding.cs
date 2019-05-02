using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialBuilding : Building
{
    public int incomeBonus;

    public override void Emit()
    {
        resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
        resourceKeeper.emission += totalEmission;
        resourceKeeper.income += incomeBonus;
    }
}
