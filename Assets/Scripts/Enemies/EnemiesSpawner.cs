using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> bossPrefabs;
    public Vector3 center;
    public Vector3 spawnSize;

    public float timeBetweenWaves = 5f;
    private float countDown = 2f;
    public int waveNumber = 1;
    [SerializeField] private int enemiesNumber = 3; //enemies during the first wave
    private float multWave = 1.15f; //multiplicateurs d'ennemis pour la vague suivante
    [SerializeField] private int maxEnemies = 7;

    public List<GameObject> enemiesAlive;

    void Update()
    {
        if (enemiesAlive.Count == 0)
        {
            if (countDown <= 0f)
            {
                if(waveNumber % 5 != 0) // spawn un boss tt les 5 vagues
                {
                    SpawnWave();                    
                }
                else
                {
                    SpawnBossWave();
                }

                countDown = timeBetweenWaves;
            }

            countDown -= Time.deltaTime;
        } 
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

        //limiter le nombre max dennemis sur la map
        if(enemiesNumber > maxEnemies)
        {
            enemiesNumber = maxEnemies;
        }

        waveNumber++;
    }

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemiesAlive.Add(enemy);
        enemy.transform.position = center + new Vector3(Random.Range(-spawnSize.x / 2, spawnSize.x / 2), Random.Range(-spawnSize.y / 2, spawnSize.y / 2), Random.Range(-spawnSize.z / 2, spawnSize.z / 2));
    }

    public void SpawnBossWave()
    {
        List<GameObject> selectedBoss = new List<GameObject>();

        //random enemy prefab
        GameObject bossPrefab = bossPrefabs[Random.Range(0, bossPrefabs.Count)];
        selectedBoss.Add(bossPrefab);
        SpawnBoss(bossPrefab);

        waveNumber++;
    }

    void SpawnBoss(GameObject bossPrefab)
    {
        GameObject boss = Instantiate(bossPrefab);
        enemiesAlive.Add(boss);
        boss.transform.position = Vector3.zero;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, spawnSize);
    }

}
