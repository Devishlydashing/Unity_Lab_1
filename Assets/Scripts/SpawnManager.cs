using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameConstants gameConstants;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnEnemyDeath += spawnNewEnemy;
        // SceneManager.sceneLoaded += startSpawn;
        startSpawn();
        for (int j = 1; j< 2; j++){
            spawnFromPooler(ObjectType.greenEnemy);
        } 
    }

    void startSpawn()
    {
        for (int j = 0; j < 2; j++){
            spawnFromPooler(ObjectType.gombaEnemy);
        }
    }

    void spawnFromPooler(ObjectType i)
    {
        GameObject item = ObjectPooler.SharedInstance.GetPooledObject(i);

        if (item != null)
        {
            //set position
            // item.transform.localScale = new Vector3(1, 1, 1); 
            item.transform.position = new Vector3(Random.Range(-4.5f, 4.5f), gameConstants.groundDistance + item.GetComponent<SpriteRenderer>().bounds.extents.y, 0);
            item.SetActive(true);
        }
        else
        {
            Debug.Log("Not enough items in the pool!");
        }
    }

    public void spawnNewEnemy()
    {
        ObjectType i = Random.Range(0,2) == 0 ? ObjectType.gombaEnemy : ObjectType.greenEnemy;
        spawnFromPooler(i);
    }

    void OnDestroy()
    {
        GameManager.OnEnemyDeath -= spawnNewEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
