using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float attackDelay = 1f;
    private int attackDamage;

    private GameObject player;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private float timer;
    private bool playerInRange;

	// Use this for initialization
	void Start ()
    {
        attackDamage = this.transform.parent.GetComponent<EnemyData>().attackValue;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = this.transform.parent.GetComponent<EnemyHealth>();
	}


    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject == player)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;
        if(timer >= attackDelay && playerInRange && enemyHealth.currentHealth>0)
        {
            Attack();
        }
	}

    private void Attack()
    {
        timer = 0f;
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
