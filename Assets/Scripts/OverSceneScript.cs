using UnityEngine;
using System.Collections;

public class OverSceneScript : MonoBehaviour {
    // Klasse zur Übergabe über Szene hinaus
    public bool firstTime = true;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
}
