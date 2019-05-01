using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResidentialBuilding : Building
{
    public int population;

    public override void Emit()
    {
        resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
        resourceKeeper.emission += totalEmission;
        resourceKeeper.population += population;
        resourceKeeper.availablePopulation += population;
    }
}
