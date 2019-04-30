using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchTimer : MonoBehaviour
{
    [Header("Gameplay Attributes")]
    public float levelTimeInSeconds;
    public int startYear;
    public int endYear;
    public bool matchStarted;


    [Header("Accessible Data")]
    public Month currentMonth;
    public int currentYear;

    private int levelTimeInMonths;
    private float timePerMonth;
    private float timePerYear;
    private float monthTimer;
    private float yearTimer;

    [Header("Player Resources")]
    public int money;
    public int income = 5;

    public int emission = 0;
    public int population;

    public int availiablePopulation;
    public int wood;
    public int woodIncome = 5;

    public enum Month {JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC};

    void Start()
    {
        population = 0;
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
            // Increase money, wood, metal, electricity every month

            money += income;            
            wood += woodIncome;

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

    public void StartMatch()
    {
        matchStarted = true;
    }


}
