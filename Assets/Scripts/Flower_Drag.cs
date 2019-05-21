using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower_Drag : MonoBehaviour {

	/*public GameObject parentObject;
	[ SerializeField ]
	public GameObject Prefab;
	[ SerializeField ]
	private GameObject obj;
	private Vector3 clickPosition;

	void Awake(){
		parentObject = GameObject.FindGameObjectWithTag( "Cube" );
	}
	void Update(){
		clickPosition = Input.mousePosition;
		clickPosition.y = 30f;
		RaycastHit hit = new RaycastHit( );
		Ray ray = Camera.main.ScreenPointToRay( clickPosition );
		if ( Input.GetMouseButtonDown( 0 ) ) {
			if ( Physics.Raycast( ray, out hit ) ) {
				if ( hit.collider.tag == "Cube" ) {
					obj = Instantiate( Prefab, hit.point, Quaternion.identity ) as GameObject;
					obj.transform.parent = parentObject.transform; 
					Debug.Log( "Dropしました。" );
				}
			}
		}
	}*/

	void Update(){
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

		RaycastHit hit;

		int distance = 100;

		Debug.DrawRay ( ray.origin, ray.direction * distance, Color.red );

		if ( Physics.Raycast( ray,out hit,distance ) ) {
			if ( hit.collider.tag == "Plant" ) {
				Debug.Log( "Rayがplayerに当たった" );
			}
		}

		}
}
