using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls the logic of tile generation and purchases.
/// </summary>
public class WorldTile : MonoBehaviour
{
    public List<GameObject> tileList;
    //public GameObject prefabToBuild;
    public bool purchased;
    public Animator animator;
    public string title = "Expand The World";
    public string description = "Purchase another world tile to continue growing your city!";
    public int woodCost = 250;
    public int moneyCost = 500;
    public int popCost = 50;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {     
    }

    // Creates a new random tile from a pool of tile game objects.
    public GameObject createNewTile()
    {   
        int randIndex = Random.Range(0, tileList.Count);
        GameObject myTile = SimplePool.Spawn(tileList[randIndex], transform.position, transform.rotation);
        myTile.GetComponent<WorldTile>().purchased = true;
        myTile.transform.Translate(Vector3.down * 12f);
        myTile.transform.SetParent(GameObject.FindGameObjectWithTag("TileHolder").transform);
        return myTile;
    }

    // Deselects all tiles after a new tile is purchased.
    public static void UnfocusAllTiles()
    {
        WorldTile[] p = GameObject.FindObjectsOfType<WorldTile>();
        foreach (WorldTile obj in p)
        {
            obj.animator.SetBool("Focused", false);
        }
    }
}
