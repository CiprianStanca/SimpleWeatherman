using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointScript : MonoBehaviour {
    public static int index; // used to give the private identifier of the target script a unique index
    public static KeyCode[] KeyCodesArray = new KeyCode[7] { KeyCode.None, KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.I, KeyCode.O, KeyCode.P };

    public int m_index;
    private KeyCode m_KeyCode;
    // Use this for initialization

    private GameObject colObject = null;

	void Start ()
    {
        m_index = ++index;
        if(LevelManager.Instance.levelInfo[GameManager.Instance.Level].NumberOfFields == 6)
        {
            m_KeyCode = KeyCodesArray[m_index];
        }
        else
        if(LevelManager.Instance.levelInfo[GameManager.Instance.Level].NumberOfFields == 4)
        {
            m_KeyCode = KeyCodesArray[m_index + 1];
        }

        this.gameObject.transform.GetChild(2).gameObject.GetComponent<TextMesh>().text = " " + m_KeyCode;
        Debug.Log("Trigger number " + m_index + " initialised with Keycode " + m_KeyCode);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(m_KeyCode) && colObject != null)
        {
            // specific key is pressed
            Debug.Log("Trigger number " + m_index + " activated");
            if (colObject.tag == "CollisionCheck")
            {
                GameManager_Article.Instance.HitWord(1f);
                Destroy(colObject);

                Debug.Log("Object Destroyed");
            }
        }
        if(Input.GetKeyDown(m_KeyCode) && colObject == null)
        {
            // oh we got a button masher
            GameManager_Article.Instance.Misfire();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        colObject = col.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        colObject = null;
    }
}
