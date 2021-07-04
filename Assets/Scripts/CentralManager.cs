using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralManager : MonoBehaviour
{
    public  GameObject gameManagerObject;
	private  GameManager gameManager;
	public  static  CentralManager centralManagerInstance;

    void  Awake()
    {
		centralManagerInstance  =  this;
	}

    // Start is called before the first frame update
    void Start()
    {
        gameManager  =  gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void  damagePlayer(){
	    Debug.Log("Central Manager: damagePlayer()");
        gameManager.damagePlayer();
    }

    public  void  increaseScore()
    {
        Debug.Log("Central Manager: increaseScore()");
		gameManager.increaseScore();
	}
}
