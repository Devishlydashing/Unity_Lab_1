using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDebris : MonoBehaviour
{
    // public GameConstants gameConstants;
    public GameObject prefab;

    // Start is called before the first frame update
    void  Start()
    {
        // for(int x = 0; x<gameConstants.spawnNumberOfDebris; x++)
        for(int x = 0; x<10; x++)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
    void Update(){}
}
