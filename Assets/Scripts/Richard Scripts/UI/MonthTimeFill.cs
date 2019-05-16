using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonthTimeFill : MonoBehaviour
{
    private Image image;
    private MatchTimer matchTimer;
    private float timePerMonth;
    private bool filling;

    private void Awake()
    {
        image = GetComponent<Image>();
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        filling = true;
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = (matchTimer.GetMonthTimer() / matchTimer.GetTimePerMonth());
    }
}
