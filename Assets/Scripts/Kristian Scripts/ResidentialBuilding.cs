using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialBuilding : Building
{

    public override void Emit()
    {
        ResourceKeeper.emission += emission;
        ResourceKeeper.population += populationIncrease;
    }
}
