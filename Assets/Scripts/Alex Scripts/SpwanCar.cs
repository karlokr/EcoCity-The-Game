using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanCar : MonoBehaviour
{
    public GameObject car1 = null;
    public Transform start1;

    int interval = 3;
    float nextTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        // car1 = Instantiate(car1, start1.position, start1.rotation);
    }

    public void ResetCar1()
    {
        car1.transform.position = start1.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            //do something here every interval seconds
            Generate();
            nextTime += interval;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("hit trigger" + other);
        if (other.tag == "Collider")
        {
            Destroy(car1);
            Debug.Log("destroy");
            // car1.transform.position = GameObject.FindGameObjectWithTag("Start1").GetComponent<Transform>().position;
        }
    }

    public void Generate()
    {
        car1 = Instantiate(car1, start1.position, start1.rotation);
    }


}
