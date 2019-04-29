using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraClicker : MonoBehaviour
{
    private Camera viewportCamera;
    private MatchTimer matchTimer;
    private Building selectedBuilding;
    private Plot selectedPlot;
    private GameObject buildMenuObj;
    private GameObject upgradeMenuObj;
    private BuildMenu buildMenu;
    private UpgradeMenu upgradeMenu;
    
    //A GameObject that will be passed to a selected object.
    private GameObject objectToPass;

    private void Awake()
    {
        viewportCamera = GetComponent<Camera>();
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        buildMenuObj = GameObject.FindGameObjectWithTag("BuildMenu");
        buildMenuObj.SetActive(false);

        upgradeMenuObj = GameObject.FindGameObjectWithTag("UpgradeMenu");
        upgradeMenuObj.SetActive(false);

        buildMenu = buildMenuObj.GetComponent<BuildMenu>();
        upgradeMenu = upgradeMenuObj.GetComponent<UpgradeMenu>();
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
            if (!EventSystem.current.IsPointerOverGameObject())
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
                            upgradeMenuObj.SetActive(true);
                            upgradeMenu.PopulateList(selectedBuilding.upgrades);
                            upgradeMenu.SetSelectedBuilding(selectedBuilding);
                            break;
                        case "Plot":
                            ClearSelections();
                            Building.ClearDebugColor();
                            selectedPlot = other.GetComponent<Plot>();
                            buildMenuObj.SetActive(true);
                            buildMenu.SetButtonVisibilitySize(selectedPlot.size);
                            break;
                        default:
                            ClearSelections();
                            break;
                    }
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
        buildMenuObj.SetActive(false);
        upgradeMenuObj.SetActive(false);
        Building.ClearDebugColor();
    }

    
}
