using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public PlotSize size;
    public enum PlotSize { Small, Medium, Large };

    public Material debugMaterial;
    public static Material defaultMaterial;
    public Animator animator;

    private ResourceKeeper resourceKeeper;
    

    private void Awake()
    {
        animator = GetComponent<Animator>();
        resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
    }

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBuilding(GameObject prefabToBuild)
    {
        Building building = prefabToBuild.GetComponent<Building>();

        if (resourceKeeper.money < building.cost)
        {
            Debug.Log("Not enough money");
        }
        if (resourceKeeper.wood < building.woodCost)
        {
            Debug.Log("Not Enough wood");
        }
        if (resourceKeeper.population < building.populationRequired)
        {
            Debug.Log("Not enough population to build this building");
        }

        else if (resourceKeeper.money >= building.cost && resourceKeeper.wood >= building.woodCost && resourceKeeper.population >= building.populationRequired)
        {

            GameObject newBuilding = Instantiate(prefabToBuild, transform.position, transform.rotation);
            int randRotFactor = Random.Range(0, 3);
            newBuilding.transform.Rotate(Vector3.up * (90f * randRotFactor));
            newBuilding.transform.SetParent(GameObject.FindGameObjectWithTag("WorldTile").transform);
            newBuilding.transform.Translate(Vector3.up * 35f);
            resourceKeeper.money -= building.cost;
            resourceKeeper.wood -= building.woodCost;
            Destroy(gameObject);
            building.Emit();
        }

    }


    /// <summary>
    /// Debug function that sets the mesh color to magenta.
    /// </summary>
    public void FocusOnPlot()
    {
        // UnfocusAllPlots();
        animator.SetBool("Focused", true);
    }


    public static void UnfocusAllPlots()
    {
        Plot[] p = GameObject.FindObjectsOfType<Plot>();
        foreach (Plot obj in p)
        {
            obj.animator.SetBool("Focused", false);
        }
    }

    


}
