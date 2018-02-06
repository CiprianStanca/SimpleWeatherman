using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpotAreaTrigger : MonoBehaviour {


    private EnemyController parentEnemy;
    // Use this for initialization
    void Awake()
    {
        parentEnemy = this.gameObject.GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // found target;
            Debug.Log("PLAYER IN RANGE");
            parentEnemy.FoundTarget(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PLAYER GOT OUT OF RANGE");
            parentEnemy.LostTarget();
        }
    }



}
