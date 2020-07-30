using UnityEngine;
using System.Collections;

public class DelayMakeObject : MonoBehaviour {

    public GameObject _Parent;
    public GameObject _createObj;
    public float _DelayTime;
    public bool _Maintain;

    public bool _setPos;
    public bool _addMyPos;
    public Vector3 _cPos;
    public bool _setScale;
    public Vector3 _cScale;

    public bool _EnableOn;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(_DelayTime);

        if (_EnableOn)
            _createObj.SetActive(true);
        else
        {
            GameObject obj = NGUITools.AddChild(_Parent, _createObj);
            if (_Maintain)
                obj.transform.localPosition = new Vector3(0, 30, 0);
            if (_setPos)
            {
                if (_addMyPos)
                    obj.transform.localPosition = _cPos + transform.localPosition;
                else
                    obj.transform.localPosition = _cPos;
            }
            if (_setScale)
                obj.transform.localScale = _cScale;
        }
    }
}
