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
        GameObject newTile = PickTile();
        newTile.GetComponent<WorldTile>().purchased = true;
        newTile.transform.Translate(Vector3.down * 12f);
        newTile.transform.SetParent(GameObject.FindGameObjectWithTag("TileHolder").transform);
        return newTile;
    }

    public GameObject PickTile()
    {
        int randIndex = Random.Range(0, tileList.Count);
        GameObject myTile = Instantiate(tileList[randIndex], transform.position, transform.rotation, transform.parent);
        return myTile;
    }
}
