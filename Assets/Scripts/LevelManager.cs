using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager _instance;

    [SerializeField]
    public TextAsset level1;
    public TextAsset level2;
    public TextAsset level3;
    public TextAsset level4;
    public TextAsset level5;
    public TextAsset level6;
    public TextAsset level7;

    [System.Serializable]
    public class LevelInfo
    {
        // Article scene
        int numberOfFields;
        int maxNumberOfItems;
        float speed; // difficulty
        string[] level_info;
        float spawnTime;
        bool rainOn;

        // Road Back Home
        int numberOfEnemies;
        bool continousSpawn;
        int asteroidTypeNumber;

        // constructor
        public LevelInfo(int a, float c, string[] d, float g, int e, bool f, int h, bool rain)
        {
            numberOfFields = a;
            //maxNumberOfItems = b;
            speed = c;
            level_info = d;
            spawnTime = g;
            numberOfEnemies = e;
            continousSpawn = f;
            asteroidTypeNumber = h;
            rainOn = rain;
        }

        // methods
        public bool RainOn
        {
            get
            {
                return rainOn;
            }
        }

        public int AsteroidTypeNumber
        {
            get
            {
                return asteroidTypeNumber;
            }
        }

        public float SpawnTime
        {
            get
            {
                return spawnTime;
            }
        }

        public string[] Level_info
        {
            get
            {
                return level_info;
            }
            set
            {
                level_info = value;
            }
        }

        public int NumberOfFields
        {
            get
            {
                return numberOfFields;
            }
            set
            {
                numberOfFields = value;
            }
        }

        public int MaxNumberOfItems
        {
            get
            {
                return maxNumberOfItems;
            }
            set
            {
                maxNumberOfItems = value;
            }
        }

        public float Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
            }
        }

        public int NumberOfEnemies
        {
            get
            {
                return numberOfEnemies;
            }
        }

        public bool ContinousSpawn
        {
            get
            {
                return continousSpawn;
            }
        }
    };

    public LevelInfo[] levelInfo;

	protected void Awake ()
    {
		if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        levelInfo = new LevelInfo[10];
        Init();
        
	}

    public void Init()
    {
        // Level 1 

        /*levelInfo[1].NumberOfFields = 4;
        levelInfo[1].MaxNumberOfItems = 50;
        levelInfo[1].Speed = 6f;*/
        string[] temp = level1.text.Split(' ');
        levelInfo[1] = new LevelInfo(4, 5f, temp, 2f, 10, false, 1, false);
        levelInfo[1].MaxNumberOfItems = temp.Length;
        Debug.Log("The text is:");

        //for(int i = 0; i< temp.Length; i++)
        //{
           // Debug.Log(temp[i]);
        //}

        // Level 2
        
        /*levelInfo[2].NumberOfFields = 6;
        levelInfo[2].MaxNumberOfItems = 100;
        levelInfo[2].Speed = 8f;*/
        temp = null;
        temp = level2.text.Split(' ');
        levelInfo[2] = new LevelInfo(6, 6f, temp, 2f, 20, false, 1,true);
        levelInfo[2].MaxNumberOfItems = temp.Length;

        //Debug.Log(levelInfo[1].MaxNumberOfItems + " /// " +levelInfo[2].MaxNumberOfItems);

        // level 3
        temp = null;
        temp = level3.text.Split(' ');
        levelInfo[3] = new LevelInfo(6, 7f, temp, 1.5f, 25,false,1, false);
        levelInfo[3].MaxNumberOfItems = temp.Length;

        // level 4
        temp = null;
        temp = level4.text.Split(' ');
        levelInfo[4] = new LevelInfo(6, 8f, temp, 1.5f, 15, true,2, true);
        levelInfo[4].MaxNumberOfItems = temp.Length;

        // level 5
        temp = null;
        temp = level5.text.Split(' ');
        levelInfo[5] = new LevelInfo(6, 9f, temp, 1f, 20, true,2, false);
        levelInfo[5].MaxNumberOfItems = temp.Length;

        // level 6
        temp = null;
        temp = level6.text.Split(' ');
        levelInfo[6] = new LevelInfo(6, 9f, temp, 1f, 20, true,1, true);
        levelInfo[6].MaxNumberOfItems = temp.Length;

        // level 7
        temp = null;
        temp = level6.text.Split(' ');
        levelInfo[7] = new LevelInfo(6, 10f, temp, 0.5f, 20, true,2, true);
        levelInfo[7].MaxNumberOfItems = temp.Length;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public static LevelManager Instance
    {
        get
        {
            return _instance;
        }
    }

    public int GetNumberOfFields(int level)
    {
        return levelInfo[level].NumberOfFields;
    }
    public string[] GetWordInfo(int level)
    {
        return levelInfo[level].Level_info;
    }
    public float GetSpeed(int level)
    {
        return levelInfo[level].Speed;
    }

}
