using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    //public GameObject source;
    //private TargetLocations targetLocs;

    public GameObject[] enemyTypes = new GameObject[10];
    public float delay=0.1f;
    private bool spawned;

    private int numberOfEnemies;
    private bool spawnContinous;
    

    private void Start()
    {
        numberOfEnemies = LevelManager.Instance.levelInfo[GameManager.Instance.Level].NumberOfEnemies;
        spawnContinous = LevelManager.Instance.levelInfo[GameManager.Instance.Level].ContinousSpawn;
    }
    void Spawn()
    {
        //targetLocs = source.GetComponent<TargetLocations>();

        for(int i = 0; i< numberOfEnemies; i++)
        {
            Transform spawnPoint = TargetLocations.Instance.GiveMeRandomTarget();
            Instantiate(enemyTypes[ Random.Range(0, enemyTypes.Length-1) ], spawnPoint.position, spawnPoint.rotation);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        delay -= Time.deltaTime;
        if (delay <= 0 && !spawned)
        {
            spawned = true;
            Spawn();
        }

        if(LevelManager.Instance.levelInfo[GameManager.Instance.Level].ContinousSpawn)
        {
            
        }
	}

    public void EnemyDown()
    {
        if (spawnContinous)
        {
            Transform spawnPoint = TargetLocations.Instance.GiveMeRandomTarget();
            Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length - 1)], spawnPoint.position, spawnPoint.rotation);
        }
    }

    
}
