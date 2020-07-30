using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill_Buff : Skill {

    public bool _Timebuff;
    public bool _boolBuff;

    public int _BuffLoopCount;

    /// <summary>
    /// 1 - Damage
    /// 2 - Critical
    /// 3 - Heal
    /// 4 - HitDelay
    /// 5 - MoveSpeed
    /// 6 - Armor
    /// 7 - Evasion
    /// 8 - AvoidLate
    /// </summary>
    public int _BuffType;
    public float _BuffTime;
    public float _BuffNum;//버프수치값
    public float _DotDelay;
    public float _DotDelayMax;

    /// <summary>
    /// 1 - AirLow
    /// 2 - 
    /// </summary>
    public int _AttackSubEffectNum;//몆회공격버프때 추가로 뜨는 이펙트
    public int _MotionChangeNum;//공격모션,이펙트가 아예 바뀌는 스킬

    public void _BuffSetting(int buffcount, bool bufdebuf, int bufftype, float buffnume)
    {
        _Timebuff = false;
        _BuffLoopCount = buffcount;
        _boolBuff = bufdebuf;
        _BuffType = bufftype;
        _BuffNum = buffnume;
    }
    public void _BuffSetting(float bufftime, bool bufdebuf, int bufftype, float buffnum)
    {
        _Timebuff = true;
        _BuffTime = bufftime;
        _boolBuff = bufdebuf;
        _BuffType = bufftype;
        _BuffNum = buffnum;
    }
    public void _BuffSetting(int healcount, bool bufdebuf, int bufftype, int buffnum,float healdelay)//DotHeal
    {
        _Timebuff = false;
        _BuffLoopCount = healcount;
        _boolBuff = bufdebuf;
        _BuffType = bufftype;
        _BuffNum = buffnum;
        _DotDelayMax = healdelay;
    }
}
