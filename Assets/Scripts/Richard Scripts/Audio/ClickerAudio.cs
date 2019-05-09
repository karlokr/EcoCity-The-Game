using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerAudio : MonoBehaviour
{
    public AudioClip[] inspectClips;

    private AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer = GameObject.FindGameObjectWithTag("AudioPlayer").GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayInspect()
    {
        int randIndex = Random.Range(0, inspectClips.Length);
        audioPlayer.PlayOneShot(inspectClips[randIndex]);
    }
}
