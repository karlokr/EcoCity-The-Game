using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Destroy Cars if it collides with same tag
/// </summary>
public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collider")
        {
            Destroy(gameObject);
        }
    }
}
