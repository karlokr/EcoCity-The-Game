﻿
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("hit trigger" + other);
        if (other.tag == "Collider")
        {
            Debug.Log("Hello collider");

            // other.GetComponent<Transform>().position = GetComponentInParent<Transform>().position;
            
        }
    }
}
