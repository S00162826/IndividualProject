using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] path;
    public float speed = 5.0f;
    public float reachdist = 1.0f;
    public int currentPoint;
    public int nextPoint;

    void Start()
    {
        currentPoint = path.Length - 1;
    }

    void Update()
    {
        float dist = Vector3.Distance(path[currentPoint].position, transform.position);
        transform.position = Vector3.Lerp(transform.position, path[currentPoint].position, Time.deltaTime * speed);
        transform.LookAt(path[currentPoint]);

        if (dist < reachdist)
        {
            currentPoint--;
        }
        if (currentPoint == -1)
        {
            currentPoint = path.Length - 1;
        }

    }
    void OnDrawGizmos()
    {
        if (path.Length > 0)
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] != null)
                {
                    Gizmos.DrawSphere(path[i].position, reachdist);
                }
            }

        }

    }

}