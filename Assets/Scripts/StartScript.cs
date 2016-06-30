using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	private Text info;
	private Button infoBtn; 
	private GameObject infoBtnGc;

	// Use this for initialization
	void Start () {
		info = GameObject.Find ("InfoText").GetComponent<Text>();
		infoBtnGc = GameObject.Find ("InfoBtn");
		infoBtn = infoBtnGc.GetComponent<Button>();
		infoBtn.gameObject.SetActive (false);

		StartCoroutine (showDialogueBox ());
	}

	public void LoadScene(int scene) {
		SceneManager.LoadScene(scene);
	}

	public void Help(){
	
	}

	public void Quit(){
		Application.Quit ();
	}
	
	// Update is called once per frame
	void Update () { 
	
	}

	IEnumerator showDialogueBox()
	{
		info.text = "Hi there!\n\nTo move through the menu you have to stand on the Balance Board\nand " +
			"lean back and forward to change the menu entry. To select an entry you have to jump one time";
		yield return new WaitForSeconds(4);
		infoBtn.gameObject.SetActive (true);
		EventSystem.current.SetSelectedGameObject(infoBtnGc);
	} 
    
	public void disableInfoPanel(){
		GameObject.Find ("InfoPanel").SetActive(false);
		EventSystem.current.SetSelectedGameObject(GameObject.Find("Start"));
	}

}
