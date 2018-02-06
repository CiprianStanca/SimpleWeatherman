using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager _instance = null;
    // Use this for initialization

    public int level = 1;
    private bool isPaused = false;
    public GameObject PauseMenu;

    private float _previousTimeScale;

    public int Level
    {
        get
        {
            return level;
        }
    }

    public bool IsPaused
    {
        get
        {
            return isPaused;
        }
    }
    
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void advanceLevel()
    {
        level++;
        Debug.Log(level);
        if (level == 8)
        {
            ChangeToScene(3);
        }
    }

    public void TogglePause()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0) {
            isPaused = !isPaused;
            PauseMenu.SetActive(isPaused);
            if (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (Time.timeScale != 0)
                {
                    _previousTimeScale = Time.timeScale;
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = _previousTimeScale;
                }
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("I'm alive still");
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
	}

    public void ChangeToScene(int sceneIndex)
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
}
