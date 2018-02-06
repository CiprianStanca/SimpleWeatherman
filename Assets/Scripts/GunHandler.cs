using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHandler : MonoBehaviour {

    public GameObject activeGun;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // tell gun to fire.

            if(activeGun != null)
            {
                //activeGun.Fire();
            }
        }
	}
}
