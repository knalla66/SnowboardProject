using UnityEngine;
using System.Collections;
using System;

public class PointCounter : MonoBehaviour {
    private GameController gc;
    

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();

        if(gc == null)
            Debug.Log("Problem with finding GameController");
        
    }
	
	// Update is called once per frame
	void Update () {
        gc.AddPoints();
    }
}
