using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewDetection : MonoBehaviour
{
    //This is so the win lose condition script know when to
    //activate certain methods
    public static event System.Action PlayerSpotted;

    //The player is what the target will be for the enemy
    //set game object too because I decided i wanted 
    //the player to also be destroyed under certain conditions
    public Transform player;
    public GameObject playerObject;

    //I can set how far and wide I want their vision
    //to be
    public float maxAngle;
    public float maxRadius;

    //So I can decide what happens when the player is caught
    private bool isInFOV = false;

    //Means there is a slight delay before the player is caughts
    //Just looks nicer than having them caught suddenly
    float playerCaughtTimer;
    float timeToSpotPlayer = .1f;

    public void OnDrawGizmos()
    {
        //This is all for the editor
        //Gizmos do not appear in runtime
        //Just for visual representaion of whats happening
        //and makes it easier to test
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position,maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (!isInFOV)
            Gizmos.color = Color.red;
        else
            Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position,(player.position - transform.position).normalized *maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position,transform.forward * maxRadius);

    }

    //This determines whether the player is "seen" or not.
    //There is a line from the enemy to the player constantly
    //If this line intersects the width and distance i.e. radius and angle
    //of their vision the player is in the their field of vision
    public static bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
    {
        Collider[] overlaps = new Collider[10];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform == target)
                {
                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {
                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray,out hit, maxRadius))
                        {
                            if (hit.transform == target)
                                return true;
                        }
                    }
                }
            }
        }

        return false;
    }


    private void Update()
    {
        isInFOV = inFOV(transform, player, maxAngle, maxRadius);

        //Can decide what happens when they are in the field of vision
        if (isInFOV == true)
        {           
            playerCaughtTimer += Time.deltaTime;
        }
        else
        {
            playerCaughtTimer -= Time.deltaTime;
        }
        playerCaughtTimer = Mathf.Clamp(playerCaughtTimer, 0, timeToSpotPlayer);

        if (playerCaughtTimer >= timeToSpotPlayer)
        {
            //PlayerSpotted will casue GameOverDisplay in WInLoseConditions to activate
            if (PlayerSpotted != null)
            {
                PlayerSpotted();
            }
        }
    }
}
