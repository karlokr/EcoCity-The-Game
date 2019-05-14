using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Michsky.UI.ModernUIPack;

public class WinConditions : MonoBehaviour
{
    public float populationRequirement;
    public float emissionLimit;
    public int yearRequirement;

    [Header("UI")]
    public float barLerpSpeed = 15f;
   
    private MatchTimer matchTimer;
    private ProgressBar emissionBar;
    private ProgressBar populationBar;

    private void Awake()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        emissionBar = GameObject.FindGameObjectWithTag("EmissionsBar").GetComponent<ProgressBar>();
        populationBar = GameObject.FindGameObjectWithTag("PopulationBar").GetComponent<ProgressBar>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (matchTimer.currentYear >= yearRequirement)
        {
            if (CheckWin())
            {
                SceneManager.LoadScene("win_screen");
            }
            else
            {
                SceneManager.LoadScene("lose_screen");
            }
        } else if (CheckWin())
        {
            SceneManager.LoadScene("win_screen");
        }

        emissionBar.currentPercent = Mathf.Lerp(emissionBar.currentPercent, (ResourceKeeper.emission / emissionLimit) * 100f, barLerpSpeed * Time.deltaTime);
        emissionBar.currentPercent = Mathf.Clamp(emissionBar.currentPercent, 0, 100);

        populationBar.currentPercent = Mathf.Lerp(populationBar.currentPercent, (ResourceKeeper.population / populationRequirement) * 100f, barLerpSpeed * Time.deltaTime);
        
    }


    public bool CheckWin()
    {
        if (ResourceKeeper.population > populationRequirement && ResourceKeeper.emission < emissionLimit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
