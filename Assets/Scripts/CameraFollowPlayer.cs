using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

    [SerializeField]
	public GameObject player;
    [SerializeField]
    public GameObject cam;

    private Vector3 previousPlayerPosition;
    private Vector3 newPlayerPosition;

    private Vector3 adjustment;

	// Use this for initialization
	void Start () 
	{
        previousPlayerPosition = player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        newPlayerPosition = player.transform.position;
        adjustment = newPlayerPosition - previousPlayerPosition;

        cam.transform.Translate(adjustment);
        previousPlayerPosition = newPlayerPosition;
	}
}
