using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTimer : MonoBehaviour
{
    public float levelTimeInSeconds;
    public bool matchStarted;


    // Start is called before the first frame update
    void Start()
    {
        matchStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (matchStarted)
            levelTimeInSeconds -= Time.deltaTime;
    }

    public void StartMatch()
    {
        matchStarted = true;
    }


}
