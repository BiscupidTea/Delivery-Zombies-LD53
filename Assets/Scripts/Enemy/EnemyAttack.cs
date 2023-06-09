using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject Player;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject audiomanagergameonbject;
    public AudioManager audioManager;

    [Header("Basic Info")]
    [SerializeField] private float damage;
    [SerializeField] private float attackRadius;
    [SerializeField] private float attackDelayTimer;

    private float attackTimer;
    private float distancePlayerEnemy;

    private void Start()
    {
        audiomanagergameonbject = GameObject.FindGameObjectWithTag("Audio");
        audioManager = audiomanagergameonbject.GetComponent<AudioManager>();

        List<GameObject> PlayerObject = GameObject.FindGameObjectsWithTag("Player").ToList();
        Player = PlayerObject[0];
        playerHealth = Player.GetComponent<PlayerHealth>();

    }
    private void Update()
    {
        detectIsNearPlayer();

        attackTimer += Time.deltaTime;
    }

    private void detectIsNearPlayer()
    {
        distancePlayerEnemy = Vector2.Distance(Enemy.transform.position, Player.transform.position) - attackRadius;
        if (distancePlayerEnemy <= attackRadius)
        {
            DealDamage();
        }
    }

    private void DealDamage()
    {
        if (attackTimer >= attackDelayTimer)
        {
            playerHealth.PlayerTakeDamage(damage);
            audioManager.PlayZombieDamageSFX();
            Debug.Log("attack");
            attackTimer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Enemy.transform.position, attackRadius);
    }
}
