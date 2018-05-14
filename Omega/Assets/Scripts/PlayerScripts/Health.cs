using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image currentHealth;

    private float health = 100;
    private float maxHealth = 100;

    private void Start()
    {
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        float ratio = health / maxHealth;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void Damage(float damage)
    {
        health -= damage;
        if (health < 0)
            health = 0;

        UpdateHealth();
    }

    private void Heal(float heal)
    {
        health += heal;
        if (health > maxHealth)
            health = maxHealth;

        UpdateHealth();
    }

}
