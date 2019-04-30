using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public PlotSize size;
    public enum PlotSize { Small, Medium, Large };

    public Material debugMaterial;
    public static Material defaultMaterial;
    public Renderer[] rends;

    private MatchTimer matchTimer;

    private void Awake()
    {
        rends = GetComponentsInChildren<Renderer>();
        defaultMaterial = GetComponentInChildren<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBuilding(GameObject prefabToBuild)
    {
        Building building = prefabToBuild.GetComponent<Building>();

        if (matchTimer.money < building.buildingCost)
        {
            Debug.Log("Not enough money");
        }
        if (matchTimer.wood < building.woodCost)
        {
            Debug.Log("Not Enough wood");
        }
        if (matchTimer.availiablePopulation < building.populationCost)
        {
            Debug.Log("Not enough people availiable to work");
        }

        else if (matchTimer.money >= building.buildingCost && matchTimer.wood >= building.woodCost && matchTimer.availiablePopulation >= building.populationCost)
        {
            Instantiate(prefabToBuild, transform.position, transform.rotation);
            matchTimer.money -= building.buildingCost;
            matchTimer.wood -= building.woodCost;
            Destroy(gameObject);
            building.Emit();
        }

    }


    /// <summary>
    /// Debug function that sets the mesh color to magenta.
    /// </summary>
    public void ActivateDebugColor()
    {
        foreach (Renderer r in rends)
        {
            r.material = debugMaterial;
        }
        
        Plot[] p = GameObject.FindObjectsOfType<Plot>();
        foreach (Plot obj in p)
        {
            if (obj != this)
            {
                foreach(Renderer r in obj.rends)
                {
                    r.material = defaultMaterial;
                }
            }
        }
    }

    public static void ClearDebugColor()
    {
        Plot[] p = GameObject.FindObjectsOfType<Plot>();
        foreach (Plot obj in p)
        {
            foreach (Renderer r in obj.rends)
            {
                r.material = defaultMaterial;
            }
        }
    }


}
