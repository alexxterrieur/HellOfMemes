using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    public Vector3 center;
    public Vector3 spawnSize;

    public float timeBetweenWaves = 15f;
    private float countDown = 2f;
    //private int waveNumber = 1;
    [SerializeField] private int enemiesNumber = 3; //enemies during the first wave
    private float multWave = 1.2f; //multiplicateurs d'ennemis pour la vague suivante
    [SerializeField] private int maxEnemies = 7;

    void Update()
    {
        if (countDown <= 0f)
        {
            SpawnWave();
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;
    }

    public void SpawnWave()
    {
        List<GameObject> selectedEnemies = new List<GameObject>();
        for (int i = 0; i < enemiesNumber; i++)
        {
            //random enemy prefab
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            selectedEnemies.Add(enemyPrefab);
            SpawnEnemy(enemyPrefab);
        }
        enemiesNumber = Mathf.RoundToInt(enemiesNumber * multWave);
        if(enemiesNumber > maxEnemies)
        {
            enemiesNumber = maxEnemies;
        }

        //waveNumber++;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.transform.position = center + new Vector3(Random.Range(-spawnSize.x / 2, spawnSize.x / 2), Random.Range(-spawnSize.y / 2, spawnSize.y / 2), Random.Range(-spawnSize.z / 2, spawnSize.z / 2));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, spawnSize);
    }

}
