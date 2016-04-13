using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer Instance = null;
	
	void Awake (){
		if (Instance != null){
			Destroy (gameObject);
		} else {
			Instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
