using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraClicker : MonoBehaviour
{
    private Camera viewportCamera;
    private CameraHolder cameraHolder;
    private MatchTimer matchTimer;
    private ResourceKeeper resourceKeeper;
    private Building selectedBuilding;
    private Plot selectedPlot;
    private Forest selectedForest;
    private GameObject[] buildMenuObj;
    private GameObject upgradeMenuObj;
    private BuildMenu buildMenu;
    private UpgradeMenu upgradeMenu;
    private InspectMenu inspectMenu;
    private bool dragging;
    private Vector3 startDragPosition;
    
    //A GameObject that will be passed to a selected object.
    private GameObject objectToPass;

    private void Awake()
    {
        resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
        viewportCamera = GetComponent<Camera>();
        cameraHolder = GameObject.FindGameObjectWithTag("CameraHolder").GetComponent<CameraHolder>();
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        inspectMenu = GameObject.FindGameObjectWithTag("InspectMenu").GetComponent<InspectMenu>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        buildMenuObj = GameObject.FindGameObjectsWithTag("BuildMenu");
        for(int i = 0; i < buildMenuObj.Length; i++)
        {
            buildMenuObj[i].SetActive(false);
        }

        upgradeMenuObj = GameObject.FindGameObjectWithTag("UpgradeMenu");
        upgradeMenuObj.SetActive(false);

       // buildMenu = buildMenuObj.GetComponentsInChildren<BuildMenu>();
        upgradeMenu = upgradeMenuObj.GetComponent<UpgradeMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMouseDrag();
        HandleMobileDrag();
        HandleClicks();
    }


    public void PassObject(GameObject obj)
    {
        objectToPass = obj;
    }

    private void HandleClicks()
    {
        if (Input.GetMouseButtonUp(0) && matchTimer.matchStarted && !dragging)
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
                            selectedBuilding = other.GetComponentInParent<Building>();
                            //selectedBuilding.ActivateDebugColor();
                            upgradeMenuObj.SetActive(true);
                            upgradeMenu.PopulateList(selectedBuilding.upgrades);
                            upgradeMenu.SetSelectedBuilding(selectedBuilding);
                            break;
                        case "Plot":
                            ClearSelections();
                            Building.ClearDebugColor();
                            selectedPlot = other.GetComponent<Plot>();
                            selectedPlot.ActivateDebugColor();
                            if (selectedPlot.size == (Plot.PlotSize) 0)
                            {
                                buildMenuObj[0].SetActive(true);
                            }
                            else if (selectedPlot.size == (Plot.PlotSize) 1)
                            {
                                buildMenuObj[1].SetActive(true);
                            }
                            else if (selectedPlot.size == (Plot.PlotSize) 2)
                            {
                                buildMenuObj[2].SetActive(true);
                            }
                            //buildMenu.SetButtonVisibilitySize(selectedPlot.size);
                            break;
                        case "Forest":
                            ClearSelections();
                            selectedForest = other.GetComponent<Forest>();
                            selectedForest.BuyForest();

                            if (selectedForest.finished)
                            {
                                selectedForest.TurnIntoPlot();
                            }
                            break;
                        case "WorldTile":
                            Destroy(hit.transform.gameObject);
                            break;
                        default:
                            ClearSelections();
                            break;
                    }
                }
            }
        }
    }

    private void HandleMouseDrag()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startDragPosition = Input.mousePosition;
            dragging = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 rawDelta = (Input.mousePosition - startDragPosition).normalized;
            Vector3 ourDelta = new Vector3(rawDelta.x, 0, rawDelta.y);
            cameraHolder.transform.Translate(ourDelta * cameraHolder.speed * Time.deltaTime);                                         //Move the position of the camera to simulate a drag, speed * 10 for screen to worldspace conversion
        }


        if (Input.GetMouseButtonUp(0))
        {
            if (Input.mousePosition != startDragPosition)
            {
                dragging = true;
            }
            else
            {
                dragging = false;
            }
        }
    }

    private void HandleMobileDrag()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            cameraHolder.transform.Translate(-touchDeltaPosition.x * cameraHolder.speed, 0, -touchDeltaPosition.y * cameraHolder.speed);
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
        for (int i = 0; i < buildMenuObj.Length; i++)
        {
            buildMenuObj[i].SetActive(false);
        }
        
        upgradeMenuObj.SetActive(false);
        Building.ClearDebugColor();
        Plot.ClearDebugColor();
        Forest.ClearDebugColor();
        inspectMenu.SetInspecting(false);
    }

    
}
