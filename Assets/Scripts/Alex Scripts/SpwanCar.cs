using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanCar : MonoBehaviour
{
    // public GameObject car1 = null;
    public Transform start1;

    public GameObject[] spawnees;
    // GameObject myCar;

    int randomInt;

    int interval = 3;
    float nextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        // car1 = Instantiate(car1, start1.position, start1.rotation);
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

    public void Generate()
    {
        // int randIndex = Random.Range(0, models.Count - 1);

        // myModel = Instantiate(models[randIndex], start1.position, start1.rotation);

        // car1 = Instantiate(car1, start1.position, start1.rotation);
    }

    void SpawnRandom()
    {
        randomInt = Random.Range(0, spawnees.Length);
        GameObject myCar = Instantiate(spawnees[randomInt], start1.position, start1.rotation);
        myCar.transform.Rotate(0f, 180f, 0f);
    }


}
