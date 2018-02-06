using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public GameObject[] locationData = new GameObject[8];
    public GameObject[] objectType = new GameObject[2];
    private float delay=0.6f;
    private bool spawned = false;
    // Use this for initialization

    public GameObject rain;
	void Start ()
    {
        rain.SetActive(LevelManager.Instance.levelInfo[GameManager.Instance.Level].RainOn);
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        delay -= Time.deltaTime;
        if(delay <=0 && !spawned)
        {
            SpawnObjects();
        }
	}

    private void SpawnObjects()
    {
        spawned = true;
        int asteroidNumber = locationData[GameManager.Instance.Level].transform.childCount;
        for(int i = 0; i < asteroidNumber; i++)
        {
            Instantiate(objectType[Random.Range(0, LevelManager.Instance.levelInfo[GameManager.Instance.Level].AsteroidTypeNumber)],   // asteroid type
                locationData[GameManager.Instance.Level].transform.GetChild(i).transform);   // asteroid location
        }
    }
}
