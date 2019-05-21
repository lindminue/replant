using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisPlay : MonoBehaviour
{

    public List<GameObject> _Dis = new List<GameObject>();
	private bool _isActive;

	void Update (){
		
	}

    public void OnClick()
    {
			if (_isActive) {
				foreach (var obj in _Dis) {
			
					obj.gameObject.SetActive (false);
					_isActive = obj.activeSelf;
				}
			} else {
				foreach (var obj in _Dis) {

					obj.gameObject.SetActive (true);
					_isActive = obj.activeSelf;
				}
			}
    }
}

