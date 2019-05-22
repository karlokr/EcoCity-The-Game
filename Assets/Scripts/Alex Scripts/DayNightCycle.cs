using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Sun rotating 
        transform.RotateAround(Vector3.zero, (Vector3.back + 0.5f * Vector3.left), 50f * Time.deltaTime);
        transform.LookAt(Vector3.zero);
    }
}
