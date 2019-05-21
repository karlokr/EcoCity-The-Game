using System.Collections;
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
    public Button SignUpButton;
    public GameObject GameMenu;
    public GameObject GameCanvas;
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
        if (AuthFuncs.CheckUsername(Username) && AuthFuncs.CheckSignupPassword(Password, ConfirmPassword)) {
            SignUpButton.interactable = true;
        } else {
            SignUpButton.interactable = false; 
        }
        if (Username == "") {
            username.GetComponentInChildren<TextMeshProUGUI>().text = "Username";
            GameObject.FindGameObjectWithTag("SignupUserLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
            GameObject.FindGameObjectWithTag("SignupPasswordLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
            GameObject.FindGameObjectWithTag("SignupCPasswordLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
        }
        if (Password == "") {
            password.GetComponentInChildren<TextMeshProUGUI>().text = "Password";
            GameObject.FindGameObjectWithTag("SignupUserLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
            GameObject.FindGameObjectWithTag("SignupPasswordLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
            GameObject.FindGameObjectWithTag("SignupCPasswordLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
        }
        if (ConfirmPassword == "") {
            confirmPassword.GetComponentInChildren<TextMeshProUGUI>().text = "Confirm Password";
            GameObject.FindGameObjectWithTag("SignupUserLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
            GameObject.FindGameObjectWithTag("SignupPasswordLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
            GameObject.FindGameObjectWithTag("SignupCPasswordLine").GetComponentInChildren<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
        }
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
                int res = int.Parse(webRequest.downloadHandler.text[0].ToString());
                switch (res) {
                    case 0:
                        Debug.Log("User created successfully.");
                        DBManager.username = Username;
                        DBManager.id = int.Parse(webRequest.downloadHandler.text.Split('\t')[1]);
                        PlayerPrefs.SetString("username", DBManager.username);
                        PlayerPrefs.SetInt("id", DBManager.id);
                        PlayerPrefs.Save();
                        (Instantiate(GameMenu) as GameObject).transform.parent = GameCanvas.transform;
                        break;
                    case 1:
                        Debug.Log("User creation failed. No Connection to Server. Error #" + webRequest.downloadHandler.text);
                        break;
                    case 2:
                        Debug.Log("User creation failed. Name check query failure. Error #" + webRequest.downloadHandler.text);
                        break;
                    case 3:
                        Debug.Log("User creation failed. Name already exists. Error #" + webRequest.downloadHandler.text);
                        username.GetComponentInChildren<TextMeshProUGUI>().text = "Username taken";
                        password.GetComponentInChildren<TextMeshProUGUI>().text = "Password";
                        confirmPassword.GetComponentInChildren<TextMeshProUGUI>().text = "Confirm Password";
                        GameObject.FindGameObjectWithTag("SignupUserLine").GetComponent<Image>().color = Color.red;
                        GameObject.FindGameObjectWithTag("SignupPasswordLine").GetComponent<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
                        GameObject.FindGameObjectWithTag("SignupCPasswordLine").GetComponent<Image>().color = new Color(95 / 255f, 105 / 255f, 115 / 255f, 1f);
                        break;
                    case 4:
                        Debug.Log("User creation failed. Insert user into DB failed. Error #" + webRequest.downloadHandler.text);
                        break;
                    case 10:
                        Debug.Log("User creation failed. Retrieve user ID failed. Error #" + webRequest.downloadHandler.text);
                        break;
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
