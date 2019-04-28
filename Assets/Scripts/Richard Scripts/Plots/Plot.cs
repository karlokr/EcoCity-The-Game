using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public PlotSize size;
    public enum PlotSize { Small, Medium, Large };
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
        Instantiate(prefabToBuild, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
