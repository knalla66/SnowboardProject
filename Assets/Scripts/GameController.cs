using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private int points = 0;
    private Text pointTxt;

    // Use this for initialization
    void Start () {
		pointTxt = GameObject.Find("PointsTopRight").GetComponent<Text>();
        UpdatePoints();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void AddPoints()
    {
        //points++;
		points = points + 100;	
        UpdatePoints();
    }

    void UpdatePoints()
    {
        pointTxt.text = points.ToString();
    }
}
