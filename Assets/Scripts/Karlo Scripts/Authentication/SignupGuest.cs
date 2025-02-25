﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class SignupGuest : MonoBehaviour {

    public GameObject GameMenu;
    public GameObject GameCanvas;

    /// <summary>
    /// Contacts the server to actually register the guest user
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    IEnumerator RegisterGuest(string url) {
        WWWForm form = new WWWForm();
        string username = Guid.NewGuid().ToString();
        string password = Guid.NewGuid().ToString();
        form.AddField("name", username);
        form.AddField("password", password);

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
                        DBManager.username = username;
                        DBManager.isGuest = true;
                        PlayerPrefs.SetString("username", DBManager.username);
                        PlayerPrefs.SetString("isGuest", "true");
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

    /// <summary>
    /// method for the sign up guest button
    /// </summary>
    public void RegisterGuestButton() {
            StartCoroutine(RegisterGuest("https://ecocitythegame.ca/sqlconnect/register.php"));
    }
}

    

