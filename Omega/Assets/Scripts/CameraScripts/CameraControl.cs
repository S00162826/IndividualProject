using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0f, 60f, -20f);

    private bool standing = true;

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(target.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }

    void ChangeCameraAngle()
    {

        if (Input.GetKeyDown("c") && standing == true)
        {
            standing = false;
            offset = new Vector3(0f, 70f, -0f);
        }
        else if (Input.GetKeyDown("c") && standing == false)
        {
            standing = true;
            offset = new Vector3(0f, 50f, -20f);
        }
    }
}
