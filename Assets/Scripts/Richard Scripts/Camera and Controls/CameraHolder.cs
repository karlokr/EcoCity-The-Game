using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{

    public float speed;
    public float zoomSpeed;

    private Animator animator;
    private float animPlayPercent = 0.0f;
    private Camera mainCamera;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleControls();
        SetZoom();
    }

    /// <summary>
    ///     Checks for Camera Movement Keypresses. Only for M/KB.
    /// </summary>
    private void HandleControls()
    {
        //Strafe Controls
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
    }

    private void SetZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize - zoomSpeed, 13, 60);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize + zoomSpeed, 13, 60);
        }
    }



}
