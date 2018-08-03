using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public event System.Action NoHealth;
    public Image currentHealth;

    public float health = 100;
    public float maxHealth = 100;

    bool disabled;

    public Canvas GameOver;

    public Text healthText;

    private void Start()
    {
        FieldOfViewDetection.PlayerSpotted += Disable;

        UpdateHealth();
    }

    private void UpdateHealth()
    {
        float ratio = health / maxHealth;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && NoHealth != null)
        {
            Destroy(gameObject);
            health = 0;
            Disable();
            //if (NoHealth != null)
            //{
            NoHealth();
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;



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
        healthText.text = health.ToString("0") + "/" + maxHealth;
        if (health <= 0 && NoHealth != null)
        {
            NoHealth();
        }

       
    }

private void Disable()
{
    disabled = true;
}

}
