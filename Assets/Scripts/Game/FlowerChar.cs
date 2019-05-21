using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerChar : MonoBehaviour {

    //移動中にどのマスにいるか
    [SerializeField]
    private int _nowFieldPositon;

    public int NowFieldPosition {
        get { return _nowFieldPositon; }
        set { _nowFieldPositon = value; }
    }

    //もともとどのマスにいたか
    private int _beforeFieldPosition;
    
    public int BeforeFieldPosition {
        get { return _beforeFieldPosition; }
        set { _beforeFieldPosition = value; }
    }

    bool _isInstantiate = false; //instantiateしたかどうかのフラグ

    public bool IsInstantiate
    {
        get { return _isInstantiate; }
        set { _isInstantiate = value; }
    }

    void Start() {
        if (_isInstantiate) return;
        //初期の位置設定
        _beforeFieldPosition = 1;   
        _nowFieldPositon = 1;
    }

}
