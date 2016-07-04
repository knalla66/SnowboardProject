using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    private Snowboard snowboarder;
    public bool firstTime = true;
    GameObject continueBtn;
    GameObject restartBtn;
    // Use this for initialization
    void Start () {
        //this.gameObject.SetActive(false);
        snowboarder = GameObject.Find("Snowboard").GetComponent<Snowboard>();

    }
	
	// Update is called once per frame
	void Update () {
         if (this.gameObject.activeSelf)
        {
            continueBtn = GameObject.Find("Continue");
            restartBtn = GameObject.Find("Restart");


            if (firstTime) //Only highlight button at beginning
            {
                EventSystem.current.SetSelectedGameObject(null);
                if(!snowboarder.isOnEnd())
                    EventSystem.current.SetSelectedGameObject(continueBtn);
                else
                {
                    continueBtn.SetActive(false);
                    EventSystem.current.SetSelectedGameObject(restartBtn);
                }
                
                firstTime = false;
                snowboarder.setDeactive();
            }   
        }

	}

    public void Continue()
    {
        snowboarder.setActive();
        firstTime = true;
        this.gameObject.SetActive(false);
    }

    public void Restart()
    {

    }

    public void Back(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
