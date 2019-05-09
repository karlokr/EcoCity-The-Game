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

    public void Awake() {
        LeaderBoardCoroutine();
        GameMode.GetComponent<TMP_Text>().text = DBManager.game_mode;
        Level.GetComponent<TMP_Text>().text = DBManager.level;
    }

    public void LeaderBoardCoroutine()
    {
        StartCoroutine(GetLeaderBoard("https://ecocitythegame.ca/sqlconnect/leaderboard.php"));
    }

    IEnumerator GetLeaderBoard(string url)
    {
        WWWForm form = new WWWForm();
        form.AddField("pageno", 0);
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
            }
            if (webRequest.downloadHandler.text[0] == '0')
            {
                Debug.Log(webRequest.downloadHandler.text.Split('\t')[1]);
                LeaderManager.LeaderData = webRequest.downloadHandler.text.Split('\t')[1];
                LeaderAssembly.GenerateLeaderBoard();
            }
            else
            {
                Debug.Log("User login failed. Error #" + webRequest.downloadHandler.text);
            }
        }
    }

    public void Back() {
        Destroy(Menu);
    }


}
