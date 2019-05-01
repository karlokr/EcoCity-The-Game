using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceKeeperText : MonoBehaviour
{
    private Text population;
    private Text money;
    private Text emission;
    private Text wood;
    private ResourceKeeper resourceKeeper;
    private MatchTimer matchTimer;

    private void Awake()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
        money = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();
        emission = GameObject.FindGameObjectWithTag("Emission").GetComponent<Text>();
        population = GameObject.FindGameObjectWithTag("Population").GetComponent<Text>();
        wood = GameObject.FindGameObjectWithTag("Wood").GetComponent<Text>();
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
            money.text = resourceKeeper.money.ToString();
            emission.text = resourceKeeper.emission.ToString();
            population.text = resourceKeeper.availablePopulation.ToString() + "/" + resourceKeeper.population.ToString();
            wood.text = resourceKeeper.wood.ToString();
        }
    }
}
