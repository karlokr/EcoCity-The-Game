using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour
{
    public WorldTile prefabToBuild;
    private bool status;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createNewTile()
    {   


        WorldTile newTile = Instantiate(prefabToBuild, transform.position, transform.rotation);
        newTile.transform.SetParent(GameObject.FindGameObjectWithTag("TileHolder").transform);
        newTile.transform.Translate(Vector3.up * 7.125f);
        newTile.transform.Translate(Vector3.left * 7.4f);
        newTile.transform.Translate(Vector3.forward * 2.5f);
    }
}
