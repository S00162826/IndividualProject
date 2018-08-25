using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    //Variables for keeping track of enemies health
    public float enemyHealth = 100;
    public float maxEnemyHealth = 100;

    //To display in game the enemies health
    public Image currentHealth;

    private void Start()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        //Shows their current health in relation to their full health
        float ratio = enemyHealth / maxEnemyHealth;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    void OnTriggerEnter(Collider col)
    {
        //Bullets damage enemy
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            enemyHealth -= 20;
            UpdateHealth();
        }

    }

    void Update()
    {
        //If health reaches 0, object is destroyed
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
