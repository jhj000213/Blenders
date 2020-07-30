using UnityEngine;
using System.Collections;

public class UpgradeMng : MonoBehaviour {

    public PublicSoundData _SoundData;
    public DataSaveMng _SaveMng;

    public UILabel _LowSkillLevel;
    public UILabel _HighSkillLevel;
    public UILabel _SkillPoint;
    public UILabel _HeroClass;
    public UILabel _HPValue;
    public UILabel _AttackPointValue;
    public UILabel _PowerValue;
    public UILabel _IntellectValue;
    public UILabel _ArmorValue;
    public UILabel _HealthValue;
    public UILabel _CriticalValue;
    public UILabel _AvoidValue;
    public UILabel _MoveSpeedValue;
    public UILabel _AttackSpeedValue;

    public UILabel _SoldierLevel;
    public UILabel _SoldierDmg;
    public UILabel _SoldierHP;
    public UILabel _SoldierUpgradeNeedGold;

    public UILabel _Gold;

    public UISprite _SkillEleTypeIcon;
    public UILabel _SkillEleTypeLabel;
    public UILabel _SkillLowName;
    public UILabel _SkillHighName;
    public UISprite _SkillLowIcon;
    public UISprite _SkillHighIcon;

    public UILabel _SkillEleType;
    public UILabel _SkillDmgValue;
    public UILabel _SkillCoolTime;
    public UILabel _SkillInfoValue;

    public GameObject _AlarmLabelParent;
    public GameObject _NeedLevel_Skill;

    public bool _HighLow;

    public PopupNumMng _PopupMng;

    public int _nowSelectSkillEleType;
    public int _nowSelectSoldierType;


    public bool _true = true;
    public bool _false = false;
    void Start()
    {
        //StaticDataMng._HeroSkillPoint = 10;
        //StaticDataMng._HeroLevel = 3;
        //StaticDataMng._HeroSkillPoint = 20;
    }

    void HeroStatUpdate()
    {
        _HeroClass.text = "전사";//temp

        int basepower = 1;
        int basepowermultyple = 1;
        int baseintellect = 1;
        int baseintellectmultyple = 1;
        int basehealth = 1;
        int basehealthmultyple = 1;
        int basehpmultyple = 1;

        //if (_Type == 1)
        //{
            basepower = 30;
            basepowermultyple = 30;
            baseintellect = 10;
            baseintellectmultyple = 10;
            basehealth = 40;
            basehealthmultyple = 40;
            basehpmultyple = 1000;
        //}
        //if (_Type == 2)
        //{
        //    basepower = 1;
        //    basepowermultyple = 1;
        //    baseintellect = 4;
        //    baseintellectmultyple = 5;
        //    basehealth = 2;
        //    basehealthmultyple = 1;
        //    basehpmultyple = 50;
        //}
        HeroItem weapon = new HeroItem();
        HeroItem armor = new HeroItem();
        if (StaticDataMng._HeroSetItem_Armor.Count != 0)
        {
            armor._AttackPoint = StaticDataMng._HeroSetItem_Armor[0]._AttackPoint;
            armor._PowerPoint = StaticDataMng._HeroSetItem_Armor[0]._PowerPoint;
            armor._IntellectPoint = StaticDataMng._HeroSetItem_Armor[0]._IntellectPoint;
            armor._ArmorPoint = StaticDataMng._HeroSetItem_Armor[0]._ArmorPoint;
            armor._HealthPoint = StaticDataMng._HeroSetItem_Armor[0]._HealthPoint;
        }
        if (StaticDataMng._HeroSetItem_Weapon.Count != 0)
        {
            weapon._AttackPoint = StaticDataMng._HeroSetItem_Weapon[0]._AttackPoint;
            weapon._PowerPoint = StaticDataMng._HeroSetItem_Weapon[0]._PowerPoint;
            weapon._IntellectPoint = StaticDataMng._HeroSetItem_Weapon[0]._IntellectPoint;
            weapon._ArmorPoint = StaticDataMng._HeroSetItem_Weapon[0]._ArmorPoint;
            weapon._HealthPoint = StaticDataMng._HeroSetItem_Weapon[0]._HealthPoint;
        }

        _AttackPointValue.text = ((20 + weapon._AttackPoint)).ToString();
        _PowerValue.text = ((basepower+(StaticDataMng._HeroLevel * basepowermultyple) + armor._PowerPoint + weapon._PowerPoint)).ToString();
        _IntellectValue.text = ((baseintellect + (StaticDataMng._HeroLevel * baseintellectmultyple) + armor._IntellectPoint + weapon._IntellectPoint)).ToString();
        _ArmorValue.text = ((armor._ArmorPoint + weapon._ArmorPoint)).ToString();
        _HealthValue.text = ((basehealth + (StaticDataMng._HeroLevel * basehealthmultyple) + armor._HealthPoint + weapon._HealthPoint)).ToString();
        _CriticalValue.text = "0" + " %";
        _AvoidValue.text = "0" +  " %";
        _MoveSpeedValue.text = "300";
        _AttackSpeedValue.text = "0" + " %";

        _HPValue.text = (((2000 + basehpmultyple * StaticDataMng._HeroLevel) + 
            ((2 * (armor._ArmorPoint + weapon._ArmorPoint) * (basehealth +
            (StaticDataMng._HeroLevel * basehealthmultyple) + armor._HealthPoint + weapon._HealthPoint)) / 10)
            )).ToString();
    }

