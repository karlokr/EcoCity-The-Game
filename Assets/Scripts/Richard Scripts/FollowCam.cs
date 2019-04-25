using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float followSpeed;
    private CameraHolder cameraHolder;
    
    private void Awake()
    {
        cameraHolder = GameObject.FindGameObjectWithTag("CameraHolder").GetComponent<CameraHolder>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraHolder.transform.position, followSpeed * Time.deltaTime);
    }
}
