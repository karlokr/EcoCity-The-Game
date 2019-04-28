using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KBuilding : MonoBehaviour
{
    public Material debugMaterial;
    public Material defaultMaterial;
    public Renderer rend;

    [Header("Building Attributes")]
    public int buildingCost;
    public int buildingLevel;
    public float emissionPerSecond = 0.1f;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    /// <summary>
    ///  Upgrades the buidling to emit less.
    /// </summary>
    /// <param name="emissionRatio">The ratio at which to multiply emissionPerSecond.</param>
    public void UpgradeBuilding(float emissionRatio)
    {
        buildingLevel++;
        emissionPerSecond /= emissionRatio;
    }

    public void Emit()
    {
        KMatchTimer matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<KMatchTimer>();
        matchTimer.emissionsFromBuildings += emissionPerSecond;
    }

    /// <summary>
    /// Debug function that sets the mesh color to magenta.
    /// </summary>
    public void ActivateDebugColor()
    {
        rend.material = debugMaterial;
        Building[] b = GameObject.FindObjectsOfType<Building>();
        foreach (Building obj in b)
        {
            if (obj != this)
            {
                obj.rend.material = defaultMaterial;
            }
        }


    }
}
