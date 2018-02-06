using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// singleton

public class GameManager_Article : MonoBehaviour {

    public static GameManager_Article _instance = null;

    public static float wordsSpawned = 0;
    public static float playerReward = 0;
    public static int wordsDestroyed = 0;
    public static float wordsAccuracy;
    private static bool spawnerFinished = false;
    private static int misfirePresses = 0;

    public GameObject LostGameUI;
    public GameObject WonGameUI;
    public GameObject UI;

    // Use this for initialization
    public void ResetEverything()
    {
        wordsSpawned = 0;
        playerReward = 0;
        wordsDestroyed = 0;
        wordsAccuracy = 0;
        spawnerFinished = false;
        misfirePresses = 0;
    }

    void Start ()
    {
        ResetEverything();
	}

	
	// Update is called once per frame
	void Update ()
    {
        if(spawnerFinished)
        {
            // wait for all words to be destroyed
            if (wordsDestroyed == LevelManager.Instance.levelInfo[GameManager.Instance.Level].MaxNumberOfItems)
            {
                spawnerFinished = false;
                //wordsDestroyed = 0;
                // all words have been destroyed
                //GameManager.Instance.advanceLevel();
                //GameManager.Instance.ChangeToScene(2);

                if(CalculateAccuracy() >= 70)
                {
                    // game won
                    UI.SetActive(false);
                    WonGameUI.SetActive(true);
                }
                else
                {
                    UI.SetActive(false);
                    // game lost
                    LostGameUI.SetActive(true);
                }
            }
        }

	}

    public void AddWord()
    {
        wordsSpawned++;
    }

    public void HitWord(float reward)
    {
        playerReward += reward;
        wordsDestroyed++;
    }

    public void WordDestroyed()
    {
        wordsDestroyed++;
    }

    public int CalculateAccuracy()
    {
        int percentage;

        if (wordsDestroyed > 0)
        {
            if (playerReward == 0)
            {
                return 0;
            }
            percentage = (int)((playerReward / (wordsDestroyed + misfirePresses)) * 100);
        }
        else return 100;
        
        return percentage;
    }

    public void Misfire()
    {
        misfirePresses++;
    }

    public int NumberOfWords
    {
        get
        { 
            return (int)wordsSpawned;
        }
    }

    public int WordsDestroyed
    {
        get
        {
            return (int)wordsDestroyed;
        }
    }

    private void Awake()
    {
        if(_instance != null && _instance !=this)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
    }

    public static GameManager_Article Instance
    {
        get
        {
            return _instance;
        }
    }

    public void Reset()
    {
        // reset important values
        wordsSpawned = 0;
        wordsDestroyed = 0;
        wordsAccuracy = 0;
        playerReward = 0;
        spawnerFinished = false;
    }

    public void SpawnerIsDone()
    {
        spawnerFinished = true;
    }
}
