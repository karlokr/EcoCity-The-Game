using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using UnityEngine.UI;

public class LeaderAssembly : MonoBehaviour
{

    public static void GenerateLeaderBoard(GameObject[] LeaderSlots) {
        string RawData = LeaderManager.LeaderData;
        Debug.Log(RawData);
        var LeaderData = JObject.Parse(RawData);
        JArray items = (JArray)LeaderData["leaderboard"];
        int length = items.Count;
        Debug.Log(length);

        for (int i=0; i<LeaderSlots.Length; i++) { 
            if (i < length) {
                Debug.Log(i);
                LeaderSlots[i].GetComponent<Image>().gameObject.SetActive(true);
                LeaderSlots[i].GetComponentInChildren<Text>().text = (string)LeaderData["leaderboard"][i]["username"];
                LeaderSlots[i].GetComponentInChildren<Text>().GetComponentInChildren<Text>().text = (string)LeaderData["leaderboard"][i]["ecoscore"];
            } else {
                LeaderSlots[i].GetComponent<Image>().gameObject.SetActive(false);
            }
        }

    }
}
