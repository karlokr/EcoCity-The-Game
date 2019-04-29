using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Signup : MonoBehaviour {
    public GameObject username;
    public GameObject password;
    public GameObject confirmPassword;
    private string Username;
    private string Password;
    private string ConfirmPassword;
    private string form;
    private bool PasswordValid = false;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Tab();
        Enter();
        AssignInputs();
    }

    public void RegisterButton() {
        if (CheckUsername() && CheckPassword()) {
            Password = EncryptPassword();
            form = Username + "\n" + Password;
            Debug.Log(form);
        }
    }

    private string EncryptPassword() {
        string EncryptedPass = "";
        for (int i = 1; i <= Password.Length; i++) {
            EncryptedPass += ((char)(Password[i - 1] * (i + 1))).ToString();
        }
        return EncryptedPass;
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
            if (!System.IO.File.Exists(@"E:/UnityTestFolder/" + Username + ".txt")) {
                return true;
            } else {
                Debug.LogWarning("Username taken");
                return false;
            }
        } else {
            Debug.LogWarning("Username field empty");
            return false;
        }
    }

    private bool CheckPassword() {
        if (Password.Equals(ConfirmPassword)) {
            if (OneCapital()
                && OneLower()
                && OneNumber()
                && OneSpecial()
                && LengthConstraint()) {
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

    private bool OneCapital() {
        bool isTrue = false;
        for (int i = 0; i < Password.Length; i++) {
            char character = Password[i];
            if ('A' <= character && character <= 'Z') {
                isTrue = true;
                break;
            }
        }
        return isTrue;
    }

    private bool OneLower() {
        bool isTrue = false;
        int i;
        for (i = 0; i < Password.Length; i++) {
            char character = Password[i];
            if ('a' <= character && character <= 'z') {
                isTrue = true;
                break;
            }
        }
        return isTrue;
    }

    private bool OneNumber() {
        bool isTrue = false;
        int i;
        for (i = 0; i < Password.Length; i++) {
            char character = Password[i];
            if ('0' <= character && character <= '9') {
                isTrue = true;
                break;
            }
        }
        return isTrue;
    }

    private bool OneSpecial() {
        bool isTrue = false;
        int i;
        for (i = 0; i < Password.Length; i++) {
            char character = Password[i];
            if ('!' <= character && character <= '*') {
                isTrue = true;
                break;
            }
        }
        return isTrue;
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
        }
    }
}
