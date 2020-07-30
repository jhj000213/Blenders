using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMng : MonoBehaviour
{
    public GameCamera _Camera;

    public PublicSoundData _SoundData;

    public GameObject _RangeArrow;
    public GameObject _RangeCircle;
    public GameObject _RangeSecterForm;
    public GameObject _RangeNoneTarget;

    public StoryTellingMng _StoryMng;
    public StoryActionMng _S_ActionMng;
    public GameClearLayerMng _GameClearMng;
    public MonsterWaveMng _MosnterWaveMng;
    public HyperSkillMng _HyperSkillMng;

    public SceneChangeMng _SceneMng;

    public QuestMng _QuestMng;

    public string _StageName;

    public AudioClip _ShootArrow;

    public GameObject _Map_Forest;
    public GameObject _Map_FireForest;
    public GameObject _Map_SnowMountain;
    public GameObject _Map_Castle;
    public GameObject _Map_Cave;
    public GameObject _Map_DestroyVillage;
    public GameObject _Map_Port;
    public GameObject _Map_BattleShip;

    public UILabel _HeroLevel;

    public GameObject _Pause_OutGameScene_Gray;

    public string _SkillName;

    public float _GameTime;
    public bool _MoveBg;

    public GameObject _ProgressingIcon;
    public float _ProgressingGaze;
    public float _ProgressingGaze_Max;

    public float _SkillDmgMultyple = 1.0f;
    public float _SkillCoolTimeMultyple = 1.0f;

    public GameObject _EffectSoundListObj;
    public GameObject _DummySoundObj;
    public GameObject _UIRoot;
    public GameObject _StageNameEffect;

    AudioSource _BgmAudio;

    public bool _BossKill;

    public List<int> _UseSkillType = new List<int>();


    void Start()
    {
        _BgmAudio = GetComponent<AudioSource>();
        _BgmAudio.Play();
        _BgmAudio.volume = StaticDataMng._SoundOn;
        _RangeArrow.SetActive(false);
        _RangeCircle.SetActive(false);
        _RangeSecterForm.SetActive(false);
        _GameTime = 0.0f;

        int waveloop = 0;
        float wavedelay = 0;
        if (StaticDataMng._Tutorial)
        {
            
            _StageName = "Stage_Tutorial";
            waveloop = 5;
            wavedelay = 3.0f;
            _Map_FireForest.SetActive(true);
        }
        else
        {
            _StageName = StaticDataMng._SelectStageName;
            if(_StageName == "불타는 숲")
            {
                if(StaticDataMng._StoryOn)
                {
                    waveloop = 6;
                    wavedelay = 3.0f;
                }
                else
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                _Map_FireForest.SetActive(true);
            }
            else if (_StageName == "설산")
            {
                if (StaticDataMng._StoryOn)
                {
                    waveloop = 4;
                    wavedelay = 3.0f;
                }
                else
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                _Map_SnowMountain.SetActive(true);
            }
            else if (_StageName == "선스피어")
            {
                if (StaticDataMng._StoryOn)
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                else
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                _Map_Castle.SetActive(true);
            }
            else if (_StageName == "아라드라")
            {
                if (StaticDataMng._StoryOn)
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                else
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                _Map_Cave.SetActive(true);
            }
            else if (_StageName == "서쪽 태양들판")
            {
                if (StaticDataMng._StoryOn)
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                else
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                _Map_Forest.SetActive(true);
            }
            else if (_StageName == "동쪽 태양들판")
            {
                if (StaticDataMng._StoryOn)
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                else
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                _Map_Forest.SetActive(true);
            }
            else if (_StageName == "민가")
            {
                if (StaticDataMng._StoryOn)
                {
                    waveloop = 4;
                    wavedelay = 3.0f;
                }
                else
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                _Map_DestroyVillage.SetActive(true);
            }
            else if (_StageName == "에이즈네브 항구")
            {
                if (StaticDataMng._StoryOn)
                {
                    waveloop = 4;
                    wavedelay = 3.0f;
                }
                else
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                _Map_Port.SetActive(true);
            }
            else if (_StageName == "갑판 위의 격전")
            {
                if (StaticDataMng._StoryOn)
                {
                    waveloop = 4;
                    wavedelay = 3.0f;
                }
                else
                {
                    waveloop = 5;
                    wavedelay = 3.0f;
                }
                _Map_BattleShip.SetActive(true);
            }
        }
        _MosnterWaveMng.Init(waveloop, wavedelay);
        _ProgressingGaze_Max = wavedelay * waveloop;
        
        
        //_GameClearMng.ClearLayerOn(500,400,1,2);


        StartCoroutine(StageNameEffect(2.0f));
    }
    void Update()
    {
        _Pause_OutGameScene_Gray.SetActive(StaticDataMng._StoryOn);
        _HeroLevel.text = StaticDataMng._HeroLevel.ToString();
        _GameTime += Time.smoothDeltaTime;
        _updateAction();
        ClearCheck();

        if (_ProgressingGaze >= _ProgressingGaze_Max)
            _ProgressingGaze = _ProgressingGaze_Max;
        _ProgressingIcon.transform.localPosition = new Vector3(500.0f * (_ProgressingGaze / _ProgressingGaze_Max),41,0);
    }

    void ClearCheck()
    {
        if(_BossKill&&_GameDate._EnemyUnitList.Count==0)
        {
            _BossKill = false;
            if (!StaticDataMng._StoryOn)
            {
                int gold = 0;
                int exp = 0;
                int stagelevel = 0;
                int getitemnum = 0;
                if (GameMng.Data._StageName == "서쪽 태양들판")
                {
                    gold = Random.Range(180, 201);
                    exp = 800;
                    stagelevel = 3;
                    getitemnum = 1;
                }
                if (GameMng.Data._StageName == "불타는 숲")
                {
                    gold = Random.Range(280, 301);
                    exp = 950;
                    stagelevel = 8;
                    getitemnum = 3;
                }
                if (GameMng.Data._StageName == "민가")
                {
                    gold = Random.Range(200, 231);
                    exp = 950;
                    stagelevel = 5;
                    getitemnum = 2;
                }
                if (GameMng.Data._StageName == "동쪽 태양들판")
                {
                    gold = Random.Range(250, 281);
                    exp = 900;
                    stagelevel = 6;
                    getitemnum = 2;
                }
                if (GameMng.Data._StageName == "아라드라")
                {
                    gold = Random.Range(300, 331);
                    exp = 1000;
                    stagelevel = 9;
                    getitemnum = 3;
                }
                if (GameMng.Data._StageName == "선스피어")
                {
                    gold = Random.Range(150, 181);
                    exp = 800;
                    stagelevel = 3;
                    getitemnum = 1;
                }
                if (GameMng.Data._StageName == "설산")
                {
                    gold = Random.Range(350, 401);
                    exp = 1500;
                    stagelevel = 10;
                    getitemnum = 3;
                }
                if (GameMng.Data._StageName == "해상 위의 격전")
                {
                    gold = Random.Range(350, 401);
                    exp = 1500;
                    stagelevel = 10;
                    getitemnum = 3;
                }
                if (GameMng.Data._StageName == "에이즈네브 항구")
                {
                    gold = Random.Range(350, 401);
                    exp = 1500;
                    stagelevel = 10;
                    getitemnum = 3;
                }
                GameMng.Data._GameClearMng.ClearLayerOn(gold, exp, stagelevel, getitemnum);
                
                
            }
            else
            {
                //if(StaticDataMng._StoryWaveOn==false)
                //{
                //    int gold = 0;
                //    int exp = 0;
                //    int stagelevel = 0;
                //    int getitemnum = 0;
                //    if (GameMng.Data._StageName == "설산")
                //    {
                //        gold = Random.Range(350, 401);
                //        exp = 1100;
                //        stagelevel = 10;
                //        getitemnum = 3;
                //    }
                //    GameMng.Data._GameClearMng.ClearLayerOn(gold, exp, stagelevel, getitemnum);
                //    _BossKill = false;
                //}
                
            }
        }
    }

    private static GameMng instance = null;

    public static GameMng Data
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(GameMng)) as GameMng;
                if (instance == null)
                {
                    Debug.Log("no instance");
                }
            }
            return instance;
        }
    }

    IEnumerator StageNameEffect(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject obj = NGUITools.AddChild(_UIRoot, _StageNameEffect);
        obj.transform.localPosition = new Vector3(0, 162, 0);
        obj.transform.Find("StageName").GetComponent<UILabel>().text = _StageName;
    }

    public void ShakeGameCamera()
    {
        _Camera.MoveCamera();
    }

    public CreativeCircle _CreativeTable;
    public GameData _GameDate;
    public EffectAnimation _EffectAnimation;
    public TargettingObjList _TargetObjList;

    public List<HaveList> n_list = new List<HaveList>();
    void _updateAction()
    {
        for (int l = 0; l < n_list.Count; l++)
        {
            HaveList list = n_list[l];
            if (list == null)
                n_list.Remove(list);
            else
            {
                for (int i = 0; i < list.o_List.Count; )
                {
                    Action action = list.o_List[i];
                    if (action.n_update(Time.smoothDeltaTime) == true)
                        list.o_List.Remove(action);
                    break;
                }
            }
            
        }
    }
}