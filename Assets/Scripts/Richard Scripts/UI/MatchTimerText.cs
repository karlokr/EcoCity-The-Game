using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MatchTimerText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private MatchTimer matchTimer;


    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
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
