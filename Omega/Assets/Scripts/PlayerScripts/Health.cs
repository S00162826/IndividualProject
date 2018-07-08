using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image currentHealth;

    public float health = 100;
    public float maxHealth = 100;
   

    public Canvas GameOver;


    private void Start()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        float ratio = health / maxHealth;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;

        UpdateHealth();

    }

    private void HealDamage(float heal)
    {
        health += heal;
        if (health > maxHealth)
            health = maxHealth;

        UpdateHealth();
    }

        private void Update()
        {
            if (health <= 0)
            {
                GameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    
}
