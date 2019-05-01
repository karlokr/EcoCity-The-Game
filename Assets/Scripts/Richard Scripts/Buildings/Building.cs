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
    public int buildingCost;
    public int woodCost;

    private Animator animator;
    public int populationCost;
    public int totalEmission;
    public ResourceKeeper resourceKeeper;

    private int buildingLevel;
    private ParticleSystem particleSystem;

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
        animator.SetTrigger("Land");
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
        if (resourceKeeper.money >= upgrades[index].cost)
        {
            upgrades[index].Activate();
            resourceKeeper.money -= upgrades[index].cost;
            resourceKeeper.emission -= upgrades[index].emissionReduction;
        }  
    }

    public void ShakeOnLand()
    {
        CameraShaker.Instance.ShakeOnce(4f, 2f, 0.0f, 0.5f);
        particleSystem.Play();
    }
}
