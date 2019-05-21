using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinText : MonoBehaviour
{

    private WinConditions winConditions;
    private TextMeshProUGUI conditionsPara;
    private void Awake()
    {
        winConditions = GameObject.FindGameObjectWithTag("WinConditions").GetComponent<WinConditions>();
        conditionsPara = GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        conditionsPara.text = "- REACH POPULATION " + winConditions.populationRequirement + "\n";
        conditionsPara.text = conditionsPara.text + "- ZERO EMISSION BY " + winConditions.yearRequirement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
