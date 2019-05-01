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
    private ResourceKeeper resourceKeeper;
    private int buildingLevel;

    private void Awake()
    {
        resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
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
        resourceKeeper.emission += totalEmission;
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
        if (resourceKeeper.money >= upgrades[index].cost)
        {
            upgrades[index].Activate();
            resourceKeeper.money -= upgrades[index].cost;
            resourceKeeper.emission -= upgrades[index].emissionReduction;
        }  
    }
}
