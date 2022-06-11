using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]Asteroid asteroid;
    [SerializeField]int numberOfAsteroidsOnAxis = 10;
    [SerializeField]int gridSpacing = 100;

    // Start is called before the first frame update
    void Start()
    {
        //PlaceAsteroids();
    }

    void OnEnable()
    {
        EventManager.onSpaceFightGame += PlaceAsteroids;
    }

    void OnDisable()
    {
        EventManager.onSpaceFightGame -= PlaceAsteroids;
    }

    void PlaceAsteroids()
    {
        for(int x = 0; x < numberOfAsteroidsOnAxis; x++)
        {
            for(int y = 0; y < numberOfAsteroidsOnAxis; y++)
            {
                for(int z = 0; z < numberOfAsteroidsOnAxis; z++)
                {
                    InstantiateAsteroid(x, y, z);
                }
            }
        }
    }

    void InstantiateAsteroid(int x, int y, int z)
    {
        Instantiate(asteroid,
                    new Vector3(transform.position.x + (x * gridSpacing) + AsteroidOffset(),
                                transform.position.y + (y * gridSpacing) + AsteroidOffset(),
                                transform.position.z + (z * gridSpacing) + AsteroidOffset()),
                    Quaternion.identity,
                    transform);
    }

    float AsteroidOffset()
    {
        return Random.Range(-gridSpacing/2f, gridSpacing/2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
