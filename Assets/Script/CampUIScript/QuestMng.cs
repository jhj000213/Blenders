using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class QuestMng : MonoBehaviour {

    public List<Quest> _HaveMainQuest = new List<Quest>();
    public List<Quest> _HaveSubQuest = new List<Quest>();

    public DataSaveMng _SaveMng;

    public StoryTellingMng _StoryMng;
    public StoryActionMng _ActionMng;
    public MonsterWaveMng _WaveMng;
    public PublicSoundData _SoundData;
    public GameObject _QuestClearAlarm_Ingame;

    int _InStoryNum;

    public bool _NewQuest;
    public GameObject _NewAlarm;
    public GameObject _ClearAlarm;

    public GameObject _QuestIcon;
    public GameObject _QuestGetEffect;

    public UILabel _MainQuestName;
    public UILabel _MainQuestTarget;
    public UILabel _MainQuestTargetName;
    public UILabel _MainQuestNowValue;
    public UILabel _MainQuestGoalValue;

    public UILabel _Sub_1_QuestName;
    public UILabel _Sub_1_QuestTarget;
    public UILabel _Sub_1_QuestTargetName;
    public UILabel _Sub_1_QuestNowValue;
    public UILabel _Sub_1_QuestGoalValue;

    public UILabel _Sub_2_QuestName;
    public UILabel _Sub_2_QuestTarget;
    public UILabel _Sub_2_QuestTargetName;
    public UILabel _Sub_2_QuestNowValue;
    public UILabel _Sub_2_QuestGoalValue;

    void Start()
    {
        _InStoryNum = 0;
        SettingQuest();
        if(_HaveMainQuest.Count!=0)
        {
            if (_HaveMainQuest[0].QuestClear())
            {
                StaticDataMng._HaveQuestList.Remove(_HaveMainQuest[0]);
                if (_HaveMainQuest[0]._QuestName == "소탕")
                {

                    _StoryMng.Calltxt("story_10");
                }
                if (_HaveMainQuest[0]._QuestName == "민가 순찰")
                {
                    _StoryMng.Calltxt("story_11");
                }
                if (_HaveMainQuest[0]._QuestName == "임시기지 구축")
                {
                    _StoryMng.Calltxt("story_12");
                }
                if (_HaveMainQuest[0]._QuestName == "불타는 숲 소탕")
                {
                    _StoryMng.Calltxt("story_14");
                }
                if (_HaveMainQuest[0]._QuestName == "에이즈네브 항구 탐색")
                {
                    _StoryMng.Calltxt("story_22");
                }
                if (_HaveMainQuest[0]._QuestName == "갑판 위의 전투")
                {
                    _StoryMng.Calltxt("story_25");
                }
            }
        }
        
    }

    public void PlusQuest(Quest quest,bool storyon,bool storywaveon)
    {
        if(!_ActionMng._GameScene)
        {
            GameObject obj = NGUITools.AddChild(_QuestIcon, _QuestGetEffect);
            obj.transform.localPosition = new Vector3(37, 34, 0);
            AudioSource.PlayClipAtPoint(_SoundData._GetQuest, Vector2.zero, StaticDataMng._SoundOn);
        }
        

        _NewQuest = true;
        StaticDataMng._HaveQuestList.Add(quest);
        StaticDataMng._StoryOn = storyon;
        StaticDataMng._StoryWaveOn = storywaveon;
        _SaveMng.Saving();
    }

    void QuestInStory()
    {

        if (_ActionMng._GameScene)
        {
            for (int i = 0; i < _HaveMainQuest.Count; i++)
            {
                if (_HaveMainQuest[i]._NowValue >= _HaveMainQuest[i]._GoalValue)
                    _QuestClearAlarm_Ingame.SetActive(true);
            }
            if (_HaveMainQuest.Count != 0)
            {
                if (_HaveMainQuest[0]._QuestName == "불타는 숲 소탕" && StaticDataMng._SelectStageName == "불타는 숲")
                {
                    if (_HaveMainQuest[0]._NowValue == 4)
                    {
                        StaticDataMng._StoryOn = true;
                        if (GameMng.Data._GameDate._EnemyUnitList.Count == 0 && _InStoryNum == 0 && _WaveMng._NowWave >= _WaveMng._MaxWave)
                        {
                            _InStoryNum = 1;
                            _StoryMng.Calltxt("story_13");
                        }
                    }

                }

                if (_HaveMainQuest[0]._QuestName == "안좋은 예감" && StaticDataMng._SelectStageName == "아라드라")
                {
                    if (_HaveMainQuest[0]._NowValue == 0)
                    {
                        if (GameMng.Data._GameDate._EnemyUnitList.Count == 0 && _InStoryNum == 0)
                        {
                            _InStoryNum = 1;
                            _StoryMng.Calltxt("story_15");

                            _WaveMng._WaveOn = false;
                        }
                    }
                    if (_HaveMainQuest[0]._NowValue == 2)
                    {
                        if (_InStoryNum == 0 && _WaveMng._NowWave == 2&&_WaveMng._NowWaveTime>=2.5f)
                        {   
                            _WaveMng._WaveOn = false;
                            StaticDataMng._StoryWaveOn = true;
                            _InStoryNum = 1;
                            _StoryMng.Calltxt("story_16");
                            StaticDataMng._StoryNum = 16;
                        }
                    }
                    if (_HaveMainQuest[0]._NowValue == 3)
                    {
                        if (_WaveMng._NowWave == 4 && _WaveMng._NowWaveTime >= 2.0f && _InStoryNum == 0)
                        {
                            StaticDataMng._StoryWaveOn = true;
                            _InStoryNum = 1;
                            _StoryMng.Calltxt("story_17");
                        }
                    }
                }
                if (_HaveMainQuest[0]._QuestName == "크나큰 충격" && StaticDataMng._SelectStageName == "설산")
                {
                    if (_HaveMainQuest[0]._NowValue == 1)
                    {
                        if (GameMng.Data._GameDate._EnemyUnitList.Count == 0 && _InStoryNum == 0 && _WaveMng._NowWave >= _WaveMng._MaxWave)
                        {
                            _InStoryNum = 1;
                            _StoryMng.Calltxt("story_19");
                        }
                    }
                }
                if (_HaveMainQuest[0]._QuestName == "에이즈네브 항구 탐색" && StaticDataMng._SelectStageName == "에이즈네브 항구")
                {
                    if (_HaveMainQuest[0]._NowValue == 0)
                    {
                        if (GameMng.Data._GameDate._EnemyUnitList.Count == 0 && _InStoryNum == 0 && _WaveMng._NowWave ==0)
                        {
                            _WaveMng._WaveOn = false;
                            _InStoryNum = 1;
                            _StoryMng.Calltxt("story_21");
                        }
                    }
                }
                if (_HaveMainQuest[0]._QuestName == "갑판 위의 전투" && StaticDataMng._SelectStageName == "해상 위의 격전")
                {
                    if (_HaveMainQuest[0]._NowValue == 0)
                    {
                        if (GameMng.Data._GameDate._EnemyUnitList.Count == 0 && _InStoryNum == 0 && _WaveMng._NowWave == 0)
                        {
                            _WaveMng._WaveOn = false;
                            _InStoryNum = 1;
                            _StoryMng.Calltxt("story_23");
                        }
                    }
                    if (_HaveMainQuest[0]._NowValue == 3)
                    {
                        if (GameMng.Data._GameDate._EnemyUnitList.Count == 0 && _InStoryNum == 0 && _WaveMng._NowWave >= _WaveMng._MaxWave)
                        {
                            _InStoryNum = 1;
                            _StoryMng.Calltxt("story_24");
                        }
                    }
                }
            }
        }

    }

    void Update()
    {
        SettingQuest();
        QuestInStory();
        SaveQuest();
    }

    public void QuestPlayingCheck(string targetname)
    {
        for (int i = 0; i < StaticDataMng._HaveQuestList.Count;i++ )
        {
            if (StaticDataMng._HaveQuestList[0]._TargetName == targetname)
                StaticDataMng._HaveQuestList[0].QuestValuePlus();
        }
    }

    void SettingQuest()
    {
        _HaveMainQuest.Clear();
        _HaveSubQuest.Clear();
        for(int i=0;i<StaticDataMng._HaveQuestList.Count;i++)
        {
            if (StaticDataMng._HaveQuestList[i]._MainQuest)
                _HaveMainQuest.Add(StaticDataMng._HaveQuestList[i]);
            else
                _HaveSubQuest.Add(StaticDataMng._HaveQuestList[i]);
        }

        
        if(!_ActionMng._GameScene)
        {
            _MainQuestName.text = "";
            _MainQuestTarget.text = "퀘스트가 없습니다";
            _MainQuestTargetName.text = "";
            _MainQuestNowValue.text = "0";
            _MainQuestGoalValue.text = "0";

            _Sub_1_QuestName.text = "";
            _Sub_1_QuestTarget.text = "퀘스트가 없습니다";
            _Sub_1_QuestTargetName.text = "";
            _Sub_1_QuestNowValue.text = "0";
            _Sub_1_QuestGoalValue.text = "0";

            _Sub_2_QuestName.text = "";
            _Sub_2_QuestTarget.text = "퀘스트가 없습니다";
            _Sub_2_QuestTargetName.text = "";
            _Sub_2_QuestNowValue.text = "0";
            _Sub_2_QuestGoalValue.text = "0";



            for (int i = 0; i < _HaveMainQuest.Count;i++ )
            {
                _MainQuestName.text = _HaveMainQuest[i]._QuestName;
                _MainQuestTarget.text = _HaveMainQuest[i]._Target;
                _MainQuestTargetName.text = _HaveMainQuest[i]._TargetName;
                _MainQuestNowValue.text = _HaveMainQuest[i]._NowValue.ToString();
                _MainQuestGoalValue.text = _HaveMainQuest[i]._GoalValue.ToString();
            }
            if(_HaveSubQuest.Count>=1)
            {
                _Sub_1_QuestName.text = _HaveSubQuest[0]._QuestName;
                _Sub_1_QuestTarget.text = _HaveSubQuest[0]._Target;
                _Sub_1_QuestTargetName.text = _HaveSubQuest[0]._TargetName;
                _Sub_1_QuestNowValue.text = _HaveSubQuest[0]._NowValue.ToString();
                _Sub_1_QuestGoalValue.text = _HaveSubQuest[0]._GoalValue.ToString();
                if(_HaveSubQuest.Count>=2)
                {
                    _Sub_2_QuestName.text = _HaveSubQuest[1]._QuestName;
                    _Sub_2_QuestTarget.text = _HaveSubQuest[1]._Target;
                    _Sub_2_QuestTargetName.text = _HaveSubQuest[1]._TargetName;
                    _Sub_2_QuestNowValue.text = _HaveSubQuest[1]._NowValue.ToString();
                    _Sub_2_QuestGoalValue.text = _HaveSubQuest[1]._GoalValue.ToString();
                }
            }
            _NewAlarm.SetActive(_NewQuest);
            bool setclear = false;
            for (int i = 0; i < StaticDataMng._HaveQuestList.Count; i++)
            {
                if (StaticDataMng._HaveQuestList[i]._NowValue >= StaticDataMng._HaveQuestList[i]._GoalValue)
                    setclear = true;
            }
            _ClearAlarm.SetActive(setclear);
        }

        
    }

    

    void SaveQuest()
    {
        for (int i = 0; i < 1; i++)
        {
            PlayerPrefs.SetString("MainQuest_QuestName", "");
            PlayerPrefs.SetString("MainQuest_Target", "");
            PlayerPrefs.SetString("MainQuest_TargetName", "");
            PlayerPrefs.SetInt("MainQuest_Type", 0);
            PlayerPrefs.SetInt("MainQuest_GoalValue", 0);
            PlayerPrefs.SetInt("MainQuest_NowValue", 0);
        }
        for (int i = 0; i < 2; i++)
        {
            PlayerPrefs.SetString("SubQuest_" + i.ToString() + "_QuestName", "");
            PlayerPrefs.SetString("SubQuest_" + i.ToString() + "_Target", "");
            PlayerPrefs.SetString("SubQuest_" + i.ToString() + "_TargetName", "");
            PlayerPrefs.SetInt("SubQuest_" + i.ToString() + "_Type", 0);
            PlayerPrefs.SetInt("SubQuest_" + i.ToString() + "_GoalValue", 0);
            PlayerPrefs.SetInt("SubQuest_" + i.ToString() + "_NowValue", 0);
        }


        for (int i = 0; i < _HaveMainQuest.Count; i++)
        {
            PlayerPrefs.SetString("MainQuest_QuestName", _HaveMainQuest[i]._QuestName);
            PlayerPrefs.SetString("MainQuest_Target", _HaveMainQuest[i]._Target);
            PlayerPrefs.SetString("MainQuest_TargetName", _HaveMainQuest[i]._TargetName);
            PlayerPrefs.SetInt("MainQuest_Type", _HaveMainQuest[i]._QuestType);
            PlayerPrefs.SetInt("MainQuest_GoalValue", _HaveMainQuest[i]._GoalValue);
            PlayerPrefs.SetInt("MainQuest_NowValue", _HaveMainQuest[i]._NowValue);
        }
        for (int i = 0; i < _HaveSubQuest.Count;i++ )
        {
            PlayerPrefs.SetString("SubQuest_" + i.ToString() + "_QuestName", _HaveSubQuest[i]._QuestName);
            PlayerPrefs.SetString("SubQuest_" + i.ToString() + "_Target", _HaveSubQuest[i]._Target);
            PlayerPrefs.SetString("SubQuest_" + i.ToString() + "_TargetName", _HaveSubQuest[i]._TargetName);
            PlayerPrefs.SetInt("SubQuest_"+i.ToString()+"_Type", _HaveSubQuest[i]._QuestType);
            PlayerPrefs.SetInt("SubQuest_" + i.ToString() + "_GoalValue", _HaveSubQuest[i]._GoalValue);
            PlayerPrefs.SetInt("SubQuest_" + i.ToString() + "_NowValue", _HaveSubQuest[i]._NowValue);
        }
    }
}
