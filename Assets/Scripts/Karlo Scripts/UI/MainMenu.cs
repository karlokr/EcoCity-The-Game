using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject CampaignButton;
    public GameObject EndlessButton;
    public GameObject PlayButton;
    public GameObject CampaignSelectedButton;
    public GameObject EndlessSelectedButton;
    private GameObject BackButton;
    private bool CampaignSelected;
    private bool EndlessSelected;

    // Start is called before the first frame update
    void Start()
    {
        NewGameManager.game_mode = null;
        NewGameManager.level = null;
        CampaignSelected = false;
        EndlessSelected = false;
        CampaignSelectedButton.SetActive(false);
        EndlessSelectedButton.SetActive(false);
        if (DBManager.inGame == false) {
            BackButton = GameObject.FindGameObjectWithTag("BackButton");
            BackButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame() {
        DBManager.level = NewGameManager.level;
        DBManager.game_mode = NewGameManager.game_mode;
        DBManager.newGame = true;
        DBManager.inGame = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);

    }

    public void CampignSelect() {
        CampaignSelected = true;
        EndlessSelected = false;
        NewGameManager.game_mode = "campaign";
        CampaignSelectedButton.SetActive(true);
        CampaignButton.SetActive(false);
        EndlessButton.SetActive(true);
        EndlessSelectedButton.SetActive(false);
        PlayButton.GetComponent<Button>().interactable = true;
    }

    public void EndlessSelect() {
        CampaignSelected = false;
        EndlessSelected = true;
        NewGameManager.game_mode = "endless";
        CampaignSelectedButton.SetActive(false);
        CampaignButton.SetActive(true);
        EndlessButton.SetActive(false);
        EndlessSelectedButton.SetActive(true);
        PlayButton.GetComponent<Button>().interactable = true;
    }
}
