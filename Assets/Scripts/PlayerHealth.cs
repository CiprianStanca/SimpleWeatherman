using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public Animator anim;
    public PlayerController playerController;
    public PlayerShooting playerShooting;

    public int startingHealth = 100;
    public int currentHealth;

    public Slider healthSlider;
    public Image damageImage;
    public float imageFadeSpeed = 5f;
    public Color flashColour = new Color(1f,0f,0f,0.1f);

    bool isDead;
    bool damaged;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        isDead = false;
        damaged = false;
        currentHealth = startingHealth;
    }

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, imageFadeSpeed*Time.deltaTime);
        }
        damaged = false;
	}

    public void TakeDamage(int value)
    {
        Debug.Log("Took Damage");
        damaged = true;
        currentHealth -= value;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("I'm Dead");

        isDead = true;
        playerShooting.DisableEffects();
        anim.SetTrigger("isDead");
        playerController.enabled = false;
        playerShooting.enabled = false;
    }
}
