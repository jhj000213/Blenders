using UnityEngine;
using System.Collections;

public class GameClearLayerMng : MonoBehaviour {

    public DataSaveMng _SaveMng;

    public bool _Clear;
    public GameObject _ClearLayerBlack;
    public GameObject _ClearLayer;
    public UILabel _StageClear;
    string[] _StageClearArr = new string[] { "", "S", "St", "Sta", "Stag", "Stage", "Stage ", "Stage C", "Stage Cl", "Stage Cle", "Stage Clea", "Stage Clear", "Stage Clear!", "Stage Clear!!" };
    int _StageClearNum;

    public UILabel _StageName;
    public UILabel _StageName_1;
    public UILabel _GoldLabel;
    public UILabel _TimeLabel;

    public UILabel _HeroLevel;

    public GameObject _Item;
    public GameObject[] _ItemSlot = new GameObject[3];

    public GameObject _Table;
    public GameObject _Wing;
    public GameObject _Light;

    public UI2DSprite _ExpGaze;
    public GameObject _PlusExp;

    public GameObject _TouchToFast;
    bool _FastTouch;

    int _StageLevel;
    int _GetItemNum;

    bool _ExpGazeUp;
    float _FirstExp;
    float _nowExp;
    float _MaxUpExp;
    float _GetExp;
    float _OverExp;
    bool _LevelUP;


    float _TickUpGold;
    float _NowGold;
    int _GetGold;
    int _nowGoldUpLoop;
    int _MaxLoopCount;

    float _TickUpTime;
    float _NowTime;
    int _PlayTime;
    int _nowTimeUpLoop;
    int _MaxLoopCount_Time;

    public bool _GetBasicItem;
    public int _GetbasicItemNum;

    void Start()
    {
        _TouchToFast.SetActive(false);
        //StaticDataMng._HeroExpValue = 800.0f;//temp
        //StaticDataMng._HeroMaxExpValue = 1000.0f;
    }

    void Update()
    {
        _TimeLabel.text = ((int)(_NowTime / 60)).ToString() + " : " + ((int)(_NowTime % 60)).ToString();
        _HeroLevel.text = StaticDataMng._HeroLevel.ToString();
        _GoldLabel.text = ((int)_NowGold).ToString();
        _StageName_1.text = GameMng.Data._StageName;
        _StageName.text = GameMng.Data._StageName;
        if (!_FastTouch)
        {
            if (_ExpGazeUp)
            {
                _ExpGaze.fillAmount = _nowExp / StaticDataMng._HeroMaxExpValue;
                if (_MaxUpExp >= _nowExp)
                {
                    _nowExp += 250.0f * Time.smoothDeltaTime;
                    
                    //Debug.Log(StaticDataMng._HeroMaxExpValue);
                    if (StaticDataMng._HeroMaxExpValue <= _nowExp)
                    {
                        _MaxUpExp -= StaticDataMng._HeroMaxExpValue;

                        if (StaticDataMng._HeroLevel < 10)
                        {
                            StaticDataMng._HeroLevel++;
                            StaticDataMng._HeroSkillPoint += 4;
                            StaticDataMng._HeroMaxExpValue = 500.0f + StaticDataMng._HeroLevel * 500.0f;
                            StaticDataMng._HeroExpValue = 0.0f;
                        }
                        else
                        {
                            StaticDataMng._HeroMaxExpValue = 500.0f + StaticDataMng._HeroLevel * 500.0f;
                            StaticDataMng._HeroExpValue = StaticDataMng._HeroMaxExpValue;
                        }


                        _nowExp = 0.0f;
                    }
                }
                else
                {
                    if (_LevelUP)
                    {
                        _nowExp = _OverExp;
                        StaticDataMng._HeroExpValue = _OverExp;
                    }
                    else
                    {
                        _nowExp = _MaxUpExp;
                        StaticDataMng._HeroExpValue = _MaxUpExp;
                    }
                    _ExpGazeUp = false;

                    GameObject obj = NGUITools.AddChild(_ExpGaze.gameObject, _PlusExp);
                    obj.transform.localPosition = new Vector3(_ExpGaze.width * _ExpGaze.fillAmount, 0, 0);
                    obj.transform.GetChild(0).GetComponent<UILabel>().text = "+Exp " + _GetExp.ToString();
                }
            }
        }
        else
        {

        }
    }

    IEnumerator SetClearLabel(float time)
    {
        yield return new WaitForSeconds(time);

        _StageClear.text = _StageClearArr[_StageClearNum];
        _StageClearNum++;
        if (_StageClearNum < _StageClearArr.Length)
            StartCoroutine(SetClearLabel(0.1f));
    }

