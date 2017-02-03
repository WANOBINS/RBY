using UnityEngine;
using System.Collections;

public class Music_Player : MonoBehaviour {
	static Music_Player instance = null;

	void Awake () {
		if (instance != null) {
			Destroy (gameObject);
			Debug.Log ("Destroyed second instance of music_player");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			
		}


	}

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
