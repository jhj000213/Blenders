using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class StaticDataMng{

    public static bool _PlayingDead;
    public static int _LastStoryNum;
    public static string _LastStageName;


    public static GameObject _LoadRoot;

    public static int _SoundOn;
    public static int _VibOn;

    public static string _SelectStageName = "";

    public static bool _StoryGoGameScene;
    //public static string _StoryStageName = "";
    //public static bool _StoryHave;

    public static bool _Tutorial = false;

    public static int _HeroSkillPoint;
    public static int _Gold;
    public static int _HeroLevel;
    public static float _HeroExpValue;
    public static float _HeroMaxExpValue;

    public static int _SkillLevel_Low_4 ;
    public static int _SkillLevel_Low_9 ;
    public static int _SkillLevel_Low_25;
    public static int _SkillLevel_Low_49;
    public static int _SkillLevel_Low_6 ;
    public static int _SkillLevel_Low_15;
    public static int _SkillLevel_Low_35;
    public static int _SkillLevel_Low_14;
    public static int _SkillLevel_Low_21;
    public static int _SkillLevel_Low_10;

    public static int _SkillLevel_High_4 ;
    public static int _SkillLevel_High_9 ;
    public static int _SkillLevel_High_25;
    public static int _SkillLevel_High_49;
    public static int _SkillLevel_High_6 ;
    public static int _SkillLevel_High_15;
    public static int _SkillLevel_High_35;
    public static int _SkillLevel_High_14;
    public static int _SkillLevel_High_21;
    public static int _SkillLevel_High_10;

    /// <summary>
    /// 1 - warrior
    /// 2 - mage
    /// 3 - shaman
    /// </summary>
    public static int _HeroClass;
    public static int _SkillDmg;
    public static int _Soldier_Warrior_Level;
    public static int _Soldier_Archer_Level;
    public static int _Soldier_Mage_Level;

    public static int _StoryNum;
    public static bool _StoryOn;
    public static bool _StoryWaveOn;
    public static bool _StoryWaveOn_Save;
    public static string _StoryScene;

    public static int _nowHeroUnitNum;
    public static int _nowUnitNum;

    public static List<Quest> _HaveQuestList = new List<Quest>();

    public static List<PormationIcon> _PormationList = new List<PormationIcon>();

    public static List<HeroItem> _HeroSetItem_Weapon = new List<HeroItem>();
    public static List<HeroItem> _HeroSetItem_Armor = new List<HeroItem>();

    public static List<HeroItem> _HeroHaveItem_Weapon = new List<HeroItem>();
    public static List<HeroItem> _HeroHaveItem_Armor = new List<HeroItem>();

    public static List<HeroItem> _AllHeroItemList_Common = new List<HeroItem>();
    public static List<HeroItem> _AllHeroItemList_Rare = new List<HeroItem>();
    public static List<HeroItem> _AllHeroItemList_Legendery = new List<HeroItem>();

    public static string _TeamName = "";




    public static float[] _HyperSkillDmg = {0.08f,0.096f,0.112f,0.128f,0.144f,0.16f,0.18f,0.2f,0.22f,0.24f };
    
    public static float[] _FireSkill_Low = {1.0f,1.1f,1.3f,1.4f,1.5f,1.7f,1.8f,1.9f,2f,2.2f };
    public static float[] _FireSkill_Low_CoolTime = { 5.0f, 4.8f, 4.6f, 4.3f, 4f, 3.8f, 3.6f, 3.4f, 3.2f, 3.0f };
    public static float[] _FireSkill_High_First = {0.5f,0.6f,0.7f,0.8f,0.9f,1.0f,1.1f,1.2f,1.3f,1.5f };
    public static float[] _FireSkill_High_Second = {1f,1.2f,1.4f,1.6f,1.8f,2f,2.1f,2.3f,2.4f,2.5f };
    public static float[] _FireSkill_High_CoolTime = {10.0f,9.5f,9f,8.5f,8f,7.5f,7f,6.5f,6f,5 };
    public static int  [] _WaterSkill_Low = {150,300,450,600,750,900,1500,1200,1350,1500 };
    public static float[] _WaterSkill_Low_CoolTime = {7f,6.8f,6.6f,6.4f,6.2f,6f,5.8f,5.7f,5.6f,5.5f};
    public static float[] _WaterSkill_High_First = {0.1f,0.12f,0.14f,0.16f,0.18f,0.2f,0.21f,0.22f,0.23f,0.25f};
    public static float[] _WaterSkill_High_Second = {0.3f,0.4f,0.5f,0.6f,0.7f,0.8f,0.9f,1f,1.1f,1.2f};
    public static float[] _WaterSkill_High_CoolTime = {15f,14.5f,14f,13.5f,13f,12.5f,12f,11.5f,11f,10};
    public static float[] _AirSkill_Low_First = {10,20,30,40,50,60,0,80,90,100};
    public static float[] _AirSkill_Low_Second = {10,15,25,40,50,60,65,70,80,90};
    public static float[] _AirSkill_Low_CoolTime = {6f,5.8f,5.6f,5.4f,5.2f,5f,4.8f,4.6f,4.3f,4};
    public static int  [] _AirSkill_High = {300,600,900,1200,1500,1800,2100,2400,2700,3000};
    public static float[] _AirSkill_High_CoolTime = {15f,14.5f,14f,13.5f,13f,12.5f,12f,11.5f,11f,10};
    public static float[] _GroundSkill_Low_CoolTime = {4f,3.8f,3.6f,3.4f,3.2f,3f,2.8f,2.6f,2.3f,2};
    public static float[] _GroundSkill_High = {1.3f,1.5f,1.7f,1.9f,2f,2.2f,2.3f,2.5f,2.7f,3};
    public static float[] _GroundSkill_High_CoolTime = {20,19,18,17,16,15,14,13,12,10};

    public static float[] _FogSkill_Low_CoolTime = { 7.0f, 6.5f, 6.0f, 5.5f, 5f, 4.8f, 4.6f, 4.4f, 4.2f, 4.0f };
    public static float[] _FogSkill_High_CoolTime = { 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f };
    public static float[] _MudSkill_Low_CoolTime = { 12.0f, 11.6f, 11.2f, 10.8f, 10.4f, 10.0f, 9.8f, 9.6f, 9.4f, 9.2f };
    public static float[] _MudSkill_High_CoolTime = { 12.0f, 11.6f, 11.2f, 10.8f, 10.4f, 10.0f, 9.8f, 9.6f, 9.4f, 9.2f };
    public static float[] _SandSkill_Low_CoolTime = { 8.0f, 7.8f, 7.6f, 7.4f, 7.2f, 7.0f, 6.8f, 6.6f, 6.4f, 6.2f };
    public static float[] _SandSkill_High_CoolTime = { 20, 19, 18, 17, 16, 15, 14, 13, 12, 10 };
    public static float[] _FlameSkill_Low_CoolTime = { 13, 12.5f, 12, 11.5f, 11f, 10.5f, 10f, 9.5f, 9f, 8 };
    public static float[] _FlameSkill_High_CoolTime = { 15f, 14.5f, 14f, 13.5f, 13f, 12.5f, 12f, 11.5f, 11f, 10 };
    public static float[] _IceSkill_Low_CoolTime = { 5.0f, 4.8f, 4.6f, 4.3f, 4f, 3.8f, 3.6f, 3.4f, 3.2f, 3.0f };
    public static float[] _IceSkill_High_CoolTime = { 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f };
    public static float[] _RockSkill_Low_CoolTime = { 5.0f, 4.8f, 4.6f, 4.3f, 4f, 4f, 4f, 4f, 4f, 4f };
    public static float[] _RockSkill_High_CoolTime = { 15.0f, 14.5f, 14.0f, 13.5f, 13.0f, 12.5f, 12.0f, 11.5f, 11.0f, 10.5f };



    public static int  [] _Soldier_W_HP = { 600, 800, 1000, 1500, 2000, 2500, 2800, 3000, 3300, 3500 };
    public static int  [] _Soldier_W_Damage = { 3,4,6,8,10,11,13,15,18,20 };
    public static int  [] _Soldier_W_Price = { 0,0,400,600,850,1000,1250,1500,1750,2000 ,0};
    public static int  [] _Soldier_A_HP = {250,500,750,1000,1250,1500,1750,2000,2250,2500 };
    public static int  [] _Soldier_A_Damage = { 4,6,9,11,14,16,18,20,23,26 };
    public static int  [] _Soldier_A_Price = { 0, 200, 400, 600, 850, 1000, 1250, 1500, 1750, 2000 ,0};
    public static int  [] _Soldier_M_HP = { 250, 500, 750, 1000, 1250, 1500, 1750, 2000, 2250, 2500 };
    public static int  [] _Soldier_M_Damage = { 50, 70, 90, 110, 140, 160, 180, 200, 230, 260 };
    public static int  [] _Soldier_M_Price = { 0, 200, 400, 600, 850, 1000, 1250, 1500, 1750, 2000, 0 };

    public static int _OnlySoldier_W_Clear;
    public static int _OnlySoldier_A_Clear;
    public static int _OnlyElementClear;
    public static int _In30SecondClear;
}