using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCircle : MonoBehaviour
{


    void Awake()
    {
        if (DBManager.level == "easy") {
            if (DBManager.game_mode == "campaign") {
                UnityEngine.SceneManagement.SceneManager.LoadScene("campaign_easy");
            } else {
                UnityEngine.SceneManagement.SceneManager.LoadScene("endless_easy");
            }
        } else if (DBManager.level == "medium") {
            if (DBManager.game_mode == "campaign") {
                UnityEngine.SceneManagement.SceneManager.LoadScene("campaign_medium");
            } else {
                UnityEngine.SceneManagement.SceneManager.LoadScene("endless_medium");
            }
        } else if (DBManager.level == "hard") {
            if (DBManager.game_mode == "campaign") {
                UnityEngine.SceneManagement.SceneManager.LoadScene("campaign_hard");
            } else {
                UnityEngine.SceneManagement.SceneManager.LoadScene("endless_hard");
            }
        }
    }

}
