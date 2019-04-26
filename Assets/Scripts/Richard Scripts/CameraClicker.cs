using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClicker : MonoBehaviour
{
    private Camera viewportCamera;
    private MatchTimer matchTimer;
    private Building selectedBuilding;

    private void Awake()
    {
        viewportCamera = GetComponent<Camera>();
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleClicks();
    }

    private void HandleClicks()
    {
        if (Input.GetMouseButtonDown(0) && matchTimer.matchStarted)
        {
            RaycastHit raycastHit;
            Ray screenToWorld = viewportCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(screenToWorld, out raycastHit))
            {
                Collider other = raycastHit.collider;
                switch (other.tag)
                {
                    case "Building":
                        selectedBuilding = other.GetComponent<Building>();
                        selectedBuilding.ActivateDebugColor();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
