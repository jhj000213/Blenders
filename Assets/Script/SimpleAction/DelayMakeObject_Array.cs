using UnityEngine;
using System.Collections;

public class DelayMakeObject_Array : MonoBehaviour {

    public float _delaytime;
    public int _maxroop;
    int _nowroop;
    public GameObject _obj;
    public GameObject _parent;
    public Vector2 _Pos;

    void Start()
    {
        StartCoroutine(AddObj(_delaytime));
    }

    IEnumerator AddObj(float time)
    {
        yield return new WaitForSeconds(time);

        GameMng.Data.ShakeGameCamera();

        GameObject obj = NGUITools.AddChild(_parent, _obj);
        obj.GetComponent<Skill_Circle>()._init(GameMng.Data._GameDate._HeroUnit,1,0,1,0.4f,0);
        obj.transform.localPosition = _Pos;
        _nowroop++;
        if(_nowroop<=_maxroop)
            StartCoroutine(AddObj(_delaytime));
    }

}
