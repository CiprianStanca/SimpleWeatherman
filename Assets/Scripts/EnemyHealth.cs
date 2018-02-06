using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    private EnemyData unitInformation;
    private Rigidbody rigidBody;
    private Animator anim;
    private bool isDead;
    private bool isSinking;
    private NavMeshAgent agent;
    

    public int currentHealth;
    public float sinkSpeed;
    public float destroyTime;

    private GameObject citizenSpawner;
    

    // Use this for initialization
    private void Awake()
    {
        unitInformation = this.gameObject.GetComponent<EnemyData>();
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        citizenSpawner = GameObject.FindGameObjectWithTag("EnemySpawner");
    }
    void Start ()
    {
        currentHealth = unitInformation.startingHealth;
        isDead = false;
        isSinking = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isSinking)
        {
            transform.Translate(-Vector3.up*sinkSpeed*Time.deltaTime);
        }
	}

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if(isDead == true) // enemy cant take damage anymore and is about to disappear
        {
            return;
        }

        //play hit sound

        // deduct damage amount;
        currentHealth -= amount;

        // display some particles in hit location;

        // if no health left, begin death ceremony
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        agent.enabled = false;
        anim.SetTrigger("isDead");
    }

    public void StartSinking()
    {
        //Debug.Log("im sinking lol");
        Transform.FindObjectOfType<EnemySpawner>().GetComponent<EnemySpawner>().EnemyDown();
        rigidBody.isKinematic = true;
        rigidBody.useGravity = false;
        agent.enabled = false;
        isSinking = true;
        Destroy(this.gameObject, destroyTime);

        citizenSpawner.GetComponent<EnemySpawner>().EnemyDown();
    }

    public bool IsAlive()
    {
        return !isDead;
    }

}
