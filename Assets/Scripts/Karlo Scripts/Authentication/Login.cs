using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using TMPro;

public class Login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public Button LogInButton;
    public GameObject GameMenu;
    public GameObject GameCanvas;
    private string Username;
    private string Password;
    private bool isFocused;

    void Update() { 
        Tab();
        Enter();
        AssignInputs();
        isFocused = username.GetComponentInChildren<TMP_InputField>().isFocused || password.GetComponentInChildren<TMP_InputField>().isFocused;
        if (AuthFuncs.CheckUsername(Username) && AuthFuncs.CheckPassword(Password)) {
            LogInButton.interactable = true;
        } else {
            LogInButton.interactable = false;
        }
        if (Username == "") {
            username.GetComponentInChildren<TextMeshProUGUI>().text = "Username";
            GameObject.FindGameObjectWithTag("LoginUserLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
        }
        if (Password == "") {
            password.GetComponentInChildren<TextMeshProUGUI>().text = "Password";
            GameObject.FindGameObjectWithTag("LoginPasswordLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);

        }
    }

    public void LoginButton() {
            Password = AuthFuncs.EncryptPassword(Password);
            StartCoroutine(UserLogin("https://ecocitythegame.ca/sqlconnect/login.php"));
    }

    IEnumerator UserLogin(string url) {
        WWWForm form = new WWWForm();
        form.AddField("name", Username);
        form.AddField("password", Password);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form)) {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError || webRequest.isHttpError) {
                Debug.Log(webRequest.error);
            } else {
                Debug.Log("Form upload complete!");
                int res = int.Parse(webRequest.downloadHandler.text[0].ToString());
                switch (res) {
                    case 0:
                        DBManager.username = Username;
                        DBManager.id = int.Parse(webRequest.downloadHandler.text.Split('\t')[1]);
                        Debug.Log("User login success");
                        PlayerPrefs.SetString("username", DBManager.username);
                        PlayerPrefs.SetInt("id", DBManager.id);
                        PlayerPrefs.Save();
                        (Instantiate(GameMenu) as GameObject).transform.parent = GameCanvas.transform;
                        break;
                    case 1:
                        Debug.Log("User login failed. No Connection to Server. Error #" + webRequest.downloadHandler.text);
                        break;
                    case 2:
                        Debug.Log("User login failed. Name check query failure. Error #" + webRequest.downloadHandler.text);
                        break;
                    case 5:
                        Debug.Log("User login failed. No account associated with inputed username. Error #" + webRequest.downloadHandler.text);
                        username.GetComponentInChildren<TextMeshProUGUI>().text = "Incorrect username";
                        password.GetComponentInChildren<TextMeshProUGUI>().text = "Password";
                        GameObject.FindGameObjectWithTag("LoginUserLine").GetComponent<Image>().color = Color.red;
                        GameObject.FindGameObjectWithTag("LoginPasswordLine").GetComponent<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
                        break;
                    case 6:
                        Debug.Log("User login failed. Password Incorrect. Error #" + webRequest.downloadHandler.text);
                        password.GetComponentInChildren<TextMeshProUGUI>().text = "Incorrect password";
                        username.GetComponentInChildren<TextMeshProUGUI>().text = "Username";
                        GameObject.FindGameObjectWithTag("LoginUserLine").GetComponent<Image>().color = new Color(95/255f, 105/255f, 115/255f, 1f);
                        GameObject.FindGameObjectWithTag("LoginPasswordLine").GetComponent<Image>().color = Color.red;
                        break;
                }
            }
            
        }
    }

    private void AssignInputs() {
        Username = username.GetComponentInChildren<TMP_InputField>().text;
        Password = password.GetComponentInChildren<TMP_InputField>().text;
    }

    /*************************
     * Keyboard controls
     ************************/
    private void Tab() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                if (password.GetComponentInChildren<TMP_InputField>().isFocused) {
                    username.GetComponentInChildren<TMP_InputField>().Select();
                }
            } else {
                if (username.GetComponentInChildren<TMP_InputField>().isFocused) {
                    password.GetComponentInChildren<TMP_InputField>().Select();
                }
            }
        }
    }

    public void Enter() {
        if (isFocused) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                LoginButton();
            }
        }
    }
}
