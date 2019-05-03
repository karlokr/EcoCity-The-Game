using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogInMenu : MonoBehaviour
{
    public void GoToMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
