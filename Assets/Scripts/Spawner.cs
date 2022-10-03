using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prototype;
    [SerializeField] float time_to_spawn_max = 10, time_to_spawn;
    [SerializeField] int max_enemies = 5;
    [SerializeField] string prototypeJSON_; 
    [SerializeField] string enemyToSpawnID; 
    private List<EnemyInfo> enemyPrototypes;
    private EnemyInfos? infos;
    private Dictionary<string, GameObject> slimes;



    void Start()
    {
        time_to_spawn = time_to_spawn_max;
        infos = JsonConvert.DeserializeObject<EnemyInfos>(prototypeJSON_);
        enemyPrototypes = infos.Prototypes;
        slimes = new Dictionary<string, GameObject>();

        foreach (var enemyPrototype in enemyPrototypes)
        {
            Debug.Log("Dictionary has " + slimes.Count + " entries. Adding type:" + enemyPrototype.ID);
            GameObject slime;
            if (enemyPrototype.PrototypeID == null)
            {
                slime = Instantiate(prototype, transform.position, Quaternion.identity);
            }
            else
            {
                slime = Instantiate(slimes[enemyPrototype.PrototypeID], transform.position, Quaternion.identity);
            }
            slime.name = enemyPrototype.ID;

            // Add properties
            if (enemyPrototype.Properties.ContainsKey("Speed"))
            {
                var speed = float.Parse(enemyPrototype.Properties["Speed"]);
                if (slime.TryGetComponent<MovementComponent>(out var speedScript))
                {
                    speedScript.Speed = speed;
                }
                else
                {
                    speedScript = slime.AddComponent<MovementComponent>();
                    speedScript.Speed = speed;
                }
            }
            if (enemyPrototype.Properties.ContainsKey("Size"))
            {
                var size = float.Parse(enemyPrototype.Properties["Size"]);
                slime.transform.localScale = new Vector3(size, size, size);
            }
            if (enemyPrototype.Properties.ContainsKey("Health"))
            {
                var health = int.Parse(enemyPrototype.Properties["Health"]);
                if (slime.TryGetComponent<HealthComponent>(out var healthScript))
                {
                    healthScript.Health = health;
                }
                else
                {
                    healthScript = slime.AddComponent<HealthComponent>();
                    healthScript.Health = health;
                }
            }
            if (!slime.TryGetComponent<Actor>(out var _))
            {
                slime.AddComponent<Actor>();
            }
            if (!slimes.ContainsKey(enemyPrototype.ID))
            {
                slimes[enemyPrototype.ID] = slime;
            }
            slime.SetActive(false);
        }
    }

    void SpawnEnemy()
    {
        var slime = Instantiate(slimes[enemyToSpawnID], transform.position, Quaternion.identity);
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
                int count = GameObject.FindGameObjectsWithTag("Enemy").Length; // dead enemies are not destroyed RN
                if(count < max_enemies)
                {
                    SpawnEnemy();
                    time_to_spawn = time_to_spawn_max;
                }
            }
        }
    }


}
