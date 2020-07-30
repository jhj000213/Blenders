using UnityEngine;
using System.Collections;

public class UnitPositionSettingMng : MonoBehaviour {

    public UILabel _NowUnitNumLabel;
    public UILabel _MowHeroNumLabel;

    public GameObject _Table;
    public GameObject _MakingUnitIcon;
    public UISprite _MoveIcon;
    
    public int _one = 1;
    public int _two = 2;
    public int _three = 3;
    public int _four = 4;

    int _nowSelectIcon;
    public bool _MovingIcon;

    public int _MaxUnitNum;

    public Vector2 _RectStartPos;
    public Vector2 _RectEndPos;

    void Start()
    {
        StaticDataMng._nowHeroUnitNum = 0;
        StaticDataMng._nowUnitNum = 0;
        for(int i=0;i<StaticDataMng._PormationList.Count;i++)
        {
            GameObject obj = NGUITools.AddChild(_Table, _MakingUnitIcon);
            obj.transform.localPosition = StaticDataMng._PormationList[i]._nowPos;
            obj.GetComponent<PormationIcon>()._nowPos = StaticDataMng._PormationList[i]._nowPos;
            obj.GetComponent<PormationIcon>()._UnitNum = StaticDataMng._PormationList[i]._UnitNum;
            obj.GetComponent<PormationIcon>()._Mng = GetComponent<UnitPositionSettingMng>();
            obj.GetComponent<PormationIcon>()._IconName = StaticDataMng._PormationList[i]._IconName;
            obj.GetComponent<UISprite>().spriteName = StaticDataMng._PormationList[i]._IconName;
            Debug.Log(obj.GetComponent<UISprite>().spriteName);
            if (obj.GetComponent<PormationIcon>()._UnitNum == 1)
                StaticDataMng._nowHeroUnitNum++;
            else
                StaticDataMng._nowUnitNum++;
        }
    }
    void Update()
    {
        _NowUnitNumLabel.text = StaticDataMng._nowUnitNum.ToString();
        _MowHeroNumLabel.text = StaticDataMng._nowHeroUnitNum.ToString();

        _MoveIcon.transform.localPosition = new Vector2(Input.mousePosition.x * (1280.0f / Screen.width), Input.mousePosition.y * (720.0f / Screen.height));

        if(_MovingIcon)
        {
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 mousepos = new Vector2(Input.mousePosition.x * (1280.0f / Screen.width), Input.mousePosition.y * (720.0f / Screen.height));
                if (mousepos.x >= _RectStartPos.x && mousepos.x < _RectEndPos.x && mousepos.y >= _RectStartPos.y && mousepos.y < _RectEndPos.y)
                {
                    GameObject obj = NGUITools.AddChild(_Table, _MakingUnitIcon);
                    obj.transform.localPosition = mousepos;//
                    obj.GetComponent<PormationIcon>()._UnitNum = _nowSelectIcon;
                    obj.GetComponent<PormationIcon>()._Mng = GetComponent<UnitPositionSettingMng>();
                    StaticDataMng._PormationList.Add(obj.GetComponent<PormationIcon>());
                    obj.GetComponent<UISprite>().spriteName = _MoveIcon.spriteName;
                    obj.GetComponent<PormationIcon>()._IconName = _MoveIcon.spriteName;
                    if (_nowSelectIcon == 1)
                        StaticDataMng._nowHeroUnitNum++;
                    else
                        StaticDataMng._nowUnitNum++;
                }
                _MoveIcon.enabled = false;
                _MovingIcon = false;
                _nowSelectIcon = 0;
            }
        }

        
        
    }

    
    public void ResetIcon()
    {
        StaticDataMng._nowHeroUnitNum = 0;
        StaticDataMng._nowUnitNum = 0;
        StaticDataMng._PormationList.Clear();
        _Table.transform.DestroyChildren();
    }
    

    public void SetMoveIcon(int num)
    {
        _MoveIcon.enabled=true;
        _MovingIcon = true;
        _nowSelectIcon = num;
        if (num == 1)
        {
            if (StaticDataMng._nowHeroUnitNum == 0)
            {
                _MoveIcon.spriteName = "heroicon";
            }
            else
            {
                _MoveIcon.enabled = false;
                _MovingIcon = false;
                _nowSelectIcon = 0;
            }
        }
        else if (num == 2)
        {
            if (StaticDataMng._nowUnitNum < _MaxUnitNum)
                _MoveIcon.spriteName = "soldier_w_icon";
            else
            {
                _MoveIcon.enabled = false;
                _MovingIcon = false;
                _nowSelectIcon = 0;
            }
        }
        else if (num == 3)
        {
            if (StaticDataMng._nowUnitNum < _MaxUnitNum)
                _MoveIcon.spriteName = "soldier_a_icon";
            else
            {
                _MoveIcon.enabled = false;
                _MovingIcon = false;
                _nowSelectIcon = 0;
            }
        }
        else if (num == 4)
        {
            if (StaticDataMng._nowUnitNum < _MaxUnitNum)
                _MoveIcon.spriteName = "soldier_m_icon";
            else
            {
                _MoveIcon.enabled = false;
                _MovingIcon = false;
                _nowSelectIcon = 0;
            }
        }
    }

   
}
