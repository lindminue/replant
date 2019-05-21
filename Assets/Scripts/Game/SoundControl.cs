using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour {

    public bool DontDestroyEnable = true;

	// Use this for initialization
	void Start () {
        if (DontDestroyEnable)
        {
            DontDestroyOnLoad(this);
        }
		
	}
	
}
