using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public Transform finish;
    public Transform barrier;
    public Text enemyCount;
    public float totalEnemies;

    void Update()
    {
        enemyCount.text = "Enemies Remaining : " +
            GameObject.FindGameObjectsWithTag("Enemy").Length.ToString()
            +"/" + totalEnemies.ToString();

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            finish.gameObject.SetActive(true);
            barrier.gameObject.SetActive(false);
        }
    }
}
