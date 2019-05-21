using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_Move : MonoBehaviour {

	public void OnDrag(){
		/*Vector3 objectPoint = Camera.main.WorldToScreenPoint( this.transform.position );

		Vector3 mousePoint = new Vector3( Input.mousePosition.x, Input.mousePosition.y, objectPoint.z );

		Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePoint);
		mousePointInWorld.z = this.transform.position.z;
		this.transform.position = mousePointInWorld;*/
		Vector3 TapPos = Input.mousePosition;
		TapPos.z = 10f;
		transform.position = Camera.main.ScreenToWorldPoint(TapPos);
	}
		

}
