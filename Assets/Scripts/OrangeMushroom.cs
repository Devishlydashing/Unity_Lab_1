using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class OrangeMushroom : MonoBehaviour, ConsumableInterface
{
    public GameConstants gameConstants;
	public  Texture t;

    public void Start()
    {

    }
	public  void  consumedBy(GameObject player){
		// give player jump boost
        gameConstants.playerMaxJumpSpeed *= 2;
		// player.GetComponent<PlayerController>().playerMaxSpeed  *=  2;
		StartCoroutine(removeEffect(player));
	}

	IEnumerator  removeEffect(GameObject player){
		yield  return  new  WaitForSeconds(5.0f);
        gameConstants.playerMaxJumpSpeed /= 2;
		// player.GetComponent<PlayerController>().playerMaxSpeed  /=  2;
	}

    void  OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player")){
            // update UI
            CentralManager.centralManagerInstance.addPowerup(t, 1, this);
            GetComponent<Collider2D>().enabled  =  false;
        }
    }
}