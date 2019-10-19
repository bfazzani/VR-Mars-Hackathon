using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private float timeBetweenSpawns = 2f;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    float spawnRateChange = .02f;

    [SerializeField]
    private float spawnY = -1.605f;
    [SerializeField]
    private float spawnRadius = 20f;


    private void Start()
    {
        StartCoroutine(LoopSpawn());
    }

    private IEnumerator LoopSpawn()
    {

        while (true)
        {

            timeBetweenSpawns -= spawnRateChange;

            Spawn();
            yield return new WaitForSeconds(timeBetweenSpawns);


        }

    }

    private void Spawn()
    {
        float theta = Random.Range(0, 2 * Mathf.PI);
        Vector3 spawnPos = new Vector3(spawnRadius * Mathf.Sin(theta), spawnY, spawnRadius * Mathf.Cos(theta));
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

}
