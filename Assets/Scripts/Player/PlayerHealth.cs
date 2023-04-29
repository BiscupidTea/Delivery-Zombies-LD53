using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Basic Info")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;

    private bool dead;

    private void Start()
    {
        health = maxHealth;
        dead = false;
    }

    public void PlayerTakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            dead = true;
            Debug.Log("player is dead");
        }
    }
}
