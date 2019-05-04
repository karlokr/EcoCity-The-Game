using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCircle : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * -100);
    }
}
