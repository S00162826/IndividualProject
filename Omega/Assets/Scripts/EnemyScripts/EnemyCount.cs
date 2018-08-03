using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCount : MonoBehaviour
{
    public Text enemyCount;
    public float totalEnemies;

    void Update()
    {
        enemyCount.text = "Enemies Remaining : " +
            GameObject.FindGameObjectsWithTag("Enemy").Length.ToString()
            +"/" + totalEnemies.ToString();
    }
}
