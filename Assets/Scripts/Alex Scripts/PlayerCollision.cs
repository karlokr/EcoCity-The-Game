
using UnityEngine;
/// <summary>
/// Collision Script for cars,
/// Destroying Cars when it collides objects.
/// </summary>
public class PlayerCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Collision Testing Script

        // Debug.Log("hit trigger" + other);
        if (other.tag == "Collider")
        {

            // other.GetComponent<Transform>().position = GetComponentInParent<Transform>().position;
            
        }
    }
}
