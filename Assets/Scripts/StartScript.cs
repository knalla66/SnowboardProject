using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	AsyncOperation ao;

	// Use this for initialization
	void Start () {
		

	}

	public void LoadScene(int scene) {

		StartCoroutine(load(scene));

	}


	IEnumerator load (int scene) {
		yield return new WaitForSeconds(2);
		ao = SceneManager.LoadSceneAsync(scene);
		ao.allowSceneActivation = false;

		while (!ao.isDone) {

			yield return new WaitForSeconds(1);
			Debug.Log (ao.progress);

			if (ao.progress == 0.9F) {
				ao.allowSceneActivation = true;
				break;
			}
		}

	}



}
