using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageNo : MonoBehaviour {
    public int No;
	public int FlowerNo;
    public GameObject Panel;

    
     void Start()
    { 
        if (Panel.activeSelf)
        {
            PlayerPrefs.SetInt("CLEAR", No);
			PlayerPrefs.SetInt("Flower", FlowerNo );
        }
    }

}
