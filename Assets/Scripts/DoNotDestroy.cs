﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour {

	// Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}