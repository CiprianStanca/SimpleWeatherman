using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private NavMeshAgent agent;
    //public GameObject player;

    private GameObject target;
    private bool hasJob; // this does not consider the player tracking

    //public GameObject locationData;
    //private TargetLocations targetLocations;

    private Animator anim;
    private EnemyData enemyData;
    private EnemyHealth healthData;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = null;
        anim = GetComponentInChildren<Animator>();
        anim.SetBool("isRunning", false);
        anim.SetBool("isDead", false);

        healthData = GetComponent<EnemyHealth>();
        enemyData = GetComponent<EnemyData>();
    }
    void Start ()
    {
        //targetLocations = locationData.GetComponent<TargetLocations>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (healthData.IsAlive())
        {
            if (target != null)
            {
                agent.destination = target.transform.position;
                anim.SetBool("isRunning", true);
                agent.speed = enemyData.runSpeed;
            }
            else
            if (!hasJob) // doesnt have anything to do
            {
                agent.destination = TargetLocations.Instance.GiveMeRandomTarget().position;
                hasJob = true;
                anim.SetBool("isRunning", false);
                agent.speed = enemyData.walkSpeed;
            }

            if (PathComplete() && hasJob)
            {
                agent.destination = TargetLocations.Instance.GiveMeRandomTarget().position;
                hasJob = true;
            }
        }
	}

    public void LostTarget()
    {
        target = null;
    }

    public void FoundTarget(GameObject obj)
    {
        target = obj;
        hasJob = false;
    }

    public GameObject PassTarget()
    {
        return target;
    }


    protected bool PathComplete()
    {
        if (Vector3.Distance(agent.destination, agent.transform.position) <= agent.stoppingDistance)
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
            {
                return true;
            }
        }

        return false;
    }
}
