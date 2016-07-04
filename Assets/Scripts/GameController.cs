using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private int points = 0;
    private Text pointTxt;
	private Text timerTxt;
    private Text infoTxt;
	private Image loadingbar;

    private float timer;
    public float countdown;
    private bool countdownRunning = true;

    // Use this for initialization
    void Start () {
		pointTxt = GameObject.Find("PointsTopRight").GetComponent<Text>();
		timerTxt = GameObject.Find("TimerTopLeft").GetComponent<Text>();
        infoTxt = GameObject.Find("InfoText").GetComponent<Text>();
        loadingbar = GameObject.Find ("LoadingBar").GetComponent<Image>(); //Findet loadingbar nicht
        
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
                loadingbar.color = Color.Lerp(Color.red, Color.yellow, countdown / 15);
				
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

	public void AddCountdown(float checkpointTime)
	{
		countdown += checkpointTime;
	}

	public void startCountdown(bool start){ //if false: stop timer
        countdownRunning = start;
	}

    public float getCountdown()
    {
        return this.countdown;
    }

    public float getTime()
    {
        return this.timer;
    }

    public void setStartGo(String text)
    {
        if (text == null)
            GameObject.Find("PanelInfo").GetComponent<CanvasGroup>().alpha = 0f;
        else
        {
            GameObject.Find("PanelInfo").GetComponent<CanvasGroup>().alpha = 1f;
            infoTxt.text = text;
        }
        
    }
}
