using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BuyTile : MonoBehaviour
{
    GameObject randomTile;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void handleClick(WorldTile selectedTile)
    {
        SelectRandomTile();
        Vector2 index = TileManager.findTile(selectedTile.gameObject);
        GameObject newTile = selectedTile.createNewTile(randomTile);
        TileManager.tiles[(int)index.x, (int)index.y] = newTile;
        TileManager.shownTiles[(int)index.x, (int)index.y] = true;
        TileManager.showTiles();
        Destroy(selectedTile.gameObject);
    }

    private void SelectRandomTile()
    {
        int randomNumber = Random.Range(0, 1);
#if UNITY_EDITOR
        randomTile = (GameObject) AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Kristian Prefab/WorldTile" + randomNumber, typeof(GameObject));
#endif
    }
}
