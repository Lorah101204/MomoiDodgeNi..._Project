using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class NigaSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject nigaPrefab;
    public float minTimeBetweenSpawns = 0.5f;
    public float maxTimeBetweenSpawns = 2f;

    private float timeToSpawn;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        SetRandomTimeToSpawn();
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.time >= timeToSpawn)
        {
            SpawnNiga();
            SetRandomTimeToSpawn();
            increaseHard();
        }
    }
     void SetRandomTimeToSpawn()
    {
        timeToSpawn = Time.time + Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
    }

    void SpawnNiga()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(nigaPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
    public void increaseHard() {
        if (logic.playerScore > 100) {
            maxTimeBetweenSpawns = 0.1f;
        }
    }
    
}
