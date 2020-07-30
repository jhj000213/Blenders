using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InOrderMakingObj : MonoBehaviour {

    public GameObject _Parent;
    public List<GameObject> _obj = new List<GameObject>();
    public GameObject _oneObj;
    public List<Vector3> _CreatePos = new List<Vector3>();
    public Vector3 _onePos;
    public bool _SameObject;
    public bool _SamePos;
    public bool _AddPos;
    int nowCount;
    public int maxCount;
    float _nowTime;
    public float _delayTime;


    void Update()
    {
        _nowTime += Time.smoothDeltaTime;
        if(_nowTime>=_delayTime && nowCount<maxCount)
        {
            GameObject obj;
            nowCount++;
            _nowTime = 0.0f;
            if(_SameObject)
                obj = NGUITools.AddChild(_Parent, _oneObj);
            else
            {
                obj = NGUITools.AddChild(_Parent, _obj[0]);
                _obj.RemoveAt(0);
            }
            if(_SamePos)
            {
                if (_AddPos)
                    obj.transform.localPosition = _onePos*nowCount;
                else
                    obj.transform.localPosition = _onePos;
            }
            else
            {
                obj.transform.localPosition = _CreatePos[0];
                _CreatePos.RemoveAt(0);
            }
            
        }
    }
}