    public void ClearLayerOn(int getgold,int getexp,int stagelevel,int getitemnum)
    {
        
        if(GameMng.Data._UseSkillType.Count!=0)
        {
            int tempele = 0;
            bool dificult = false;
            tempele = GameMng.Data._UseSkillType[0];
            for (int i = 0; i < GameMng.Data._UseSkillType.Count; i++)
            {
                if (tempele != GameMng.Data._UseSkillType[i])
                {
                    dificult = true;
                    break;
                }
            }
            if (!dificult)
                StaticDataMng._OnlyElementClear++;
        }
        int tempsoldiertype = 0;
        bool dificultsoldier = false;
        for (int i = 0; i < StaticDataMng._PormationList.Count; i++)
        {
            if(StaticDataMng._PormationList[i]._UnitNum!=1)
            {
                tempsoldiertype=StaticDataMng._PormationList[i]._UnitNum;
                break;
            }
        }
        for (int i = 0; i < StaticDataMng._PormationList.Count;i++ )
        {
            if(StaticDataMng._PormationList[i]._UnitNum!=1)
            {
                if(tempsoldiertype!=StaticDataMng._PormationList[i]._UnitNum)
                {
                    dificultsoldier = true;
                    break;
                }
            }
        }
        if(!dificultsoldier)
        {
            if (tempsoldiertype == 2)
                StaticDataMng._OnlySoldier_W_Clear++;
            else
                StaticDataMng._OnlySoldier_A_Clear++;
        }

        



            _Clear = true;
        _StageLevel = stagelevel;
        _GetItemNum = getitemnum;
        GameMng.Data._QuestMng.QuestPlayingCheck(GameMng.Data._StageName);
        _MaxLoopCount = 60;
        _MaxLoopCount_Time = 60;
        _GetGold = getgold;
        _GetExp = getexp;
        _TickUpGold = (float)_GetGold / (float)_MaxLoopCount;
        _PlayTime = (int)GameMng.Data._GameTime;
        _TickUpTime = (float)_PlayTime / (float)_MaxLoopCount_Time;
        StaticDataMng._Gold += _GetGold;
        _TouchToFast.SetActive(true);

        if (_PlayTime <= 30.0f)
            StaticDataMng._In30SecondClear++;


        StartCoroutine(LayerOn(1.5f));

        StartCoroutine(BlackLayerOn(0.3f));
        
    }

    IEnumerator SetWing(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject obj = NGUITools.AddChild(_Table, _Wing);
        StartCoroutine(SetLight(0.25f));
    }
    IEnumerator SetLight(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject obj = NGUITools.AddChild(_Table, _Light);
        obj.transform.localPosition = new Vector3(0, 131, 0);
    }

    IEnumerator BlackLayerOn(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject obj = NGUITools.AddChild(GameMng.Data._UIRoot, _ClearLayerBlack);
    }

    IEnumerator LayerOn(float time)
    {
        yield return new WaitForSeconds(time);

        

        GameMng.Data.gameObject.GetComponent<AudioSource>().Stop();
        Debug.Log("clear");
        if (StaticDataMng._Tutorial)
            StaticDataMng._Tutorial = false;
        _ClearLayer.GetComponent<Animator>().SetTrigger("clear");
        StartCoroutine(SetWing(0.8f));
        StartCoroutine(SetClearLabel(1.05f));
        _GoldLabel.text = "0";
        _ExpGaze.fillAmount = StaticDataMng._HeroExpValue / StaticDataMng._HeroMaxExpValue;

        StartCoroutine(SetExpGazeUp(2.0f));
        StartCoroutine(SetGetGold(2.0f));
        StartCoroutine(SetPlayTime(2.0f));


        for(int i=0;i<_GetItemNum;i++)
        {
                StartCoroutine(SetGetItem(4.0f + 0.5f * i, i));
        }
        StartCoroutine(DestroyTouchToFast(2.0f+(_GetExp/250)));
    }


    IEnumerator SetExpGazeUp(float time)
    {
        yield return new WaitForSeconds(time);

        _ExpGazeUp = true;
        
        _MaxUpExp = StaticDataMng._HeroExpValue + _GetExp;
        _nowExp = StaticDataMng._HeroExpValue;

        if(_nowExp+_GetExp>=StaticDataMng._HeroMaxExpValue)
        {
            _LevelUP = true;
            _OverExp = (_nowExp + _GetExp) - StaticDataMng._HeroMaxExpValue;
            //_GetExp -= _OverExp;
        }
    }
    IEnumerator SetGetGold(float time)
    {
        yield return new WaitForSeconds(time);

        _nowGoldUpLoop++;
        if (_nowGoldUpLoop < _MaxLoopCount-1)
        {
            _NowGold += _TickUpGold;
            if (!_FastTouch)
                StartCoroutine(SetGetGold(0.015f));
        }
        if (_nowGoldUpLoop == _MaxLoopCount-1)
        {
            _NowGold = _GetGold;
        }

    }

