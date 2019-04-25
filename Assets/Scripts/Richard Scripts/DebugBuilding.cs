using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugBuilding : MonoBehaviour
{
    public Material debugMaterial;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateDebugColor()
    {
        rend.material = debugMaterial;
    }
}
