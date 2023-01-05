using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidS;
    public GameObject asteroidM;
    public GameObject asteroidL;

    public float spawnInterval;
    private float currentSpawn;

    public int smallSpawnChance;
    public int mediumSpawnChance;
    public int largeSpawnChance;

    void Start()
    {
        currentSpawn = 0;
    }

    void Update()
    {
        currentSpawn += Time.deltaTime;

        if (currentSpawn >= spawnInterval)
        {
            int spawnType = 0;
            float spawnX = 0;
            float spawnRotation = 0;
            GameObject asteroid = null;

            currentSpawn = 0;
            spawnType = Random.Range(1, smallSpawnChance + mediumSpawnChance + largeSpawnChance + 1);
            spawnX = Random.Range(-7, 7);
            spawnRotation = Random.Range(-45, 45);
            if (spawnType <= smallSpawnChance)
            {
                asteroid = Instantiate(asteroidS, new Vector3(spawnX, 6, 0), Quaternion.identity);
                asteroid.transform.Rotate(0f, 0f, spawnRotation, Space.World);
            }
            else if (spawnType <= smallSpawnChance + mediumSpawnChance)
            {
                asteroid = Instantiate(asteroidM, new Vector3(spawnX, 6, 0), Quaternion.identity);
                asteroid.transform.Rotate(0f, 0f, spawnRotation, Space.World);
            }
            else
            {
                asteroid = Instantiate(asteroidL, new Vector3(spawnX, 6, 0), Quaternion.identity);
                asteroid.transform.Rotate(0f, 0f, spawnRotation, Space.World);
            }
        }
    }
}
