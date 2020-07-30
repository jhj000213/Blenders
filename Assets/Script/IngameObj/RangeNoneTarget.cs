using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeNoneTarget : MonoBehaviour {

    public GameObject _Parent;
    public Unit _TargetUnit;

    [System.Serializable]
    public class BuffStruct
    {
        public bool boolBuff;
        public List<int> BuffType;
        public float BuffTime;
        public int BuffCount;
    }
    public GameObject _MudWarrior;
    public GameObject _MudCloud;
    public GameObject _WaterHealZone;
    public GameObject _AirFastAttack;
    public GameObject _FireShout;
    public GameObject _GroundBarriorCreate;
    public GameObject _Ground_EarthQuake;
    public GameObject _SandBlind;
    public GameObject _RockBody;

    public RangeNoneTargetUpdate _UpdateMng;
    void Update()
    {
        MakeBuff();
        gameObject.SetActive(false);

    }

    void MakeBuff()
    {
        _TargetUnit = GameMng.Data._GameDate._HeroUnit;//변할수잇음
        List<string> bufftypeList = new List<string>();//버프동그라미 종류
        List<Vector2> bufficonpos = new List<Vector2>();//버프동그라미 뜨는 위치
        switch (GameMng.Data._SkillName)
        {
            case "warrior_15_high":
                {
                    Skill_Buff buff1 = new Skill_Buff();
                    buff1._BuffSetting(6, true, 4, 30);
                    _TargetUnit._BuffList.Add(buff1);
                    bufftypeList.Add(4.ToString());
                    bufficonpos.Add(new Vector2(-50, 0));

                    Skill_Buff buff2 = new Skill_Buff();
                    buff2._BuffSetting(6, true, 5, 50);
                    _TargetUnit._BuffList.Add(buff2);
                    bufftypeList.Add(5.ToString());
                    bufficonpos.Add(new Vector2(50, 0));

                    _TargetUnit.BuffIconEffect(0.5f, bufftypeList, bufficonpos);
                    GameObject obj = NGUITools.AddChild(_TargetUnit.gameObject, _MudWarrior);
                    obj.transform.localPosition = new Vector3(5, 60, 0);
                    break;
                }
                case "warrior_15_low":
                {
                    Skill_Buff buff1 = new Skill_Buff();
                    buff1._BuffSetting(4, true, 8,100);
                    _TargetUnit._BuffList.Add(buff1);
                    bufftypeList.Add(8.ToString());
                    bufficonpos.Add(new Vector2(0,0));

                    _TargetUnit.SetAlpha();
                    _TargetUnit.BuffIconEffect(1.0f,bufftypeList,bufficonpos);
                    GameObject obj = NGUITools.AddChild(_Parent, _MudCloud);
                    obj.transform.localPosition = _TargetUnit.transform.localPosition + new Vector3(0,40,0);
                    break;
                }
            case "warrior_9_low":
                {

                    GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._HeroUnit.gameObject, _WaterHealZone);
                    obj.GetComponent<Skill_HealZone>()._UseUnit = GameMng.Data._GameDate._HeroUnit;
                    obj.transform.localPosition = Vector3.zero;
                    break;
                }
            case "warrior_9_high":
                {
                    Skill_Buff buff1 = new Skill_Buff();
                    buff1._BuffSetting(5, true, 1, StaticDataMng._WaterSkill_High_Second[StaticDataMng._SkillLevel_High_9 - 1]);
                    buff1._MotionChangeNum = 2;
                    _TargetUnit._BuffList.Add(buff1);
                    bufftypeList.Add("1");
                    bufficonpos.Add(new Vector2(0, 0));


                    _TargetUnit.BuffIconEffect(0.5f, bufftypeList, bufficonpos);

                    

                    break;
                }
            case "warrior_21_high"://냉혹한 추위
                {
                    if (GameMng.Data._GameDate._HeroUnit._HeroFiledSkillNum != 1)
                        GameMng.Data._GameDate._HeroUnit._HeroFiledSkillNum = 1;
                    else
                        GameMng.Data._GameDate._HeroUnit._HeroFiledSkillNum = 0;

                    break;
                }
            case "warrior_6_high":
                {
                    if (GameMng.Data._GameDate._HeroUnit._HeroFiledSkillNum != 2)
                        GameMng.Data._GameDate._HeroUnit._HeroFiledSkillNum = 2;
                    else
                        GameMng.Data._GameDate._HeroUnit._HeroFiledSkillNum = 0;

                    break;
                }
            case "warrior_49_low"://속공
                {
                    Skill_Buff buff1 = new Skill_Buff();
                    buff1._BuffSetting(5, true, 1, StaticDataMng._AirSkill_Low_First[StaticDataMng._SkillLevel_Low_49 - 1]);//공격속도 버프 부여
                    buff1._AttackSubEffectNum = 1;
                    _TargetUnit._BuffList.Add(buff1);
                    bufftypeList.Add(1.ToString());
                    bufficonpos.Add(new Vector2(-50, 0));

                    Skill_Buff buff2 = new Skill_Buff();
                    buff2._BuffSetting(3.0f, true, 4, StaticDataMng._AirSkill_Low_Second[StaticDataMng._SkillLevel_Low_49 - 1]);//공격력 버프 부여
                    _TargetUnit._BuffList.Add(buff2);
                    bufftypeList.Add(4.ToString());
                    bufficonpos.Add(new Vector2(50, 0));

                    _TargetUnit.BuffIconEffect(0.5f, bufftypeList, bufficonpos);//버프 아이콘 이펙트 효과
                    GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._HeroUnit.gameObject, _AirFastAttack);
                    obj.transform.localPosition = new Vector3(0,60,0);
                    break;
                }
            case "warrior_25_low"://정신 집중
                {
                    GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._HeroUnit.gameObject, _GroundBarriorCreate);
                    //obj.transform.localPosition = GameMng.Data._GameDate._HeroUnit._FootPos;
                    GameMng.Data._GameDate._HeroUnit.ForHero_SetGroundBarrior(0.34f);
                    obj.transform.localPosition = Vector3.zero;
                    break;
                }
            case "warrior_25_high"://대지 분쇄
                {
                    GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._Parent, _Ground_EarthQuake);
                    obj.transform.localPosition = GameMng.Data._GameDate._HeroUnit.transform.localPosition;
                    obj.transform.localPosition += new Vector3(-20, 20);
                    obj.transform.GetChild(0).GetComponent<Skill_Circle>()._init(GameMng.Data._GameDate._HeroUnit, 1, 0, 1, StaticDataMng._GroundSkill_High[StaticDataMng._SkillLevel_High_25 - 1], 25);
                    GameMng.Data._GameDate._HeroUnit.GetComponent<Unit>().SetSprite_SkillShot(6, 11);


                    obj.transform.GetChild(0).GetComponent<Skill_Circle>()._CCType = 1;//스턴 CC
                    obj.transform.GetChild(0).GetComponent<Skill_Circle>()._CCTime = 3.0f;
                    break;
                }
            case "warrior_35_high"://위장 급습
                {
                    GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._Parent, _SandBlind);
                    obj.transform.localPosition = GameMng.Data._GameDate._HeroUnit.transform.localPosition;
                    GameMng.Data._GameDate._HeroUnit.GetComponent<Unit>().SetSprite_SkillShot(8, 6);
                    GameMng.Data._GameDate._HeroUnit._CantTarget = true;

                    List<Unit> _SandtargetUnit = new List<Unit>();
                    for (int i = 0; i < GameMng.Data._GameDate._EnemyUnitList.Count; i++)
                    {
                        if (Mathf.Sqrt(Mathf.Pow(GameMng.Data._GameDate._HeroUnit.transform.localPosition.x - GameMng.Data._GameDate._EnemyUnitList[i].transform.localPosition.x, 2) +
                                       Mathf.Pow(GameMng.Data._GameDate._HeroUnit.transform.localPosition.y - GameMng.Data._GameDate._EnemyUnitList[i].transform.localPosition.y, 2)) <= 430.0f)
                        {
                            _SandtargetUnit.Add(GameMng.Data._GameDate._EnemyUnitList[i]);
                        }
                    }
                    obj.GetComponent<RemoveSelfTimer>().DestroyTime = 0.625f + _SandtargetUnit.Count * 0.3f;
                    _UpdateMng.SetSandAfterImage(_SandtargetUnit);

                    break;
                }
            case "warrior_14_high":
                {
                    Skill_Buff buff1 = new Skill_Buff();
                    buff1._BuffSetting(3, true, 1, 100);
                    buff1._MotionChangeNum = 1;
                    _TargetUnit._BuffList.Add(buff1);
                    bufftypeList.Add(1.ToString());
                    bufficonpos.Add(new Vector2(0, 0));


                    _TargetUnit.BuffIconEffect(0.5f, bufftypeList, bufficonpos);
                    GameMng.Data._GameDate._HeroUnit.GetComponent<Unit>().SetSprite_SkillShot(3, 5);
                    break;
                }
            case "warrior_49_high":
                {
                    Skill_Buff buff2 = new Skill_Buff();
                    buff2._BuffSetting(1, true, 3, StaticDataMng._AirSkill_High[StaticDataMng._SkillLevel_High_49 - 1]*10, 0.5f);
                    GameMng.Data._GameDate._HeroUnit._BuffList.Add(buff2);

                    GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._HeroUnit.gameObject, GameMng.Data._EffectAnimation._AirHealEffect);
                    obj.transform.localPosition = new Vector3(0, 50, 0);
                    obj.GetComponent<UI2DSprite>().depth = obj.transform.parent.GetComponent<UISprite>().depth-1;

                    GameMng.Data._GameDate._HeroUnit.GetComponent<Unit>().SetSprite_SkillShot(2, 7);

                    break;
                }
            case "warrior_4_low":
                {
                    GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._HeroUnit.gameObject, _FireShout);
                    obj.transform.localPosition = GameMng.Data._GameDate._HeroUnit._FootPos;
                    obj.GetComponent<Skill_Circle>()._init(GameMng.Data._GameDate._HeroUnit, 1, 0, 1, StaticDataMng._FireSkill_Low[StaticDataMng._SkillLevel_Low_4 - 1], 4);
                    GameMng.Data._GameDate._HeroUnit.GetComponent<Unit>().SetSprite_SkillShot(4, 5);


                    obj.GetComponent<Skill_Circle>()._CCType = 2;
                    obj.GetComponent<Skill_Circle>()._CCTime = 0.2f;

                    break;
                }
            case "warrior_10_low":
                {
                    GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._HeroUnit.gameObject, _RockBody);
                    obj.transform.localPosition = GameMng.Data._GameDate._HeroUnit._FootPos;
                    GameMng.Data._GameDate._HeroUnit.GetComponent<Unit>().SetSprite_SkillShot(8, 24);

                    GameMng.Data._GameDate._HeroUnit._CantTarget = true;

                    break;
                }
        }

    }

    
}