    IEnumerator SetPlayTime(float time)
    {
        yield return new WaitForSeconds(time);

        _nowTimeUpLoop++;
        if (_nowTimeUpLoop < _MaxLoopCount_Time - 1)
        {
            _NowTime += _TickUpTime;
            if (!_FastTouch)
                StartCoroutine(SetPlayTime(0.015f));
        }
        if (_nowTimeUpLoop == _MaxLoopCount_Time - 1)
        {
            _NowTime = _PlayTime;
        }

    }

    IEnumerator SetGetItem(float time,  int slotnum)
    {
        yield return new WaitForSeconds(time);
        GameObject obj = NGUITools.AddChild(_ItemSlot[slotnum], _Item);
        
        obj.transform.localScale = new Vector3(0.9f, 0.9f, 1);


        bool canitem = false;
        HeroItem Item = new HeroItem();
        if(_GetBasicItem)
        {
            
            for(int i=0;i<StaticDataMng._AllHeroItemList_Common.Count;i++)
            {
                if(_GetbasicItemNum==1)
                {
                    if (StaticDataMng._AllHeroItemList_Common[i]._ItemName == "warrior_lv1_common_1")
                    {
                        _GetbasicItemNum = 2;
                        Item.ItemInit(StaticDataMng._AllHeroItemList_Common[i]._ItemName, StaticDataMng._AllHeroItemList_Common[i]._ItemKoreanName,
                            StaticDataMng._AllHeroItemList_Common[i]._ItemType, StaticDataMng._AllHeroItemList_Common[i]._Rating,
                            0, StaticDataMng._AllHeroItemList_Common[i]._OriginAttackPoint,
                            StaticDataMng._AllHeroItemList_Common[i]._OriginPowerPoint, StaticDataMng._AllHeroItemList_Common[i]._OriginIntellectPoint,
                            StaticDataMng._AllHeroItemList_Common[i]._OriginArmorPoint, StaticDataMng._AllHeroItemList_Common[i]._OriginHealthPoint,
                            StaticDataMng._AllHeroItemList_Common[i]._ItemLevel);
                        Item._ItemInfo = StaticDataMng._AllHeroItemList_Common[i]._ItemInfo;
                        Item.SetStatRankB();
                        break;
                    }
                }
                if (_GetbasicItemNum == 2)
                {
                    if (StaticDataMng._AllHeroItemList_Common[i]._ItemName == "armor_lv1_common_1")
                    {
                        _GetbasicItemNum = 3;
                        Item.ItemInit(StaticDataMng._AllHeroItemList_Common[i]._ItemName, StaticDataMng._AllHeroItemList_Common[i]._ItemKoreanName,
                            StaticDataMng._AllHeroItemList_Common[i]._ItemType, StaticDataMng._AllHeroItemList_Common[i]._Rating,
                            0, StaticDataMng._AllHeroItemList_Common[i]._OriginAttackPoint,
                            StaticDataMng._AllHeroItemList_Common[i]._OriginPowerPoint, StaticDataMng._AllHeroItemList_Common[i]._OriginIntellectPoint,
                            StaticDataMng._AllHeroItemList_Common[i]._OriginArmorPoint, StaticDataMng._AllHeroItemList_Common[i]._OriginHealthPoint,
                            StaticDataMng._AllHeroItemList_Common[i]._ItemLevel);
                        Item._ItemInfo = StaticDataMng._AllHeroItemList_Common[i]._ItemInfo;
                        Item.SetStatRankB();
                        break;
                    }
                }
            }
        }
        else
        {
            while (!canitem)
            {
                int itemrarity = Random.Range(0, 100);
                if (itemrarity < 5)
                {
                    //레전
                    //int itemnum = Random.Range(0, StaticDataMng._AllHeroItemList_Legendery.Count);
                    //Item = StaticDataMng._AllHeroItemList_Legendery[itemnum];
                    //if (_StageLevel >= Item._ItemLevel&&Item._ItemLevel!=0)
                    //    canitem = true;
                }
                else if (itemrarity > 4 && itemrarity < 20)
                {
                    //레어
                    int itemnum = Random.Range(0, StaticDataMng._AllHeroItemList_Rare.Count);
                    Item.ItemInit(StaticDataMng._AllHeroItemList_Rare[itemnum]._ItemName, StaticDataMng._AllHeroItemList_Rare[itemnum]._ItemKoreanName,
                        StaticDataMng._AllHeroItemList_Rare[itemnum]._ItemType, StaticDataMng._AllHeroItemList_Rare[itemnum]._Rating,
                        StaticDataMng._AllHeroItemList_Rare[itemnum]._Price, StaticDataMng._AllHeroItemList_Rare[itemnum]._OriginAttackPoint,
                        StaticDataMng._AllHeroItemList_Rare[itemnum]._OriginPowerPoint, StaticDataMng._AllHeroItemList_Rare[itemnum]._OriginIntellectPoint,
                        StaticDataMng._AllHeroItemList_Rare[itemnum]._OriginArmorPoint, StaticDataMng._AllHeroItemList_Rare[itemnum]._OriginHealthPoint,
                        StaticDataMng._AllHeroItemList_Rare[itemnum]._ItemLevel);
                    Item._ItemInfo = StaticDataMng._AllHeroItemList_Rare[itemnum]._ItemInfo;
                    if (_StageLevel >= Item._ItemLevel && Item._ItemLevel != 0)
                        canitem = true;
                }
                else
                {
                    int itemnum = Random.Range(0, StaticDataMng._AllHeroItemList_Common.Count);
                    Item.ItemInit(StaticDataMng._AllHeroItemList_Common[itemnum]._ItemName, StaticDataMng._AllHeroItemList_Common[itemnum]._ItemKoreanName,
                        StaticDataMng._AllHeroItemList_Common[itemnum]._ItemType, StaticDataMng._AllHeroItemList_Common[itemnum]._Rating,
                        StaticDataMng._AllHeroItemList_Common[itemnum]._Price, StaticDataMng._AllHeroItemList_Common[itemnum]._OriginAttackPoint,
                        StaticDataMng._AllHeroItemList_Common[itemnum]._OriginPowerPoint, StaticDataMng._AllHeroItemList_Common[itemnum]._OriginIntellectPoint,
                        StaticDataMng._AllHeroItemList_Common[itemnum]._OriginArmorPoint, StaticDataMng._AllHeroItemList_Common[itemnum]._OriginHealthPoint,
                        StaticDataMng._AllHeroItemList_Common[itemnum]._ItemLevel);
                    Item._ItemInfo = StaticDataMng._AllHeroItemList_Common[itemnum]._ItemInfo;
                    if (_StageLevel >= Item._ItemLevel && Item._ItemLevel != 0)
                    {
                        canitem = true;
                    }
                }
            };
            Item.ItemStatSet();
        }
        
        obj.transform.GetChild(1).GetComponent<UISprite>().spriteName = "heroitem_"+Item._ItemName;
        //Debug.Log("heroitem_" + Item._ItemName + slotnum);
        if (Item._ItemType == "warriorweapon")
            StaticDataMng._HeroHaveItem_Weapon.Add(Item);
        else
            StaticDataMng._HeroHaveItem_Armor.Add(Item);

        _SaveMng.Saving();
    }
    public void SetFast()
    {
        //Time.timeScale = 50.0f;
        _FastTouch=true;
        //_nowGoldUpLoop = _MaxLoopCount - 1;
        //_nowTimeUpLoop = _MaxLoopCount_Time - 1;

        _ExpGazeUp = false;
        _NowGold = _GetGold;
        _NowTime = _PlayTime;
        Destroy(_TouchToFast);
        float getExp = _GetExp;
        _FirstExp = StaticDataMng._HeroExpValue;


        while (_FirstExp + getExp > StaticDataMng._HeroMaxExpValue)
        {
            getExp = _FirstExp + getExp - StaticDataMng._HeroMaxExpValue;
            _FirstExp = 0;
            StaticDataMng._HeroLevel++;
            StaticDataMng._HeroSkillPoint += 4;
            StaticDataMng._HeroMaxExpValue = 500.0f + StaticDataMng._HeroLevel * 500.0f;
            StaticDataMng._HeroExpValue = 0.0f;
        }
        _ExpGaze.fillAmount = getExp / StaticDataMng._HeroMaxExpValue;
        StaticDataMng._HeroExpValue = _FirstExp + getExp;

        StartCoroutine(SetSlow(10.0f));
    }
    IEnumerator SetSlow(float time)
    {
        yield return new WaitForSeconds(time);

        Time.timeScale = 1.0f;
    }
    IEnumerator DestroyTouchToFast(float time)
    {
        yield return new WaitForSeconds(time);

        if (!_FastTouch)
            Destroy(_TouchToFast);
    }
}
