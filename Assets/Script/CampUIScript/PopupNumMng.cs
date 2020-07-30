using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopupNumMng : MonoBehaviour {

    public PublicSoundData _SoundData;

    public GameObject _WorldMap;
    public Animator _WorldMapAnimator;

    public GameObject[] _WorldMapArrow;

    public GameObject _MainPopup;
    public GameObject _HeroTab;
    public GameObject _ItemTab;
    public GameObject _ItemTab_ArmorTab;
    public GameObject _ItemTab_WarriorWeaponTab;
    public GameObject _ItemTab_MageWeaponTab;
    public GameObject _ItemTab_ShamanWeaponTab;
    public GameObject _ItemTab_ExpendableseTab;
    public GameObject _SkillTab;
    public GameObject _SkillTab_1;
    public GameObject _SkillTab_2;
    public GameObject _SkillTab_3;
    public GameObject _SoldierTab;
    public GameObject _SoldierTab_Warrior;
    public GameObject _SoldierTab_Archer;
    public GameObject _SoldierTab_Mage;
    public GameObject _SoldierTab_LevelSetting;
    public GameObject _SoldierTab_SetFormation;
    public UI2DSprite _HeroExpGaze;
    public UI2DSprite _HeroExpGaze_1;
    public UILabel _HeroNowExpValue;
    public UILabel _HeroNowExpValue_1;
    public UILabel _HeroMaxExpValue;
    public UILabel _HeroExpPercent;
    public UILabel _HeroLevel;

    public UIGrid _MobGrid;
    public GameObject _MobIcon;
    public UILabel _StageLevel;

    public GameObject _StageSelectPopup;
    public UILabel _NowSelectStage;

    public GameObject _SoldierUpgradePopup;
    public GameObject _PormationResetPopup;

    public GameObject _QuestPopup;
    public GameObject _NoPormationPopup;
    public GameObject _NoVoidItemSlotPopup;

    public GameObject _VillageLock;
    public GameObject _SnowMountainLock;
    public GameObject _AradraLock;
    public GameObject _SunguardLock;
    public GameObject _LeftGrassLock;
    public GameObject _RightGrassLock;
    public GameObject _FireForestLock;
    public GameObject _PortLock;
    public GameObject _ShipLock;

    public QuestMng _QuestMng;

    public int _NowPopupSetNum;
    public int _NoPormationOn;
    public int _NoVoidItemSlotOn;

    public int _SoldierUpgradePopupOn;

    public int _PormationResetPopupOn;

    public int _ItemTabNum;
    public int _SkillTabNum;
    public int _SoldierTabNum;

    public int _zero = 0;
    public int _one = 1;
    public int _tow = 2;
    public int _three = 3;
    public int _four = 4;
    public int _five = 5;
    public int _six = 6;
    public int _seven = 7;

    public int _Fire_Origin = 4;
    public int _Water_Origin = 9;
    public int _Ground_Origin = 25;
    public int _Air_Origin = 49;
    public int _Fog_Origin = 6;
    public int _Mud_Origin = 15;
    public int _Sand_Origin = 35;
    public int _Flame_Origin = 14;
    public int _Ice_Origin = 21;
    public int _Rock_Origin = 10;

    void Start()
    {
        _NowPopupSetNum = 0;
        _ItemTabNum = 1;
        _SkillTabNum = 1;
        _SoldierTabNum = 1;

        _WorldMap.transform.localPosition = new Vector3(PlayerPrefs.GetInt("WorldmapPos")*1280,0,0);
    }

    void LockUpdate()
    {
        if (PlayerPrefs.GetInt("SecondWorldmapOpen")==1)
        {
            _WorldMapArrow[0].SetActive(true);
            _WorldMapArrow[1].SetActive(true);
        }
        else
        {
            _WorldMapArrow[0].SetActive(false);
            _WorldMapArrow[1].SetActive(false);
        }

        if (PlayerPrefs.GetInt("SnowMountainUnlock") == 1)
            _SnowMountainLock.SetActive(false);
        else
            _SnowMountainLock.SetActive(true);

        if (PlayerPrefs.GetInt("VillageUnlock") == 1)
            _VillageLock.SetActive(false);
        else
            _VillageLock.SetActive(true);

        if (PlayerPrefs.GetInt("AradraUnlock") == 1)
            _AradraLock.SetActive(false);
        else
            _AradraLock.SetActive(true);

        if (PlayerPrefs.GetInt("SunSpearUnlock") == 1)
            _SunguardLock.SetActive(false);
        else
            _SunguardLock.SetActive(true);

        if (PlayerPrefs.GetInt("LeftGrassUnlock") == 1)
            _LeftGrassLock.SetActive(false);
        else
            _LeftGrassLock.SetActive(true);

        if (PlayerPrefs.GetInt("RightGrassUnlock") == 1)
            _RightGrassLock.SetActive(false);
        else
            _RightGrassLock.SetActive(true);

        if (PlayerPrefs.GetInt("FireForestUnlock") == 1)
            _FireForestLock.SetActive(false);
        else
            _FireForestLock.SetActive(true);

    }

    void Update()
    {
        LockUpdate();
        _HeroExpGaze.fillAmount = StaticDataMng._HeroExpValue / StaticDataMng._HeroMaxExpValue;
        _HeroExpGaze_1.fillAmount = StaticDataMng._HeroExpValue / StaticDataMng._HeroMaxExpValue;
        _HeroNowExpValue.text = ((int)StaticDataMng._HeroExpValue).ToString();
        _HeroNowExpValue_1.text = ((int)StaticDataMng._HeroExpValue).ToString() + "   EXP";
        _HeroExpPercent.text = ((int)((StaticDataMng._HeroExpValue / StaticDataMng._HeroMaxExpValue)*100.0f)).ToString();
        _HeroMaxExpValue.text = ((int)StaticDataMng._HeroMaxExpValue).ToString();

        _HeroLevel.text = StaticDataMng._HeroLevel.ToString();
        if(_NowPopupSetNum == 0)
        {
            _QuestPopup.SetActive(false);
            _MainPopup.SetActive(false);
            _StageSelectPopup.SetActive(false);
        }
        else if(_NowPopupSetNum == 1)
        {
            _StageSelectPopup.SetActive(false);
            _MainPopup.SetActive(true);
            _HeroTab.SetActive(true);
            _ItemTab.SetActive(false);
            _SkillTab.SetActive(false);
            _SoldierTab.SetActive(false);
        }
        else if (_NowPopupSetNum == 2)
        {
            _StageSelectPopup.SetActive(false);
            _MainPopup.SetActive(true);
            _HeroTab.SetActive(false);
            _ItemTab.SetActive(true);
            _SkillTab.SetActive(false);
            _SoldierTab.SetActive(false);
            if(_ItemTabNum == 1)
            {
                _ItemTab_ArmorTab.SetActive(true);
                _ItemTab_WarriorWeaponTab.SetActive(false);
                _ItemTab_MageWeaponTab.SetActive(false);
                _ItemTab_ShamanWeaponTab.SetActive(false);
                _ItemTab_ExpendableseTab.SetActive(false);
            }
            else if (_ItemTabNum == 2)
            {
                _ItemTab_ArmorTab.SetActive(false);
                _ItemTab_WarriorWeaponTab.SetActive(true);
                _ItemTab_MageWeaponTab.SetActive(false);
                _ItemTab_ShamanWeaponTab.SetActive(false);
                _ItemTab_ExpendableseTab.SetActive(false);
            }
            else if (_ItemTabNum == 3)
            {
                _ItemTab_ArmorTab.SetActive(false);
                _ItemTab_WarriorWeaponTab.SetActive(false);
                _ItemTab_MageWeaponTab.SetActive(true);
                _ItemTab_ShamanWeaponTab.SetActive(false);
                _ItemTab_ExpendableseTab.SetActive(false);
            }
            else if (_ItemTabNum == 4)
            {
                _ItemTab_ArmorTab.SetActive(false);
                _ItemTab_WarriorWeaponTab.SetActive(false);
                _ItemTab_MageWeaponTab.SetActive(false);
                _ItemTab_ShamanWeaponTab.SetActive(true);
                _ItemTab_ExpendableseTab.SetActive(false);
            }
            else if (_ItemTabNum == 5)
            {
                _ItemTab_ArmorTab.SetActive(false);
                _ItemTab_WarriorWeaponTab.SetActive(false);
                _ItemTab_MageWeaponTab.SetActive(false);
                _ItemTab_ShamanWeaponTab.SetActive(false);
                _ItemTab_ExpendableseTab.SetActive(true);
            }
        }
        else if (_NowPopupSetNum == 3)
        {
            _StageSelectPopup.SetActive(false);
            _MainPopup.SetActive(true);
            _HeroTab.SetActive(false);
            _ItemTab.SetActive(false);
            _SkillTab.SetActive(true);
            _SoldierTab.SetActive(false);
            if(_SkillTabNum == 1)
            {
                _SkillTab_1.SetActive(true);
                _SkillTab_2.SetActive(false);
                _SkillTab_3.SetActive(false);
            }
            else if (_SkillTabNum == 2)
            {
                _SkillTab_1.SetActive(false);
                _SkillTab_2.SetActive(true);
                _SkillTab_3.SetActive(false);
            }
            else if (_SkillTabNum == 3)
            {
                _SkillTab_1.SetActive(false);
                _SkillTab_2.SetActive(true);
                _SkillTab_3.SetActive(true);
            }
        }
        else if (_NowPopupSetNum == 4)
        {
            _StageSelectPopup.SetActive(false);
            _MainPopup.SetActive(true);
            _HeroTab.SetActive(false);
            _ItemTab.SetActive(false);
            _SkillTab.SetActive(false);
            _SoldierTab.SetActive(true);
            if(_SoldierTabNum == 1)
            {
                _SoldierTab_Warrior.SetActive(true);
                _SoldierTab_Archer.SetActive(false);
                _SoldierTab_Mage.SetActive(false);
                _SoldierTab_SetFormation.SetActive(false);
                _SoldierTab_LevelSetting.SetActive(true);
            }
            else if (_SoldierTabNum == 2)
            {
                _SoldierTab_Warrior.SetActive(false);
                _SoldierTab_Archer.SetActive(true);
                _SoldierTab_Mage.SetActive(false);
                _SoldierTab_SetFormation.SetActive(false);
                _SoldierTab_LevelSetting.SetActive(true);
            }
            else if (_SoldierTabNum == 3)
            {
                _SoldierTab_Warrior.SetActive(false);
                _SoldierTab_Archer.SetActive(false);
                _SoldierTab_Mage.SetActive(true);
                _SoldierTab_SetFormation.SetActive(false);
                _SoldierTab_LevelSetting.SetActive(true);
            }
            else if (_SoldierTabNum == 4)
            {
                _SoldierTab_Warrior.SetActive(false);
                _SoldierTab_Archer.SetActive(false);
                _SoldierTab_Mage.SetActive(false);
                _SoldierTab_SetFormation.SetActive(true);
                _SoldierTab_LevelSetting.SetActive(false);
            }
        }
        else if(_NowPopupSetNum==6)
        {
            _MainPopup.SetActive(false);
            _StageSelectPopup.SetActive(true);

            _NowSelectStage.text = StaticDataMng._SelectStageName;

            
            
        }
        else if (_NowPopupSetNum == 7)
        {
            _MainPopup.SetActive(false);
            _QuestPopup.SetActive(true);
        }

        if (_NoPormationOn == 1)
        {
            _NoPormationPopup.SetActive(true);
        }
        else
            _NoPormationPopup.SetActive(false);

        if (_NoVoidItemSlotOn == 1)
        {
            _NoVoidItemSlotPopup.SetActive(true);
        }
        else
            _NoVoidItemSlotPopup.SetActive(false);

        if (_SoldierUpgradePopupOn == 1)
            _SoldierUpgradePopup.SetActive(true);
        else
            _SoldierUpgradePopup.SetActive(false);

        if (_PormationResetPopupOn == 1)
            _PormationResetPopup.SetActive(true);
        else
            _PormationResetPopup.SetActive(false);
    }

    public void SetMobList()
    {
        string[] moblist = { "wolf", "whitewolf", "digarr_w", "digarr_m", "unsoldier_w", "unsoldier_a", "wolfboss", "whitewolfboss", "digarr_middle_w", "digarr_middle_m" };
        List<int> moblistint = new List<int>();
        int stagelevel = 1;


        if(StaticDataMng._LastStageName == StaticDataMng._SelectStageName)
        {
            StaticDataMng._StoryWaveOn = StaticDataMng._StoryWaveOn_Save;
        }
        else
        {
            StaticDataMng._StoryWaveOn = false;
        }
        #region
        if (StaticDataMng._SelectStageName == "민가")
        {
            if(StaticDataMng._StoryOn || StaticDataMng._LastStageName==StaticDataMng._SelectStageName)
            {
                moblistint.Add(8);
                moblistint.Add(2);
                moblistint.Add(0);
                stagelevel = 1;
            }
            else
            {
                moblistint.Add(8);
                moblistint.Add(3);
                moblistint.Add(2);
                stagelevel = 5;
            }
        }
        if (StaticDataMng._SelectStageName == "설산" )
        {
            if (StaticDataMng._StoryOn || StaticDataMng._LastStageName == StaticDataMng._SelectStageName)
            {
                moblistint.Add(3);
                moblistint.Add(2);
                moblistint.Add(1);
                stagelevel = 2;
            }
            else
            {
                moblistint.Add(5);
                moblistint.Add(9);
                moblistint.Add(1);
                moblistint.Add(2);
                stagelevel = 10;
            }
        }
        if (StaticDataMng._SelectStageName == "선스피어")
        {
            if (StaticDataMng._StoryOn || StaticDataMng._LastStageName == StaticDataMng._SelectStageName)
            {
                moblistint.Add(8);
                moblistint.Add(3);
                moblistint.Add(2);
                stagelevel = 3;
            }
            else
            {
                moblistint.Add(8);
                moblistint.Add(3);
                moblistint.Add(2);
                stagelevel = 3;
            }
        }
        if (StaticDataMng._SelectStageName == "서쪽 태양들판" )
        {
            if (StaticDataMng._StoryOn || StaticDataMng._LastStageName == StaticDataMng._SelectStageName)
            {
                
            }
            else
            {
                moblistint.Add(8);
                moblistint.Add(9);
                moblistint.Add(0);
                moblistint.Add(2);
                
                stagelevel = 3;
            }
        }
        if (StaticDataMng._SelectStageName == "동쪽 태양들판" )
        {
            if (StaticDataMng._StoryOn || StaticDataMng._LastStageName == StaticDataMng._SelectStageName)
            {

            }
            else
            {
                moblistint.Add(8);
                moblistint.Add(9);
                moblistint.Add(0);
                moblistint.Add(2);
                
                stagelevel = 6;
            }
        }
        if (StaticDataMng._SelectStageName == "불타는 숲" )
        {
            if (StaticDataMng._StoryOn || StaticDataMng._LastStageName == StaticDataMng._SelectStageName)
            {

            }
            else
            {
                moblistint.Add(3);
                moblistint.Add(8);
                moblistint.Add(0);
                moblistint.Add(2);
                
                stagelevel = 8;
            }
        }
        if (StaticDataMng._SelectStageName == "아라드라" )
        {
            if (StaticDataMng._StoryOn || StaticDataMng._LastStageName == StaticDataMng._SelectStageName)
            {

            }
            else
            {
                moblistint.Add(2);
                moblistint.Add(9);
                moblistint.Add(0);
                moblistint.Add(1);
                
                stagelevel = 9;
            }
        }
        #endregion
        _MobGrid.gameObject.transform.DestroyChildren();
            for (int i = 0; i < moblistint.Count; i++)
            {
                GameObject obj = NGUITools.AddChild(_MobGrid.gameObject, _MobIcon);
                obj.GetComponent<UISprite>().spriteName = "bossicon_" + moblist[moblistint[i]];
            }
            _MobGrid.Reposition();

        _StageLevel.text = stagelevel.ToString();
        if (StaticDataMng._HeroLevel < stagelevel)
            _StageLevel.color = hexToColor("FF0000FF");
        else if (StaticDataMng._HeroLevel > stagelevel)
            _StageLevel.color = hexToColor("33FF00FF");
        else
            _StageLevel.color = new Color(255,255,255);
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

    public void SetWorldMapLeft()
    {
        _WorldMapAnimator.SetTrigger("left");
        PlayerPrefs.SetInt("WorldmapPos", 0);
    }

    public void SetWorldMapRight()
    {
        _WorldMapAnimator.SetTrigger("right");
        PlayerPrefs.SetInt("WorldmapPos", 1);
    }

    public void SetUINum(int num)
    {
        AudioSource.PlayClipAtPoint(_SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
        if (num == 6)
        {
            if (StaticDataMng._HeroHaveItem_Armor.Count < 14 && StaticDataMng._HeroHaveItem_Weapon.Count < 14)
            {
                _NowPopupSetNum = num;
                _SkillTabNum = 1;
            }
            else
                SetVoidItemSlotPopup(1);
        }
        else
        {
            _NowPopupSetNum = num;
            _SkillTabNum = 1;

            if (num == 7)
                _QuestMng._NewQuest = false;
        }
    }
    public void SetItemTab(int num)
    {
        AudioSource.PlayClipAtPoint(_SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
        _ItemTabNum = num;
    }
    public void SetSkillTab(int num)
    {
        AudioSource.PlayClipAtPoint(_SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
        _SkillTabNum = num;
    }
    public void SetSoldierTab(int num)
    {
        AudioSource.PlayClipAtPoint(_SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
        _SoldierTabNum = num;
    }

    public void SetSelectStage(string stagename)
    {
        _NowPopupSetNum = 6;

    }

    public void SetPormationPopup(int num)
    {
        _NoPormationOn = num;
    }
    public void SetVoidItemSlotPopup(int num)
    {
        _NoVoidItemSlotOn = num;
    }

    public void SetSoldierUpgradePopup(int num)
    {
        _SoldierUpgradePopupOn = num;
    }

    public void SetPormationResetPopup(int num)
    {
        _PormationResetPopupOn = num;
    }
}
