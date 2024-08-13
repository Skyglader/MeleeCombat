using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEnemySpawner : MonoBehaviour
{
    public List<LoneEnemySpawner> spawnerQueue = new List<LoneEnemySpawner>();
    public LoneEnemySpawner[] spawners;
    public GameObject[] enemies;

    public static WorldEnemySpawner instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        spawners = GetComponentsInChildren<LoneEnemySpawner>();
    }

    private void Start()
    {
        foreach (LoneEnemySpawner spawner in spawners)
        {
            spawner.SpawnEnemy(enemies[0]);
        }
    }

    private void Update()
    {
        List<LoneEnemySpawner> spawnerQueueCopy = new List<LoneEnemySpawner>(spawnerQueue);

        foreach (LoneEnemySpawner spawner in spawnerQueueCopy)
        {
            spawner.SpawnEnemy(enemies[0]);
            spawnerQueue.Remove(spawner); // Modify the original list
        }
    }
}
