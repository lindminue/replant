using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchSystem : MonoBehaviour {
   /*public bool zooming;
    public float zoomSpeed;*/
    private Camera mainCamera;
    private RaycastHit rayHit;
    private Ray ray;

	public GameObject ClearPanel;


    [ SerializeField ]
    public GameObject cube;
    [ SerializeField ]
    public GameObject flower;
    [ SerializeField ]
    public GameObject goal;

    void Awake() {
        flower = GameObject.FindGameObjectWithTag ( "Flower" );
        cube = GameObject.FindGameObjectWithTag ( "Cube" );
        goal = GameObject.FindGameObjectWithTag ( "Goal" );
        mainCamera = Camera.main.GetComponent<Camera>();
    }

    void Update() {
        if ( Input.GetMouseButton( 0 ) ) {
            
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast ( ray, out rayHit, Mathf.Infinity );
            Debug.DrawRay( ray.origin, ray.direction * 100, Color.red );
			/*#if UNITY_IOS  
			if(EventSystem.current.IsPointerOverGameObject()){
				//処理をキャンセル（マウスver）
				return;
			}
			#else
			if(Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){
				//処理をキャンセル（タップver）
				return;
				}
			#endif*/
              /*  if ( rayHit.collider != null ) {
				if (rayHit.collider.gameObject.tag == "Cube" || rayHit.collider.gameObject.tag == "Goal")
				{
					cube = rayHit.collider.gameObject;
					goal = rayHit.collider.gameObject;
					var Flower = Instantiate(Resources.Load<GameObject>("Flower"));
					Flower.transform.parent = cube.transform;
					Flower.transform.localPosition = new Vector3(0.1f, 0.9f, -0.1f);
					Flower.transform.localRotation = Quaternion.Euler(45, -45, 0);
					Flower.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
					//if ( null != GameObject.Find("Flower") {
                        
     //           }
				}
                
				if ( rayHit.collider.gameObject.tag == "Goal" ){
					ClearPanel.SetActive( true );
				}
                }*/
                Debug.Log( "Mouse Click" );
        }
    }
}