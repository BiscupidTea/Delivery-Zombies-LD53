using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Entity")]
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject Player;

    [Header("Radius")]
    [SerializeField] private float detectionRadius;
    [SerializeField] private float followRadius;

    [Header("Basic Info")]
    [SerializeField] private float speed;

    private float angle;
    private float distancePlayerEnemy;
    private bool isChasing;

    private void Start()
    {
        Enemy ??= GetComponent<GameObject>();
        isChasing = false;
    }
    private void Update()
    {
        DetectPlayer();

        if (isChasing)
        {
            Enemy.transform.position = Vector2.MoveTowards(Enemy.transform.position, Player.transform.position, speed * Time.deltaTime);
        }

        if (distancePlayerEnemy <= followRadius)
        {
            Enemy.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
    }

    private void DetectPlayer()
    {
        distancePlayerEnemy = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - Enemy.transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distancePlayerEnemy <= detectionRadius)
        {
            isChasing = true;
        }

        if (distancePlayerEnemy >= followRadius)
        {
            isChasing = false;
        }
    }

    private void OnDrawGizmos()
    {
        //draw followRadius
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Enemy.transform.position, followRadius);

        //draw detectionRadius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(Enemy.transform.position, detectionRadius);

        if (isChasing) 
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(Enemy.transform.position, Player.transform.position);
        }

    }
}
