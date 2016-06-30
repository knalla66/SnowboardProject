using UnityEngine;
using System.Collections;
using System;

public class Snowboard : MonoBehaviour {
    public float druck;
    public float moveSpeed = 700f;
    public Rigidbody rb;

	private float hori;
	private float vert;
	private Vector3 input;
    private GameController gc;
	private GameObject pMenu; //Pause Menu
	private float timerPause = 0f; //Timer to check for PauseMenu
	private bool started = false;
    private bool active = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0f, 0f, 0f);
		hori = 0f; vert = 0f;

        gc = GameObject.Find("GameController").GetComponent<GameController>();
		pMenu = GameObject.Find ("PauseMenu");
		pMenu.SetActive (false);

        if (gc == null)
            Debug.Log("Problem with finding GameController");

    }

	void OnGUI(){
		GUI.color = Color.red;
		GUI.Label (new Rect (25, 25, 400, 25), "Horizontal " + hori); 
		GUI.Label (new Rect (25, 50, 400, 25), "Vertical " + vert);
	} 

    void FixedUpdate()
    {
        if (active)
        {
            hori = Input.GetAxis("Horizontal");
            vert = Input.GetAxis("Vertical");
            Debug.Log("Horizontal: " + hori + "Vertical: " + vert);
     //       Debug.Log(started);
     //       Debug.Log(timerPause);
			Debug.Log(pMenu);

            if (hori != 0f || vert != 0f) // TODO: Problem bei Navigation man müsste mit beiden Füßen gleichzeitig abspringen damit er auf dem jeweiligen Punkt bleibt 
            {
                timerPause = 0f;
                started = false;
            }
            else if (started)
                timerPause += Time.deltaTime; //Falls geprungen hochzählen 

            if (timerPause > 1.5f)
            {
                pMenu.SetActive(true);
                started = false;
            }

            if (rb.velocity.magnitude < 3) //Limit speed
                rb.AddForce(transform.forward * 600f * Time.deltaTime);


            transform.Rotate(0, hori, 0);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector3(0, 4, 0); // bleibt stehen bei sprung
                started = true;
                timerPause += Time.deltaTime;
            }
        }
    }
     
    public void setDeactive()
    {
        active = false; 
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }       
    
    public void setActive()
    {
        active = true;
        timerPause = 0f;
        rb.constraints = RigidbodyConstraints.None;
    } 
}