    void ElseInfoUpdate()
    {
        _Gold.text = StaticDataMng._Gold.ToString();
    }
    void SkillInfoUpdate()
    {
       
        _SkillLowIcon.spriteName = "skillicon_warrior_" + _nowSelectSkillEleType.ToString() + "_low";
        _SkillHighIcon.spriteName = "skillicon_warrior_" + _nowSelectSkillEleType.ToString() + "_high";
        if (_nowSelectSkillEleType == 4)
        {
            _LowSkillLevel.text = StaticDataMng._SkillLevel_Low_4.ToString();
            if (StaticDataMng._SkillLevel_Low_4 == 10)
                _LowSkillLevel.text = "Max";
            _HighSkillLevel.text = StaticDataMng._SkillLevel_High_4.ToString();
            if (StaticDataMng._SkillLevel_High_4 == 10)
                _HighSkillLevel.text = "Max";

            _SkillEleTypeLabel.text = "불";
            _SkillEleTypeIcon.spriteName = "fireball";
            _SkillLowName.text = "불의 외침";
            _SkillHighName.text = "화염의 심판";
            _SkillEleType.text = "불";
            if (_HighLow)
            {
                _SkillDmgValue.text = "- 검 낙하 -" + "\r\n" + (StaticDataMng._FireSkill_High_First[StaticDataMng._SkillLevel_High_4 - 1]).ToString() + "\r\n" + "- 폭발 -" + "\r\n" + (StaticDataMng._FireSkill_High_Second[StaticDataMng._SkillLevel_High_4 - 1]).ToString();
                _SkillInfoValue.text = "지정한 위치에 불로 만들어진 검을 낙하한다. 낙하된 검은 지면을 뚫고 들어가서 폭파한다음 사라진다.";
                _SkillCoolTime.text = (StaticDataMng._FireSkill_High_CoolTime[StaticDataMng._SkillLevel_High_4]).ToString() + "초";
            }
            else
            {
                _SkillDmgValue.text = (StaticDataMng._FireSkill_Low[StaticDataMng._SkillLevel_Low_4 - 1]).ToString();
                _SkillInfoValue.text = "주위에 있는 적들을 일정거리 밀어내고 데미지를 입힌다";
                _SkillCoolTime.text = (StaticDataMng._FireSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_4 - 1]).ToString() + "초";
            }
        }
        else if (_nowSelectSkillEleType == 9)
        {
            _LowSkillLevel.text = StaticDataMng._SkillLevel_Low_9.ToString();
            if (StaticDataMng._SkillLevel_Low_9 == 10)
                _LowSkillLevel.text = "Max";
            _HighSkillLevel.text = StaticDataMng._SkillLevel_High_9.ToString();
            if (StaticDataMng._SkillLevel_High_9 == 10)
                _HighSkillLevel.text = "Max";

            _SkillEleTypeLabel.text = "물";
            _SkillEleTypeIcon.spriteName = "waterball";
            _SkillLowName.text = "전투의 물결";
            _SkillHighName.text = "폭풍검";
            _SkillEleType.text = "물";
            if (_HighLow)
            {
                _SkillDmgValue.text = "- 수탄(개당) -" + "\r\n" + (StaticDataMng._WaterSkill_High_First[StaticDataMng._SkillLevel_High_9 - 1]).ToString() + "\r\n" + "- 베기 -" + "\r\n" + (StaticDataMng._WaterSkill_High_Second[StaticDataMng._SkillLevel_High_9 - 1]).ToString();
                _SkillInfoValue.text = "검을 치켜들어 적이 있는 방향으로 검을 5번 빠르게 벤다. 베는 동안 주위에 얇은 수탄이 생기며 적을 추적한다.";
                _SkillCoolTime.text = (StaticDataMng._WaterSkill_High_CoolTime[StaticDataMng._SkillLevel_High_9 - 1]).ToString() + "초";
            }
            else
            {
                _SkillDmgValue.text = (StaticDataMng._WaterSkill_Low[StaticDataMng._SkillLevel_Low_9 - 1] * 10).ToString();
                _SkillInfoValue.text = "주위의 아군에게 조금씩 치유가 되는 버프를 시전한다.";
                _SkillCoolTime.text = (StaticDataMng._WaterSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_9 - 1]).ToString() + "초";
            }
        }
        else if (_nowSelectSkillEleType == 25)
        {
            _LowSkillLevel.text = StaticDataMng._SkillLevel_Low_25.ToString();
            if(StaticDataMng._SkillLevel_Low_25==10)
                _LowSkillLevel.text = "Max";
            _HighSkillLevel.text = StaticDataMng._SkillLevel_High_25.ToString();
            if (StaticDataMng._SkillLevel_High_25 == 10)
                _HighSkillLevel.text = "Max";

            _SkillEleTypeLabel.text = "대지";
            _SkillEleTypeIcon.spriteName = "groundball";
            _SkillLowName.text = "집중";
            _SkillHighName.text = "대지분쇄";
            _SkillEleType.text = "대지";
            if (_HighLow)
            {
                _SkillDmgValue.text = (StaticDataMng._GroundSkill_High[StaticDataMng._SkillLevel_High_25 - 1]).ToString();
                _SkillInfoValue.text = "땅을 검으로 내리찍어서 충격파를 발생시킨다. 이 충격파는 부채꼴범위로 퍼져나가게 하며 맞은 적은 일정 시간 기절한다.";
                _SkillCoolTime.text = (StaticDataMng._GroundSkill_High_CoolTime[StaticDataMng._SkillLevel_High_25 - 1]).ToString() + "초";
            }
            else
            {
                _SkillDmgValue.text = "없음";
                _SkillInfoValue.text = "기술을 시전하고 제일 처음 들어오는 피해를 막는다.";
                _SkillCoolTime.text = (StaticDataMng._GroundSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_25 - 1]).ToString() + "초";
            }
        }
        else if (_nowSelectSkillEleType == 49)
        {
            _LowSkillLevel.text = StaticDataMng._SkillLevel_Low_49.ToString();
            if (StaticDataMng._SkillLevel_Low_49 == 10)
                _LowSkillLevel.text = "Max";
            _HighSkillLevel.text = StaticDataMng._SkillLevel_High_49.ToString();
            if (StaticDataMng._SkillLevel_High_49 == 10)
                _HighSkillLevel.text = "Max";

            _SkillEleTypeLabel.text = "공기";
            _SkillEleTypeIcon.spriteName = "airball";
            _SkillLowName.text = "속공";
            _SkillHighName.text = "숨돌리기";
            _SkillEleType.text = "공기";
            if (_HighLow)
            {
                _SkillDmgValue.text = (StaticDataMng._AirSkill_High[StaticDataMng._SkillLevel_High_49 - 1]).ToString();
                _SkillInfoValue.text = "숨을 크게 들이쉬어 전투 중에 누적된 피로를 푼다.";
                _SkillCoolTime.text = (StaticDataMng._AirSkill_High_CoolTime[StaticDataMng._SkillLevel_High_49 - 1]).ToString() + "초";
            }
            else
            {
                _SkillDmgValue.text = "- 속도 증가율 -" + "\r\n" + (StaticDataMng._AirSkill_Low_First[StaticDataMng._SkillLevel_Low_49 - 1]).ToString() + " %" + "\r\n" + "- 공격력 증가율 -" + "\r\n" + (StaticDataMng._AirSkill_Low_Second[StaticDataMng._SkillLevel_Low_49 - 1]).ToString() + " %";
                _SkillInfoValue.text = "일정시간 동안 공격속도를 증가 시키고 시전 후 5번의 기본 공격의 데미지를 증폭시킨다.";
                _SkillCoolTime.text = (StaticDataMng._AirSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_49 - 1]).ToString() + "초";
            }
        }
        else if (_nowSelectSkillEleType == 6)
        {
            _LowSkillLevel.text = StaticDataMng._SkillLevel_Low_6.ToString();
            _HighSkillLevel.text = StaticDataMng._SkillLevel_High_6.ToString();
            _SkillEleTypeLabel.text = "증기";
            _SkillEleTypeIcon.spriteName = "fogball";
            _SkillLowName.text = "전투의 대가";
            _SkillHighName.text = "열풍";
            _SkillEleType.text = "증기";
            if (_HighLow)
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_High_6 * 0.2f).ToString();
                _SkillInfoValue.text = "자신의 주위에 뜨거운 증기를 발산한다. 증기 범위안에 있는 적들은 지속적으로 피해를 입고 약화되어 받는 데미지가 증폭된다.";
            }
            else
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_Low_6 * 0.2f).ToString();
                _SkillInfoValue.text = "뜨거운 증기를 전방으로 내뿜어 시야를 차단하고 돌진한다. 대상은 네임드몬스터->일반몬스터 순으로 지정되며, 일반 몬스터만 있을 경우 체럭이 가장 많은 대상에게 돌진한다. 돌진하는 중 적 몬스터와 충돌하면 적 몬스터는 밀어낸다.";
            }
        }
        else if (_nowSelectSkillEleType == 15)
        {
            _LowSkillLevel.text = StaticDataMng._SkillLevel_Low_15.ToString();
            _HighSkillLevel.text = StaticDataMng._SkillLevel_High_15.ToString();
            _SkillEleTypeLabel.text = "진흙";
            _SkillEleTypeIcon.spriteName = "mudball";
            _SkillLowName.text = "위장";
            _SkillHighName.text = "늪의 전사";
            _SkillEleType.text = "진흙";
            if (_HighLow)
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_High_15 * 0.2f).ToString();
                _SkillInfoValue.text = "바닥이 질척해서 움직이기 어려운 늪에서 살던 전사의 혼을 불러내 일정 시간동안 공격속도, 이동속도가 증가한다.";
            }
            else
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_Low_15 * 0.2f).ToString();
                _SkillInfoValue.text = "주변의 자연과 비슷한 색깔로 갑옷을 칠해 주변의 자연과 동화된다. 적이 공격할 때 회피할 확률이 늘어나게 된다.";
            }
        }
        else if (_nowSelectSkillEleType == 35)
        {
            _LowSkillLevel.text = StaticDataMng._SkillLevel_Low_35.ToString();
            _HighSkillLevel.text = StaticDataMng._SkillLevel_High_35.ToString();
            _SkillEleTypeLabel.text = "모래";
            _SkillEleTypeIcon.spriteName = "sandball";
            _SkillLowName.text = "비겁한 술수";
            _SkillHighName.text = "위장 급습";
            _SkillEleType.text = "모래";
            if (_HighLow)
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_High_35 * 0.2f).ToString();
                _SkillInfoValue.text = "자신의 몸을 모래폭풍 속에 숨기고 주변의 적 4명을 강타한 후 원래 자리로 되돌아온다. 시전중에는 무적 상태가 된다.";
            }
            else
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_Low_35 * 0.2f).ToString();
                _SkillInfoValue.text = "검을 땅에 박은 후 파내어 모래를 적의 눈에 뿌린다. 타격당한 적은 일정 시간 동안 적중률이 하락한다.";
            }
        }
        else if (_nowSelectSkillEleType == 14)
        {
            _LowSkillLevel.text = StaticDataMng._SkillLevel_Low_14.ToString();
            _HighSkillLevel.text = StaticDataMng._SkillLevel_High_14.ToString();
            _SkillEleTypeLabel.text = "염화";
            _SkillEleTypeIcon.spriteName = "flameball";
            _SkillLowName.text = "폭발 돌진";
            _SkillHighName.text = "크로즌의 보검";
            _SkillEleType.text = "염화";
            if (_HighLow)
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_High_14 * 0.2f).ToString();
                _SkillInfoValue.text = "검에 전사의 혼을 주입해 검을 불로 감싸서 3회의 기본공격을 강화시킨다.";
            }
            else
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_Low_14 * 0.2f).ToString();
                _SkillInfoValue.text = "방패를 앞세워 일정 거리를 돌진한다.";
            }
        }
        else if (_nowSelectSkillEleType == 21)
        {
            _LowSkillLevel.text = StaticDataMng._SkillLevel_Low_21.ToString();
            _HighSkillLevel.text = StaticDataMng._SkillLevel_High_21.ToString();
            _SkillEleTypeLabel.text = "얼음";
            _SkillEleTypeIcon.spriteName = "iceball";
            _SkillLowName.text = "얼음 칼날";
            _SkillHighName.text = "냉혹한 추위";
            _SkillEleType.text = "얼음";
            if (_HighLow)
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_High_21 * 0.2f).ToString();
                _SkillInfoValue.text = "자신의 몸 주위에 찬 기운이 감돌게 한다. 적이 찬 기운에 노출될 경우, 공격속도와 이동속도가 느려지고, 아군의 데미지가 증폭된다.";
            }
            else
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_Low_21 * 0.2f).ToString();
                _SkillInfoValue.text = "전방에 부채꼴 모양으로 날카롭게 얼어붙은 단도를 투척한다.";
            }
        }
        else if (_nowSelectSkillEleType == 10)
        {
            _LowSkillLevel.text = StaticDataMng._SkillLevel_Low_21.ToString();
            _HighSkillLevel.text = StaticDataMng._SkillLevel_High_21.ToString();
            _SkillEleTypeLabel.text = "바위";
            _SkillEleTypeIcon.spriteName = "rockball";
            _SkillLowName.text = "바위 투척";
            _SkillHighName.text = "암석화";
            _SkillEleType.text = "바위";
            if (_HighLow)
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_High_10 * 0.2f).ToString();
                _SkillInfoValue.text = "자신의 몸을 암석처럼 딱딱하게 굳힌다. 암석이 된 상태에선 공격을 할 수 없지만, 버프 유형의 스킬은 사용할 수 있다. 암석화가 된 상태에서는 적의 데미지가 감소하고 자신의 치유량이 증가한다.";
            }
            else
            {
                _SkillDmgValue.text = (1.0f + (float)StaticDataMng._SkillLevel_Low_10 * 0.2f).ToString();
                _SkillInfoValue.text = "전방으로 큰 돌덩이를 투척해 큰 피해를 입히고 기절시킨다. 네임드 몬스터가 피격시 데미지와 스턴 시간이 2배가 된다.";
            }
        }
        _SkillPoint.text = StaticDataMng._HeroSkillPoint.ToString();
    }
    void SoldierInfoUpdate()
    {
        _nowSelectSoldierType = _PopupMng._SoldierTabNum;

        if (_nowSelectSoldierType == 1)
        {
            _SoldierLevel.text = StaticDataMng._Soldier_Warrior_Level.ToString();
            _SoldierDmg.text = (StaticDataMng._Soldier_W_Damage[StaticDataMng._Soldier_Warrior_Level]*10).ToString();
            _SoldierHP.text = (StaticDataMng._Soldier_W_HP[StaticDataMng._Soldier_Warrior_Level] * 10).ToString();
            _SoldierUpgradeNeedGold.text = (StaticDataMng._Soldier_W_Price[StaticDataMng._Soldier_Warrior_Level]).ToString();
        }
        else if (_nowSelectSoldierType == 2)
        {
            _SoldierLevel.text = StaticDataMng._Soldier_Archer_Level.ToString();
            _SoldierDmg.text = (StaticDataMng._Soldier_A_Damage[StaticDataMng._Soldier_Archer_Level] * 10).ToString();
            _SoldierHP.text = (StaticDataMng._Soldier_A_HP[StaticDataMng._Soldier_Archer_Level] * 10).ToString();
            _SoldierUpgradeNeedGold.text = (StaticDataMng._Soldier_A_Price[StaticDataMng._Soldier_Archer_Level]).ToString();
        }
        else if (_nowSelectSoldierType == 3)
        {
            _SoldierLevel.text = StaticDataMng._Soldier_Mage_Level.ToString();
            _SoldierDmg.text = (StaticDataMng._Soldier_Mage_Level * 10).ToString();
            _SoldierHP.text = (StaticDataMng._Soldier_Mage_Level * 100).ToString();
            _SoldierUpgradeNeedGold.text = (StaticDataMng._Soldier_Mage_Level * 200).ToString();
        }
    }

    void Update()
    {
        HeroStatUpdate();
        ElseInfoUpdate();
        SkillInfoUpdate();
        SoldierInfoUpdate();
    }


    public void UpgradeSkillLevel(bool updown, bool highlow)
    {
        AudioSource.PlayClipAtPoint(_SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
        _HighLow = highlow;
        if (_nowSelectSkillEleType == 4)
        {
            if (highlow)
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0 && StaticDataMng._SkillLevel_High_4<10)
                    {
                        if(StaticDataMng._SkillLevel_High_4<StaticDataMng._HeroLevel)
                        {
                            StaticDataMng._SkillLevel_High_4++;
                            StaticDataMng._HeroSkillPoint--;
                        }
                        else
                        {
                            GameObject obj = NGUITools.AddChild(_AlarmLabelParent, _NeedLevel_Skill);
                            obj.transform.localPosition = new Vector3(0, 0, 0);
                            obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        }
                    }
                    
                }
                else
                {
                    if (StaticDataMng._SkillLevel_High_4 > 1)
                    {
                        StaticDataMng._SkillLevel_High_4--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
            else
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0 && StaticDataMng._SkillLevel_Low_4 < 10)
                    {
                        if (StaticDataMng._SkillLevel_Low_4 < StaticDataMng._HeroLevel)
                        {
                            StaticDataMng._SkillLevel_Low_4++;
                            StaticDataMng._HeroSkillPoint--;
                        }
                        else
                        {
                            GameObject obj = NGUITools.AddChild(_AlarmLabelParent, _NeedLevel_Skill);
                            obj.transform.localPosition = new Vector3(0, 0, 0);
                            obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        }
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_Low_4 > 1)
                    {
                        StaticDataMng._SkillLevel_Low_4--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
        }
        else if (_nowSelectSkillEleType == 9)
        {
            if (highlow)
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0 && StaticDataMng._SkillLevel_High_9 < 10)
                    {
                        if (StaticDataMng._SkillLevel_High_9 < StaticDataMng._HeroLevel)
                        {
                            StaticDataMng._SkillLevel_High_9++;
                            StaticDataMng._HeroSkillPoint--;
                        }
                        else
                        {
                            GameObject obj = NGUITools.AddChild(_AlarmLabelParent, _NeedLevel_Skill);
                            obj.transform.localPosition = new Vector3(0, 0, 0);
                            obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        }
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_High_9 > 1)
                    {
                        StaticDataMng._SkillLevel_High_9--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
            else
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0 && StaticDataMng._SkillLevel_Low_9 < 10)
                    {
                        if (StaticDataMng._SkillLevel_Low_9 < StaticDataMng._HeroLevel)
                        {
                            StaticDataMng._SkillLevel_Low_9++;
                            StaticDataMng._HeroSkillPoint--;
                        }
                        else
                        {
                            GameObject obj = NGUITools.AddChild(_AlarmLabelParent, _NeedLevel_Skill);
                            obj.transform.localPosition = new Vector3(0, 0, 0);
                            obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        }
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_Low_9 > 1)
                    {
                        StaticDataMng._SkillLevel_Low_9--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
        }
        else if (_nowSelectSkillEleType == 25)
        {
            if (highlow)
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0 && StaticDataMng._SkillLevel_High_25 < 10)
                    {
                        if (StaticDataMng._SkillLevel_High_25 < StaticDataMng._HeroLevel)
                        {
                            StaticDataMng._SkillLevel_High_25++;
                            StaticDataMng._HeroSkillPoint--;
                        }
                        else
                        {
                            GameObject obj = NGUITools.AddChild(_AlarmLabelParent, _NeedLevel_Skill);
                            obj.transform.localPosition = new Vector3(0, 0, 0);
                            obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        }
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_High_25 > 1)
                    {
                        StaticDataMng._SkillLevel_High_25--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
            else
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0 && StaticDataMng._SkillLevel_Low_25 < 10)
                    {
                        if (StaticDataMng._SkillLevel_Low_25 < StaticDataMng._HeroLevel)
                        {
                            StaticDataMng._SkillLevel_Low_25++;
                            StaticDataMng._HeroSkillPoint--;
                        }
                        else
                        {
                            GameObject obj = NGUITools.AddChild(_AlarmLabelParent, _NeedLevel_Skill);
                            obj.transform.localPosition = new Vector3(0, 0, 0);
                            obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        }
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_Low_25 > 1)
                    {
                        StaticDataMng._SkillLevel_Low_25--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
        }
        else if (_nowSelectSkillEleType == 49)
        {
            if (highlow)
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0 && StaticDataMng._SkillLevel_High_49 < 10)
                    {
                        if (StaticDataMng._SkillLevel_High_49 < StaticDataMng._HeroLevel)
                        {
                            StaticDataMng._SkillLevel_High_49++;
                            StaticDataMng._HeroSkillPoint--;
                        }
                        else
                        {
                            GameObject obj = NGUITools.AddChild(_AlarmLabelParent, _NeedLevel_Skill);
                            obj.transform.localPosition = new Vector3(0, 0, 0);
                            obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        }
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_High_49 > 1)
                    {
                        StaticDataMng._SkillLevel_High_49--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
            else
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0 && StaticDataMng._SkillLevel_Low_49 < 10)
                    {
                        if (StaticDataMng._SkillLevel_Low_49 < StaticDataMng._HeroLevel)
                        {
                            StaticDataMng._SkillLevel_Low_49++;
                            StaticDataMng._HeroSkillPoint--;
                        }
                        else
                        {
                            GameObject obj = NGUITools.AddChild(_AlarmLabelParent, _NeedLevel_Skill);
                            obj.transform.localPosition = new Vector3(0, 0, 0);
                            obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                        }
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_Low_49 > 1)
                    {
                        StaticDataMng._SkillLevel_Low_49--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
        }
        else if (_nowSelectSkillEleType == 6)
        {
            if (highlow)
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_High_6++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_High_6 > 1)
                    {
                        StaticDataMng._SkillLevel_High_6--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
            else
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_Low_6++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_Low_6 > 1)
                    {
                        StaticDataMng._SkillLevel_Low_6--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
        }
        else if (_nowSelectSkillEleType == 15)
        {
            if (highlow)
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_High_15++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_High_15 > 1)
                    {
                        StaticDataMng._SkillLevel_High_15--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
            else
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_Low_15++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_Low_15 > 1)
                    {
                        StaticDataMng._SkillLevel_Low_15--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
        }
        else if (_nowSelectSkillEleType == 35)
        {
            if (highlow)
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_High_35++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_High_35 > 1)
                    {
                        StaticDataMng._SkillLevel_High_35--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
            else
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_Low_35++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_Low_35 > 1)
                    {
                        StaticDataMng._SkillLevel_Low_35--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
        }
        else if (_nowSelectSkillEleType == 14)
        {
            if (highlow)
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_High_14++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_High_14 > 1)
                    {
                        StaticDataMng._SkillLevel_High_14--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
            else
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_Low_14++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_Low_14 > 1)
                    {
                        StaticDataMng._SkillLevel_Low_14--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
        }
        else if (_nowSelectSkillEleType == 21)
        {
            if (highlow)
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_High_21++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_High_21 > 1)
                    {
                        StaticDataMng._SkillLevel_High_21--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
            else
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_Low_21++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_Low_21 > 1)
                    {
                        StaticDataMng._SkillLevel_Low_21--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
        }
        else if (_nowSelectSkillEleType == 10)
        {
            if (highlow)
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_High_10++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_High_10 > 1)
                    {
                        StaticDataMng._SkillLevel_High_10--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
            else
            {
                if (updown)
                {
                    if (StaticDataMng._HeroSkillPoint > 0)
                    {
                        StaticDataMng._SkillLevel_Low_10++;
                        StaticDataMng._HeroSkillPoint--;
                    }
                }
                else
                {
                    if (StaticDataMng._SkillLevel_Low_10 > 1)
                    {
                        StaticDataMng._SkillLevel_Low_10--;
                        StaticDataMng._HeroSkillPoint++;
                    }
                }
            }
        }
        _SaveMng.Saving();
    }

    public void UpgradeSoldierLevel(bool updown)
    {
        //Debug.Log("soldier");
        if(_nowSelectSoldierType==1)
        {
            if(updown)
            {
                //솔저레벨 조건 추가
                if (StaticDataMng._Soldier_Warrior_Level < 10)
                {
                    if (StaticDataMng._Gold >= StaticDataMng._Soldier_W_Price[StaticDataMng._Soldier_Warrior_Level])
                    {
                        AudioSource.PlayClipAtPoint(_SoundData._UsingGold, Vector2.zero, StaticDataMng._SoundOn);
                        StaticDataMng._Gold -= StaticDataMng._Soldier_W_Price[StaticDataMng._Soldier_Warrior_Level];
                        StaticDataMng._Soldier_Warrior_Level++;
                    }
                }
            }
        }
        else if (_nowSelectSoldierType == 2)
        {
            if (updown)
            {
                //솔저레벨 조건 추가
                if (StaticDataMng._Soldier_Archer_Level < 10)
                {
                    if (StaticDataMng._Gold >= StaticDataMng._Soldier_A_Price[StaticDataMng._Soldier_Archer_Level])
                    {
                        AudioSource.PlayClipAtPoint(_SoundData._UsingGold, Vector2.zero, StaticDataMng._SoundOn);
                        StaticDataMng._Gold -= StaticDataMng._Soldier_A_Price[StaticDataMng._Soldier_Archer_Level];
                        StaticDataMng._Soldier_Archer_Level++;
                    }
                }
            }
        }
        else if (_nowSelectSoldierType == 3)
        {
            if (updown)
            {
                //솔저레벨 조건 추가
                if(StaticDataMng._Soldier_Mage_Level<10)
                {
                    if (StaticDataMng._Gold >= StaticDataMng._Soldier_Mage_Level * 200)
                    {
                        AudioSource.PlayClipAtPoint(_SoundData._UsingGold, Vector2.zero, StaticDataMng._SoundOn);
                        StaticDataMng._Gold -= StaticDataMng._Soldier_Mage_Level * 200;
                        StaticDataMng._Soldier_Mage_Level++;
                    }
                }
                
            }
        }
        _SaveMng.Saving();
    }

    public void SetElementType(int num)
    {
        _nowSelectSkillEleType = num;
    }

    Color hexToColor(string hex)
    {
        hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
        hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
        byte a = 255;//assume fully visible unless specified in hex
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        //Only use alpha if the string has enough characters

        return new Color32(r, g, b, a);
    }
}
