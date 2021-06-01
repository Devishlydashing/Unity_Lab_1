using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{

    private float originalX;
    private float maxOffset = 10.0f;
    private float mushroomMovementTime = 1.75f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D mushroomBody;
    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        mushroomBody = GetComponent<Rigidbody2D>();
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
        if (hit == false){
            ComputeVelocity();
            MoveMushroom(); 
        }
        else{
            mushroomBody.MovePosition(mushroomBody.position);
        }
    }
    void  OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision detected between Pipe and Mushroom");
        if (col.gameObject.CompareTag("Pipe")){
            moveRight *= -1;
        }
        Debug.Log("Collision detected between Player and Mushroom");
        if (col.gameObject.CompareTag("Player")){
            hit = true;
        }
    }

    void OnBecameInvisible(){
        Debug.Log("Mushroom Destroyed!");
	    Destroy(gameObject);	
    }


}
