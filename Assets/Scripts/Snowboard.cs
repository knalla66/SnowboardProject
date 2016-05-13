using UnityEngine;
using System.Collections;
using System;

public class Snowboard : MonoBehaviour {
    public float druck;
    public Rigidbody rb;


    private GameController gc;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0f, -0f, -0.3f); ;

        gc = GameObject.Find("GameController").GetComponent<GameController>();
        if (gc == null)
            Debug.Log("Problem with finding GameController");

    }

    void FixedUpdate()
    {
        rb.AddForce(transform.up * druck); // Drückt Objekt gegen den Boden wenn im Minus Bereich; 7,76
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * 400f * Time.deltaTime);
        }
            

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 1f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, -1f, 0f);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Coin") // Collision mit Coin
        {
            gc.AddPoints();
        }
    }
}
