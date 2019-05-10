using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLeaderboards : MonoBehaviour
{
    public GameObject GameCanvas;
    public GameObject Leaderboard;

    public void ShowLeaderboard() { 
        (Instantiate(Leaderboard) as GameObject).transform.parent = GameCanvas.transform;
    }
}
