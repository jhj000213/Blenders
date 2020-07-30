using UnityEngine;
using System.Collections;

public class PormationIcon : MonoBehaviour {

    public Vector2 _nowPos;
    public int _UnitNum;
    public string _IconName;
    public UnitPositionSettingMng _Mng;

    void Update()
    {
        _nowPos = transform.localPosition;
    }
    public void UnSetIcon()
    {
        
        //for (int i = 0; i < StaticDataMng._PormationList.Count;i++ )
        //{
        //    if (((Mathf.Abs(StaticDataMng._PormationList[i]._nowPos.x - _nowPos.x) < 1.0f) && (Mathf.Abs(StaticDataMng._PormationList[i]._nowPos.y - _nowPos.y) < 1.0f)
        //        &&StaticDataMng._PormationList[i]._UnitNum==_UnitNum))
        //    {
        //        if (_UnitNum == 1)
        //            StaticDataMng._nowHeroUnitNum--;
        //        else
        //            StaticDataMng._nowUnitNum--;
        //        StaticDataMng._PormationList.Remove(StaticDataMng._PormationList[i]);
        //        Destroy(gameObject);
        //        break;
        //    }//|| () < 1.0f && Mathf.Abs(StaticDataMng._PormationList[i]._nowPos.y - _nowPos.y) )        StaticDataMng._PormationList[i]._nowPos == _nowPos || 
        //}
        //    //Debug.Log("띠용");//&&StaticDataMng._PormationList[i]._UnitNum==_UnitNum && StaticDataMng._PormationList[i]._IconName==_IconName
        //Debug.Log(StaticDataMng._PormationList.Count);
        //Debug.Log(_IconName);
        //Debug.Log(_nowPos);
    }
}
