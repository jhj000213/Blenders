using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData : MonoBehaviour 
{
    public bool _touchScene;

    public GameObject _Parent;
    public GameObject _EleBallBoard;

    public UISprite _HeroHPBar;

    public UIAtlas _HeroAtlas;
    public UIAtlas _Soldier_Warrior_Atlas;
    public UIAtlas _Soldier_Archer_Atlas;
    public UIAtlas _Soldier_Mage_Atlas;
    public UIAtlas _SeedMobAtlas;
    public UIAtlas _WolfAtlas;
    public UIAtlas _WolfBossAtlas;
    public UIAtlas _WhiteWolfAtlas;
    public UIAtlas _WhiteWolfBossAtlas;
    public UIAtlas _DigarrWarriorAtlas;
    public UIAtlas _DigarrMageAtlas;
    public UIAtlas _UnSoldier_W_Atlas;
    public UIAtlas _UnSoldier_A_Atlas;
    public UIAtlas _DigarrWarriorMiddleAtlas;
    public UIAtlas _DigarrMageMiddleAtlas;
    public UIAtlas _PirateAtlas;
    public UIAtlas _PirateLeaderAtlas;

    public GameObject _WolfDead;
    public GameObject _WolfBossDead;
    public GameObject _WhiteWolfDead;
    public GameObject _WhiteWolfBossDead;
    public GameObject _UnSoldier_W_Dead;
    public GameObject _UnSoldier_A_Dead;
    public GameObject _Digarr_W_Dead;
    public GameObject _Digarr_M_Dead;
    public GameObject _Digarr_Middle_W_Dead;
    public GameObject _Digarr_Middle_M_Dead;
    public GameObject _Pirate_Dead;
    public GameObject _PirateLeader_Dead;

    public GameObject _Warrior_Dead;
    public GameObject _Soldier_W_Dead;
    public GameObject _Soldier_A_Dead;
    public GameObject _Soldier_M_Dead;

    public List<Skill> _SkillList = new List<Skill>();

    public List<Unit> _EnemyUnitList = new List<Unit>();
    public List<Unit> _SoldierUnitList = new List<Unit>();
    public Unit _HeroUnit;

    public List<bool> _SoundEffectList = new List<bool>();
}
