using UnityEngine;
using System.Collections;

public class CoinCollision : MonoBehaviour {
    private GameController gc;

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
			gc.AddPoints ();
			Destroy (this.gameObject);
		}
    }
}
