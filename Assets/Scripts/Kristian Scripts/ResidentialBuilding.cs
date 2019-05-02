using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialBuilding : Building
{
    public int populationIncrease;

    public override void Emit()
    {
        resourceKeeper.emission += emission;
        resourceKeeper.population += populationIncrease;
    }
}
