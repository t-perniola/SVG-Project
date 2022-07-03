using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]GameObject enemyPrefab;
    [SerializeField]float spawnTimer = 5f;
    [SerializeField]int maxEnemy = 5;
    int enemyCounter = 0;
    GameObject temp;

    void Start()
    {
        temp = enemyPrefab;
        SpawnEnemy();
      //  StartSpawning();
    }

    void OnEnable()
    {   
        EventManager.onSpaceFightGame += StartSpawning;
        //EventManager.onPlayerDeath += StopSpawning;
    }

       void OnDisable()
    {
        StopSpawning();
        EventManager.onSpaceFightGame -= StartSpawning;
        //EventManager.onPlayerDeath -= StopSpawning;
    }

    void SpawnEnemy()
    {
        if(enemyPrefab != null)
        {
          Instantiate(enemyPrefab, transform.position, Quaternion.identity);  
        }
          else
        {
           Instantiate(temp,  transform.position, Quaternion.identity);
        }
        

    }

    void StopSpawning()
    {
        CancelInvoke();
    }

    void StartSpawning()
    {
            InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);      
    }
}
