using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private AudioSource fire;
    private Rigidbody2D fireBody;
    // private EdgeCollider fireEdge;
    // Start is called before the first frame update
    void Start()
    {
        fire = GetComponent<AudioSource>();
        fireBody = GetComponent<Rigidbody2D>();
        // fireBody.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            fire.Play();
            Debug.Log("Mario Roasting!");
            
        };
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            fire.Stop();
            Debug.Log("Mario is out of the fire!");
            // fireEdge.Destroy();
        };
    }
}
