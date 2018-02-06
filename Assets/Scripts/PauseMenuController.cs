using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    // Use this for initialization
    //[SerializeField]
    //public Transform canvas;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        this.gameObject.SetActive(false);
    }
    
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
