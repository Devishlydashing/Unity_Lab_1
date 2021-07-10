using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBrick : Singleton<BreakBrick>
{
    // private bool broken = false;
    public GameObject prefab;
    public GameObject coin;

    public override void Awake()
    {
        base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  OnTriggerEnter2D(Collider2D col){
        Debug.Log("Breakable Brick: Trigger detected");
        // if (col.gameObject.CompareTag("Player") &&  !broken){
        if (col.gameObject.CompareTag("Player")){
            Debug.Log("Breakable Brick: In if Loop");
            // broken  =  true;
            prefab.SetActive(true);
            // assume we have 5 debris per box
            for (int x =  0; x<5; x++){
                Instantiate(prefab, transform.position, Quaternion.identity);
            }
            
            CentralManager.centralManagerInstance.increaseScore();
            CentralManager.centralManagerInstance.spawnNewEnemy();


            gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled  =  false;
            gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled  =  false;
            GetComponent<AudioSource>().Play();
            coin.SetActive(true);
            GetComponent<EdgeCollider2D>().enabled  =  false;
        }
    }



}
