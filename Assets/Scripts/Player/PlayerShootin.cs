using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShootin : MonoBehaviour
{

    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject Bullet;

    [Header("Basic Info")]
    [SerializeField] private float damage;
    [SerializeField] private float reloadTimer;
    [SerializeField] private float bulletForce;
    
    [Header("Timers")]
    [SerializeField] private float attackDelayTimer;
    [SerializeField] private int magazineCapacity;

    private int magazine;
    private float attackTimer;
    private float actualRelodTimer;

    // Start is called before the first frame update
    void Start()
    {
        magazine = magazineCapacity;
        actualRelodTimer = reloadTimer;
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        actualRelodTimer += Time.deltaTime;

        if (actualRelodTimer >= reloadTimer)
        {
            if (attackTimer >= attackDelayTimer)
            {
                if (Input.GetMouseButton(0))
                {
                    Shoot();
                }
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rigiBullet = bullet.GetComponent<Rigidbody2D>();
        rigiBullet.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);

        attackTimer = 0;
        magazine--;

        if (magazine <= 0)
        {
            actualRelodTimer = 0;
            magazine = magazineCapacity;
        }
    }
}
