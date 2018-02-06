using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    public GameObject player;
    [SerializeField]
    public float speed = 5f;

    [SerializeField]
    public GameObject gun;

    private Rigidbody playerRigidbody;
	private Animator anim;
	private float speedX, speedZ;
    private float camRayLength = 200f;
    private int floorMask;
    private GunController gunController;


    // Use this for initialization
    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = player.GetComponent<Animator>();
        playerRigidbody = player.GetComponent<Rigidbody>();
        gunController = gun.GetComponent<GunController>();
    }

	void Start () 
	{
		
	}

    // Update is called once per frame
    void FixedUpdate () 
	{
		// transmit axis float to animator for proper animation display
		speedZ = Input.GetAxisRaw ("Horizontal");
		speedX = Input.GetAxisRaw ("Vertical");
        //transmitToAnimator(speedX, speedZ);

        translatePlayer();
        FollowMouse();
       // transmitToAnimator(speedX, speedZ);

        if(Input.GetMouseButtonDown(0))
        {
            // fire

            Fire();
        }
    }

    private void FollowMouse()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            //Debug.Log(" x " + playerToMouse.x + " z "+ playerToMouse.z);
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);

            MouseFilterMovement(playerToMouse);

        }
        else
        {
            transmitToAnimator(speedX, speedZ, 0, 0);
        }

    }

    private void MouseFilterMovement(Vector3 mousePosition)
    {
        float margin = 16.5f;
        Vector3 filteredPosition = mousePosition;

        if( (filteredPosition.x < margin && filteredPosition.x > margin * (-1)) && 
            (filteredPosition.z < margin && filteredPosition.z > margin * (-1))  )
        {
            //Debug.Log("READJUSTING MOUSE POSITION");
            // determin max min under margin;
            float maxMin = -100000f;
            if (filteredPosition.x > maxMin) maxMin = filteredPosition.x;
            if (filteredPosition.z > maxMin) maxMin = filteredPosition.z;
            filteredPosition = filteredPosition * (margin / maxMin + 0.01f);
        }

        if (filteredPosition.x > margin) filteredPosition.x = 1;
        else if (filteredPosition.x < margin * (-1)) filteredPosition.x = -1;
        else filteredPosition.x = 0;
        if (filteredPosition.z > margin) filteredPosition.z = 1;
        else if (filteredPosition.z < margin * (-1)) filteredPosition.z = -1;
        else filteredPosition.z = 0;

        float x = filteredPosition.x;
        float z = filteredPosition.z;
        //Debug.Log("########" + x + "  " + z);

        transmitToAnimator(speedX,speedZ,x,z);
    }

    private void translatePlayer()
    {
        

        Vector3 movement = new Vector3();
        movement.Set(speedZ, 0 , speedX);
        movement = movement.normalized * speed * Time.deltaTime;

        float translationX = movement.x;
        float translationZ = movement.z;
        player.transform.Translate(translationX, 0, translationZ, Space.World);
        // translationZ, 0, translationX, Space.World
    }

    private void transmitToAnimator (float vert, float hoz, float mouseVert, float mouseHoz)
	{
        //Debug.Log("speedX " + hoz + " / speedY " + vert + " / MasterX " + mouseHoz + " / MasterY " + mouseVert);
        anim.SetFloat ("speedX", hoz);
        anim.SetFloat("speedY", vert);
        anim.SetFloat("MasterY", mouseVert);
        anim.SetFloat("MasterX", mouseHoz);
	}

    private void Fire()
    {
        gunController.Fire();

    }
}
