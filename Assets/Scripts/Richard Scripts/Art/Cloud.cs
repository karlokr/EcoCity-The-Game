using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public int speedLowerBound;
    public int speedUpperBound;
    public int lifeTime;
    public int verticalDisplacement;

    private float initialDisplace;

    // Start is called before the first frame update
    void Start()
    {
        initialDisplace = Random.Range(0, 2 * Mathf.PI);
        verticalDisplacement = Random.Range(0, 5);
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        int randSpeed = Random.Range(speedLowerBound, speedUpperBound);
        transform.Translate(Vector3.forward * randSpeed * Time.deltaTime);
        transform.Translate(Vector3.up * Mathf.Sin(Time.time + initialDisplace) * verticalDisplacement * Time.deltaTime);
    }
}
