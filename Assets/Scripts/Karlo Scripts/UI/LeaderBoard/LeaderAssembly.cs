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
        var LeaderData = JObject.Parse(RawData);
        JArray items = (JArray)LeaderData["leaderboard"];
        int length = items.Count;

        for (int i=0; i<LeaderSlots.Length; i++) { 
            if (i < length) {
                LeaderSlots[i].GetComponent<Image>().gameObject.SetActive(true);
                Text[] TextBoxes = LeaderSlots[i].GetComponentsInChildren<Text>();
                foreach (Text TextBox in TextBoxes) {
                    if (TextBox.CompareTag("LeaderUser")) {
                        TextBox.GetComponent<Text>().text = ((i+1) + (LeaderManager.Page)*5) + ". " + (string)LeaderData["leaderboard"][i]["username"];
                    } else {
                        TextBox.GetComponent<Text>().text = (string)LeaderData["leaderboard"][i]["ecoscore"];
                    }
                }
            } else {
                LeaderSlots[i].GetComponent<Image>().gameObject.SetActive(false);
            }
        }

    }
}
