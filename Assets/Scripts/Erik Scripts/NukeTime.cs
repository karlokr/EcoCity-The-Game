using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// When a user clicks the "skull island" game object
/// five times, a nuke is launched, ending the game. This 
/// script instantiates the nuke object.
/// </summary>
public class NukeTime : MonoBehaviour
{
    public GameObject missile;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nukeTime()
    {
        GameObject nuke = Instantiate(missile, new Vector3(0,0,0) , transform.rotation);
        nuke.transform.Translate(Vector3.up * 200f);
    }
}
