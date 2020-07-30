using UnityEngine;
using System.Collections;

public class StoryActionMng : MonoBehaviour {

    public PublicSoundData _SoundData;
    public DataSaveMng _SaveMng;


    public GameObject _UIRoot;
    public GameObject _BossWaringObj;

    public GameObject _FireEleBall;
    public GameObject _WaterEleBall;
    public GameObject _RandEleBall;
    public GameObject _AirEleBall;

    public UISprite _LowSkillIcon;
    public UISprite _HighSkillIcon;
    public GameObject _LowSkillIcon_Box;
    public GameObject _HighSkillIcon_Box;

    public UnitGenerator _UnitGenerator;
    public CreativeCircle _CreativeCircle;

    public GameObject _HyperSkillIcon;

    public GameObject _RestartButtonGray;
    public GameObject _RecallButtonGray;

    public Unit _MainEnemy;

    public GameObject[] _TutorialBlackImage;
    public GameObject[] _TutorialLabelImage;
    public GameObject _TeamNameEditor;

    public PopupNumMng _WorldMapUIMng;
    public UnitPositionSettingMng _PormationMng;
    public GameObject _HeroPormationIcon;
    public GameObject _Soldier_w_PormationIcon;
    public GameObject _Soldier_a_PormationIcon;

    public GameObject _LockGroup;
    public GameObject _LockGroup_2;
    public GameObject _VillageUnLock;
    public GameObject _SnowMountainUnLock;
    public GameObject _AradraUnLock;
    public GameObject _SunguardUnLock;
    public GameObject _LeftGrassUnLock;
    public GameObject _RightGrassUnLock;
    public GameObject _FireForestUnLock;
    public GameObject _PortUnLock;
    public GameObject _ShipUnLock;

    public StoryTellingMng _StoryMng;
    public QuestMng _QuestMng;

    public GameObject _TeamNameError;

    public int _StoryNum;
    public int _ActionClearing;

    public bool _PlayersEnd;

    public bool _TouchSkill;
    public bool _HyperSkillTouch;

    public bool _HeroOnemanShow;

    public bool _GameScene;

    public bool _TouchToObject;

    public void SetStoryStart()
    {
        if(_GameScene)
        {
            _RecallButtonGray.SetActive(false);
            _RestartButtonGray.SetActive(true);
            _HyperSkillIcon.SetActive(false);
            _FireEleBall.SetActive(false);
            _WaterEleBall.SetActive(false);
            _RandEleBall.SetActive(false);
            _AirEleBall.SetActive(false);
            _LowSkillIcon_Box.SetActive(false);
            _HighSkillIcon_Box.SetActive(false);

            if (StaticDataMng._StoryNum > 7)
                _HyperSkillIcon.SetActive(true);
        }
        else
        {
            if(StaticDataMng._StoryNum==2)
            {
                _HeroPormationIcon.SetActive(false);
                _Soldier_w_PormationIcon.SetActive(false);
                _Soldier_a_PormationIcon.SetActive(false);
            }
            
        }   
    }       


    public void TouchToNextAction()
    {
        _TouchToObject = true;
    }

