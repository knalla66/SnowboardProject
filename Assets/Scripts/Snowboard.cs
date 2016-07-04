using UnityEngine;
using System.Collections;
using System;

public class Snowboard : MonoBehaviour {
    public float druck;
    public float moveSpeed = 700f;
    public float maxVelocity = 3f;
    public float jumpForce = 3f;
    public Rigidbody rb;

	private float hori;
	private float vert;
    private float velocity;
    private float distToGround;
	private Vector3 input;
    private GameController gc;
	private GameObject pMenu; //Pause Menu
	private float timerPause = 0f; //Timer to check for PauseMenu

	private bool started = false; //Wird gestartet sobald gesprungen wurde. Dient zur feststellung ob Spieler noch am Board ist
    private bool active = true; //Wenn nicht active, pausiert Snowboarder
    private bool onEnd = false; //True wenn Snowboarder am Ende angelangt ist
    private bool gameOver = false; //True wenn Spiel verloren ist
    // For Countdown
    private bool showCountdown = false;
    private string countdown; 

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

       // StartCoroutine(GetReady());

    }

	void OnGUI(){
		GUI.color = Color.red;
		GUI.Label (new Rect (25, 200, 400, 25), "Horizontal " + hori); 
		GUI.Label (new Rect (25, 250, 400, 25), "Vertical " + vert);
        GUI.Label (new Rect (25, 300, 400, 25), "Velocity " + velocity);
	} 

    void FixedUpdate()
    {
        if (active)
        {
            hori = Input.GetAxis("Horizontal");
            vert = Input.GetAxis("Vertical");
            velocity = rb.velocity.magnitude;

            //--------------- Pause Menu Timer ---------------
            if (hori != 0f || vert != 0f)
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

            //------------------ Game Over -------------------
            if(gc.getCountdown() <= 0f)
            {
                this.gameOver = true;
                setDeactive();
                pMenu.SetActive(true);
            }

            //------------------ Physics------------------------
           if (rb.velocity.magnitude < maxVelocity) //Limit speed
                rb.AddForce(transform.forward * moveSpeed * Time.deltaTime);

           transform.Rotate(0, hori, 0);          

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                Vector3 force = transform.up * jumpForce;
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                started = true;
                timerPause += Time.deltaTime;
            }
        }
    }
    // Booster
	public IEnumerator Boost(float boost)
    {
        moveSpeed = 1500f;
        maxVelocity = 10f;
		yield return new WaitForSeconds(boost);
        moveSpeed = 700;
        maxVelocity = 3f;
    }

    public IEnumerator GetReady()
    {
        setDeactive();
        gc.setStartGo("3");
        yield return new WaitForSeconds(0.7f);

        gc.setStartGo("2");
        yield return new WaitForSeconds(0.7f);

        gc.setStartGo("1");
        yield return new WaitForSeconds(0.7f);

        gc.setStartGo("GO");
        yield return new WaitForSeconds(0.4f);

        gc.setStartGo(null);
        setActive();
    }

    public void setDeactive()
    {
        active = false; 
		gc.startCountdown (false);
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }       
    
    public void setActive()
    {
        active = true;
        timerPause = 0f;
		gc.startCountdown(true);
        rb.constraints = RigidbodyConstraints.None;
    } 

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 0.1f);
    }

    public void activatePauseMenu(bool act) //Um PausenMenü einzublenden
    {
        pMenu.SetActive(act);
    }

    public void setOnEnd() // Setzen ob am Ziel angelangt
    {
        onEnd = true;
    }

    public bool getOnEnd() //Ob am Ziel angelangt
    {
        return onEnd;
    }

    public void setGameOver(bool gameOver)
    {
        this.gameOver = gameOver;
    }

    public bool getGameOver()
    {
        return this.gameOver;
    }
}
