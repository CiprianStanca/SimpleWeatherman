using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTrigger : MonoBehaviour {

    public GameObject gameWonUI;
    public GameObject UI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            // player has reached the destination
            gameWonUI.SetActive(true);
            UI.SetActive(false);
            Time.timeScale = 0.2f;

        }
    }
}
