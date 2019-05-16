using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInMenu : MonoBehaviour
{

    public GameObject LoginMenu;
    public GameObject SignUpPanel;
    public GameObject LogInPanel;
    public GameObject Title;
    public GameObject Heading;
    public GameObject GameMenu;
    public GameObject GameCanvas;

    public void GoToLogin() {
        (Instantiate(LoginMenu) as GameObject).transform.parent = GameCanvas.transform;
        Title.SetActive(false);
        Heading.SetActive(false);
    }

    public void GoToGameMenu() {
        (Instantiate(GameMenu) as GameObject).transform.parent = GameCanvas.transform;
        Title.SetActive(false);
        Heading.SetActive(false);
    }

    public void GoToMenu() {
        if (PlayerPrefs.HasKey("id")) {
            DBManager.username = PlayerPrefs.GetString("username");
            DBManager.id = PlayerPrefs.GetInt("id");
            GoToGameMenu();
        } else {
            GoToLogin();
        }
        
    }

    public void NewAccountButton() {
        SignUpPanel.SetActive(true);
        LogInPanel.SetActive(false);
    }

    public void Back() {
        SignUpPanel.SetActive(false);
        LogInPanel.SetActive(true);
    }

}
