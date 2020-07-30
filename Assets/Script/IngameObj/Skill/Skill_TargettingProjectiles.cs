using UnityEngine;
using System.Collections;

public class Skill_TargettingProjectiles : Skill {

    public float fSpeed = 0.0f;
    public bool PixelPerpect;
    public GameObject _DestroyEffect;

    public override void _init(Unit parentObj, Unit _targetObj, Vector2 _createPos, int hittype, int hitcount, int targetG, float damage, bool onetarget, int eletype)
    {
        _TargetLockonSkill = true;
        _ParentUnit = parentObj;
        transform.localPosition = _createPos;
        _targetGroup = targetG;
        _Damage = damage;
        _HitType = hittype;
        _oneTarget = onetarget;
        _TargetUnit = _targetObj;
        _ElementType = eletype;
        if (hittype == 2)
            _HitCount = hitcount;
    }
    void Update()
    {
        if (PixelPerpect)
            GetComponent<UI2DSprite>().MakePixelPerfect();
        //transform.Translate(Vector2.up * fSpeed * Time.smoothDeltaTime);
        if(_TargetUnit!=null&&_ParentUnit!=null)
        {
            float _radi = Mathf.Atan2(_TargetUnit.transform.localPosition.y - transform.localPosition.y,
                                    _TargetUnit.transform.localPosition.x - transform.localPosition.x);
            float _speedX = (Mathf.Cos(_radi) * fSpeed);
            float _speedY = (Mathf.Sin(_radi) * fSpeed);
            transform.localPosition += new Vector3(_speedX * Time.smoothDeltaTime, _speedY * Time.smoothDeltaTime, 0);
            transform.localEulerAngles = new Vector3(0, 0, _radi * Mathf.Rad2Deg);
        }
        else
        {
            if(_DestroyEffect!=null)
            {
                GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._Parent, _DestroyEffect);
                obj.transform.localPosition = transform.localPosition;
            }
            Destroy(gameObject);
        }
        

        if (gameObject.transform.localPosition.x < -2000 || gameObject.transform.localPosition.x > 2000 ||
            gameObject.transform.localPosition.y > 1500)
        {
            Destroy(gameObject);
        }
    }
}
