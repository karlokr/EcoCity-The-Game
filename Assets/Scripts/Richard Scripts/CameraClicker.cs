using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClicker : MonoBehaviour
{
    private Camera viewportCamera;

    private void Awake()
    {
        viewportCamera = GetComponent<Camera>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleClicks();
    }

    private void HandleClicks()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray screenToWorld = viewportCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(screenToWorld, out raycastHit))
            {
                Collider other = raycastHit.collider;
                switch (other.tag)
                {
                    case "Building":
                        other.GetComponent<DebugBuilding>().ActivateDebugColor();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
