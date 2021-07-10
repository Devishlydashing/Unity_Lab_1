using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class RedMushroom : Singleton<RedMushroom>, ConsumableInterface
{
    private float originalX;
    private float maxOffset = 10.0f;
    private float mushroomMovementTime = 1.75f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D mushroomBody;
    private bool hit = false;
    public GameConstants gameConstants;
	public  Texture t;

    public override void Awake()
    {
        base.Awake();
    }
    public void Start()
    {
        mushroomBody = GetComponent<Rigidbody2D>();
        GetComponent<Collider2D>().enabled = true;
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
        mushroomBody.AddForce(Vector2.up  *  20, ForceMode2D.Impulse);
        int rand = Random.Range(0, 1000);
        Debug.Log("Random output for mushroom direction:" + rand.ToString());
        if (rand % 2 == 0){
            moveRight = -1;
        }
        else{moveRight = 1;}
    }

    void ComputeVelocity(){
        velocity = new Vector2((moveRight)*maxOffset / mushroomMovementTime, 0);
    }
    void MoveMushroom(){
        mushroomBody.MovePosition(mushroomBody.position + velocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {   
        if (!hit){
            ComputeVelocity();
            MoveMushroom(); 
        }
        else{
            mushroomBody.MovePosition(mushroomBody.position);
        }
    }

	public  void  consumedBy(GameObject player){
		// give player jump boost
        gameConstants.playerDefaultForce += 10;
		// player.GetComponent<PlayerController>().playerMaxJumpSpeed  +=  10;
		StartCoroutine(removeEffect(player));
	}

	IEnumerator  removeEffect(GameObject player){
		yield  return  new  WaitForSeconds(5.0f);
        gameConstants.playerDefaultForce -= 10;
		// player.GetComponent<PlayerController>().playerMaxJumpSpeed  -=  10;
	}

    void  OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pipe")){
            moveRight *= -1;
        }
        if (col.gameObject.CompareTag("Player")){
            // update UI
            hit = true;
            CentralManager.centralManagerInstance.addPowerup(t, 0, this);
            GetComponent<Collider2D>().enabled  =  false;
        }
    }

    // void OnBecameInvisible(){
    //     Debug.Log("Mushroom Destroyed!");
	//     Destroy(gameObject);	
    // }

}

