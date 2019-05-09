using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{

    public GameObject GameCanvas;
    public GameObject SettingsMenu;

    public void ShowSettings() {
        (Instantiate(SettingsMenu) as GameObject).transform.parent = GameCanvas.transform;
    }
}
