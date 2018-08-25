using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    //Want to know the finish and barrier objects
    //because we dont want finish to display
    //and the barrier to disappear until
    //all enemies are defeated
    public Transform finish;
    public Transform barrier;

    //Text to display to the player the enemy count
    public Text enemyCount;

    //Will be used to let player know how may
    //enemies there are in the level
    public float totalEnemies;

    void Update()
    {
        //Finds all objects with tag "Enemy" and keeps a count out of the total
        enemyCount.text = "Enemies Remaining : " +
            GameObject.FindGameObjectsWithTag("Enemy").Length.ToString()
            +"/" + totalEnemies.ToString();

        //When all enemies are defeated the barrier will disappear
        //and the finish object will be active
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finish.gameObject.SetActive(true);
            barrier.gameObject.SetActive(false);
        }
    }
}
