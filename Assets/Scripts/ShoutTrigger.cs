using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoutTrigger : MonoBehaviour {

    private EnemyController parentEnemy;
    private EnemyController colEnemy;
    // Use this for initialization

    void Awake()
    {
        parentEnemy = this.gameObject.GetComponentInParent<EnemyController>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log("SHOUT REACHED COMPATRIOT");
            colEnemy = col.gameObject.GetComponent<EnemyController>();
            GameObject target = parentEnemy.PassTarget();
            if (target != null)
            {
                colEnemy.FoundTarget(target);
                Debug.Log("SHOUT REACHED COMPATRIOT");
            }
        }
    }
}
