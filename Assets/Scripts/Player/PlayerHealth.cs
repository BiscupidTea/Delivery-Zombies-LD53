using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerHud playerHud;

    [Header("Basic Info")]
    public float maxHealth;
    public float health;

    private bool dead;

    private void Start()
    {
        health = maxHealth;
        dead = false;
    }

    public void AddHealth()
    {
        health += 25;
        playerHud.slider.value += 25;
        if (health > maxHealth)
            health = maxHealth;

        Debug.Log("Upgraded health to " + health);
        Debug.Log("Upgraded max health to " + maxHealth);
    } 

    public void AddMaxHealth()
    {
        maxHealth += 20;
        playerHud.slider.maxValue += 20;
        Debug.Log("Upgraded max health to " + maxHealth);
    }

    public void PlayerTakeDamage(float damage)
    {
        health -= damage;
        playerHud.slider.value -= damage;
        if (health <= 0)
        {
            dead = true;
            Debug.Log("player is dead");
            Destroy(gameObject);
        }
    }
}
