using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public GameObject secondaryLight;
    public GameObject player;

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    Light faceLight;
    float effectsDisplayTime = 0.2f;


    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        faceLight = secondaryLight.GetComponent<Light>();
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }


    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
        faceLight.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;
        faceLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        

        shootRay.origin = transform.position;
        shootRay.direction = player.transform.forward;
        //Debug.DrawRay(shootRay.origin, shootRay.direction*40, new Color(1f,0f,0f,1f),2f);

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            
            //Debug.DrawLine(shootRay.origin, shootHit.collider.transform.position, new Color(1f, 0f, 0f), 1f);
            EnemyHealth enemyHealth = shootHit.collider.transform.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                Debug.Log("HIT");
                gunLine.SetPosition(1, shootHit.point);
            }
            else
            {
                Debug.Log("NO ENEMY");
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
            //gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            Debug.Log("not found anything on the layer");
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}

