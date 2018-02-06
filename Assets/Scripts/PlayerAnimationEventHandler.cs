using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour {

    public GameObject gameLostUI;
    public GameObject userInterface;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void TriggerGameLostUI()
    {
        userInterface.SetActive(false);
        gameLostUI.SetActive(true);
        Time.timeScale = 0.2f;
    }
}
