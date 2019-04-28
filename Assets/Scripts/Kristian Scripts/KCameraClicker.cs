using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KCameraClicker : MonoBehaviour
{
    private Camera viewportCamera;
    private KMatchTimer matchTimer;
    private Building selectedBuilding;
    private KPlot selectedPlot;
    private GameObject buildMenu;

    //A GameObject that will be passed to a selected object.
    private GameObject objectToPass;

    private void Awake()
    {
        viewportCamera = GetComponent<Camera>();
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<KMatchTimer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        buildMenu = GameObject.FindGameObjectWithTag("BuildMenu");
        buildMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HandleClicks();
    }


    public void PassObject(GameObject obj)
    {
        objectToPass = obj;
    }

    private void HandleClicks()
    {
        if (Input.GetMouseButtonDown(0) && matchTimer.matchStarted)
        {
            Ray screenToWorld = viewportCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(screenToWorld, out RaycastHit raycastHit))
            {
                Collider other = raycastHit.collider;
                switch (other.tag)
                {
                    case "Building":
                        ClearSelections();
                        selectedBuilding = other.GetComponent<Building>();
                        selectedBuilding.ActivateDebugColor();
                        break;
                    case "Plot":
                        ClearSelections();
                        selectedPlot = other.GetComponent<KPlot>();
                        buildMenu.SetActive(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void SendBuildingToPlot()
    {
        selectedPlot.CreateBuilding(objectToPass);
    }


    private void ClearSelections()
    {
        selectedBuilding = null;
        selectedPlot = null;
        buildMenu.SetActive(false);
    }


}
