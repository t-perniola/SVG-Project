using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]GameObject enemyPrefab;
    [SerializeField]float spawnTimer = 5f;

    void Start()
    {
      //  StartSpawning();
    }

    void OnEnable()
    {
        EventManager.onSpaceFightGame += StartSpawning;
    }

       void OnDisable()
    {
        StopSpawning();
        EventManager.onSpaceFightGame -= StartSpawning;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);

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
