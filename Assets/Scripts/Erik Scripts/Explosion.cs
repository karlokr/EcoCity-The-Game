using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private AudioSource nukeSource;
    private NukeAudio nukeAudio;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        nukeAudio = GameObject.FindObjectOfType<NukeAudio>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("boooom");
        GameObject nuke = Instantiate(explosion, new Vector3(0, 30, 0), transform.rotation);
        StartCoroutine(Wait());
        nukeSource = nukeAudio.GetComponent<AudioSource>();
        nukeSource.PlayOneShot(nukeAudio.dontDoIt[5]);
    }
    private IEnumerator Wait()
    {

        yield return new WaitForSeconds(1);
        ResourceKeeper.emission = 99999;

    }
}
