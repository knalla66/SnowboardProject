using UnityEngine;
using System.Collections;
using System;

public class Snowboard : MonoBehaviour {
    public float druck;
    public float moveSpeed = 700f;
    public Rigidbody rb;

    private Vector3 input;
    private GameController gc;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0f, 0f, 0f); ;

        gc = GameObject.Find("GameController").GetComponent<GameController>();
        if (gc == null)
            Debug.Log("Problem with finding GameController");

    }

    void FixedUpdate()
    {
        //rb.AddForce(transform.up * druck); // Drückt Objekt gegen den Boden wenn im Minus Bereich; 7,76

        /*
         * if(Input.GetKey(KeyCode.W))
        {
            if(rb.velocity.magnitude < 3)
                rb.AddForce(transform.forward * 800f * Time.deltaTime);
        }
		*/
		if(rb.velocity.magnitude < 3)
			rb.AddForce(transform.forward * 800f * Time.deltaTime);
		
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 1f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -1f, 0f);
        }
		if (Input.GetKeyDown(KeyCode.Space))
        {
			rb.velocity = new Vector3(0, 4 , 0); // bleibt stehen bei sprung
        }
        //print(rb.velocity.magnitude);
    }
}
