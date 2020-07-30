using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skill_HealZone : MonoBehaviour
{

    public Unit _UseUnit;
    public int _HealSkillNum;
    public GameObject[] _HealEffect;

    void Start()
    {
        List<Unit> _TeamList = new List<Unit>();
        if (_UseUnit._Rating <= 2)
            _TeamList = GameMng.Data._GameDate._EnemyUnitList;
        else
            _TeamList = GameMng.Data._GameDate._SoldierUnitList;

        if (_TeamList.Count != 0)
        {
            for (int i = 0; i < _TeamList.Count; i++)
            {
                if (Vector2.Distance(transform.parent.localPosition, _TeamList[i].transform.localPosition) <= 205.0f)
                {
                    if(_HealSkillNum==0)
                    {

                        Skill_Buff buff2 = new Skill_Buff();
                        buff2._BuffSetting(5, true, 3, ((StaticDataMng._WaterSkill_Low[StaticDataMng._SkillLevel_Low_9 - 1] * 10) / 5) * (int)GameMng.Data._SkillDmgMultyple, 0.5f);
                        _TeamList[i]._BuffList.Add(buff2);

                        GameObject obj = NGUITools.AddChild(_TeamList[i].gameObject, _HealEffect[0]);
                        obj.transform.localPosition = new Vector3(0, -1, 0);
                    }
                }
            }
        }
    }
}