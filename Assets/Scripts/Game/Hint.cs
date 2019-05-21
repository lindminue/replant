using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hint : MonoBehaviour
{

    [SerializeField]
    List<FieldControl> _fieldlist = null;

    [SerializeField]
    Event _event = null;

    [SerializeField]
    FlowerChar _flowerchar = null;

    bool _display = false;

    [SerializeField]
    FlowerChar[] _hintFlower = new FlowerChar[4];

    public void ChangeDisplay()
    {
        if (_display == true)
        {
            _display = false;
        }
        else
        {
            _display = true;
        }


    }
    public void Compare()
    {
        if (_display == true)
        {
            for (int i = 0; i < _fieldlist.Count; i++)
            {  // 필드리스트의 숫자만큼 for문을 돌린다
                if (_event._list.Count - 1 >= i)
                {
                    if (_event._list[i].NowFieldPosition != _fieldlist[i].FieldPosition)
                    { // 플라워챠 리스트에 들어있는 현재위치와 입력한 필드리스트 포지션이 같지않을때
                        StartCoroutine( ShowHint( 0.3f, i ));
                        break;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < _hintFlower.Length; i++)
            {
                if (_hintFlower[i] != null)
                {
                    Destroy(_hintFlower[i].gameObject);
                }
            }
        }
    }


    IEnumerator ShowHint( float time, int i )
    {
        for (int j = i; j < i + 4; j++)
        {
            if (_display == false) break;
            _flowerchar = Instantiate(Resources.Load<GameObject>("HintPlant")).GetComponent<FlowerChar>();
            _flowerchar.transform.parent = _fieldlist[j].transform;
            _flowerchar.transform.localPosition = new Vector3(-0.8f, 13f, -0.8f);
            _flowerchar.transform.localRotation = Quaternion.Euler(45, 45, 0);
            _flowerchar.transform.localScale = new Vector3(4f, 4f, 4f);
            _hintFlower[j - i] = _flowerchar;

            yield return new WaitForSeconds(time);
        }
    }
}
