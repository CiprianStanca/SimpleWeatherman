using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public int numberOfFields;

    public GameObject Separator;
    public GameObject TargetLocation;
    public GameObject SpawnPoint;
    public GameObject BoundaryLeft;
    public GameObject BoundaryRight;
    public float spawnTime;
    public float spawnSpeed;

    public GameObject SpawnItem;
    public GameObject TargetItem;

    public int numberOfItems = 0;

    private float SpawnZ;
    private float limitLeft;
    private float limitRight;

    [System.Serializable]
    private class SpawnChannels
    {
        float start, end;
        float middle;
        public SpawnChannels(float a, float b, float c)
        {
            start = a;
            end = b;
            middle = c;
        }

        public float GetEnd()
        {
            return end;
        }

        public float GetStart()
        {
            return start;
        }

        public float GetMiddle()
        {
            return middle;
        }
    }
    private SpawnChannels[] fieldArray = new SpawnChannels[10];

    void Start()
    {
        spawnTime = LevelManager.Instance.levelInfo[GameManager.Instance.Level].SpawnTime;
        GameManager_Article.Instance.Reset();
        numberOfFields = LevelManager.Instance.GetNumberOfFields(GameManager.Instance.Level);
        TargetPointScript.index = 0;
        // initialise fields based on number desired
        SpawnZ = SpawnPoint.transform.position.z;
        limitLeft = BoundaryLeft.transform.position.x;
        limitRight = BoundaryRight.transform.position.x;

        float sizeOfField = (limitRight - limitLeft) / numberOfFields;
        Debug.Log("Size of Field is " + sizeOfField);
        fieldArray[0] = new SpawnChannels(limitLeft - sizeOfField, limitLeft, (limitLeft + limitLeft - sizeOfField) / 2); // redundant entry used to create the others

        for (int i = 1; i <= numberOfFields; i++) // calculate spawn points based on number of lanes desired
        {
            fieldArray[i] = new SpawnChannels(fieldArray[i - 1].GetEnd(), fieldArray[i - 1].GetEnd() + sizeOfField, fieldArray[i - 1].GetMiddle() + sizeOfField);
            Debug.Log("Field no. " + i + " is at position: " + fieldArray[i].GetMiddle());

            //TargetPointScript.index++;
            Instantiate(TargetItem, new Vector3(fieldArray[i].GetMiddle(), 0.5f, TargetLocation.transform.position.z), Quaternion.identity);
            Instantiate(Separator, new Vector3(fieldArray[i].GetStart(), 0f, 0f), Quaternion.identity);
        }
        Instantiate(Separator, new Vector3(fieldArray[numberOfFields].GetEnd(), 0f, 0f), Quaternion.identity);

        InvokeRepeating("Spawn", 6f, spawnTime);
        InvokeRepeating("Spawn", 4.8f, spawnTime);
    }

    void Spawn()
    {
        GameManager_Article.Instance.AddWord();
        int targetField = Random.Range(1, numberOfFields + 1);
        GameObject temp = Instantiate(SpawnItem, new Vector3(fieldArray[targetField].GetMiddle(), 1f, SpawnZ), Quaternion.identity);
        temp.transform.rotation = Quaternion.Euler(90, 0, 0);
        TextMesh tmcomp = temp.GetComponent<TextMesh>();
        tmcomp.text = LevelManager.Instance.GetWordInfo(GameManager.Instance.Level)[numberOfItems];
        numberOfItems++;
    }

    void Update()
    {
        if (numberOfItems >= LevelManager.Instance.levelInfo[GameManager.Instance.Level].MaxNumberOfItems)
        {
            Debug.Log(GameManager_Article.Instance.NumberOfWords + "  " + LevelManager.Instance.levelInfo[GameManager.Instance.Level].MaxNumberOfItems);
            CancelInvoke(methodName: "Spawn");
            CancelInvoke(methodName: "Spawn");
            GameManager_Article.Instance.SpawnerIsDone();
            // tell article manager i'm done here
            

            // placeholder scene change
            //GameManager.Instance.advanceLevel();
           // GameManager.Instance.ChangeToScene(1);
        }

    }

    public void StopSpawning()
    {
        
    }
}
