using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventTransmitter : MonoBehaviour {

    // Use this for initialization
    private EnemyHealth health;

    private void Awake()
    {
        health = this.gameObject.transform.parent.gameObject.GetComponent<EnemyHealth>();
    }

    public void StartSinking()
    {
        //Debug.Log("sending sink request");
        health.StartSinking();
    }
}
