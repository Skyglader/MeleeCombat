using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoneEnemySpawner : MonoBehaviour
{

    public GameObject spawnedEnemy;
    public bool spawnerOccupied = true;
    public bool requestedReplacement = false;

    public float spawnerCooldown = 3f;
    // Start is called before the first frame update
   
    void Start()
    {
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedEnemy == null && requestedReplacement == false)
        {
            StartCoroutine(RequestEnemyReplacement(spawnerCooldown));
            spawnerOccupied = false;
        }
    }
    
    public void SpawnEnemy(GameObject enemy)
    {
        requestedReplacement = false;
        spawnerOccupied = true;

        
        spawnedEnemy = Instantiate(enemy, transform.position, transform.rotation);
    }

    public IEnumerator RequestEnemyReplacement(float time)
    {
        requestedReplacement = true;
        yield return new WaitForSecondsRealtime(time);
        WorldEnemySpawner.instance.spawnerQueue.Add(this);
    }
}
