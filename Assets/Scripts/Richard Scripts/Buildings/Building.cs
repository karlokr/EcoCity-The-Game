using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Material debugMaterial;
    public static Material defaultMaterial;
    public Renderer rend;
    public Upgrade[] upgrades;

    [Header("Building Attributes")]
    // How far should this building be moved up to land on the ground.
    public float verticalOffset;

    public string buildingType;
    public int buildingCost;
    public int woodCost;
    public int populationCost;
    public int totalEmission;
    public MatchTimer matchTimer;
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

    /// <summary>
    ///  Upgrades the buidling to emit less.
    /// </summary>
    /// <param name="emissionRatio">The ratio at which to multiply emissionPerSecond.</param>
    public void UpgradeBuilding(float emissionRatio)
    {

    }

    public virtual void Emit()
    {

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
        if (matchTimer.money >= upgrades[index].cost)
        {
            upgrades[index].Activate();
            matchTimer.money -= upgrades[index].cost;
            matchTimer.emission -= upgrades[index].emissionReduction;
        }  
    }
}
