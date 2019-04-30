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

    // Update is called once per frame
    void Update() {
        Tab();
        Enter();
        AssignInputs();
    }

    public void RegisterButton() {
        if (CheckUsername() && CheckPassword()) {
            Password = EncryptPassword();
            StartCoroutine(Register("http://localhost/sqlconnect/register.php"));
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

    private string EncryptPassword() {
        string EncryptedPass = "";
        for (int i = 1; i <= Password.Length; i++) {
            EncryptedPass += ((char)(Password[i - 1] * (i + 1))).ToString();
        }
        return EncryptedPass;
    }

    private string DecryptPassword() {
        string DecryptedPass = "";
        for (int i = 1; i <= Password.Length; i++) {
            DecryptedPass += ((char)(Password[i - 1] / (i + 1))).ToString();
        }
        return DecryptedPass;
    }

    private void AssignInputs() {
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfirmPassword = confirmPassword.GetComponent<InputField>().text;
    }

    /*************************
     * Useranme and password validation.
     ************************/
    private bool CheckUsername() {
        if (Username != "") {
            return true;
        } else {
            Debug.LogWarning("Username field empty");
            return false;
        }
    }

    private bool CheckPassword() {
        if (Password.Equals(ConfirmPassword)) {
            if (LengthConstraint()) {
                Debug.LogWarning("Valid Password");
                return true;
            } else {
                Debug.LogWarning("Invalid Password");
                return false;
            }
        } else {
            Debug.LogWarning("Passwords don't match");
            return false;
        }
    }

    private bool LengthConstraint() {
        return Password.Length >= 8;
    }

    /*************************
     * Keyboard controls
     ************************/
    public void Tab() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (username.GetComponent<InputField>().isFocused) {
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused) {
                confirmPassword.GetComponent<InputField>().Select();
            }
        }
    }

    public void Enter() {
        if (Input.GetKeyDown(KeyCode.Return)
            && (username.GetComponent<InputField>().isFocused
            || password.GetComponent<InputField>().isFocused
            || confirmPassword.GetComponent<InputField>().isFocused)) {
            RegisterButton();
        }
    }
}
