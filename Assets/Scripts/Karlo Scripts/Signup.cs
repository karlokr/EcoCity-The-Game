using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class Signup : MonoBehaviour
{
    public GameObject username;
    public GameObject password;
    public GameObject confirmPassword;
    private string Username;
    private string Password;
    private string ConfirmPassword;
    private string form;
    private bool PasswordValid = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RegisterButton()
    {
        Debug.Log("Registration Successful");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            if (password.GetComponent<InputField>().isFocused)
            {
                confirmPassword.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && ConfirmPassword != "" && Username != "") {
                RegisterButton();
            }
        }
        Username = username.GetComponent<InputField>().text;
        Password = password.GetComponent<InputField>().text;
        ConfirmPassword = confirmPassword.GetComponent<InputField>().text;
    }
}
