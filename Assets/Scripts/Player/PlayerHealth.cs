using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerHud playerHud;
    public AudioManager audioManager;

    [Header("Basic Info")]
    public float maxHealth;
    public float health;

    public bool dead;

    private void Start()
    {
        health = maxHealth;
        dead = false;
    }

    public void AddHealth()
    {
        health = maxHealth;
        playerHud.slider.value += 25;

        Debug.Log("Upgraded health to " + health);
        Debug.Log("Upgraded max health to " + maxHealth);
    } 

    public void AddMaxHealth()
    {
        maxHealth *= 2;
        playerHud.slider.maxValue += 20;
        health += (maxHealth - health) / 2;
        Debug.Log("Upgraded max health to " + maxHealth);
    }

    public void PlayerTakeDamage(float damage)
    {
        audioManager.PlaySFX(audioManager.playerDamage);
        health -= damage;
        playerHud.slider.value -= damage;
        if (health <= 0)
        {
            dead = true;
            Debug.Log("player is dead");
        }
    }
}
