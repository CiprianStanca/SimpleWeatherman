using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {

    public float speed;
    public GameObject boundary = null;

	// Use this for initialization
	void Start ()
    {
        boundary = GameObject.FindWithTag("BoundaryBottom");
        if(boundary == null)
        {
            Debug.LogError("Could not find BoundaryBottom Object!");
        }
        Debug.Log("Spawned");
        speed = LevelManager.Instance.GetSpeed(GameManager.Instance.Level);

	}

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        if (boundary != null) { 
            if (this.transform.position.z < boundary.transform.position.z - 6f)
            {
                GameManager_Article.Instance.WordDestroyed();
                Destroy(this.gameObject);
            }
        }
	}
}
