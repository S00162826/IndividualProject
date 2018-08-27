using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //This is so the win lose condition script know when to
    //activate certain methods
    public event System.Action NoHealth;

    //UI Image to show player remaining health
    public Image currentHealth;

    //Sets starting health and also maximum health player can have
    public float health = 100;
    public float maxHealth = 100;

    //for disabling player movement when they die / health reaches 0
    bool disabled;

    //Want this canvas to display when player dies
    //public Canvas GameOver;

    //Also to show players health in text format
    public Text healthText;

    private void Start()
    {
        //Uses PlayerSpotted for gameover and disable player
        FieldOfViewDetection.PlayerSpotted += Disable;

        UpdateHealth();
    }

    private void UpdateHealth()
    {
        //Shows their current health in relation to their full health
        float ratio = health / maxHealth;
        currentHealth.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void TakeDamage(float damage)
    {
        //Takes the amount of damage assigned away from health
        //Health is less than 0 health is 0, this keeps the health bar from
        //going backwards after reaches 0
        health -= damage;
        if (health <= 0 && NoHealth != null)
        {
            Destroy(gameObject);
            health = 0;
            Disable();
            NoHealth();
        }

        UpdateHealth();

    }

    private void HealDamage(float heal)
    {
        //Works the same as damge expect increases hea;th
        //Max health set too stop health going on for ever
        health += heal;
        if (health > maxHealth)
            health = maxHealth;

        UpdateHealth();
    }

    private void Update()
    {
        //To display the health in text format
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
