using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditions : MonoBehaviour
{

    private MatchTimer matchTimer;
    private ResourceKeeper resourceKeeper;

    private void Awake()
    {
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resourceKeeper.population >= 250)
        {
            Debug.Log("population limit reached: " + resourceKeeper.population);
            SceneManager.LoadScene("win_screen");
        }

        if (resourceKeeper.emission >= 150)
        {
            Debug.Log("Emissions are out of control");
            SceneManager.LoadScene("lose_screen");
        }
    }
}
