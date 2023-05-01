using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Basic Info")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private EnemySpawner spawnCont;
    [SerializeField] private GameObject spawn;
    [SerializeField] private GameObject audiomanagergameonbject;       
    public AudioManager audioManager;


    [Header("References")]
    private bool dead;

    private void Start()
    {
        audiomanagergameonbject = GameObject.FindGameObjectWithTag("Audio");
        audioManager = audiomanagergameonbject.GetComponent<AudioManager>();

        List<GameObject> SpawnObject = GameObject.FindGameObjectsWithTag("Spawn").ToList();
        spawn = SpawnObject[0];
        spawnCont = spawn.GetComponent<EnemySpawner>();

        health = maxHealth;
        dead = false;
    }

    public void EnemyTakeDamage(float damage)
    {
        health -= damage;
        audioManager.PlayZombieGetDamageSFX();
        if (health <= 0)
        {
            spawnCont.zombiesSpawn--;
            audioManager.PlayZombieDieSFX();
            dead = true;
            Destroy(gameObject);
        }
    }
}
