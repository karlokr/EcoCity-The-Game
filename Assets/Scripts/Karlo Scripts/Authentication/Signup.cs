using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.Networking;

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
        isFocused = username.GetComponent<InputField>().isFocused
                    || password.GetComponent<InputField>().isFocused
                    || confirmPassword.GetComponent<InputField>().isFocused;
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
            }
            if (webRequest.downloadHandler.text == "0") {
                Debug.Log("User created successfully.");
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            } else {
                Debug.Log("User creation failed. Error #" + webRequest.downloadHandler.text);
            }
        }
    }

    private void AssignInputs() {
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfirmPassword = confirmPassword.GetComponent<InputField>().text;
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
                if (confirmPassword.GetComponent<InputField>().isFocused) {
                    password.GetComponent<InputField>().Select();
                }
            } else {
                if (username.GetComponent<InputField>().isFocused) {
                    password.GetComponent<InputField>().Select();
                }
                if (password.GetComponent<InputField>().isFocused) {
                    confirmPassword.GetComponent<InputField>().Select();
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
