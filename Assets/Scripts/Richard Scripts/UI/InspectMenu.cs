using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectMenu : MonoBehaviour
{
    public Text nameText;
    public Text description;
    public Text moneyCost;
    public Text woodCost;
    public Text popCost;
    public Text stat1;
    public Text stat2;
    public Text stat3;

    public Image stat1Image;
    public Image stat2Image;
    public Image stat3Image;

    public Image woodCostIcon;
    public Image popCostIcon;

    public Sprite gold;
    public Sprite wood;
    public Sprite pop;
    public Sprite gem;
    public Sprite upgradeMaterial;
    public Sprite gray;
    public bool inspecting;

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();


    }

    // Start is called before the first frame update
    void Start()
    {
        gem = Resources.Load<Sprite>("Sprites/UI_Graphic_Resource_Gems");
        gold = Resources.Load<Sprite>("Sprites/UI_Graphic_Resource_Coins");
        wood = Resources.Load<Sprite>("Sprites/UI_Graphic_Resource_Wood");
        pop = Resources.Load<Sprite>("Sprites/UI_Graphic_Resource_Food");
        upgradeMaterial = Resources.Load<Sprite>("Sprites/UI_Graphic_Resource_Iron");
        gray = Resources.Load<Sprite>("Sprites/grey_panel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNameText(string s)
    {
        nameText.text = s;
    }

    public void SetDescriptionText(string s)
    {
        description.text = s;
    }

    public void SetInspecting(bool b)
    {
        animator.SetBool("Inspecting", b);
        inspecting = b;
    }

    public void SetStat1(string s)
    {
        stat1.text = s;
    }

    public void SetStat2(string s)
    {
        stat2.text = s;
    }

    public void SetStat3(string s)
    {
        stat3.text = s;
    }

    public void SetMoneyCost(string s)
    {
        moneyCost.text = s;
    }

    public void SetWoodCost(string s)
    {
        woodCost.text = s;
    }

    public void SetPopCost(string s)
    {
        popCost.text = s;
    }
    public void ClearPopCostIcon()
    {
        popCostIcon.sprite = gray;
        SetPopCost("");
    }
    public void SetUpgradeCostIcon()
    {
        woodCostIcon.sprite = upgradeMaterial;
    }

    public void ReceiveBuilding(GameObject g)
    {
        Building b = g.GetComponent<Building>();

        SetMoneyCost(b.cost.ToString());
        SetPopCost(b.populationRequired.ToString());
        SetWoodCost(b.woodCost.ToString());

        stat1Image.GetComponent<Image>().sprite = gem;
        SetStat1("+" + b.emission.ToString() + " EMISSION");

        if (b.buildingType == "Industrial")
        {
            SetStat2("+" + b.woodIncomeIncrease.ToString() + " WOOD INCOME");
            stat2Image.GetComponent<Image>().sprite = wood;

        }
        if (b.buildingType == "Commercial")
        {
            SetStat2("+" + b.incomeIncrease.ToString() + " INCOME");
            stat2Image.GetComponent<Image>().sprite = gold;
        }
        if (b.buildingType == "Residential")
        {
            SetStat2("+" + b.populationIncrease.ToString() + " POPULATION");
            stat2Image.GetComponent<Image>().sprite = pop;
        }
        SetStat3("");
    }
}
