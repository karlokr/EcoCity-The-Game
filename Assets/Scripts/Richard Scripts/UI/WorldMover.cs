using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{
    public float rotateSpeed;

    private float targetAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TurnLeft();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TurnRight();
        }
    }

    public void TurnRight()
    {
        targetAngle += 90f;
    }

    public void TurnLeft()
    {
        targetAngle -= 90f;
    }
}
