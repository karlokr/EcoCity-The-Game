using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommercialBuilding : Building
{
    public override void Emit()
    {
        ResourceKeeper resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
        resourceKeeper.emission += emission;
        resourceKeeper.income += incomeIncrease;
    }
}
