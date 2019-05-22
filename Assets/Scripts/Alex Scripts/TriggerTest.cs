using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    // Destroy Cars if it collides with same tag
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collider")
        {
            Destroy(gameObject);
        }
    }
}
