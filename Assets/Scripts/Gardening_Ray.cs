using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gardening_Ray : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

		if ( Input.GetMouseButton( 0 ) ) {
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
			Debug.DrawRay( ray.origin, ray.direction * 100, Color.red );
			if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) ) {
				Debug.Log( hit.collider.gameObject.name );
			}
		}
	}
}
