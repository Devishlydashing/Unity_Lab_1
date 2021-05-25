using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{

    private float originalX;
    private float maxOffset = 2.0f;
    private float cloudMovementTime = 0.75f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D cloudBody;

    void Start()
    {
        cloudBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
    }
    void ComputeVelocity(){
        velocity = new Vector2((moveRight)*maxOffset / cloudMovementTime, 0);
    }
    void MoveCloud(){
        cloudBody.MovePosition(cloudBody.position + velocity * Time.fixedDeltaTime);
    }


    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(cloudBody.position.x - originalX) < maxOffset)
        {// move cloud
            MoveCloud();
        }
        else{
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            MoveCloud();
        }
    }
}
