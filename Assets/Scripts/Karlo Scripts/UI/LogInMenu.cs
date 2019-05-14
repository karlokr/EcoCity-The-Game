using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInMenu : MonoBehaviour
{

    public GameObject SignUpPanel;
    public GameObject LoginPanel;

    public void GoToMenu() {
        if (PlayerPrefs.HasKey("id")) {
            DBManager.username = PlayerPrefs.GetString("username");
            DBManager.id = PlayerPrefs.GetInt("id");
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        } else {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        
    }

    public void NewAccountButton() {
        SignUpPanel.SetActive(true);
        LoginPanel.SetActive(false);
    }

    public void Back() {
        SignUpPanel.SetActive(false);
        LoginPanel.SetActive(true);
    }

}
