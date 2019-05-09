using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour
{
    public GameObject prefabToBuild;
    private bool status;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject createNewTile()
    {   


        GameObject newTile = Instantiate(prefabToBuild, transform.position, transform.rotation);
        newTile.transform.Translate(Vector3.down * 12f);
        newTile.transform.SetParent(GameObject.FindGameObjectWithTag("TileHolder").transform);
        return newTile;
    }
}
