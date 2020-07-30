using UnityEngine;
using System.Collections;

public class Skill_Projectiles : Skill
{
    public float fSpeed = 0.0f;
    public bool PixelPerpect;


    public override void _init(Unit parentObj, Vector3 angle, Vector2 _createPos, int hittype, int hitcount, int targetG, float damage, bool onetarget, int eletype)
    {
        _ParentUnit = parentObj;
        transform.localEulerAngles = angle;
        transform.localPosition = _createPos;
        _targetGroup = targetG;
        _Damage = damage;
        _HitType = hittype;
        _oneTarget = onetarget;
        _ElementType = eletype;
        if (hittype == 2)
            _HitCount = hitcount;
    }
    void Update()
    {
        if (PixelPerpect)
            GetComponent<UI2DSprite>().MakePixelPerfect();
        transform.Translate(Vector2.up * fSpeed * Time.smoothDeltaTime);

        if(gameObject.transform.localPosition.x<-2000||gameObject.transform.localPosition.x>2000||
            gameObject.transform.localPosition.y>1500)
        {
            Destroy(gameObject);
        }
    }
}