using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPatrol : MonoBehaviour
{
    public bool patrolling;

    private Animator anim;
    //Whether the agent waits on each node.
    [SerializeField]
    bool patrolWaiting;

    //Time waited
    [SerializeField]
    float totalWaitTime = 3f;

    //Probability of changing direction
    [SerializeField]
    float switchProbability;

    //List of waypoints
    [SerializeField]
    List<Waypoint> patrolPoints;

    //Private variables for base behaviour
    NavMeshAgent navMeshAgent;
    int currentPatrolIndex;
    bool travelling;
    bool waiting;
    bool patrolForward;
    float waitTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (patrolling == true)
        {

            if (navMeshAgent == null)
                Debug.LogError("The nav mash agent component is not attatched to " + gameObject.name);

            else
            {
                if
                (patrolPoints != null && patrolPoints.Count >= 2)
                {
                    currentPatrolIndex = 0;
                    SetDestination();
                }
                else
                {
                    Debug.LogError("Insufficient patrol points for basic controlling behaviour");
                }

            }
        }
    }

    void Update()
    {
        if (patrolling == true)
        {
            if (travelling)
            {
                anim.SetBool("IsWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", false);
            }
            //Check if close to destination
            if (travelling && navMeshAgent.remainingDistance <= 1.0f)
            {
                travelling = false;

                //If going to wait, then wait
                if (patrolWaiting)
                {
                    waiting = true;
                    waitTimer = 0f;
                }
                else
                {

                    ChangePatrolPoint();
                    SetDestination();
                }
            
           
            }

            //If waiting
            if (waiting)
            {
                waitTimer += Time.deltaTime;
                if (waitTimer >= totalWaitTime)
                {
                    waiting = false;

                    ChangePatrolPoint();
                    SetDestination();
                }
            }
        }
    }

    private void SetDestination()
    {
        if (patrolling == true)
        {
            if (patrolPoints != null)
            {
                Vector3 targetVector = patrolPoints[currentPatrolIndex].transform.position;
                navMeshAgent.SetDestination(targetVector);
                travelling = true;
                
            }
        }
    }

    private void ChangePatrolPoint()
    {
        if (patrolling == true)
        {
            if (Random.Range(0f, 1f) <= switchProbability)
            {
                patrolForward = !patrolForward;
            }

            if (patrolForward)
            {
                currentPatrolIndex++;
                if (currentPatrolIndex >= patrolPoints.Count)
                {
                    currentPatrolIndex = 0;
                }
            }

            else
            {
                currentPatrolIndex--;

                if (currentPatrolIndex < 0)
                {
                    currentPatrolIndex = patrolPoints.Count - 1;
                }
            }
        }
    }
}