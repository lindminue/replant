using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageOpen : MonoBehaviour
{
	[ SerializeField ]
		public GameObject[] stageButtons; //ステージ選択ボタン配


    void Start()
    {
        //どのステージまでクリアしているのかをロード(セーブ前なら０）
        int clearStageNo = PlayerPrefs.GetInt("CLEAR", 0);

        //ステージボタンを有効化
        for (int i = 0; i <= stageButtons.GetUpperBound(0); i++)
        {
            bool b;

            if (clearStageNo < i)
            {
                b = false; //前ステージをクリアしていなければ無効
            }
            else
            {
                b = true; //前ステージをクリアしていれば有効
            }

            //ボタンの有効・無効を設定
            stageButtons[i].GetComponent<Button>().interactable = b;
        }

    }
}
