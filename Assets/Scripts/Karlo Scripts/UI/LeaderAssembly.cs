using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UnityEngine.UI;

public class LeaderAssembly : MonoBehaviour
{
    public static void GenerateLeaderBoard() {
        string RawData = LeaderManager.LeaderData;
        Debug.Log(RawData);
        var LeaderData = JObject.Parse(RawData);
        JArray items = (JArray)LeaderData["leaderboard"];
        int length = items.Count;
        Debug.Log(length);

        int i = 0;
        foreach (GameObject UserObject in GameObject.FindGameObjectsWithTag("LeaderUser")) {
            if (i < length) {
                Debug.Log(i);
                UserObject.GetComponentInParent<Image>().gameObject.SetActive(true);
                UserObject.GetComponent<Text>().text = (string)LeaderData["leaderboard"][i]["username"];
                i++;
            } 
        }

        int j = 0;
        foreach (GameObject ScoreObject in GameObject.FindGameObjectsWithTag("LeaderScore")) {
            if (j < length) {
                Debug.Log(j);
                // ScoreObject.GetComponent<Text>().text = score.ToString();
                j++;
            } else {
                ScoreObject.GetComponentInParent<Image>().gameObject.SetActive(false);
            }
        }
    }
}
