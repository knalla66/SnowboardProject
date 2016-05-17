using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}

	public void LoadScene(int scene) {

		SceneManager.LoadScene(scene);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
