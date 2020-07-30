using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FiledSkillRectMake : MonoBehaviour {

    public GameObject _ColliderZone;
    public GameObject _Parent;
    public float _DelayTime;
    float _nowTime;

    [System.Serializable]
    public class BuffZoneValue
    {
        public float _Damage;
        public int _ElementType;
        public int _DebuffType;
        public int _DebuffNum;

        //public BuffZoneValue(float dmg,int eletype,int bufftype,int buffnum)
        //{
        //    _Damage=dmg;
        //    _ElementType = eletype;
        //    _DebuffType=bufftype;
        //    _DebuffNum=buffnum;
        //}
    }

    public List<BuffZoneValue> _DebuffValueList = new List<BuffZoneValue>();

    void Update()
    {
        _nowTime += Time.smoothDeltaTime;
        if(_nowTime>=_DelayTime)
        {
            _nowTime -= _DelayTime;
            MakingZone(_DelayTime);
        }
    }

    void MakingZone(float time)
    {

        for(int i=0;i<_DebuffValueList.Count;i++)
        {
            GameObject skill = NGUITools.AddChild(_Parent, _ColliderZone);
            skill.GetComponent<Skill_Circle>()._init(GameMng.Data._GameDate._HeroUnit, 1, 0, 1, _DebuffValueList[i]._Damage, _DebuffValueList[i]._ElementType);
            skill.GetComponent<Skill_Circle>()._RectBuff = true;
            skill.GetComponent<Skill_Circle>()._BuffType_R = _DebuffValueList[i]._DebuffType;
            skill.GetComponent<Skill_Circle>()._BuffTime_R = time;
            skill.GetComponent<Skill_Circle>()._BuffNum_R = _DebuffValueList[i]._DebuffNum;
            GameMng.Data._GameDate._SkillList.Add(skill.GetComponent<Skill_Circle>());
            skill.GetComponent<RemoveSelfTimer>().DestroyTime = time;
        }
    }
}

