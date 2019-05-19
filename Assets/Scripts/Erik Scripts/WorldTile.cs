using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTile : MonoBehaviour
{
    public List<GameObject> tileList;
    //public GameObject prefabToBuild;
    public bool purchased;
    public Animator animator;
    public string title = "Expand The World";
    public string description = "Purchase another world tile to continue growing your city!";
    public int woodCost = 1000;
    public int moneyCost = 0;
    public int popCost = 0;
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
    public GameObject createNewTile()
    {   
        int randIndex = Random.Range(0, tileList.Count);
        GameObject myTile = SimplePool.Spawn(tileList[randIndex], transform.position, transform.rotation);
        myTile.GetComponent<WorldTile>().purchased = true;
        myTile.transform.Translate(Vector3.down * 12f);
        myTile.transform.SetParent(GameObject.FindGameObjectWithTag("TileHolder").transform);
        return myTile;
    }
    /// <summary>
    /// Debug function that sets the mesh color to magenta.
    /// </summary>


    public static void UnfocusAllTiles()
    {
        WorldTile[] p = GameObject.FindObjectsOfType<WorldTile>();
        foreach (WorldTile obj in p)
        {
            obj.animator.SetBool("Focused", false);
        }
    }
}
