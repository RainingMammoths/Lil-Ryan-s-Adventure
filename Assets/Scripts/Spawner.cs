using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float time_to_spawn_max = 10,time_to_spawn = 0;
    [SerializeField] int max_enemys = 5;
    // Start is called before the first frame update
    void Start()
    {
        time_to_spawn = time_to_spawn_max;
    }

    // Update is called once per frame
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
                //Debug.Log("Enemy count: " + count);
                if(count < max_enemys)
                {
                    Instantiate(prefab, transform.position,Quaternion.identity);
                    time_to_spawn = time_to_spawn_max;
                }
            }
        }
    }


}
