using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour {

	public List<GameObject> _Hide = new List<GameObject>();
    private bool _isActive = true;

    public void OnClick()
    {
        if (_isActive)
        {
            foreach (var obj in _Hide)
            {
                obj.SetActive(false);
                _isActive = obj.activeSelf;
            }
        }
    }
}