using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("boooom");
        GameObject nuke = Instantiate(explosion, new Vector3(0, 60, 0), transform.rotation);
        ResourceKeeper.emission = 5000;
    }
}
