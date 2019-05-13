using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePicker : MonoBehaviour
{
    public List<GameObject> tileList;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public GameObject PickTile()
    {
        int randIndex = Random.Range(0, tileList.Count - 1);
        GameObject myTile = Instantiate(tileList[randIndex], transform.parent.position, transform.parent.rotation, transform.parent);
        return myTile;
    }
}
