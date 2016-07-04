using UnityEngine;
using System.Collections;

public class CheckpointCollision : MonoBehaviour {

    private GameController gc;
    private GameObject pMenu; //Pause Menu
    // Use this for initialization
    void Start () {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
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
            if(gameObject.tag == "Goal")
            {
                col.GetComponent<Snowboard>().setOnEnd();
                int highscorePt = PlayerPrefs.GetInt("highscorePoints", 0);
                if (highscorePt == 0 || gc.getPoints() >= highscorePt)
                {
                    PlayerPrefs.SetInt("highscorePoints", gc.getPoints());
                    PlayerPrefs.SetFloat("highscoreTime", gc.getTime());
                    PlayerPrefs.Save();
                }
                pMenu.SetActive(true);
            }
            else if (gameObject.tag == "Start")
                gc.startTimer(true);
            else    
                gc.AddTime();
        }
    }
}
