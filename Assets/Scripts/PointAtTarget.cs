using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtTarget : MonoBehaviour {

    public GameObject target;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*Vector3 playerToTarget = target.transform.position - this.transform.position;
        playerToTarget.y = 0;
        Quaternion newRotation = Quaternion.LookRotation(playerToTarget);
        this.transform.Rotate(newRotation.eulerAngles);
        */
        this.transform.LookAt(target.transform);
    }
}
