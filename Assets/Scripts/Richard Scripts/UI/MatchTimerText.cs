using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchTimerText : MonoBehaviour
{
    private Text text;
    private MatchTimer matchTimer;
    private Text population;
    private Text money;
    private Text emission;
    private Text wood;

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
        {
            text.text = matchTimer.currentMonth.ToString() + " " + matchTimer.currentYear;
        }
    }
}
