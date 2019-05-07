using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditions : MonoBehaviour
{

    private MatchTimer matchTimer;

    private void Awake()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ResourceKeeper.population >= 250)
        {
            Debug.Log("population limit reached: " + ResourceKeeper.population);
            SceneManager.LoadScene("win_screen");
        }

        if (ResourceKeeper.emission >= 150)
        {
            Debug.Log("Emissions are out of control");
            SceneManager.LoadScene("lose_screen");
        }
    }
}
