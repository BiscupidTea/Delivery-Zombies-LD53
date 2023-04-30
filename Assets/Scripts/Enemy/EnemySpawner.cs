using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float SpawnRadius;

    [SerializeField] private float WaveTimer;
    [SerializeField] private int ZombiesXWave;

    [SerializeField] private int maxZombiesSpawn;
    
    public int zombiesSpawn;

    private bool canSpawn = true;

    private float nextWaveTime;

    private void Start()
    {
        nextWaveTime = 0;
    }

    private void Update()
    {
        nextWaveTime += Time.deltaTime;

        if (zombiesSpawn >= maxZombiesSpawn)
        {
            canSpawn = false;
        }

        if (zombiesSpawn < maxZombiesSpawn) 
        {
            canSpawn = true;
        }

        if (canSpawn == true ) 
        {
            if (nextWaveTime >= WaveTimer)
            {
                for (int i = 0; i < ZombiesXWave; i++)
                {
                    zombiesSpawn++;
                    float xZoneSpawn = (Random.Range(spawnPosition.position.x + -SpawnRadius, spawnPosition.position.x + SpawnRadius));
                    float YZoneSpawn = (Random.Range(spawnPosition.position.x + -SpawnRadius, spawnPosition.position.x + SpawnRadius));
                    Instantiate(enemy, new Vector2(xZoneSpawn, YZoneSpawn), Quaternion.identity);
                }

                nextWaveTime = 0;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(spawnPosition.position, SpawnRadius);
    }

}
