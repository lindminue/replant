using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour,  IDropHandler
{
	//public GameObject obj;
	[ SerializeField ]
	private Drag drag;
	private GameObject parentObject;
	private GameObject obj;
	//private Vector3 clickPosition;

	void Awake(){
		parentObject = GameObject.FindGameObjectWithTag( "Cube" );
	}

	void Start(){
		parentObject = GameObject.Find( "Rocks/GameObject" );
	}

    public void OnDrop ( PointerEventData eventData ) {
		Debug.Log( eventData.pointerDrag.name + "was dropped on" + gameObject.name );
		Drag drag = eventData.pointerDrag.GetComponent<Drag>( );

		Vector3 hitPoint;
		RaycastHit hit = new RaycastHit();
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

		if (Physics.Raycast(ray, out hit, 100))
		{
			float x = hit.point.x;
			float z = hit.point.z;
			if ( hit.collider.tag == "Cube" ) {
				hitPoint = hit.point;
				hitPoint.y = 10f;
				obj = Instantiate( drag.Flower, hitPoint, Quaternion.Euler( 30, 45, 0 ) ) as GameObject;
				obj.transform.parent = parentObject.transform; 
			} else {
				return;
			}
		}
	}
}
