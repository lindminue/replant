using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldControl : MonoBehaviour {

    [ SerializeField ]
    private bool touchFlg = false;

    public bool TouchFlg
    {
        get
        {
            return touchFlg;
        }
        set
        {
           touchFlg = value;
        }
    }

    public int _fieldPosition;

    public int FieldPosition {
        get { return _fieldPosition; }
    }
}
