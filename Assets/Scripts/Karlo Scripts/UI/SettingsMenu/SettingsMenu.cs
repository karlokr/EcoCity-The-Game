using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public GameObject GameMenu;
    public GameObject Canvas;

    /// <summary>
    /// Opens the new game menu
    /// </summary>
    public void NewGameButton() {
        (Instantiate(GameMenu) as GameObject).transform.parent = Canvas.transform;
    }

    /// <summary>
    /// closes the menu
    /// </summary>
    public void Back() {
        Destroy(Canvas);
    }
}
