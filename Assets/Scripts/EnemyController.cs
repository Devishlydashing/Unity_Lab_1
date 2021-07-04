using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class EnemyController : MonoBehaviour
{
	public  GameConstants gameConstants;
	private  int moveRight;
	private  float originalX;
	private  Vector2 velocity;
	private  Rigidbody2D enemyBody;
	// public  static  event  gameEvent OnPlayerDeath;
    // public  static  CentralManager centralManagerInstance;
	void  Start()
	{
		enemyBody  =  GetComponent<Rigidbody2D>();
		
		// get the starting position
		originalX  =  transform.position.x;
	
		// randomise initial direction
		moveRight  =  Random.Range(0, 2) ==  0  ?  -1  :  1;
		
		// compute initial velocity
		ComputeVelocity();
        // subscribe to player event
        GameManager.OnPlayerDeath  +=  EnemyRejoice;

	}
	
	void  ComputeVelocity()
	{
			velocity  =  new  Vector2((moveRight) *  gameConstants.maxOffset  /  gameConstants.enemyPatroltime, 0);
	}
  
	void  MoveEnemy()
	{
		enemyBody.MovePosition(enemyBody.position  +  velocity  *  Time.fixedDeltaTime);
	}

	void  Update()
	{
		if (Mathf.Abs(enemyBody.position.x  -  originalX) <  gameConstants.maxOffset)
		{// move gomba
			MoveEnemy();
		}
		else
		{
			// change direction
			moveRight  *=  -1;
			ComputeVelocity();
			MoveEnemy();
		}
	}

    void  OnTriggerEnter2D(Collider2D other){
		// check if it collides with Mario
		if (other.gameObject.tag  ==  "Player"){
			// check if collides on top
			float yoffset = (other.transform.position.y  -  this.transform.position.y);
			if (yoffset  >  0.75f){
				KillSelf();
			}
			else{
                // hurt player
				CentralManager.centralManagerInstance.damagePlayer();
			}
		}
	}

    void  KillSelf(){
		// enemy dies
		CentralManager.centralManagerInstance.increaseScore();
		StartCoroutine(flatten());
		Debug.Log("Kill sequence ends");
	}

    IEnumerator  flatten(){
		Debug.Log("Flatten starts");
		int steps =  5;
		float stepper =  1.0f/(float) steps;

		for (int i =  0; i  <  steps; i  ++){
			this.transform.localScale  =  new  Vector3(this.transform.localScale.x, this.transform.localScale.y  -  stepper, this.transform.localScale.z);

			// make sure enemy is still above ground
			this.transform.position  =  new  Vector3(this.transform.position.x, gameConstants.groundSurface  +  GetComponent<SpriteRenderer>().bounds.extents.y, this.transform.position.z);
			yield  return  null;
		}
		Debug.Log("Flatten ends");
		this.gameObject.SetActive(false);
		Debug.Log("Enemy returned to pool");
		yield  break;
	}

    // animation when player is dead
    void  EnemyRejoice()
    {
        GetComponent<Animator>().SetBool("playerIsDead", true);
        velocity = Vector3.zero;
        GameManager.OnPlayerDeath -= EnemyRejoice;
    }

    void OnDestroy()
    {
        //unsubscribe from player event
        GameManager.OnPlayerDeath -= EnemyRejoice;
    }

}









// public class EnemyController : MonoBehaviour
// {
//     private float originalX;
//     private float maxOffset = 10.0f;
//     private float enemyPatroltime = 2.0f;
//     private int moveRight = -1;
//     private Vector2 velocity;

//     private Rigidbody2D enemyBody;

//     // Start is called before the first frame update
//     void Start()
//     {
//         enemyBody = GetComponent<Rigidbody2D>();
//         // get the starting position
//         originalX = transform.position.x;
//         ComputeVelocity();
//     }
    
//     void ComputeVelocity(){
//         velocity = new Vector2((moveRight)*maxOffset / enemyPatroltime, 0);
//     }

//     void MoveGomba(){
//         // original_position_vector + velocity_vector * delta_time
//         enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         // If enemy is within the maxOffset range
//         if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
//         {
//             // move gomba
//             MoveGomba();
//         }
//         else{ // Enemy is at the boundary of travellable range. Will change direction and travel back.
//             // change direction
//             moveRight *= -1;
//             ComputeVelocity();
//             MoveGomba();
//         }
//     }

//     // Since the Enemy object has been flagged as a Trigger. 
//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.gameObject.CompareTag("Player"))
//         {
//             Debug.Log("Collided with Mario!");
//         }
//     }
// }
