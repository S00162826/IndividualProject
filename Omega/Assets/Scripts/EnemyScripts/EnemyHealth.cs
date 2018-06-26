using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100;
    public float maxEnemyHealth = 100;
    public Image currentHealth;

    private void Start()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        float ratio = enemyHealth / maxEnemyHealth;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            enemyHealth -= 20;
            UpdateHealth();
        }

    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
