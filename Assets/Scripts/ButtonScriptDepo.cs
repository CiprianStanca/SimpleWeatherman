using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScriptDepo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reload()
    {
        Time.timeScale = 1f;
        GameManager.Instance.ReloadScene();
    }
    
    public void NextLevel()
    {
        Time.timeScale = 1f;
        GameManager.Instance.advanceLevel();
        GameManager.Instance.ChangeToScene(1);
    }
}
