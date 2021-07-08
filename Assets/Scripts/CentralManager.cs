using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralManager : MonoBehaviour
{
    public  GameObject gameManagerObject;
	private  GameManager gameManager;
	public  static  CentralManager centralManagerInstance;
    // add reference to PowerupManager
    public  GameObject powerupManagerObject;
    private  PowerupManager powerUpManager;

    void  Awake()
    {
		centralManagerInstance  =  this;
	}

    // Start is called before the first frame update
    void Start()
    {
        gameManager  =  gameManagerObject.GetComponent<GameManager>();
        // instantiate in start
        powerUpManager  =  powerupManagerObject.GetComponent<PowerupManager>();
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

   


    public  void  consumePowerup(KeyCode k, GameObject g){
        powerUpManager.consumePowerup(k,g);
    }

    public  void  addPowerup(Texture t, int i, ConsumableInterface c){
        powerUpManager.addPowerup(t, i, c);
    }

}
