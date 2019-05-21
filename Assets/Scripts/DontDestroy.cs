using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
	private static bool created = false;
	void Awake ()
	{
		if (!created) {
			created = true;
	
			DontDestroyOnLoad (this.gameObject);
		}
		else {

			Destroy (this.gameObject);
		}

	}

}