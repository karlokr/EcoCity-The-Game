using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLeaderboards : MonoBehaviour
{
    public GameObject GameCanvas;
    public GameObject Leaderboard;

    /// <summary>
    /// opens the leaderboard menu
    /// </summary>
    public void ShowLeaderboard() { 
        (Instantiate(Leaderboard) as GameObject).transform.parent = GameCanvas.transform;
    }
}
