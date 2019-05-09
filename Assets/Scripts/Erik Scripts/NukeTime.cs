using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
