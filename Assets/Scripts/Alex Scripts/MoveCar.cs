using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Direction and speed of the car
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime * 10);
    }
}
