using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingIndustrial : MonoBehaviour
{
    public Material debugMaterial;
    public static Material defaultMaterial;
    public Renderer rend;
    public Upgrade[] upgrades;

    [Header("Building Attributes")]
    // How far should this building be moved up to land on the ground.
    public float verticalOffset;
    public int buildingCost;
    public int woodCost;

    public int totalEmission;
    private MatchTimer matchTimer;
    private int buildingLevel;

    private void Awake()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        rend = GetComponent<Renderer>();
        upgrades = GetComponentsInChildren<Upgrade>();
    }

    private void Start()
    {
        defaultMaterial = rend.material;
        transform.Translate(Vector3.up * verticalOffset);
    }
    
    public void UpgradeBuilding(float emissionRatio)
    {
        
    }

    public void Emit()
    {
        ResourceKeeper.emission += totalEmission;
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

    public static void ClearDebugColor()
    {
        Building[] b = GameObject.FindObjectsOfType<Building>();
        foreach (Building obj in b)
        {
            obj.rend.material = defaultMaterial;
        }
    }

    public void ActivateUpgrade(int index)
    {
        if (ResourceKeeper.money >= upgrades[index].cost)
        {
            upgrades[index].Activate();
            ResourceKeeper.money -= upgrades[index].cost;
            ResourceKeeper.emission -= upgrades[index].emissionReduction;
        }  
    }
}
