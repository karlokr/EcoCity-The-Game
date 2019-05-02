using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

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
    public int cost;
    public int woodCost;

    private Animator animator;
    public int populationRequired;
    public int emission;
    public ResourceKeeper resourceKeeper;

    private int level;
    private ParticleSystem particleSystem;

    //Category Specific Increases
    public int populationIncrease;
    public int woodIncomeIncrease;
    public int incomeIncrease;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
        rend = GetComponent<Renderer>();
        upgrades = GetComponentsInChildren<Upgrade>();
    }

    public void Start()
    {
        defaultMaterial = rend.material;
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
        if (resourceKeeper.money >= upgrades[index].cost && !upgrades[index].upgradeActive)
        {
            upgrades[index].Activate();
            resourceKeeper.money -= upgrades[index].cost;
            resourceKeeper.emission -= upgrades[index].emissionReduction;
            resourceKeeper.income += upgrades[index].incomeIncrease;
            resourceKeeper.woodIncome += upgrades[index].woodIncomeIncrease;
            resourceKeeper.population += upgrades[index].populationIncrease;
        }  
    }

    public void ShakeOnLand()
    {
        CameraShaker.Instance.ShakeOnce(4f, 2f, 0.0f, 0.5f);
        particleSystem.Play();
    }
}
