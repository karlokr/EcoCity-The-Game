using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Material debugMaterial;
    public static Material defaultMaterial;
    public Renderer rend;
    public Upgrade[] upgrades;

    private int buildingLevel;
    private float emissionPerSecond;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        upgrades = GetComponentsInChildren<Upgrade>();
    }

    private void Start()
    {
        defaultMaterial = rend.material;
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
}
