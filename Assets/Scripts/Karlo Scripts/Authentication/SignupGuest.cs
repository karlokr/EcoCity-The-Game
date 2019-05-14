using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class SignupGuest : MonoBehaviour {

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
                if (webRequest.downloadHandler.text == "0") {
                    Debug.Log("User created successfully.");
                    DBManager.username = username;
                    DBManager.isGuest = true;
                    UnityEngine.SceneManagement.SceneManager.LoadScene(2);
                } else {
                    Debug.Log("User creation failed. Error #" + webRequest.downloadHandler.text);
                }
            }
            
        }
    }

    public void RegisterGuestButton() {
            StartCoroutine(RegisterGuest("https://ecocitythegame.ca/sqlconnect/register.php"));
    }
}

    

