using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCircle : MonoBehaviour
{
    void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

}
