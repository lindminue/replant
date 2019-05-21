using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
	[SerializeField]GameObject _stageDifficulty = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StringArgFunction(string s){
		if ( !_stageDifficulty.activeInHierarchy ) {
			SceneManager.LoadScene( s );
		}
	}

	public void StringArgFunction2(string l){
		SceneManager.LoadScene( l );
	}
}
