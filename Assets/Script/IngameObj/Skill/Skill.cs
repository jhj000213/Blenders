using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

    public GameObject _Effect;
    public Unit _ParentUnit;
    /// <summary>
    /// 1 - Enemy
    /// 2 - Soldier
    /// 3 - EveryOne(Not Me)
    /// 4 - Me
    /// </summary>
    public int _targetGroup;
    /// <summary>
    /// 1 - OneHit
    /// 2 - DotDamage
    /// </summary>
    public int _HitType;
    public int _HitCount;
    public float _HitDelayTime;
    public float _Damage;
    public int _ElementType;
    /// <summary>
    /// 1 - Stun
    /// 2 - KnockBack
    /// </summary>
    public int _CCType;
    public float _CCTime;

    public bool _TargetLockonSkill;
    public Unit _TargetUnit;

    public bool _oneTarget;


    public bool _RectBuff;
    public int _BuffType_R;
    public float _BuffTime_R;
    public float _BuffNum_R;

    void Start()
    {
        gameObject.tag = "skill";
        //if (GameMng.Data._StoryMng.LineList.Count != 0)
        //    _Damage = 1000;
        _Damage *= (int)GameMng.Data._SkillDmgMultyple;
    }


    //RectTargetting
    public virtual void _init(Unit parentUnit, int hittype, int hitcount, int targetG, float damage,int eletype) { }
    public virtual void _init(Unit parentUnit, Vector2 _createPos, int hittype, int hitcount, int targetG, float damage, int eletype) { }

    //FlyFromObject
    public virtual void _init(Unit parentUnit, GameObject _obj, Vector2 _createPos, int hittype, int hitcount, int targetG, float damage, int eletype) { }
    public virtual void _init(Unit parentUnit, Vector3 angle, Vector2 _createPos, int hittype, int hitcount, int targetG, float damage, bool onetarget, int eletype) { }
    public virtual void _init(Unit parentUnit, Unit _targetUnit, Vector2 _createPos, int hittype, int hitcount, int targetG, float damage, bool onetarget, int eletype) { }

}
