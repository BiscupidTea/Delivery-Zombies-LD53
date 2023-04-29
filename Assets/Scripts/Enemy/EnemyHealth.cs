using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
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

    public void EnemyTakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            dead = true;
            Debug.Log("enemy is dead");
        }
    }
}
