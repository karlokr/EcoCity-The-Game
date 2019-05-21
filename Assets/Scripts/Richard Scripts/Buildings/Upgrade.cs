using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string upgradeName;
    public int cost;
    public int woodCost;
    public int emissionReduction;
    public int incomeIncrease;
    public int populationIncrease;
    public int woodIncomeIncrease;
    public Renderer visualModel;
    public bool upgradeActive;
    public int upgradeMaterialCost;
    public string description;

    private void Awake()
    {
        visualModel = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        upgradeActive = false; 
        if (!upgradeActive)
        {
            visualModel.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate() {
        if (visualModel)
        {
            visualModel.enabled = true;
            upgradeActive = true;
        }
    }
}
