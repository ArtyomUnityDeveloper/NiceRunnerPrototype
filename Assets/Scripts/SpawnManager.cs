using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemiesTopPrefabs;
    public GameObject[] enemiesSidesPrefabs;
    public GameObject[] powerupPrefabs;

    // For enemies spawn we need to have coordinates. PowerUps will also come from the top.
    // Enemies from top will spawn here:
    private float zTopEnemiesSpawn = 16;
    private float xSpawnRangeTopEnemies = 13.5f;
    private float ySpawn = 0.75f;

    // Enemies from sides will spawn here:
    private float xLeftEnemiesSpawn = -16.5f;
    private float xRightEnemiesSpawn = 17.2f;
    private float zSpawnRangeSideEnemiesMin = -4;
    private float zSpawnRangeSideEnemiesMax = 9;

    // Time for first spawn and repeat rate
    private float topEnemiesFirstSpawn = 2.0f;
    private float topEnemiesRepeatRate = 2.0f;

    private float sideEnemiesFirstSpawn = 5.0f;
    private float sideEnemiesRepeatRate = 5.0f;

    private float powerupFirstSpawn = 3.0f;
    private float powerupRepeatRate = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyTop", topEnemiesFirstSpawn, topEnemiesRepeatRate);
        InvokeRepeating("SpawnEnemySide", sideEnemiesFirstSpawn, sideEnemiesRepeatRate);
        InvokeRepeating("SpawnPowerup", powerupFirstSpawn, powerupRepeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyTop()
    {
        float randomTopX = Random.Range(-xSpawnRangeTopEnemies, xSpawnRangeTopEnemies);
        int topEnemyIndex = Random.Range(0, enemiesTopPrefabs.Length);
        Vector3 spawnPosTop = new Vector3(randomTopX, ySpawn, zTopEnemiesSpawn);
        Instantiate(enemiesTopPrefabs[topEnemyIndex], spawnPosTop, enemiesTopPrefabs[topEnemyIndex].transform.rotation);
    }

    void SpawnEnemySide()
    {
        int randomSide = Random.Range(0, 2);
        int sideEnemyIndex = Random.Range(0, enemiesSidesPrefabs.Length);
        float randomSidesZ = Random.Range(zSpawnRangeSideEnemiesMin, zSpawnRangeSideEnemiesMax);
        //Debug.Log("Random side: " + randomSide);

        if (randomSide == 0) // 0 - Left side
        {

            Vector3 spawnPosSidesL = new Vector3(xLeftEnemiesSpawn, ySpawn, randomSidesZ);
            Instantiate(enemiesSidesPrefabs[sideEnemyIndex], spawnPosSidesL, Quaternion.Euler(0, -90f, 0));

        } else if (randomSide == 1) // 1 - Right side
        {
            Vector3 spawnPosSidesR = new Vector3(xRightEnemiesSpawn, ySpawn, randomSidesZ);
            Instantiate(enemiesSidesPrefabs[sideEnemyIndex], spawnPosSidesR, enemiesSidesPrefabs[sideEnemyIndex].transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        float randomPowerupX = Random.Range(-xSpawnRangeTopEnemies, xSpawnRangeTopEnemies);
        int powerupIndex = Random.Range(0, powerupPrefabs.Length);
        Vector3 powerUpSpawnPos = new Vector3(randomPowerupX, ySpawn, zTopEnemiesSpawn);
        Instantiate(powerupPrefabs[powerupIndex], powerUpSpawnPos, powerupPrefabs[powerupIndex].transform.rotation);
    }
}
