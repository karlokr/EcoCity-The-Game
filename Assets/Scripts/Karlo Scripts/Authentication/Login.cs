using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.Networking;

public class Login : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    private string Username;
    private string Password;
    private bool isFocused;

    void Update() { 
        Tab();
        Enter();
        AssignInputs();
        isFocused = username.GetComponent<InputField>().isFocused || password.GetComponent<InputField>().isFocused;
    }

    public void LoginButton() {
        if (AuthFuncs.CheckUsername(Username) && AuthFuncs.CheckPassword(Password)) {
            Password = AuthFuncs.EncryptPassword(Password);
            StartCoroutine(UserLogin("https://ecocitythegame.ca/sqlconnect/login.php"));
        }
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
            }
            if (webRequest.downloadHandler.text[0] == '0') {
                DBManager.username = Username;
                DBManager.id = int.Parse(webRequest.downloadHandler.text.Split('\t')[1]);
                Debug.Log("User login success");
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            } else {
                Debug.Log("User login failed. Error #" + webRequest.downloadHandler.text);
            }
        }
    }

    private void AssignInputs() {
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
    }

    /*************************
     * Keyboard controls
     ************************/
    private void Tab() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                if (password.GetComponent<InputField>().isFocused) {
                    username.GetComponent<InputField>().Select();
                }
            } else {
                if (username.GetComponent<InputField>().isFocused) {
                    password.GetComponent<InputField>().Select();
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
