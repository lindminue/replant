using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetaDelete : MonoBehaviour {

	public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Delete All Data Of PlayerPrefs!!");
    }
}
