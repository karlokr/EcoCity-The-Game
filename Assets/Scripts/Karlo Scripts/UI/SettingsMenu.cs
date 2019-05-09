using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject GameMenu;
    public GameObject Canvas;

    public void NewGameButton() {
        (Instantiate(GameMenu) as GameObject).transform.parent = Canvas.transform;
    }
}
