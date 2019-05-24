using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
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

    private PostProcessVolume ppv;
    private ColorGrading colorGrade = null;

    private bool saved = false;

    private SaveGame saveGame;

    private void Awake()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        emissionBar = GameObject.FindGameObjectWithTag("EmissionsBar").GetComponent<ProgressBar>();
        populationBar = GameObject.FindGameObjectWithTag("PopulationBar").GetComponent<ProgressBar>();
        ppv = GameObject.FindGameObjectWithTag("PostProcessGlobal").GetComponent<PostProcessVolume>();
        colorGrade = ppv.profile.GetSetting<ColorGrading>();
        saveGame = GetComponent<SaveGame>();
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
            SubmitSave();
            matchTimer.StopTime();
            GameObject.FindGameObjectWithTag("LosePanel").GetComponent<Animator>().SetTrigger("Entry");
        }
        else if (CheckWin())
        {
            SubmitSave();
            matchTimer.StopTime();
            GameObject.FindGameObjectWithTag("WinPanel").GetComponent<Animator>().SetTrigger("Entry");
        }
        else if (CheckLoss())
        {
            SubmitSave();
            matchTimer.StopTime();
            GameObject.FindGameObjectWithTag("LosePanel").GetComponent<Animator>().SetTrigger("Entry");
        }

        emissionBar.currentPercent = Mathf.Lerp(emissionBar.currentPercent, (ResourceKeeper.emission / emissionLimit) * 100f, barLerpSpeed * Time.deltaTime);
        emissionBar.currentPercent = Mathf.Clamp(emissionBar.currentPercent, 0, 100);
        colorGrade.temperature.value = emissionBar.currentPercent;

        populationBar.currentPercent = Mathf.Lerp(populationBar.currentPercent, (ResourceKeeper.population / populationRequirement) * 100f, barLerpSpeed * Time.deltaTime);
        
    }


    public bool CheckWin()
    {
        if (ResourceKeeper.population >= populationRequirement && ResourceKeeper.emission <= emissionLimit)
        {        
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool CheckLoss()
    {
        if (ResourceKeeper.emission >= GameObject.FindObjectOfType<WinConditions>().emissionLimit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void SubmitSave()
    {
        if(!saved)
        {
            SaveManager.ecoscore = ResourceKeeper.ecoScore;
            saveGame.SaveButton();
            saved = true;
        }

    }

}
