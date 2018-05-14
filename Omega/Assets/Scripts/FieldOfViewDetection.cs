using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewDetection : MonoBehaviour
{
    public Transform player;
    public float maxAngle;
    public float maxRadius;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position,(player.position - transform.position).normalized *maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position,transform.forward * maxRadius);

    }

    public static bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] overlaps = new Collider[10];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i] == target)
                {

                }
            }
        }

        return false;
    }
}
