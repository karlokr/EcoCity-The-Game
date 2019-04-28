using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPlot : MonoBehaviour
{
    KMatchTimer matchTimer;
    // Start is called before the first frame update
    void Start()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<KMatchTimer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateBuilding(GameObject prefabToBuild)
    {
        KBuilding building = prefabToBuild.GetComponent<KBuilding>();
        if (matchTimer.money >= building.buildingCost)
        {
            Instantiate(prefabToBuild, transform.position, transform.rotation);
            building.Emit();
            matchTimer.money -= building.buildingCost;
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not enough Money");
        }
    }
}
