using UnityEngine;
using System.Collections;

public class CoinCollision : MonoBehaviour {
    private GameController gc;
	public int points;
	public float boostTime = 3;

    // Use this for initialization
    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();

        if (gc == null)
            Debug.Log("Problem with finding GameController");
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider col)
    {
		if (col.gameObject.tag == "Player") {
            if(this.gameObject.tag == "BoosterCoin")
            {
				StartCoroutine(GameObject.Find("Snowboard").GetComponent<Snowboard>().Boost(boostTime));
            }
            else
            {
                gc.AddPoints(points);
                Destroy(this.gameObject);
            }
		}
    }
}
