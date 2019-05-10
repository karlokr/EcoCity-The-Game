using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using TMPro;

public class LeaderBoard : MonoBehaviour {

    public GameObject[] LeaderSlots;
    public GameObject Menu;
    public GameObject GameMode;
    public GameObject Level;
    public GameObject PrevButton;
    public GameObject NextButton;

    public void Awake() {
        LeaderManager.Page = 0;
        StartCoroutine(GetLeaderBoard("https://ecocitythegame.ca/sqlconnect/leaderboard.php", LeaderManager.Page));
        GameMode.GetComponent<TMP_Text>().text = DBManager.game_mode.Substring(0,1).ToUpper() + DBManager.game_mode.Substring(1);
        Level.GetComponent<TMP_Text>().text = DBManager.level.Substring(0, 1).ToUpper() + DBManager.level.Substring(1);
    }


    public void Update() {
        if (LeaderManager.Page <= 0) {
            PrevButton.SetActive(false);
        } else {
            PrevButton.SetActive(true);
        }
        if (LeaderManager.Page >= LeaderManager.TotalNumPages - 1) {
            NextButton.SetActive(false);
        } else {
            NextButton.SetActive(true);
        }
    }


    IEnumerator GetLeaderBoard(string url, int page)
    {
        WWWForm form = new WWWForm();
        form.AddField("pageno", page);
        form.AddField("game_mode", DBManager.game_mode);
        form.AddField("level", DBManager.level);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
                Debug.Log(webRequest.downloadHandler.text);

                if (webRequest.downloadHandler.text.Split('\t')[0] == "0") {
                    
                    LeaderManager.TotalNumPages = Int32.Parse(webRequest.downloadHandler.text.Split('\t')[2]) / 5;
                    if (Int32.Parse(webRequest.downloadHandler.text.Split('\t')[2]) % 5 != 0) {
                        LeaderManager.TotalNumPages++;
                    }
                    Debug.Log("total num pages: " + LeaderManager.TotalNumPages);
                    LeaderManager.LeaderData = webRequest.downloadHandler.text.Split('\t')[1];
                    LeaderAssembly.GenerateLeaderBoard(LeaderSlots);
                } else {
                    Debug.Log("User login failed. Error #" + webRequest.downloadHandler.text);
                }
            }
            
        }
    }

    public void Back() {
        Destroy(Menu);
    }

    public void NextPage() {
        LeaderManager.Page += 1;
        StartCoroutine(GetLeaderBoard("https://ecocitythegame.ca/sqlconnect/leaderboard.php", LeaderManager.Page));
    }

    public void PreviousPage() {
        LeaderManager.Page -= 1;
        StartCoroutine(GetLeaderBoard("https://ecocitythegame.ca/sqlconnect/leaderboard.php", LeaderManager.Page));
    }


}
