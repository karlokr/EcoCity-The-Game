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

    private void Awake()
    {
        text = GetComponent<Text>();
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        money = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
        emission = GameObject.FindGameObjectWithTag("Emission").GetComponent<Text>();
        population = GameObject.FindGameObjectWithTag("Population").GetComponent<Text>();
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
            text.text = matchTimer.currentMonth.ToString() + " " + matchTimer.currentYear;

        money.text = matchTimer.money.ToString();
        emission.text = matchTimer.emission.ToString();
        population.text = matchTimer.population.ToString();
    }
}
