using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ayylmao : MonoBehaviour
{
    private string welcomeMessage;
    private double testNumber;

    // Start is called before the first frame update
    void Start()
    {
        welcomeMessage = "Loaded boi";
        Debug.Log(welcomeMessage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        testNumber = 5.0d;
        Debug.Log(testNumber);
    }
}
