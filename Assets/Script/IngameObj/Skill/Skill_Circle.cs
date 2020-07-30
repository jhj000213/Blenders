using UnityEngine;
using System.Collections;

public class Skill_Circle : Skill
{
    public bool _pixelPerpect;

    public override void _init(Unit parentObj, Vector2 _createPos, int hittype, int hitcount, int targetG, float damage, int eletype)
    {
        _ParentUnit = parentObj;
        transform.parent.localPosition = _createPos;
        _HitType = hittype;
        _targetGroup = targetG;
        _Damage = damage;
        _ElementType = eletype;
        if (hittype == 2)
            _HitCount = hitcount;
    }
    public override void _init(Unit parentObj, int hittype, int hitcount, int targetG, float damage, int eletype)
    {
        _ParentUnit = parentObj;
        _HitType = hittype;
        _targetGroup = targetG;
        _Damage = damage;
        _ElementType = eletype;
        if (hittype == 2)
            _HitCount = hitcount;
    }

    void Update()
    {
        if (_pixelPerpect)
        {
            GetComponent<UI2DSprite>().depth = 1300 - (int)transform.parent.localPosition.y;
            GetComponent<UI2DSprite>().MakePixelPerfect();
        }
    }
}