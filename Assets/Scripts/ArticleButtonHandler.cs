using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticleButtonHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void GameWonButton()
    {
        GameManager_Article.Instance.ResetEverything();
        GameManager.Instance.ChangeToScene(sceneIndex: 2);
    }

    public void GameLostButton()
    {
        GameManager_Article.Instance.ResetEverything();
        GameManager.Instance.ReloadScene();
    }
}
