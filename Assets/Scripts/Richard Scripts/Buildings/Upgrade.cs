using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public string upgradeName;
    public int cost;
    public Renderer visualModel;
    public bool upgradeActive;

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

    public void ActivateUpgrade() {
        if (visualModel)
            visualModel.enabled = true;

        Debug.Log(upgradeName + " upgrade activated");
    }
}
