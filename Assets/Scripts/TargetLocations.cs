using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocations : MonoBehaviour {

    private static TargetLocations _instance = null;

    public Transform[] targetLocations;
    // Use this for initialization

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        _instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    public static TargetLocations Instance
    {
        get
        {
            return _instance;
        }
    }
    void Start ()
    {
        targetLocations = new Transform[this.gameObject.transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            targetLocations[i] = transform.GetChild(i);
        }
        Debug.Log(targetLocations.Length + " FOUND LOCATIONS");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public Transform GiveMeRandomTarget()
    {

        if (this.gameObject.transform.childCount != 0)
        {
            int r = Random.Range((int)0, targetLocations.Length-1);
            //Debug.Log(r + " my random");
            return targetLocations[r];
        }
        else
        {
            //Debug.Log("Something Went Wrong with the targets");
            return null;
        }
    }
}
