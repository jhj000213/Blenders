using UnityEngine;
using System.Collections;

public class Skill_SecterForm : Skill
{
    public bool _pixelPerpect;
    public bool _haveChild;

    public override void _init(Unit parentObj, Vector3 angle, Vector2 _createPos, int hittype, int hitcount, int targetG, float damage, bool onetarget, int eletype)
    {
        _ParentUnit = parentObj;
        transform.localEulerAngles = angle;
        transform.localPosition = _createPos;
        _HitType = hittype;
        _Damage = damage;
        _ElementType = eletype;
        for (int i = 0; i < transform.childCount; i++)
        {
            Skill_Projectiles skill = transform.GetChild(i).GetComponent<Skill_Projectiles>();
            skill.tag = "skill";
            skill._Damage = damage;
            skill._HitType = hittype;
            skill._targetGroup = targetG;
            skill._oneTarget = onetarget;
            skill._ParentUnit = parentObj;
        }
            _targetGroup = targetG;
        if (hittype == 2)
            _HitCount = hitcount;
    }


    void Update()
    {
        if(_haveChild)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<UI2DSprite>().depth = 1300 - (int)transform.localPosition.y;
                if(_pixelPerpect)
                    transform.GetChild(i).GetComponent<UI2DSprite>().MakePixelPerfect();
            }
        }
        else
        {
            GetComponent<UI2DSprite>().depth = 1300 - (int)transform.localPosition.y;
            if (_pixelPerpect)
                GetComponent<UI2DSprite>().MakePixelPerfect();
        }
    }
}