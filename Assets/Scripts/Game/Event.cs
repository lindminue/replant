using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Event : MonoBehaviour {

    [ SerializeField ]
    public GameObject ClearPanel;

    [ SerializeField ]
    public ParticleSystem ClearParticle;

    [SerializeField]
    Texture texture;

    [SerializeField]
    public ParticleSystem Sakura;

	[ SerializeField ]
	public ParticleSystem touchParticle = null;

    FieldControl fieldControl;

    [ SerializeField ]
    public List<FlowerChar> _list = null;

    [ SerializeField ]
    public GameObject cube;

    [ SerializeField ]
    GameObject bg;

    [ SerializeField ]
    FlowerChar _flowerChar = null;

    [ SerializeField ]
    int _clearFlowerNum = 0;

    [ SerializeField ]
    float time = 1f;

    [ SerializeField ]
    float panel_time = 1f;

    int touchFieldPosition;
    int FlowerNowPosition;
    int FlowerBeforePosition;

	// Use this for initialization
	void Awake () {
        cube = GameObject.FindGameObjectWithTag ( "Cube" );
        bg = GameObject.FindGameObjectWithTag( "BackGround" );
    }

    void Start() {
        touchFieldPosition = 1;
        FlowerNowPosition = 1;
        FlowerBeforePosition = 0;

        ClearParticle.Stop( );
        Sakura.Stop( );
        texture = (Texture)Resources.Load( "background2" );

    }

    // Update is called once per frame
    void Update () {
    Debug.Log( "nowPosition is" + FlowerNowPosition );
        if ( Input.GetMouseButton ( 0 ) ) {
            Ray ray = new Ray( );
            RaycastHit hit = new RaycastHit( );
            ray = Camera.main.ScreenPointToRay( Input.mousePosition );
            //マウスクリックした場所からRayを飛ばし、オブジェクトがあればtrue 
            #if UNITY_IOS  
			if(EventSystem.current.IsPointerOverGameObject()){
				//処理をキャンセル（マウスver）
				return;
			}
			#else
			if(Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)){
				//処理をキャンセル（タップver）
				return;
				}
			#endif
            if ( Physics.Raycast( ray.origin, ray.direction, out hit, Mathf.Infinity ) ) {
                Debug.DrawRay( ray.origin, ray.direction * 100, Color.red );

                if ( _clearFlowerNum != _list.Count ) {
	    	        if ( hit.collider.gameObject.CompareTag( "Cube" ) ) {
                        //タッチされたマスのオブジェクトを取得する。
                        fieldControl = hit.collider.gameObject.GetComponent<FieldControl>( );
                        touchFieldPosition = fieldControl.FieldPosition;

                        if ( _list.Count >= 2 ) {
                            if ( fieldControl.TouchFlg && FlowerBeforePosition == touchFieldPosition ) {
                                FieldControl beforeField = _list[ _list.Count - 1 ].transform.parent.GetComponent<FieldControl>();
                                beforeField.TouchFlg = false;

                                Destroy ( _list[ _list.Count - 1 ].gameObject );
                                _list.RemoveAt( _list.Count - 1 );
                                _flowerChar = null;
                                
                                FlowerNowPosition = FlowerBeforePosition;
                                if ( _list.Count != 1 ) {
                                    FieldControl pastField = _list[ _list.Count - 2 ].transform.parent.GetComponent<FieldControl>();
                                    FlowerBeforePosition = pastField.FieldPosition;
                                }
                            }
                        }
                        // タッチされていないマス、
                            // かつ、現在のマスと同じではない
                            // かつ、ターン開始時のマスと同じではない
                            // かつ、移動可能マスの場合
                        if ( !fieldControl.TouchFlg 
                                                    && FlowerNowPosition != touchFieldPosition
                                                    && checkMove( FlowerNowPosition, touchFieldPosition ) ) {
                         
                            //タッチされたマスの位置を移動リストに追加する。
                            //GameControl.FlowerCharObject.MoveList.Add(touchFieldPosition);
                            //Debug.Log( "List Count : " + GameControl.FlowerCharObject.MoveList.Count );

                            //タッチされたら処理済にする。
                            fieldControl.TouchFlg = true;

                            //子オブジェクト
                            cube = hit.collider.gameObject;
                            _flowerChar = Instantiate(Resources.Load<GameObject>("Plant") ).GetComponent<FlowerChar>();
                            _flowerChar.transform.parent = cube.transform;
                            _flowerChar.transform.localPosition = new Vector3(-0.8f , 13f, -0.8f);
                            _flowerChar.transform.localRotation = Quaternion.Euler(45, 45, 0);
				    	    _flowerChar.transform.localScale = new Vector3(4f, 4f, 4f);
                            _flowerChar.IsInstantiate = true;

                            FlowerBeforePosition =  FlowerNowPosition;

                            //タッチされたマスが現在位置になる。
                            FlowerNowPosition = touchFieldPosition;
                            _flowerChar.NowFieldPosition = FlowerNowPosition;
                            _list.Add( _flowerChar );
                           // _list[_list.Count - 1].NowFieldPosition = 10;// touchFieldPosition;


                        }
                    }
               
                    if ( _clearFlowerNum == _list.Count ){
                        StartCoroutine( "ShowClearLog", time );
				    }
             }
    }
        }
    }

    IEnumerator ShowClearLog( float time ) {
        yield return new WaitForSeconds ( time ); 
        for ( int i = 0; i < _list.Count; i++ ) {
            _list[ i ].gameObject.SetActive( false );
        }
        for ( int i = 0; i < _list.Count; i++ ) {
            _list[ i ].gameObject.SetActive( true );     
            yield return new WaitForSeconds( time );
        }
        ClearParticle.Play( );
        yield return new WaitForSeconds(panel_time);
        bg.GetComponent<Renderer>().material.mainTexture = texture;
        Sakura.Play( );
        yield return new WaitForSeconds( panel_time * 1.5f );
        ClearPanel.SetActive( true );
    }

    bool checkMove( int charPosition, int touchPosition ) {

        bool okFlg = false;

        switch ( charPosition ) {
            case  1: if ( touchPosition == 2 || touchPosition == 6 )
                okFlg = true;
                break;
            case  2: if ( touchPosition == 3 || touchPosition == 7 || touchPosition == 1 )
                okFlg = true;
                break;
            case  3: if ( touchPosition == 4 || touchPosition == 8 || touchPosition == 2 )
                okFlg = true;
                break;
            case  4: if ( touchPosition == 5 || touchPosition == 9 || touchPosition == 3 )
                okFlg = true;
                break;
            case  5: if ( touchPosition == 10 || touchPosition == 4 )
                okFlg = true;
                break;
            case  6: if (touchPosition == 11 || touchPosition == 7 || touchPosition == 1 )
                okFlg = true;
                break;
            case  7: if ( touchPosition == 12 || touchPosition == 8 || touchPosition == 6 || touchPosition == 2 )
                okFlg = true;
                break;
            case  8: if ( touchPosition == 13 || touchPosition == 9 || touchPosition == 7 || touchPosition == 3 )
                okFlg = true;
                break;
            case  9: if ( touchPosition == 14 || touchPosition == 10 || touchPosition == 8 || touchPosition == 4 )
                okFlg = true;
                break;
            case 10: if ( touchPosition == 15 || touchPosition == 9 || touchPosition == 5 )
                okFlg = true;
                break;
            case 11: if ( touchPosition == 16 || touchPosition == 12 || touchPosition == 6 )
                okFlg = true;
                break;
            case 12: if ( touchPosition == 11 || touchPosition == 17 || touchPosition == 13 || touchPosition == 7 )
                okFlg = true;
                break;
            case 13: if ( touchPosition == 12 || touchPosition == 18 || touchPosition == 14 || touchPosition == 8 )
                okFlg = true;
                break;
            case 14: if (touchPosition == 13 || touchPosition == 19 || touchPosition == 15 || touchPosition == 9 )
                okFlg = true;
                break;
            case 15: if (touchPosition == 14 || touchPosition == 20 || touchPosition == 10 )
                okFlg = true;
                break;
            case 16: if (touchPosition == 21 || touchPosition == 17 || touchPosition == 11 )
                okFlg = true;
                break;
            case 17: if (touchPosition == 16 || touchPosition == 22 || touchPosition == 18 || touchPosition == 12 )
                okFlg = true;
                break;
            case 18: if (touchPosition == 17 || touchPosition == 23 || touchPosition == 19 || touchPosition == 13 )
                okFlg = true;
                break;
            case 19: if (touchPosition == 18 || touchPosition == 24 || touchPosition == 20 || touchPosition == 14 )
                okFlg = true;
                break;
            case 20: if (touchPosition == 19 || touchPosition == 25 || touchPosition == 15 )
                okFlg = true;
                break;
            case 21: if (touchPosition == 22 || touchPosition == 16 )
                okFlg = true;
                break;
            case 22: if (touchPosition == 21 || touchPosition == 17 || touchPosition == 23 )
                okFlg = true;
                break;
            case 23: if (touchPosition == 22 || touchPosition == 18 || touchPosition == 24 )
                okFlg = true;
                break;
            case 24: if (touchPosition == 23 || touchPosition == 19 || touchPosition == 25 )
                okFlg = true;
                break;
            case 25: if (touchPosition == 24 || touchPosition == 20 )
                okFlg = true;
                break;

        }
        return okFlg;
    }

}
