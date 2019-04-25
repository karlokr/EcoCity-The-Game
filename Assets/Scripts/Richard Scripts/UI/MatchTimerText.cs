using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchTimerText : MonoBehaviour
{
    private Text text;
    private MatchTimer matchTimer;

    private void Awake()
    {
        text = GetComponent<Text>();
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (matchTimer.matchStarted)
            text.text = "Time Left: " + (int)matchTimer.levelTimeInSeconds + "s";
    }
}
