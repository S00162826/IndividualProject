using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamControl : MonoBehaviour
{

    public Transform target;

    public float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0f, 100f, 0f);

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(target.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }

}