    void Update()
    {
        if(_GameScene)
        {
            _CreativeCircle._LowGray = "";
            _CreativeCircle._HighGray = "";
            _LowSkillIcon_Box.SetActive(false);
            _HighSkillIcon_Box.SetActive(false);
        }
        

        //    if(Input.GetKeyDown(KeyCode.S))
        //        SetStoryMove(true);
        //    if(Input.GetKeyDown(KeyCode.F))
        //        SetStoryMove(false);
        _HeroOnemanShow = false;
        for (int i = 0; i < _TutorialBlackImage.Length; i++)
            _TutorialBlackImage[i].SetActive(false);
        for (int i = 0; i < _TutorialLabelImage.Length; i++)
            _TutorialLabelImage[i].SetActive(false);

        if (_PlayersEnd)
        {
            #region 튜토리얼
            if (_StoryNum == 1)
            {
                if (_ActionClearing == 1)
                {
                    _LowSkillIcon_Box.SetActive(false);

                    
                }
                if (_ActionClearing == 2)
                {
                    if (_MainEnemy != null)
                    {
                        if (_MainEnemy._HP <= _MainEnemy._MaxHP / 2)
                        {
                            StartCoroutine(EndAction(0.0f, true));
                            _PlayersEnd = false;
                            GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                        }
                    }
                }
                if (_ActionClearing == 3)
                {
                    _FireEleBall.SetActive(true);
                    _TutorialBlackImage[0].SetActive(true);
                    if (_CreativeCircle._BallList.Count >= 2)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 4)
                {
                    _FireEleBall.SetActive(true);//false
                    _LowSkillIcon_Box.SetActive(false);
                    _HighSkillIcon_Box.SetActive(true);
                    _CreativeCircle._HighGray = "_gray";
                    _TutorialBlackImage[1].SetActive(true);
                    if (_TouchSkill)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if(_ActionClearing==5)
                {
                    _LowSkillIcon_Box.SetActive(true);
                    _HighSkillIcon_Box.SetActive(true);
                    _CreativeCircle._LowGray = "_gray";
                    _CreativeCircle._HighGray = "_gray";
                }
                if (_ActionClearing == 6)
                {
                    GameMng.Data._SkillDmgMultyple = 5.0f;
                    GameMng.Data._SkillCoolTimeMultyple = 8.0f;
                    _FireEleBall.SetActive(true);
                    _LowSkillIcon_Box.SetActive(true);
                    _HighSkillIcon_Box.SetActive(false);
                    _CreativeCircle._LowGray = "_gray";
                    _TutorialLabelImage[0].SetActive(true);
                    if (GameMng.Data._GameDate._EnemyUnitList.Count == 0)
                    {
                        GameMng.Data._SkillDmgMultyple = 1.0f;
                        GameMng.Data._SkillCoolTimeMultyple = 1.0f;
                        StartCoroutine(EndAction(0.0f, false));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 7)
                {
                    _LowSkillIcon_Box.SetActive(false);
                    _HighSkillIcon_Box.SetActive(false);
                    if (GameMng.Data._MosnterWaveMng._BossOn == true)
                    {
                        StartCoroutine(EndAction(0.0f, false));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 8)
                {
                    _LowSkillIcon_Box.SetActive(false);
                    _HighSkillIcon_Box.SetActive(true);
                    _CreativeCircle._HighGray = "_gray";
                    _TutorialLabelImage[1].SetActive(true);
                    GameMng.Data._SkillDmgMultyple = 3.0f;
                    if (GameMng.Data._GameDate._HeroUnit._HP >= GameMng.Data._GameDate._HeroUnit._MaxHP)
                    {
                        GameMng.Data._SkillDmgMultyple = 1.0f;
                        //Debug.Log("Heal");
                        StartCoroutine(EndAction(1.0f, false));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 9)
                {
                    _LowSkillIcon_Box.SetActive(false);
                    _HighSkillIcon_Box.SetActive(false);
                    if (_MainEnemy._ObjName == "wolfboss")
                    {
                        if (_MainEnemy._HP <= _MainEnemy._MaxHP / 2)
                        {
                            _CreativeCircle._ElementList.Clear();
                            for (int i = 0; i < _CreativeCircle._BallList.Count; i++)
                                Destroy(_CreativeCircle._BallList[i]);
                            _CreativeCircle._BallList.Clear();
                            StartCoroutine(EndAction(0.0f, true));
                            _PlayersEnd = false;
                            GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                        }
                    }

                }
                if (_ActionClearing == 10)
                {
                    _LowSkillIcon_Box.SetActive(true);
                    _HighSkillIcon_Box.SetActive(false);
                    _CreativeCircle._LowGray = "_gray";
                    _TutorialBlackImage[2].SetActive(true);
                    _TutorialLabelImage[2].SetActive(true);

                    if (_TouchSkill)
                    {

                        _TouchSkill = false;
                        StartCoroutine(EndAction_HeroExcept(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 11)
                {
                    _LowSkillIcon_Box.SetActive(true);
                    _HighSkillIcon_Box.SetActive(false);
                    _CreativeCircle._LowGray = "_gray";
                    _HeroOnemanShow = true;
                    GameMng.Data._SkillCoolTimeMultyple = 5.0f;
                    GameMng.Data._SkillDmgMultyple = 1.6f;
                    if (GameMng.Data._GameDate._EnemyUnitList.Count == 0)
                    {
                        GameMng.Data._SkillCoolTimeMultyple = 1.0f;
                        GameMng.Data._SkillDmgMultyple = 1.0f;
                        //Debug.Log("BossDead");
                        StartCoroutine(EndAction(0.5f, false));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                        
                    }
                }
                
            }
            #endregion

            #region 스토리2
            if (_StoryNum == 2)
            {
                if (_ActionClearing == 1)
                {
                    _TutorialBlackImage[0].SetActive(true);//마을/기지만 주시
                    if (_WorldMapUIMng._NowPopupSetNum != 0)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 2)
                {
                    _TutorialBlackImage[1].SetActive(true);//마을/왼쪽탭만 주시하는 검은색(애니메이션 잇으면좋음)
                }
                if (_ActionClearing == 3)
                {
                    _TutorialBlackImage[2].SetActive(true);//마을/용병탭만 주시함
                    if (_WorldMapUIMng._NowPopupSetNum == 4)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 4)
                {
                    _TutorialBlackImage[3].SetActive(true);//마을/대열편성만 주시
                    if (_WorldMapUIMng._NowPopupSetNum == 4 && _WorldMapUIMng._SoldierTabNum == 4)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 5)
                {
                    _TutorialBlackImage[8].SetActive(true);//마을/배치필드만 주시
                    _TutorialLabelImage[0].SetActive(true);//영웅과 전사 아이콘을 드래그하여 대열을 편성하세요.
                    _Soldier_w_PormationIcon.SetActive(true);
                    _HeroPormationIcon.SetActive(true);
                    if (StaticDataMng._nowUnitNum >= 4 && StaticDataMng._nowHeroUnitNum >= 1)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 6)
                {
                    _TutorialBlackImage[8].SetActive(true);//마을/배치필드만 주시
                    _TutorialLabelImage[1].SetActive(true);//궁수 아이콘을 드래그하여 대열을 편성하세요
                    _Soldier_a_PormationIcon.SetActive(true);
                    if (StaticDataMng._nowUnitNum >= 6)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 7)
                {
                    _TutorialBlackImage[4].SetActive(true);//마을/장비 탭만 주시
                    if (_WorldMapUIMng._NowPopupSetNum == 2)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 8)
                {
                    _TutorialBlackImage[8].SetActive(true);//마을/장비장착관련부분만 주시
                    _TutorialLabelImage[2].SetActive(true);//장비를 장착해보세요
                    //_WorldMapUIMng._NowPopupSetNum = 2;
                    if (StaticDataMng._HeroHaveItem_Weapon.Count == 0 && StaticDataMng._HeroSetItem_Weapon.Count == 0)
                    {
                        for (int i = 0; i < StaticDataMng._AllHeroItemList_Common.Count; i++)
                        {
                            if (StaticDataMng._AllHeroItemList_Common[i]._ItemName == "warrior_lv1_common_1")
                            {
                                HeroItem Item = new HeroItem();
                                Item.ItemInit(StaticDataMng._AllHeroItemList_Common[i]._ItemName, StaticDataMng._AllHeroItemList_Common[i]._ItemKoreanName,
                                    StaticDataMng._AllHeroItemList_Common[i]._ItemType, StaticDataMng._AllHeroItemList_Common[i]._Rating,
                                    0, StaticDataMng._AllHeroItemList_Common[i]._OriginAttackPoint,
                                    StaticDataMng._AllHeroItemList_Common[i]._OriginPowerPoint, StaticDataMng._AllHeroItemList_Common[i]._OriginIntellectPoint,
                                    StaticDataMng._AllHeroItemList_Common[i]._OriginArmorPoint, StaticDataMng._AllHeroItemList_Common[i]._OriginHealthPoint,
                                    StaticDataMng._AllHeroItemList_Common[i]._ItemLevel);
                                Item._ItemInfo = StaticDataMng._AllHeroItemList_Common[i]._ItemInfo;
                                Item.SetStatRankB();
                                StaticDataMng._HeroHaveItem_Weapon.Add(Item);
                                break;
                            }
                        }
                    }
                    if (StaticDataMng._HeroHaveItem_Armor.Count == 0 && StaticDataMng._HeroSetItem_Armor.Count == 0)
                    {
                        for (int i = 0; i < StaticDataMng._AllHeroItemList_Common.Count; i++)
                        {
                            if (StaticDataMng._AllHeroItemList_Common[i]._ItemName == "armor_lv1_common_1")
                            {
                                HeroItem Item = new HeroItem();
                                Item.ItemInit(StaticDataMng._AllHeroItemList_Common[i]._ItemName, StaticDataMng._AllHeroItemList_Common[i]._ItemKoreanName,
                                    StaticDataMng._AllHeroItemList_Common[i]._ItemType, StaticDataMng._AllHeroItemList_Common[i]._Rating,
                                    0, StaticDataMng._AllHeroItemList_Common[i]._OriginAttackPoint,
                                    StaticDataMng._AllHeroItemList_Common[i]._OriginPowerPoint, StaticDataMng._AllHeroItemList_Common[i]._OriginIntellectPoint,
                                    StaticDataMng._AllHeroItemList_Common[i]._OriginArmorPoint, StaticDataMng._AllHeroItemList_Common[i]._OriginHealthPoint,
                                    StaticDataMng._AllHeroItemList_Common[i]._ItemLevel);
                                Item._ItemInfo = StaticDataMng._AllHeroItemList_Common[i]._ItemInfo;
                                Item.SetStatRankB();
                                StaticDataMng._HeroHaveItem_Armor.Add(Item);
                                break;
                            }
                        }
                    }

                    if (StaticDataMng._HeroSetItem_Weapon.Count != 0 && StaticDataMng._HeroSetItem_Armor.Count!=0)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 9)
                {
                    _TutorialBlackImage[2].SetActive(true);//마을/용병탭만 주시
                    if (_WorldMapUIMng._NowPopupSetNum == 4)
                    {
                        _WorldMapUIMng._SoldierTabNum = 1;
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 10)
                {
                    _TutorialBlackImage[8].SetActive(true);//마을/
                    _TutorialLabelImage[5].SetActive(true);//전사를 강화하여 보세요
                    _WorldMapUIMng._NowPopupSetNum = 4;
                    _WorldMapUIMng._SoldierTabNum = 1;
                    if (StaticDataMng._Soldier_Warrior_Level>=2)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 11)
                {
                    _TutorialBlackImage[6].SetActive(true);//마을/X 버튼만 주시
                    if (_WorldMapUIMng._NowPopupSetNum==0)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 12)
                {
                    
                    

                    _TutorialBlackImage[7].SetActive(true);//마을/민가던전만 주시
                    if (_WorldMapUIMng._NowPopupSetNum == 6)
                    {
                        //Debug.Log("in");
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;

                        
                    }
                }
            }
            #endregion

            #region 스토리3
            if (_StoryNum == 3)
            {
                if (_ActionClearing == 1)
                {
                    if (GameMng.Data._MosnterWaveMng._NowWave >= 2 && GameMng.Data._MosnterWaveMng._NowWaveTime >= 1.5f)
                    {
                        GameMng.Data._MosnterWaveMng._WaveOn = false;
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 4)
                {
                    _LowSkillIcon_Box.SetActive(false);
                    _HighSkillIcon_Box.SetActive(true);
                    _CreativeCircle._HighGray = "_gray";
                    _TutorialBlackImage[3].SetActive(true);//게임/공기구슬 주시
                    _TutorialLabelImage[3].SetActive(true);//게임/속공~~
                    if (_TouchSkill)
                    {
                        _TouchSkill = false;
                        StartCoroutine(EndAction(0.0f, false));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 5)
                {
                    _LowSkillIcon_Box.SetActive(false);
                    _HighSkillIcon_Box.SetActive(true);
                    _CreativeCircle._HighGray = "_gray";
                    if (GameMng.Data._GameDate._EnemyUnitList.Count==0)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 6)
                {
                    _LowSkillIcon_Box.SetActive(true);
                    _HighSkillIcon_Box.SetActive(false);
                    _CreativeCircle._LowGray = "_gray";
                    _TutorialBlackImage[3].SetActive(true);//게임/공기구슬 주시
                    _TutorialLabelImage[4].SetActive(true);//게임/숨돌리기~~
                    if (_TouchSkill)
                    {
                        _TouchSkill = false;
                        StartCoroutine(EndAction(0.0f, false));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 7)
                {
                    _LowSkillIcon_Box.SetActive(false);
                    _HighSkillIcon_Box.SetActive(false);
                    
                }
                if (_ActionClearing == 8)
                {
                    _LowSkillIcon_Box.SetActive(false);
                    _HighSkillIcon_Box.SetActive(true);
                    _CreativeCircle._HighGray = "_gray";
                    _TutorialBlackImage[4].SetActive(true);//게임/흙속성 주시
                    _TutorialLabelImage[5].SetActive(true);//정신집중~~
                    if (_TouchSkill)
                    {
                        _TouchSkill = false;
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 9)
                {
                    _LowSkillIcon_Box.SetActive(true);
                    _HighSkillIcon_Box.SetActive(false);
                    _CreativeCircle._LowGray = "_gray";
                    _TutorialBlackImage[4].SetActive(true);//게임/흙속성 주시
                    _TutorialLabelImage[6].SetActive(true);//대지분쇄~~
                    if (_TouchSkill)
                    {
                        _TouchSkill = false;
                        StartCoroutine(EndAction_HeroExcept(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 10)
                {

                }
                if (_ActionClearing == 11)
                {
                    _LowSkillIcon_Box.SetActive(false);
                    _HighSkillIcon_Box.SetActive(false);
                    if (GameMng.Data._MosnterWaveMng._BossOn == true)
                    {
                        _TouchSkill = false;
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 12)
                {
                    _LowSkillIcon_Box.SetActive(false);
                    _HighSkillIcon_Box.SetActive(false);
                    if (GameMng.Data._GameDate._EnemyUnitList.Count == 0)
                    {
                        StartCoroutine(EndAction(0.5f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                        
                    }
                }
                if (_ActionClearing == 13)
                {
                    
                }
            }
            #endregion

            #region 스토리4
            if (_StoryNum == 4)
            {
                if (_ActionClearing == 1)
                {
                    _TutorialBlackImage[0].SetActive(true);//마을/용병단캠프
                    if (_WorldMapUIMng._NowPopupSetNum == 1)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if (_ActionClearing == 2)
                {
                    _TutorialLabelImage[3].SetActive(true);//마을/스포를 다쓰세요
                    _WorldMapUIMng._NowPopupSetNum = 3;
                    if (StaticDataMng._HeroSkillPoint == 0)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                    }
                }
                if(_ActionClearing==3)//설산 언락
                {
                    
                }
            }
            #endregion

            #region 스토리5
            if (_StoryNum == 5)
            {
                _LowSkillIcon_Box.SetActive(false);
                _HighSkillIcon_Box.SetActive(false);
                if (_ActionClearing == 1)
                {
                    if (GameMng.Data._MosnterWaveMng._BossOn == true)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 2)
                {
                    if (GameMng.Data._GameDate._EnemyUnitList.Count == 0)
                    {
                        StartCoroutine(EndAction(0.5f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
            }
            #endregion

            #region 스토리6
            if (_StoryNum == 6)
            {

            }
            #endregion

            #region 스토리7
            if (_StoryNum == 7)
            {
                _LowSkillIcon_Box.SetActive(false);
                _HighSkillIcon_Box.SetActive(false);
                if (_ActionClearing == 1)
                {
                    if (GameMng.Data._MosnterWaveMng._BossOn == true)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 2)
                {
                    if (_MainEnemy._ObjName == "digarr_middle_w")//temp
                    {
                        if (_MainEnemy._HP <= _MainEnemy._MaxHP / 2)
                        {
                            StartCoroutine(EndAction(0.0f, true));
                            _PlayersEnd = false;
                            GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                        }
                    }
                }
                if (_ActionClearing == 3)
                {
                    _TutorialBlackImage[5].SetActive(true);//게임/필살기 주시
                    _TutorialLabelImage[7].SetActive(true);//게임/필살기터치하세요!
                    if (_HyperSkillTouch)
                    {
                        _HyperSkillTouch = false;
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 4)
                {
                    if (GameMng.Data._GameDate._EnemyUnitList.Count == 0)
                    {
                        StartCoroutine(EndAction(0.5f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                        
                        
                    }
                }
                if(_ActionClearing == 5)
                {
                    _RestartButtonGray.SetActive(false);
                    _RecallButtonGray.SetActive(true);
                }
            }
            #endregion

            #region 스토리8
            if (_StoryNum == 8)
            {
                if (_ActionClearing == 1)
                {
                    if (GameMng.Data._MosnterWaveMng._BossOn == true)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 2)
                {
                    if (GameMng.Data._GameDate._EnemyUnitList.Count == 0)
                    {
                        StartCoroutine(EndAction(0.5f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
                if (_ActionClearing == 3)
                {

                }
            }
            #endregion

            #region 스토리9
            if (_StoryNum == 9)
            {
                if (_ActionClearing == 1)
                {
                    _TutorialLabelImage[4].SetActive(true);//마을/서쪽 태양들판 던전을 4번 클리어 하세요

                    _HeroPormationIcon.SetActive(true);
                    _Soldier_w_PormationIcon.SetActive(true);
                    _Soldier_a_PormationIcon.SetActive(true);
                }
            }
            #endregion

            #region 스토리10
            if (_StoryNum == 10)
            {
                if (_ActionClearing == 1)
                {
                    _HeroPormationIcon.SetActive(true);
                    _Soldier_w_PormationIcon.SetActive(true);
                    _Soldier_a_PormationIcon.SetActive(true);
                }
            }
            #endregion

            #region 스토리11
            if (_StoryNum == 11)
            {
                if (_ActionClearing == 1)
                {
                    _HeroPormationIcon.SetActive(true);
                    _Soldier_w_PormationIcon.SetActive(true);
                    _Soldier_a_PormationIcon.SetActive(true);
                }
            }
            #endregion

            #region 스토리12
            if (_StoryNum == 12)
            {
                if (_ActionClearing == 1)
                {
                    _HeroPormationIcon.SetActive(true);
                    _Soldier_w_PormationIcon.SetActive(true);
                    _Soldier_a_PormationIcon.SetActive(true);
                }
            }
            #endregion

            #region 스토리15
            if (_StoryNum == 15)
            {
                if (_ActionClearing == 1)
                {
                    _HighSkillIcon_Box.SetActive(false);
                    _LowSkillIcon_Box.SetActive(false);
                }
            }
            #endregion

            #region 스토리16
            if (_StoryNum == 16)
            {
                _HighSkillIcon_Box.SetActive(false);
                _LowSkillIcon_Box.SetActive(false);
                if (_ActionClearing == 1)
                {
                    if(GameMng.Data._GameDate._EnemyUnitList.Count==0 && GameMng.Data._MosnterWaveMng._NowWave==3)
                    {
                        GameMng.Data._MosnterWaveMng._WaveOn = false;
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
            }
            #endregion

            #region 스토리17
            if (_StoryNum == 17)
            {
                if (_ActionClearing == 1)
                {
                    if (GameMng.Data._MosnterWaveMng._BossOn)
                    {
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                }
            }
            #endregion

            #region 스토리18
            if (_StoryNum == 18)
            {
                _LowSkillIcon_Box.SetActive(false);
                _HighSkillIcon_Box.SetActive(false);
            }
            #endregion

            #region 스토리19
            if (_StoryNum == 19)
            {
                if(_ActionClearing==1)
                {
                    
                    if(StaticDataMng._TeamName != "")
                    {
                        _TeamNameEditor.SetActive(false);
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;

                        StaticDataMng._StoryOn = false;
                        StaticDataMng._StoryNum = 20;
                        StaticDataMng._StoryScene = "BasecampScene";

                        PlayerPrefs.SetInt("LastStoryClear", 1);
                    }
                }
            }
            #endregion

            #region 스토리20
            if (_StoryNum == 20)
            {
                if (_ActionClearing == 1)
                {
                    _TutorialBlackImage[9].SetActive(true);
                    if (_WorldMapUIMng._NowPopupSetNum == 6)
                    {
                        //Debug.Log("in");
                        StartCoroutine(EndAction(0.0f, true));
                        _PlayersEnd = false;


                    }

                }
            }
            #endregion

            #region 스토리21
            if (_StoryNum == 21)
            {
                if (_ActionClearing == 1)
                {
                    if(GameMng.Data._MosnterWaveMng._NowWave==1)
                    {
                        StartCoroutine(EndAction(0.5f, true));
                        _PlayersEnd = false;
                    }
                }
            }
            #endregion
        }
    }

    public void StoryAction()
    {
        _TouchSkill = false;
        _TouchToObject = false;
        _HyperSkillTouch = false;
        switch (_StoryNum)
        {
            #region 튜토리얼
            case 1:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;
                        //걸어가다가 늑대 한마리 생성 후 대치상황에서 끝
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 410), 50,4, 400.0f);//핏빛늑대
                        _UnitGenerator.MakeUnit_StoryMainTarget(1, 2, new Vector2(1300, 210), false, 50, 4, 400.0f);//핏빛늑대
                        StartCoroutine(EndAction(1.0f, true));
                    }
                    if (_ActionClearing == 2)
                    {
                        //늑대와 전투시킨 후 늑대의 피가 반 이상 까이면 3마리 추가 후 끝
                        StartCoroutine(MakeUnit(1.5f, 1, 2, new Vector2(1300, 510), false, false, 50, 3, 400.0f));//핏빛늑대
                        StartCoroutine(MakeUnit(1.5f, 1, 2, new Vector2(1300, 310), false, false, 50, 3, 400.0f));//핏빛늑대
                        StartCoroutine(MakeUnit(1.5f, 1, 2, new Vector2(1300, 110), false, false, 50, 3, 400.0f));//핏빛늑대
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 3)
                    {
                        //게임 시간정지, 불의 구슬만 생성 후 두번 클릭하도록 유도 후 끝
                        SetStoryMove(true);

                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 4)
                    {
                        //조합구슬에 불이들어오며 하급스킬만 생성 가능 후 스킬 사용유도, 스킬 데미지 맥뎀,
                        //몬스터를 죽인 후 끝
                        SetStoryMove(true);

                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 5)
                    {
                        SetStoryMove(false);
                        //늑대 5마리 생성 후 끝
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 50, 3, 400.0f);//핏빛늑대
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 410), 50, 3, 400.0f);//핏빛늑대
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 50, 3, 400.0f);//핏빛늑대
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 210), 50, 3, 400.0f);//핏빛늑대
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 50, 3, 400.0f);//핏빛늑대
                        StartCoroutine(EndAction(2.0f, true));
                        _PlayersEnd = true;
                        GameMng.Data._GameDate._HeroUnit._SkillAction = false;
                    }
                    if (_ActionClearing == 6)
                    {
                        //게임시간정지, 불의 속성구슬 반짝인 후 상급스킬 생성 유도, 사용 유도 후 늑대 처치 시 끝
                        SetStoryMove(true);
                        _CreativeCircle.SetCircleClaer();
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 7)
                    {
                        //늑대 2마리 일정시간마다 생성, 일반스테이지 진행과 같음. 보스 도달시 문구 출력 후 
                        //일반늑대 3마리와 보스, 쓰러진 소녀와 조우 후 끝
                        GameMng.Data._MosnterWaveMng._WaveOn = true;

                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 8)
                    {
                        //게임시간정지, 물의 속성구슬 반짝인 후 하급스킬 생성유도, 사용유도 후 회복된 후 끝
                        SetStoryMove(true);
                        _CreativeCircle.SetCircleClaer();
                        _FireEleBall.SetActive(false);
                        _WaterEleBall.SetActive(true);

                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 9)
                    {
                        //전투진행, 보스의 체력이 반 이하로 떨어지면 끝
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(false);

                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 50, 5, 400.0f);//핏빛늑대
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 410), 50, 5, 400.0f);//핏빛늑대
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 50, 5, 400.0f);//핏빛늑대
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 210), 50, 5, 400.0f);//핏빛늑대
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 50, 5, 400.0f);//핏빛늑대
                        _UnitGenerator.MakeUnit_StoryMainTarget(2, 1, new Vector2(1500, 310), true, 180,22, 400.0f);//핏빛늑대보스
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 10)
                    {
                        //게임시간정지, 물의 속성구슬 반짝인 후 상급스킬 생성유도, 사용유도 후 
                        //사용 후 보스를 처치하고 끝
                        _CreativeCircle.SetCircleClaer();
                        SetStoryMove(true);
                        _FireEleBall.SetActive(false);
                        _WaterEleBall.SetActive(true);

                        _TouchSkill = false;
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 11)
                    {
                        _PlayersEnd = true;

                    }
                    if(_ActionClearing==12)
                    {
                        //Debug.Log("Clear");
                        GameMng.Data._GameClearMng.ClearLayerOn(Random.Range(80,121),400,1,2);
                        GameMng.Data._GameClearMng._GetBasicItem = true;
                        GameMng.Data._GameClearMng._GetbasicItemNum = 1;
                        StaticDataMng._StoryNum = 2;
                        StaticDataMng._StoryOn = true;
                        StaticDataMng._StoryScene = "BasecampScene";
                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion//튜토리얼 

            #region 스토리2
            case 2:
                {
                    if(_ActionClearing==1)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 2)
                    {
                        _PlayersEnd = true;
                        StartCoroutine(EndAction(2.0f, true));
                    }
                    if (_ActionClearing == 3)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 4)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 5)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 6)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 7)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 8)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 9)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 10)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 11)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 12)
                    {
                        _PlayersEnd = true;
                        PlayerPrefs.SetInt("VillageUnlock", 1);
                        GameObject obj = NGUITools.AddChild(_LockGroup, _VillageUnLock);
                        obj.transform.localPosition = _WorldMapUIMng._VillageLock.transform.localPosition;
                        StaticDataMng._StoryNum = 3;
                        StaticDataMng._LastStageName = "민가";
                        StaticDataMng._LastStoryNum = StaticDataMng._StoryNum;
                        StaticDataMng._PlayingDead = true;
                        StaticDataMng._StoryOn = false;
                        StaticDataMng._StoryWaveOn_Save = true;
                        StaticDataMng._StoryScene = "GameScene";
                        _SaveMng.Saving();
                    }
                    if(_ActionClearing==13)
                    {
                        _PlayersEnd = true;
                        //Debug.Log("SetStory3");
                        
                        
                        
                       
                        
                    }
                    break;
                }
            #endregion//스토리2

            #region 스토리3
            case 3:
                {
                    if(_ActionClearing == 1)
                    {
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 2)
                    {
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 120, 9, 400.0f);//디가르 전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 377), 120, 9, 400.0f);//디가르 전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 243), 120, 9, 400.0f);//디가르 전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 120, 9, 400.0f);//디가르 전사
                        
                        StartCoroutine(EndAction(1.0f, true));
                    }
                    if (_ActionClearing == 3)
                    {
                        StartCoroutine(EndAction(5.0f, true));
                    }
                    if (_ActionClearing == 4)
                    {
                        _CreativeCircle.SetCircleClaer();
                        _FireEleBall.SetActive(false);
                        _WaterEleBall.SetActive(false);
                        _AirEleBall.SetActive(true);

                        SetStoryMove(true);
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 5)
                    {
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);

                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 6)
                    {
                        _CreativeCircle.SetCircleClaer();
                        _FireEleBall.SetActive(false);
                        _WaterEleBall.SetActive(false);
                        _AirEleBall.SetActive(true);

                        
                        SetStoryMove(true);
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 7)
                    {
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);

                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 120, 17, 400.0f);//디가르 전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 410), 120, 17, 400.0f);//디가르 전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 120, 17, 400.0f);//디가르 전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 210), 120, 17, 400.0f);//디가르 전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 120, 17, 400.0f);//디가르 전사

                        StartCoroutine(EndAction(6.0f, true));
                    }
                    if (_ActionClearing == 8)
                    {
                        _CreativeCircle.SetCircleClaer();
                        _FireEleBall.SetActive(false);
                        _WaterEleBall.SetActive(false);
                        _AirEleBall.SetActive(false);
                        _RandEleBall.SetActive(true);

                        SetStoryMove(true);
                        _PlayersEnd = true;
                    }
                    
                    if (_ActionClearing == 9)
                    {
                        _CreativeCircle.SetCircleClaer();
                        _FireEleBall.SetActive(false);
                        _WaterEleBall.SetActive(false);
                        _AirEleBall.SetActive(false);
                        _RandEleBall.SetActive(true);

                        SetStoryMove(true);
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 10)
                    {
                        StartCoroutine(EndAction(1.0f, true));
                    }
                    if (_ActionClearing == 11)
                    {
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        

                        _PlayersEnd = true;
                    }
                    if(_ActionClearing==12)
                    {
                        //GameMng.Data._MosnterWaveMng._WaveOn = true;
                        //GameMng.Data._MosnterWaveMng._NowWaveTime = GameMng.Data._MosnterWaveMng._WaveDelayTime;
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);

                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 120, 22, 400.0f);//디가르전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 410), 120, 22, 400.0f);//디가르전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 120, 22, 400.0f);//디가르전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 210), 120, 22, 400.0f);//디가르전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 120, 22, 400.0f);//디가르전사
                        _UnitGenerator.MakeUnit_StoryMainTarget(2, 3, new Vector2(1500, 320), true, 400, 28, 400.0f);//디가르 중급전사

                        _PlayersEnd = true;
                    }
                    if(_ActionClearing==13)
                    {
                        //Debug.Log("Clear");
                        GameMng.Data._GameClearMng.ClearLayerOn(Random.Range(120, 151), 600,1,1);

                        StaticDataMng._StoryNum = 4;
                        StaticDataMng._StoryOn = true;
                        StaticDataMng._StoryScene = "BasecampScene";
                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion 

            #region 스토리4
            case 4:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 2)
                    {
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 3)
                    {
                        PlayerPrefs.SetInt("SnowMountainUnlock", 1);
                        GameObject obj = NGUITools.AddChild(_LockGroup, _SnowMountainUnLock);
                        obj.transform.localPosition = _WorldMapUIMng._SnowMountainLock.transform.localPosition;

                        StaticDataMng._StoryNum = 5;
                        StaticDataMng._LastStageName = "설산";
                        StaticDataMng._LastStoryNum = StaticDataMng._StoryNum;
                        StaticDataMng._PlayingDead = true;
                        StaticDataMng._StoryOn = false;
                        StaticDataMng._StoryWaveOn_Save = true;
                        StaticDataMng._StoryScene = "GameScene";
                        _WorldMapUIMng._NowPopupSetNum = 0;//설산 언락애니메이션
                        StartCoroutine(EndAction(2.0f, true));
                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion

            #region 스토리5
            case 5:
                {
                    if (_ActionClearing == 1)
                    {
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 2)
                    {
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 410), 130,22, 400.0f);//디가르전사
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 210), 130, 22, 400.0f);//디가르전사
                        _UnitGenerator.MakeUnit_StoryMainTarget(2, 4, new Vector2(1500, 310), true, 280,30, 400.0f);//중급강령술사
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 3)
                    {
                        GameMng.Data._GameClearMng.ClearLayerOn(Random.Range(130, 161), 700,2,1);
                        StaticDataMng._StoryNum = 6;
                        StaticDataMng._StoryOn = true;
                        StaticDataMng._StoryScene = "BasecampScene";
                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion

            #region 스토리6
            case 6:
                {
                    if (_ActionClearing == 1)
                    {
                        PlayerPrefs.SetInt("SunSpearUnlock", 1);
                        GameObject obj = NGUITools.AddChild(_LockGroup, _SunguardUnLock);
                        obj.transform.localPosition = _WorldMapUIMng._SunguardLock.transform.localPosition;

                        StaticDataMng._StoryNum = 7;
                        StaticDataMng._LastStageName = "선스피어";
                        StaticDataMng._LastStoryNum = StaticDataMng._StoryNum;
                        StaticDataMng._PlayingDead = true;
                        StaticDataMng._StoryOn = false;
                        StaticDataMng._StoryWaveOn_Save = true;
                        StaticDataMng._StoryScene = "GameScene";
                        _SaveMng.Saving();
                    }
                    
                    break;
                }
            #endregion

            #region 스토리7
            case 7:
                {
                    if (_ActionClearing == 1)
                    {
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 2)
                    {
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 410), 130, 22, 400.0f);
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 210), 130, 22, 400.0f);
                        _UnitGenerator.MakeUnit_StoryMainTarget(2, 3, new Vector2(1340, 310),true, 300,25, 400.0f);//디가르하급2 중급1(보스)
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 3)
                    {
                        _FireEleBall.SetActive(false);
                        _WaterEleBall.SetActive(false);
                        _RandEleBall.SetActive(false);
                        _AirEleBall.SetActive(false);
                        _HyperSkillIcon.SetActive(true);
                        GameMng.Data._HyperSkillMng._HeroHyperValue = 100;
                        SetStoryMove(true);
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 4)
                    {
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 5)
                    {
                        GameMng.Data._GameClearMng.ClearLayerOn(Random.Range(150, 180), 800,3,1);
                        StaticDataMng._StoryNum = 8;
                        
                        StaticDataMng._StoryOn = true;
                        StaticDataMng._StoryWaveOn = true;
                        StaticDataMng._StoryScene = "GameScene";
                        StaticDataMng._StoryGoGameScene = true;
                        _PlayersEnd = true;
                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion

            #region 스토리8
            case 8:
                {
                    if (_ActionClearing == 1)
                    {
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 2)
                    {
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 300, 22, 400.0f);//디가르하급3 중급강령1(보스)
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 300, 22, 400.0f);
                        _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 300, 22, 400.0f);
                        _UnitGenerator.MakeUnit_StoryMainTarget(2, 4, new Vector2(1400, 310), true, 270,30, 400.0f);//중급강령술사
                        _PlayersEnd = true;
                    }
                    if (_ActionClearing == 3)
                    {
                        GameMng.Data._GameClearMng.ClearLayerOn(Random.Range(150, 181), 800,3,1);
                        StaticDataMng._StoryNum = 9;
                        StaticDataMng._StoryOn = true;
                        StaticDataMng._StoryWaveOn_Save = true;
                        StaticDataMng._StoryScene = "BasecampScene";
                        _PlayersEnd = true;
                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion

            #region 스토리9
            case 9: 
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;

                        PlayerPrefs.SetInt("LeftGrassUnlock", 1);
                        GameObject obj = NGUITools.AddChild(_LockGroup, _LeftGrassUnLock);
                        obj.transform.localPosition = _WorldMapUIMng._LeftGrassLock.transform.localPosition;


                        Quest quest = new Quest();
                        quest.Init("소탕", "서쪽 태양들판 던전을 4번 클리어 하세요.", "서쪽 태양들판", 1,4, true);
                        //quest._NowValue = 3;
                        _QuestMng.PlusQuest(quest,false,false);
                    }
                    break;
                }
            #endregion

            #region 스토리10
            case 10:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;

                        

                        Quest quest = new Quest();
                        quest.Init("민가 순찰", "민가 던전을 4번 클리어 하세요.", "민가", 1, 4, true);
                        //quest._NowValue = 4;
                        _QuestMng.PlusQuest(quest, false, false);
                    }
                    break;
                }
            #endregion

            #region 스토리11
            case 11:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;

                        PlayerPrefs.SetInt("RightGrassUnlock", 1);
                        GameObject obj = NGUITools.AddChild(_LockGroup, _RightGrassUnLock);
                        obj.transform.localPosition = _WorldMapUIMng._RightGrassLock.transform.localPosition;

                        Quest quest = new Quest();
                        quest.Init("임시기지 구축", "동쪽 태양들판 던전을 6번 클리어 하세요.", "동쪽 태양들판", 1, 6, true);
                        //quest._NowValue = 5;
                        _QuestMng.PlusQuest(quest, false, false);
                    }
                    break;
                }
            #endregion

            #region 스토리12
            case 12:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;

                        PlayerPrefs.SetInt("FireForestUnlock", 1);
                        GameObject obj = NGUITools.AddChild(_LockGroup, _FireForestUnLock);
                        obj.transform.localPosition = _WorldMapUIMng._FireForestLock.transform.localPosition;

                        Quest quest = new Quest();
                        quest.Init("불타는 숲 소탕", "불타는 숲 던전을 5번 클리어 하세요.", "불타는 숲", 1, 5, true);
                        //quest._NowValue = 4;
                        _QuestMng.PlusQuest(quest, false, false);
                    }
                    break;
                }
            #endregion

            #region 스토리13
            case 13:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;

                        GameMng.Data._GameClearMng.ClearLayerOn(Random.Range(280, 301), 950,8,3);

                        StaticDataMng._StoryOn = true;
                        StaticDataMng._StoryNum = 14;
                        StaticDataMng._StoryScene = "BasecampScene";
                        StaticDataMng._StoryWaveOn_Save = false;
                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion

            #region 스토리14
            case 14:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;

                        PlayerPrefs.SetInt("AradraUnlock", 1);
                        GameObject obj = NGUITools.AddChild(_LockGroup, _AradraUnLock);
                        obj.transform.localPosition = _WorldMapUIMng._AradraLock.transform.localPosition;

                        Quest quest = new Quest();
                        quest.Init("안좋은 예감", "아라드라 던전을 4번 클리어 하세요.", "아라드라", 1, 4, true);
                        //quest._NowValue = 2;
                        _QuestMng.PlusQuest(quest, false, false);
                    }
                    break;
                }
            #endregion

            #region 스토리15
            case 15:
                {
                    if (_ActionClearing == 1)
                    {
                        //Debug.Log("false");
                        _PlayersEnd = true;
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        StaticDataMng._StoryWaveOn = false;

                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        _RestartButtonGray.SetActive(false);
                    }
                    break;
                }
            #endregion

            #region 스토리16
            case 16:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        _RestartButtonGray.SetActive(false);
                    }

                    if (_ActionClearing == 2)
                    {
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                    }
                    break;
                }
            #endregion

            #region 스토리17
            case 17:
                {
                    if(_ActionClearing==1)
                    {

                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 455), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 395), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 332), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 270), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 210), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 455), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 395), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 332), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 270), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 210), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 455), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 395), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 332), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 270), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 210), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 455), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 395), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 332), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 270), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 210), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 455), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 395), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 332), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 270), 1000, 25, 400.0f);
                        _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 210), 1000, 25, 400.0f);

                        StartCoroutine(EndAction(1.0f, true));
                    }
                    if (_ActionClearing == 2)
                    {
                        SetStoryMove(true);
                        GameMng.Data._GameClearMng.ClearLayerOn(Random.Range(300, 351), 1000,9,3);

                        
                        StaticDataMng._StoryOn = true;
                        StaticDataMng._StoryNum = 18;
                        StaticDataMng._StoryScene = "GameScene";
                        StaticDataMng._SelectStageName = "설산";
                        StaticDataMng._StoryWaveOn = false;
                        StaticDataMng._StoryGoGameScene = true;
                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion

            #region 스토리18
            case 18:
                {
                    if (_ActionClearing == 1)
                    {
                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        _HyperSkillIcon.SetActive(true);


                        _PlayersEnd = true;

                        Quest quest = new Quest();
                        quest.Init("크나큰 충격", "설산 던전을 2번 클리어 하세요.", "설산", 1, 2, true);
                        StaticDataMng._StoryScene = "GameScene";
                        StaticDataMng._SelectStageName = "설산";
                        //quest._NowValue = 1;//temp
                        _QuestMng.PlusQuest(quest, false, false);

                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        _RestartButtonGray.SetActive(false);
                        _RecallButtonGray.SetActive(true);
                    }
                    break;
                }
            #endregion

            #region 스토리19
            case 19:
                {
                    if (_ActionClearing == 1)
                    {
                        GameMng.Data._MosnterWaveMng._WaveOn = false;
                        _PlayersEnd = true;
                        _TeamNameEditor.SetActive(true);
                        StaticDataMng._TeamName = "";
                    }

                    if (_ActionClearing == 2)
                    {
                        //Debug.Log("ohh");
                        _PlayersEnd = true;
                        GameMng.Data._GameClearMng.ClearLayerOn(Random.Range(350, 401), 1500, 10, 3);
                        GameMng.Data._BossKill = false;
                        StaticDataMng._StoryOn = false;
                        StaticDataMng._StoryNum = 20;
                        StaticDataMng._StoryScene = "BasecampScene";

                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion

            #region 스토리20
            case 20:
                {
                    if (_ActionClearing == 1)
                    {
                        PlayerPrefs.SetInt("SecondWorldmapOpen", 1);
                        _WorldMapUIMng._WorldMapAnimator.SetTrigger("right");

                        StartCoroutine(UnlockDelay_Azeneb(1.0f));
                    }
                    break;
                }
            #endregion

            #region 스토리21
            case 21:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        StaticDataMng._StoryWaveOn = false;

                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                    }
                    if (_ActionClearing == 2)
                    {
                        _PlayersEnd = true;
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        StaticDataMng._StoryWaveOn = false;

                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        _RestartButtonGray.SetActive(true);
                    }
                    break;
                }
            #endregion

            #region 스토리22
            case 22:
                {
                    if (_ActionClearing == 1)
                    {
                        PlayerPrefs.SetInt("ShipUnlock", 1);
                        GameObject iconlock = NGUITools.AddChild(_LockGroup_2, _ShipUnLock);
                        iconlock.transform.localPosition = _WorldMapUIMng._ShipLock.transform.localPosition;

                        Quest quest = new Quest();
                        quest.Init("갑판 위의 전투", "해상 위의 격전 던전을 3번 클리어 하세요.", "해상 위의 격전", 1, 4, true);
                        StaticDataMng._SelectStageName = "해상 위의 격전";
                    }
                    break;
                }
            #endregion

            #region 스토리23
            case 23:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;
                        GameMng.Data._MosnterWaveMng._WaveOn = true;
                        StaticDataMng._StoryWaveOn = false;

                        _FireEleBall.SetActive(true);
                        _WaterEleBall.SetActive(true);
                        _RandEleBall.SetActive(true);
                        _AirEleBall.SetActive(true);
                        _RestartButtonGray.SetActive(true);
                    }
                    break;
                }
            #endregion

            #region 스토리24
            case 24:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;
                        GameMng.Data._GameClearMng.ClearLayerOn(Random.Range(350, 401), 1500, 10, 3);
                        GameMng.Data._BossKill = false;
                        StaticDataMng._StoryOn = false;
                        StaticDataMng._StoryNum = 25;
                        StaticDataMng._StoryScene = "BasecampScene";

                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion

            #region 스토리25
            case 25:
                {
                    if (_ActionClearing == 1)
                    {
                        _PlayersEnd = true;


                        PlayerPrefs.SetInt("LastStoryClear", 1);
                        _SaveMng.Saving();
                    }
                    break;
                }
            #endregion
        }
    }

    IEnumerator UnlockDelay_Azeneb(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject iconlock = NGUITools.AddChild(_LockGroup_2, _PortUnLock);
        iconlock.transform.localPosition = _WorldMapUIMng._PortLock.transform.localPosition;
        //항구 언락
        
        PlayerPrefs.SetInt("PortUnlock", 1);
        //StaticDataMng._StoryNum = 22;
        //StaticDataMng._LastStageName = "에이즈네브 항구";
        //StaticDataMng._LastStoryNum = StaticDataMng._StoryNum;
        //StaticDataMng._PlayingDead = true;
        //StaticDataMng._StoryOn = false;
        //StaticDataMng._StoryWaveOn_Save = true;
        //StaticDataMng._StoryScene = "GameScene";

        Quest quest = new Quest();
        quest.Init("에이즈네브 항구 탐색", "에이즈네브 항구 던전을 3번 클리어 하세요.", "에이즈네브 항구", 1, 3, true);
        StaticDataMng._SelectStageName = "에이즈네브 항구";
        //quest._NowValue = 1;//temp
        _QuestMng.PlusQuest(quest, false, false);

        _SaveMng.Saving();
        _PlayersEnd = true;
    }


    public void SetStoryMove(bool ent)
    {
        if(_GameScene)
        {
            for (int i = 0; i < GameMng.Data._GameDate._SoldierUnitList.Count; i++)
                GameMng.Data._GameDate._SoldierUnitList[i]._StoryActioning = ent;
            for (int i = 0; i < GameMng.Data._GameDate._EnemyUnitList.Count; i++)
                GameMng.Data._GameDate._EnemyUnitList[i]._StoryActioning = ent;

            if (ent)
                GameMng.Data._MoveBg = false;
        }
        
    }

    public void SetStoryMove_HeroExcept(bool ent)
    {
        if (_GameScene)
        {
            for (int i = 0; i < GameMng.Data._GameDate._SoldierUnitList.Count; i++)
            {
                if (GameMng.Data._GameDate._SoldierUnitList[i]._Rating != 4)
                {

                    GameMng.Data._GameDate._SoldierUnitList[i]._StoryActioning = ent;
                }
                else
                    GameMng.Data._GameDate._SoldierUnitList[i]._StoryActioning = !ent;
            }
            for (int i = 0; i < GameMng.Data._GameDate._EnemyUnitList.Count; i++)
                GameMng.Data._GameDate._EnemyUnitList[i]._StoryActioning = ent;
            if (ent)
                GameMng.Data._MoveBg = false;
        }
    }

    IEnumerator EndAction(float time,bool ac)
    {
        yield return new WaitForSeconds(time);

        if (_GameScene)
            GameMng.Data._GameDate._HeroUnit._SkillAction = false;
        _StoryMng._StoryObject.SetActive(true);
        _StoryMng.SetCharArr();
        SetStoryMove(ac);
    }
    IEnumerator EndAction_HeroExcept(float time, bool ac)
    {
        yield return new WaitForSeconds(time);

            GameMng.Data._StoryMng._StoryObject.SetActive(true);
        GameMng.Data._StoryMng.SetCharArr();
        SetStoryMove_HeroExcept(ac);
    }
    IEnumerator MakeUnit(float time,int rating,int type,Vector2 Pos,bool main,bool boss,int hp,int damage,float movespeed)
    {
        yield return new WaitForSeconds(time);

        if (main)
            _UnitGenerator.MakeUnit_StoryMainTarget(rating, type, Pos,boss,hp,damage,movespeed);
        else
            _UnitGenerator.MakeUnit(rating, type, Pos, hp, damage, movespeed);
    }

    public void BossWaring()
    {
        GameObject obj = NGUITools.AddChild(_UIRoot, _BossWaringObj);
        StartCoroutine(UnsetBossWaring(2.5f));
        SetStoryMove(true);
        
    }
    IEnumerator UnsetBossWaring(float time)
    {
        yield return new WaitForSeconds(time);


        GameMng.Data._MosnterWaveMng._BossHPOn = true;
        GameMng.Data._MosnterWaveMng._BossHPAniOn = true;
        SetStoryMove(false);
    }

    public void SetTeamName(UILabel label)
    {
        AudioSource.PlayClipAtPoint(_SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
        if(label.text.Length>1&&label.text.Length<11)
        {
            StaticDataMng._TeamName = label.text;
        }
        else
        {
            GameObject obj = NGUITools.AddChild(_UIRoot, _TeamNameError);

        }
    }
}
