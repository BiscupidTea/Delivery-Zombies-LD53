using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            Debug.Log("colition");
            enemyHealth.EnemyTakeDamage(damage);
        }
        
        Destroy(gameObject);      
    }
}
