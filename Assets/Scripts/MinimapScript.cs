using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour {

    public GameObject target;
    private Vector3 movement;
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        movement = target.transform.position;
        movement.y = this.transform.position.y;
        this.transform.position = movement;
        
	}
}
