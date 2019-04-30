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
    public int buildingCost;
    public int population;
    public int woodCost;

    public float totalEmission;

    private Animator animator;
    private MatchTimer matchTimer;
    private int buildingLevel;
    private ParticleSystem particleSystem;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        rend = GetComponent<Renderer>();
        upgrades = GetComponentsInChildren<Upgrade>();
    }

    private void Start()
    {
        defaultMaterial = rend.material;
        StartCoroutine(StaggerLand());
    }

    IEnumerator StaggerLand()
    {
        float waitTime = Random.Range(0.0f, 3f);
        yield return new WaitForSeconds(waitTime);
        animator.SetTrigger("Land");
    }

    /// <summary>
    ///  Upgrades the buidling to emit less.
    /// </summary>
    /// <param name="emissionRatio">The ratio at which to multiply emissionPerSecond.</param>
    public void UpgradeBuilding(float emissionRatio)
    {
        buildingLevel++;
        totalEmission /= emissionRatio;
    }

    public void Emit()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        matchTimer.emission += totalEmission;
        matchTimer.population += population;
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

    public void ShakeOnLand()
    {
        CameraShaker.Instance.ShakeOnce(4f, 2f, 0.0f, 0.5f);
        particleSystem.Play();
    }
}
