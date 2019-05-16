using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Collider")
        {
            Destroy(gameObject);
            Debug.Log("destroy!!!!!!!!!!!!! " + gameObject);
        }
    }
}
