using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamControl : MonoBehaviour
{
    //Can set what the camera looks at in inspector
    public Transform target;

    //The speed the camera follows at
    public float smoothSpeed = 0.125f;

    //Camera Position
    private Vector3 offset = new Vector3(0f, 100f, 0f);

    void LateUpdate()
    {
        //Using the variables above to follow the target smoothly
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(target.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }

}
