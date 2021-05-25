using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;

    private Rigidbody2D enemyBody;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
    }
    
    void ComputeVelocity(){
        velocity = new Vector2((moveRight)*maxOffset / enemyPatroltime, 0);
    }

    void MoveGomba(){
        // original_position_vector + velocity_vector * delta_time
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        // If enemy is within the maxOffset range
        if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
        {
            // move gomba
            MoveGomba();
        }
        else{ // Enemy is at the boundary of travellable range. Will change direction and travel back.
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            MoveGomba();
        }
    }

    // Since the Enemy object has been flagged as a Trigger. 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with Mario!");
        }
    }
}
