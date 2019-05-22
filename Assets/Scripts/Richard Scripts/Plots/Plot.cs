using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Plot : MonoBehaviour
{
    
    public enum PlotSize { Small, Medium, Large };
    public PlotSize size;

    public Sprite negativeSprite;
    public Sprite positiveSprite;
    public static Material defaultMaterial;
    public Animator animator;

    public AudioSource audioData;
    public AudioClip positive;

    private ResourceKeeper resourceKeeper;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioData = GameObject.FindGameObjectWithTag("UIAudioPlayer").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateBuilding(GameObject prefabToBuild)
    {
        Building building = prefabToBuild.GetComponent<Building>();

        if (ResourceKeeper.money < building.cost)
        {
            GameObject.FindGameObjectWithTag("CreditNotif").GetComponent<Animator>().SetTrigger("Notify");
            GameObject.FindGameObjectWithTag("CreditPanel").GetComponentInChildren<Image>().color = Color.red;
            GameObject.FindGameObjectWithTag("CreditNotifTitle").GetComponent<TextMeshProUGUI>().text = "NOT ENOUGH MONEY";
        }
        if (ResourceKeeper.wood < building.woodCost)
        {
            GameObject.FindGameObjectWithTag("WoodNotif").GetComponent<Animator>().SetTrigger("Notify");
            GameObject.FindGameObjectWithTag("WoodPanel").GetComponentInChildren<Image>().color = Color.red;
            GameObject.FindGameObjectWithTag("WoodNotifTitle").GetComponent<TextMeshProUGUI>().text = "NOT ENOUGH WOOD";
        }
        if (ResourceKeeper.population < building.populationRequired)
        {
            GameObject.FindGameObjectWithTag("PopNotif").GetComponent<Animator>().SetTrigger("Notify");
        }

        else if (ResourceKeeper.money >= building.cost && ResourceKeeper.wood >= building.woodCost && ResourceKeeper.population >= building.populationRequired)
        {

            GameObject newBuilding = Instantiate(prefabToBuild, transform.position, transform.rotation);
            int randRotFactor = Random.Range(0, 3);
            newBuilding.transform.Rotate(Vector3.up * (90f * randRotFactor));
            newBuilding.transform.SetParent(GameObject.FindGameObjectWithTag("WorldTile").transform);
            newBuilding.transform.Translate(Vector3.up * 35f);
            ResourceKeeper.money -= building.cost;
            ResourceKeeper.wood -= building.woodCost;
            ResourceKeeper.buildingSizeTotal += building.size;
            Destroy(gameObject);
            building.Emit();
             
            // Play audio
            audioData.PlayOneShot(positive);
        }

    }


    /// <summary>
    /// Debug function that sets the mesh color to magenta.
    /// </summary>
    public void FocusOnPlot()
    {
        animator.SetBool("Focused", true);
    }


    public static void UnfocusAllPlots()
    {
        Plot[] p = GameObject.FindObjectsOfType<Plot>();
        foreach (Plot obj in p)
        {
            obj.animator.SetBool("Focused", false);
        }
    }




}
