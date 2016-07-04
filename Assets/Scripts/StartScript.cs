using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

    private Text info;
	private GameObject infoBtn;
    private GameObject mainPanel;
    private GameObject highscorePanel;

    // Use this for initialization
    void Start () {
		info = GameObject.Find ("InfoText").GetComponent<Text>(); 
		infoBtn = GameObject.Find ("InfoBtn");
        mainPanel = GameObject.Find("MainPanel");
        highscorePanel = GameObject.Find("HighscorePanel");

        Debug.Log(PlayerPrefs.GetInt("highscorePoints"));
        //Zu Beginn ausgeblendet
        mainPanel.SetActive(false);
        highscorePanel.SetActive(false);
        infoBtn.gameObject.SetActive (false);

        StartCoroutine (showDialogueBox ());
	}

	public void LoadScene(int scene) {
		SceneManager.LoadScene(scene);
	}

    public void Highscore()
    {
        mainPanel.SetActive(false);
        highscorePanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("BackHighscore"));

        // Eintragen eines Highscores 
        string highscore = "";
        if (PlayerPrefs.GetInt("highscorePoints", 0) != 0)
            highscore = "Points: " + PlayerPrefs.GetInt("highscorePoints") + " " +  "Time: " + PlayerPrefs.GetFloat("highscoreTime");     
        GameObject.Find("HighscoreText").GetComponent<Text>().text = highscore;
    }

    public void ClearHighscore()
    {
        PlayerPrefs.DeleteAll();
        Highscore();
    }

    public void Back()
    {
        // Wenn Highscore aktiv dann das deaktivieren sonst Help deaktivieren
        highscorePanel.SetActive(false);
        mainPanel.SetActive(true);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("Start"));
    }

	public void Help(){
	    
	}

	public void Quit(){
		Application.Quit ();
	}
	

	IEnumerator showDialogueBox()
	{
		info.text = "Hi there!\n\nTo move through the menu you have to stand on the Balance Board\nand " +
			"lean back and forward to change the menu entry. To select an entry you have to jump one time";
		yield return new WaitForSeconds(4); //Button Jump wird erst nach 4 Sekunden eingeblendet
		infoBtn.GetComponent<Button>().gameObject.SetActive (true);
		EventSystem.current.SetSelectedGameObject(infoBtn);
	} 
    
	public void disableInfoPanel(){
		GameObject.Find ("InfoPanel").SetActive(false);
        mainPanel.SetActive(true);
		EventSystem.current.SetSelectedGameObject(GameObject.Find("Start"));
	}

}
