using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour
{
    public List<GameObject> tileList;
    //public GameObject prefabToBuild;
    public bool purchased;
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
        int randIndex = Random.Range(0, tileList.Count);
        GameObject myTile = SimplePool.Spawn(tileList[randIndex], transform.position, transform.rotation);
        myTile.GetComponent<WorldTile>().purchased = true;
        myTile.transform.Translate(Vector3.down * 12f);
        //myTile.transform.SetParent(GameObject.FindGameObjectWithTag("TileHolder").transform);
        return myTile;
    }
}
