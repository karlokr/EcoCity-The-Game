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
    private int level;
    public ParticleSystem landingParticleSystem;
    public ParticleSystem popParticleSystem;
    public ParticleSystem moneyParticleSystem;
    public ParticleSystem woodParticleSystem;

    //Category Specific Increases
    public int populationIncrease;
    public int woodIncomeIncrease;
    public int incomeIncrease;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
    public void FocusOnBuilding()
    {
        animator.SetBool("Inspecting", true);
    }

    public static void UnfocusAllBuildings()
    {
        Building[] b = GameObject.FindObjectsOfType<Building>();
        foreach (Building obj in b)
        {
            obj.animator.SetBool("Inspecting", false);
        }
    }

    public void ActivateUpgrade(int index)
    {
        if (ResourceKeeper.money >= upgrades[index].cost && !upgrades[index].upgradeActive)
        {
            upgrades[index].Activate();
            ResourceKeeper.money -= upgrades[index].cost;
            ResourceKeeper.emission -= upgrades[index].emissionReduction;
            ResourceKeeper.income += upgrades[index].incomeIncrease;
            ResourceKeeper.woodIncome += upgrades[index].woodIncomeIncrease;
            ResourceKeeper.population += upgrades[index].populationIncrease;
        }  
    }

    public void ShakeOnLand()
    {
        CameraShaker.Instance.ShakeOnce(4f, 2f, 0.0f, 0.5f);
        landingParticleSystem.Play();
        EmitResources(populationIncrease, incomeIncrease, woodIncomeIncrease);
    }

    public void EmitResources(int pop, int credits, int wood)
    {
        popParticleSystem.Emit(pop);
        woodParticleSystem.Emit(wood);
        moneyParticleSystem.Emit(credits);
        
    }
}
