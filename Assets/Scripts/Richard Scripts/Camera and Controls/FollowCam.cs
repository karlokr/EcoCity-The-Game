using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float followSpeed;
    public float rotationSpeed;
    private CameraHolder cameraHolder;
    
    private void Awake()
    {
        GameObject cameraGO = GameObject.FindGameObjectWithTag("CameraHolder");
        cameraHolder = cameraGO.GetComponent<CameraHolder>();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraHolder.transform.position, followSpeed * Time.deltaTime);
    }
}
