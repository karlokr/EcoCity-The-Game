using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public int speedLowerBound;
    public int speedUpperBound;
    public int lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        int randSpeed = Random.Range(speedLowerBound, speedUpperBound);
        transform.Translate(Vector3.forward * randSpeed * Time.deltaTime);
    }
}
