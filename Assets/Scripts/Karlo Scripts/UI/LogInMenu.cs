using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInMenu : MonoBehaviour
{

    public GameObject LoginMenu;
    public GameObject SignUpPanel;
    public GameObject LogInPanel;
    //public GameObject Title;
    //public GameObject Heading;
    public GameObject GameMenu;
    public GameObject GameCanvas;

    /// <summary>
    /// Sets the variables when first starting the game, or goes into the game menu if already logged in
    /// </summary>
    void Awake() {
        if (DBManager.inGame) {
            GoToMenu();
        } else {
            DBManager.inGame = false;
            DBManager.username = null;
            DBManager.id = -1;
            DBManager.isGuest = false;
            DBManager.save_num = -1;
            DBManager.game_mode = null;
            DBManager.level = null;
        }
    }

    /// <summary>
    /// Goes to the login menu
    /// </summary>
    public void GoToLogin() {
        (Instantiate(LoginMenu) as GameObject).transform.parent = GameCanvas.transform;
        //Title.SetActive(false);
        //Heading.SetActive(false);
    }

    /// <summary>
    /// Goes to the game menu if the user is logged in
    /// </summary>
    public void GoToGameMenu() {
        (Instantiate(GameMenu) as GameObject).transform.parent = GameCanvas.transform;
        //Title.SetActive(false);
        //Heading.SetActive(false);
    }

    /// <summary>
    /// Goes to login menu or game menu depending if user is logged in or not
    /// </summary>
    public void GoToMenu() {
        if (PlayerPrefs.HasKey("id")) {
            DBManager.username = PlayerPrefs.GetString("username");
            DBManager.id = PlayerPrefs.GetInt("id");
            GoToGameMenu();
        } else {
            GoToLogin();
        }
        
    }

    /// <summary>
    /// defines the behaviour of the new account button
    /// </summary>
    public void NewAccountButton() {
        SignUpPanel.SetActive(true);
        LogInPanel.SetActive(false);
    }

    /// <summary>
    /// defines the behaviour of the back button
    /// </summary>
    public void Back() {
        SignUpPanel.SetActive(false);
        LogInPanel.SetActive(true);
    }

}
