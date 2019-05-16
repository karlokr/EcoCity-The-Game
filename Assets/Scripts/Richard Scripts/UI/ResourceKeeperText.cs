using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ResourceKeeperText : MonoBehaviour
{
    private TextMeshProUGUI population;
    private TextMeshProUGUI money;
    private TextMeshProUGUI emission;
    private TextMeshProUGUI wood;
    private TextMeshProUGUI upgradeMaterial;
    private MatchTimer matchTimer;

    private TextMeshProUGUI woodPerMonth;
    private TextMeshProUGUI moneyPerMonth;

    private void Awake()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        money = GameObject.FindGameObjectWithTag("Money").GetComponent<TextMeshProUGUI>();
        emission = GameObject.FindGameObjectWithTag("Emission").GetComponent<TextMeshProUGUI>();
        population = GameObject.FindGameObjectWithTag("Population").GetComponent<TextMeshProUGUI>();
        wood = GameObject.FindGameObjectWithTag("Wood").GetComponent<TextMeshProUGUI>();
        upgradeMaterial = GameObject.FindGameObjectWithTag("UpgradeMaterial").GetComponent<TextMeshProUGUI>();

        woodPerMonth = GameObject.FindGameObjectWithTag("WoodPerMonth").GetComponent<TextMeshProUGUI>();
        moneyPerMonth = GameObject.FindGameObjectWithTag("MoneyPerMonth").GetComponent<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (matchTimer.matchStarted)
        {
            money.text = ResourceKeeper.money.ToString();
            emission.text = ResourceKeeper.emission.ToString() + " CO2 ppm";
            population.text = ResourceKeeper.population.ToString();
            wood.text = ResourceKeeper.wood.ToString();
            upgradeMaterial.text = ResourceKeeper.upgradeMaterial.ToString();

            woodPerMonth.text = "+" + ResourceKeeper.woodIncome.ToString();
            moneyPerMonth.text = "+" + ResourceKeeper.income.ToString();
        }
    }
}
