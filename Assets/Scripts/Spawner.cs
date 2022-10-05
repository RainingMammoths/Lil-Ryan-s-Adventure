using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float time_to_spawn_max = 10, time_to_spawn;
    [SerializeField] int max_enemies = 5;
    [SerializeField] string enemyToSpawnID;
    private EnemyManager enemyManager;

    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        time_to_spawn = time_to_spawn_max;
    }

    void SpawnEnemy()
    {
        var slime = enemyManager.BuildEnemy(enemyToSpawnID, transform.position, Quaternion.identity);
        slime.SetActive(true);
        slime.name = enemyToSpawnID;
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(time_to_spawn>0)
        {
            time_to_spawn -= Time.fixedDeltaTime;
            if(time_to_spawn<=0) // check every 10s if we need to spawn
            {
                int count = GameObject.FindGameObjectsWithTag("Enemy").Length;
                if(count < max_enemies)
                {
                    SpawnEnemy();
                    time_to_spawn = time_to_spawn_max;
                }
            }
        }
    }
}
