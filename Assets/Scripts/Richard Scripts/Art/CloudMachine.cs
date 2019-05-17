using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMachine : MonoBehaviour
{
    public GameObject[] possibleClouds;
    public float spawnInterval;
    public int spawnRadius;
    public int vertRadius;
    public float scaleFactor;

    private float timeLastSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeLastSpawn + spawnInterval)
        {
            timeLastSpawn = Time.time;
            int randIndex = Random.Range(0, possibleClouds.Length - 1);
            GameObject newCloud = Instantiate(possibleClouds[randIndex], transform.position + new Vector3(0, Random.Range(-vertRadius, vertRadius), Random.Range(-spawnRadius, spawnRadius)), transform.rotation);
            newCloud.transform.parent = transform;
            newCloud.transform.localScale = newCloud.transform.localScale * scaleFactor;
        }
    }
}
