using UnityEngine;
using System.Collections;

public class CheckpointCollision : MonoBehaviour {

    private GameController gc;
    private GameObject pMenu; //Pause Menu
	private GameObject snowboard;
    // Use this for initialization
	public float checkpointAdd;

    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
		snowboard = GameObject.Find("Snowboard");
        pMenu = GameObject.Find("PauseMenu");

        if (gc == null)
            Debug.Log("Problem with finding GameController");
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("PlayerCol");
			if (gameObject.tag == "Goal") {
				Debug.Log ("GoalCol");
				snowboard.GetComponent<Snowboard> ().setOnEnd ();
				int highscorePt = PlayerPrefs.GetInt ("highscorePoints", 0);
				if (highscorePt == 0 || gc.getPoints () >= highscorePt) {
					PlayerPrefs.SetInt ("highscorePoints", gc.getPoints ());
					PlayerPrefs.SetFloat ("highscoreTime", gc.getTime ());
					PlayerPrefs.Save ();
				}
				snowboard.GetComponent<Snowboard> ().activatePauseMenu (true);
			} else if (gameObject.tag == "Start")
				gc.startCountdown (true);
            else    
				gc.AddCountdown(checkpointAdd);
        }
    }
}
