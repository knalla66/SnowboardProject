using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private int points = 0;
    private Text pointTxt;
	private Text timerTxt;
	private Image loadingbar;

    private float timer;
    public float countdown;
    private bool countdownRunning = false;

    // Use this for initialization
    void Start () {
		pointTxt = GameObject.Find("PointsTopRight").GetComponent<Text>();
		timerTxt = GameObject.Find("TimerTopLeft").GetComponent<Text>();
		loadingbar = GameObject.Find ("LoadingBar").GetComponent<Image>();

        UpdatePoints();
	}
	
	// Update is called once per frame
	void Update () {
		if (countdownRunning) {
            timer += Time.deltaTime; //Total Time for Highscore
            countdown -= Time.deltaTime; //Countdown 
			timerTxt.text = countdown.ToString ("0.0");
			loadingbar.fillAmount = countdown / 30;

			if (countdown >= 15)
				loadingbar.color = Color.Lerp (Color.yellow, Color.green, ((countdown - 15) / 15)); //Von grün zu gelb; 1:grün; 2:gelb
			else 
				loadingbar.color = Color.Lerp (Color.red, Color.yellow, countdown / 15);
		}
	}

	public void AddPoints(int points)
    {
        //points++;
		this.points = points + this.points;
        UpdatePoints();
    }

    void UpdatePoints()
    {
        pointTxt.text = points.ToString();
    }

    public int getPoints()
    {
        return points;
    }

    public void AddTime()
    {
        countdown += 5f;
    }

	public void startTimer(bool start){ //if false: stop timer
        countdownRunning = start;
	}

    public float getTime()
    {
        return timer;
    }
}
