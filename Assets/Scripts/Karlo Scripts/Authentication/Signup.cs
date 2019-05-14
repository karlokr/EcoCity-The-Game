using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using TMPro;

public class Signup : MonoBehaviour {
    public GameObject username;
    public GameObject password;
    public GameObject confirmPassword;
    private string Username;
    private string Password;
    private string ConfirmPassword;
    private bool isFocused;

    // Update is called once per frame
    void Update() {
        Tab();
        Enter();
        AssignInputs();
        isFocused = username.GetComponentInChildren<TMP_InputField>().isFocused
                    || password.GetComponentInChildren<TMP_InputField>().isFocused
                    || confirmPassword.GetComponentInChildren<TMP_InputField>().isFocused;
    }

    public void RegisterButton() {
        if (AuthFuncs.CheckUsername(Username) && AuthFuncs.CheckSignupPassword(Password, ConfirmPassword)) {
            Password = AuthFuncs.EncryptPassword(Password);
            StartCoroutine(Register("https://ecocitythegame.ca/sqlconnect/register.php"));
        }
    }

    IEnumerator Register(string url) {
        WWWForm form = new WWWForm();
        form.AddField("name", Username);
        form.AddField("password", Password);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form)) {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError || webRequest.isHttpError) {
                Debug.Log(webRequest.error);
            } else {
                Debug.Log("Form upload complete!");
                if (webRequest.downloadHandler.text[0] == '0') {
                    Debug.Log("User created successfully.");
                    DBManager.username = Username;
                    DBManager.id = int.Parse(webRequest.downloadHandler.text.Split('\t')[1]);
                    PlayerPrefs.SetString("username", DBManager.username);
                    PlayerPrefs.SetInt("id", DBManager.id);
                    PlayerPrefs.Save();
                    UnityEngine.SceneManagement.SceneManager.LoadScene(2);
                } else {
                    Debug.Log("User creation failed. Error #" + webRequest.downloadHandler.text);
                }
            }
            
        }
    }

    private void AssignInputs() {
        Username = username.GetComponentInChildren<TMP_InputField>().text;
        Password = password.GetComponentInChildren<TMP_InputField>().text;
        ConfirmPassword = confirmPassword.GetComponentInChildren<TMP_InputField>().text;
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
                if (confirmPassword.GetComponentInChildren<TMP_InputField>().isFocused) {
                    password.GetComponentInChildren<TMP_InputField>().Select();
                }
            } else {
                if (username.GetComponentInChildren<TMP_InputField>().isFocused) {
                    password.GetComponentInChildren<TMP_InputField>().Select();
                }
                if (password.GetComponentInChildren<TMP_InputField>().isFocused) {
                    confirmPassword.GetComponentInChildren<TMP_InputField>().Select();
                }
            }
        }
    }

    public void Enter() {
        if (isFocused) {
            if (Input.GetKeyDown(KeyCode.Return)) {
                RegisterButton();
            }
        }
    }
}
