using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraClicker : MonoBehaviour
{
    private Camera viewportCamera;
    private CameraHolder cameraHolder;
    private MatchTimer matchTimer;
    private ResourceKeeper resourceKeeper;
    private Building selectedBuilding;
    private Plot selectedPlot;
    private Forest selectedForest;
    private WorldTile selectedTile;
    private GameObject[] buildMenuObj;
    private GameObject upgradeMenuObj;
    private GameObject buyMenuObj;
    private BuildMenu buildMenu;
    private UpgradeMenu upgradeMenu;
    private InspectMenu inspectMenu;
    private BuyTileMenu buyTileMenu;
    private bool dragging;
    private Vector3 startDragPosition;
    private int bombCounter;
    private ClickerAudio clickerAudio;
    //A GameObject that will be passed to a selected object.
    private GameObject objectToPass;
    private NukeTime nuke;
    private Rock selectedRock;

    private void Awake()
    {
        clickerAudio = GetComponent<ClickerAudio>();
        bombCounter = 0;
        resourceKeeper = GameObject.FindGameObjectWithTag("ResourceKeeper").GetComponent<ResourceKeeper>();
        viewportCamera = GetComponent<Camera>();
        cameraHolder = GameObject.FindGameObjectWithTag("CameraHolder").GetComponent<CameraHolder>();
        matchTimer = GameObject.FindGameObjectWithTag("MatchTimer").GetComponent<MatchTimer>();
        inspectMenu = GameObject.FindGameObjectWithTag("InspectMenu").GetComponent<InspectMenu>();
        buyTileMenu = GameObject.FindGameObjectWithTag("BuyTileMenu").GetComponent<BuyTileMenu>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dragging = false;
        buildMenuObj = GameObject.FindGameObjectsWithTag("BuildMenu");
        upgradeMenuObj = GameObject.FindGameObjectWithTag("UpgradeMenu");
        upgradeMenu = upgradeMenuObj.GetComponent<UpgradeMenu>();
        buyMenuObj = GameObject.FindGameObjectWithTag("BuyTileMenu");
        ClearSelections();
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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonUp(0) && matchTimer.matchStarted && !dragging)
            {
                Ray screenToWorld = viewportCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(screenToWorld, out RaycastHit raycastHit))
                {
                    clickerAudio.PlayInspect();
                    Collider other = raycastHit.collider;
                    switch (other.tag)
                    {
                        case "Building":
                            ClearSelections();
                            selectedBuilding = other.GetComponentInParent<Building>();
                            selectedBuilding.FocusOnBuilding();
                            upgradeMenuObj.SetActive(true);
                            upgradeMenu.PopulateList(selectedBuilding.upgrades);
                            upgradeMenu.SetSelectedBuilding(selectedBuilding);
                            break;
                        case "Plot":
                            ClearSelections();
                            Building.UnfocusAllBuildings();
                            selectedPlot = other.GetComponentInParent<Plot>();
                            selectedPlot.FocusOnPlot();
                            if (selectedPlot.size == (Plot.PlotSize)0)
                            {
                                buildMenuObj[2].SetActive(true);
                            }
                            else if (selectedPlot.size == (Plot.PlotSize)1)
                            {
                                buildMenuObj[0].SetActive(true);
                            }
                            else if (selectedPlot.size == (Plot.PlotSize)2)
                            {
                                buildMenuObj[1].SetActive(true);
                            }
                            break;
                        case "Forest":
                            ClearSelections();
                            selectedForest = other.GetComponent<Forest>();
                            buyTileMenu.SetSelectedTile(selectedForest);
                            buyMenuObj.SetActive(true);
                            if (!selectedForest.finished)
                            {
                                buyTileMenu.buildButtons[0].SetActive(true);                              
                            }
                            if (selectedForest.building)
                            {
                                buyTileMenu.buildButtons[0].SetActive(false);
                                buyTileMenu.buildButtons[1].SetActive(true);
                                buyTileMenu.buildButtons[1].GetComponent<Button>().interactable = false;
                            }
                            if (selectedForest.finished)
                            {
                                buyTileMenu.buildButtons[1].SetActive(true);
                                buyTileMenu.buildButtons[1].GetComponent<Button>().interactable = true;
                            }
                            break;
                        case "Rock":
                            ClearSelections();
                            selectedRock = other.GetComponent<Rock>();
                            buyTileMenu.SetSelectedTile(selectedRock);
                            buyMenuObj.SetActive(true);

                            if (!selectedRock.finished)
                            {
                                buyTileMenu.buildButtons[3].SetActive(true);
                            }
                            if (selectedRock.building)
                            {
                                buyTileMenu.buildButtons[3].SetActive(false);
                                buyTileMenu.buildButtons[4].SetActive(true);
                                buyTileMenu.buildButtons[4].GetComponent<Button>().interactable = false;
                            }
                            if (selectedRock.finished)
                            {
                                buyTileMenu.buildButtons[4].SetActive(true);
                                buyTileMenu.buildButtons[4].GetComponent<Button>().interactable = true;
                            }
                            break;

                        case "WorldTile":
                            ClearSelections();
                            selectedTile = other.GetComponent<WorldTile>();
                            selectedTile.GetComponent<Animator>().SetBool("Focused", true);
                            buyTileMenu.SetSelectedTile(selectedTile);
                            if (!selectedTile.purchased)
                            {
                                buyMenuObj.SetActive(true);
                                buyTileMenu.buildButtons[2].SetActive(true);
                            }
                            break;
                        case "SkullIsland":
                            bombCounter++;
                            Debug.Log(bombCounter);
                            if (bombCounter == 5)
                            {
                                nuke = other.GetComponent<NukeTime>();
                                nuke.nukeTime();
                            }
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
            cameraHolder.transform.Translate(-touchDeltaPosition.x * cameraHolder.speed, 0, -touchDeltaPosition.y * cameraHolder.speed * Time.deltaTime);
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
        
        for (int i = 0; i < buyTileMenu.buildButtons.Length; i++)
        {
            buyTileMenu.buildButtons[i].SetActive(false);
        }
        upgradeMenuObj.SetActive(false);
        Building.UnfocusAllBuildings();
        Plot.UnfocusAllPlots();
        WorldTile.UnfocusAllTiles();
        inspectMenu.SetInspecting(false);
        buyMenuObj.SetActive(false);
    }

    
}
