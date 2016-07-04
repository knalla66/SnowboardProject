using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    private Snowboard snowboarder;
    public bool firstTime = true;
    GameObject continueBtn;
    GameObject restartBtn;
    CanvasGroup gameOverTxt; 
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
            gameOverTxt = GameObject.Find("GameoverPanel").GetComponent<CanvasGroup>();


            if (firstTime) //Only highlight button at beginning
            {
                gameOverTxt.alpha = 0f;
                
                EventSystem.current.SetSelectedGameObject(null);
                if (snowboarder.getOnEnd())
                {
                    continueBtn.SetActive(false);
                    EventSystem.current.SetSelectedGameObject(restartBtn);
                }    
                else if (snowboarder.getGameOver())
                {
                    continueBtn.SetActive(false);
                    gameOverTxt.alpha = 1f;
                    GameObject.Find("PanelPoints").SetActive(false);
                    GameObject.Find("PanelProgress").SetActive(false);
                    EventSystem.current.SetSelectedGameObject(restartBtn);
                }
                else
                {
                    EventSystem.current.SetSelectedGameObject(continueBtn);
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
        SceneManager.LoadScene(2);
    }

    public void Back(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
