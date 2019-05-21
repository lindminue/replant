using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowerOpen : MonoBehaviour {

    public GameObject[] FlowerButton;
    public GameObject[] FlowerIcon;

    // Use this for initialization
    void Start()
    {
        int clearStageNo = PlayerPrefs.GetInt("Flower", 0);

        for (int i = 0; i <= FlowerButton.GetUpperBound(0); i++)
        {

            bool b;

            if (clearStageNo < i)
            {
                b = true; //前ステージをクリアしていなければ無効
            }
            else
            {
                b = false; //前ステージをクリアしていれば有効
            }

            // FlowerButton[i].GetComponent<Button>().interactable = b;
            FlowerButton[i].gameObject.SetActive(b);
            

        }

        for (int j = 0; j <= FlowerIcon.GetUpperBound(0); j++)
        {
            bool c;
            if (clearStageNo < j)
            {
                c = false; //前ステージをクリアしていなければ無効

            }
            else
            {
                c = true; //前ステージをクリアしていれば有効

            }
            FlowerIcon[j].gameObject.SetActive(c);
        }
    }
}
