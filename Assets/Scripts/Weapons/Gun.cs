using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject Bullet;

    [SerializeField] private Transform centerFirePivot;
    [SerializeField] private GameObject centerFirePivotGO;
    [SerializeField] private Transform[] firePivot;

    [SerializeField] private GameObject player;

    [Header("Basic Info")]
    [SerializeField] private float bulletForce;

    [Header("Timers")]
    private float attackTimer;


    // Start is called before the first frame update
    void Start()
    {
        ResetAttackTimer();
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer >= gunData.fireRate)
        {
            if (inputManager.CheckShootingInput())
            {
                Shoot();
            }
        }
        centerFirePivotGO.transform.rotation = player.transform.rotation;
        centerFirePivotGO.transform.Rotate(0,0, Random.Range(-5,5 ));
    }

    public void Shoot()
    {
        if (gunData.name == "Shotgun")
        {          
            for (int i = 0; i < firePivot.Length; i++)
            {
                GameObject bullet = Instantiate(Bullet, firePivot[i].position, firePivot[i].rotation);
                Rigidbody2D rigiBullet = bullet.GetComponent<Rigidbody2D>();
                rigiBullet.AddForce(firePivot[i].transform.up * bulletForce, ForceMode2D.Impulse);
            }
        }                 
        else
        {
            GameObject bullet = Instantiate(Bullet, centerFirePivot.position, centerFirePivot.rotation);
            Rigidbody2D rigiBullet = bullet.GetComponent<Rigidbody2D>();
            rigiBullet.AddForce(centerFirePivot.up * bulletForce, ForceMode2D.Impulse);
        }

        ResetAttackTimer();
    }

    public void ResetAttackTimer()
    {
        attackTimer = 0;
    }
}
