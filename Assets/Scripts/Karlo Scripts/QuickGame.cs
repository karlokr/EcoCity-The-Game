using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickGame : MonoBehaviour
{
    public void StartGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
}
