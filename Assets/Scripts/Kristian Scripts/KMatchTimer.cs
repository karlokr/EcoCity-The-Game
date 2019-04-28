using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KMatchTimer : MonoBehaviour
{
    [Header("Gameplay Attributes")]
    public float levelTimeInSeconds;
    public int startYear;
    public int endYear;
    public bool matchStarted;

    //Player resources
    public float money;
    public float emission = 0;

    [Header("Accessible Data")]
    public Month currentMonth;
    public int currentYear;

    private int levelTimeInMonths;
    private float timePerMonth;
    private float timePerYear;
    private float monthTimer;
    private float yearTimer;

    [Header("Player Resources")]
    //Money per month
    public float income = 10f;

    //Emission per month
    public float emissionsFromBuildings = 0f;
    public enum Month { JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC };

    void Start()
    {

        timePerYear = levelTimeInSeconds / (endYear - startYear);
        timePerMonth = timePerYear / 12;
        currentYear = startYear;
        levelTimeInMonths = 0;

        matchStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (matchStarted)
        {
            levelTimeInSeconds -= Time.deltaTime;
            monthTimer += Time.deltaTime;
            yearTimer += Time.deltaTime;
        }

        if (monthTimer > timePerMonth)
        {
            levelTimeInMonths++;

            //Increase money every month
            money += income;
            emission += emissionsFromBuildings;

            if (levelTimeInMonths > 11)
            {
                currentYear++;
                levelTimeInMonths = 0;
                currentMonth = (Month)levelTimeInMonths;
                monthTimer = 0;
            }
            else
            {
                currentMonth = (Month)levelTimeInMonths;
                monthTimer = 0;
            }


        }
    }

    //Iterates over all GameObjects with tag "Building" and sums their emissions.
    private float getEmissionTotal()
    {
        float totalEmission = 0;
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        foreach (GameObject building in buildings)
        {
            totalEmission += building.GetComponent<KBuilding>().emissionPerSecond;
        }
        return totalEmission;
    }

    public void StartMatch()
    {
        matchStarted = true;
    }


}
