using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public Button[] upgradeOptions;
    private Building selectedBuilding;
    public InspectMenu inspectMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            
        }
    }

    public void PopulateList(Upgrade[] upgrades)
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
           upgradeOptions[i].GetComponentInChildren<Text>().text = upgrades[i].upgradeName;
        }
    }

    public void SetSelectedBuilding(Building b)
    {
        selectedBuilding = b;
    }

    public void ClearSelected()
    {
        selectedBuilding = null;
    }

    public void PassUpgrade(int index)
    {
        selectedBuilding.ActivateUpgrade(index);
    }

    public void UpdateInspectMenu(int i)
    {
        Upgrade upgrade = selectedBuilding.upgrades[i];
        inspectMenu.SetMoneyCost(upgrade.cost.ToString());
        inspectMenu.SetNameText(upgrade.name);
        inspectMenu.SetDescriptionText(upgrade.description);
        inspectMenu.SetWoodCost("0");
        inspectMenu.SetPopCost("0");
        inspectMenu.SetStat2("-" + upgrade.emissionReduction.ToString() + " EMISSION");
        inspectMenu.stat2Image.GetComponent<Image>().sprite = inspectMenu.gem;

        if (selectedBuilding.buildingType == "Residential")
        {
            inspectMenu.SetStat1("+" + upgrade.populationIncrease.ToString() + " POP");
            inspectMenu.stat1Image.GetComponent<Image>().sprite = inspectMenu.pop;
        }
        
        if(selectedBuilding.buildingType == "Commercial")
        {
            inspectMenu.SetStat1("+" + upgrade.incomeIncrease.ToString() + " INCOME");
            inspectMenu.stat1Image.GetComponent<Image>().sprite = inspectMenu.gold;
        }

        if (selectedBuilding.buildingType == "Industrial")
        {
            inspectMenu.SetStat1("+" + upgrade.woodIncomeIncrease.ToString() + " WOOD INCOME");
            inspectMenu.stat1Image.GetComponent<Image>().sprite = inspectMenu.wood;
        }
        
    }
}
