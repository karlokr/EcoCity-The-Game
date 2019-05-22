using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanCar : MonoBehaviour
{
    // Starting point of the car
    public Transform start1;

    // List of Cars
    public GameObject[] spawnees;

    int randomInt;
    int interval = 3;
    float nextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            interval = Random.Range(4,9);

            //do something here every interval seconds
            SpawnRandom();
            nextTime += interval;
        }
        
    }

    // Spawn random Cars in random time
    void SpawnRandom()
    {
        randomInt = Random.Range(0, spawnees.Length);
        GameObject myCar = Instantiate(spawnees[randomInt], start1.position, start1.rotation);
        myCar.transform.parent = transform;
        myCar.transform.Rotate(0f, 180f, 0f);
    }


}
