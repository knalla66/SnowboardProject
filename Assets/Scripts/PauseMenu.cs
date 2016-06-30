using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    private Snowboard snowboarder;
    private bool firstTime = true;
    // Use this for initialization
    void Start () {
        //this.gameObject.SetActive(false);
        snowboarder = GameObject.Find("Snowboard").GetComponent<Snowboard>();

    }
	
	// Update is called once per frame
	void Update () {
         if (this.gameObject.activeSelf)
        {
            GameObject continueBtn = GameObject.Find("Continue");
            if (firstTime) //Only highlight button at beginning
            {
                EventSystem.current.SetSelectedGameObject(continueBtn);
                firstTime = false;
            }
               
            snowboarder.setDeactive();
        }

	}

    public void Continue()
    {
        snowboarder.setActive();
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
