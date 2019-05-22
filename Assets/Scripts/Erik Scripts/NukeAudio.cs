using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script stores audioclips, and provides them
/// when the "skull island" game object is clicked.
/// </summary>
public class NukeAudio : MonoBehaviour
{
    public AudioSource nukeSource;
    public AudioClip[] dontDoIt = new AudioClip[6];
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {        
    }
}
