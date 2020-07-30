using UnityEngine;
using System.Collections;

public class MonsterWaveMng : MonoBehaviour {

    public bool _WaveOn;

    public UnitGenerator _UnitGenerator;

    public float _NowWaveTime;
    public float _WaveDelayTime;
    public int _MaxWave;
    public int _NowWave;

    public bool _BossOn;
    public bool _BossHPOn;
    public bool _BossHPAniOn;
    public Unit _BossMosnter;

    public GameObject _BossHPBar;
    public UI2DSprite _BossHPGaze;
    public UISprite _BossIcon;

    public GameObject _ClearingBar;
    public GameObject _WavePoint;

    public UILabel _NowWaveLabel;
    public UILabel _MaxWaveLabel;

    public void Init(int maxwave, float wavedelaytime)
    {
        _MaxWave = maxwave;
        _WaveDelayTime = wavedelaytime;
        for(int i=1;i<_MaxWave+1;i++)
        {
            GameObject obj = NGUITools.AddChild(_ClearingBar, _WavePoint);
            obj.transform.localPosition = new Vector3((500/_MaxWave+1)*i,0,0);
        }
    }

    void Update()
    {
        if (_NowWave >= _MaxWave)
            _NowWaveLabel.text = _MaxWave.ToString();
        else
            _NowWaveLabel.text = _NowWave.ToString();
        _MaxWaveLabel.text = _MaxWave.ToString();
        if(_WaveOn)
        {
            if (_BossHPOn)
            {
                _BossHPBar.SetActive(true);
                _ClearingBar.SetActive(false);
                
                if (_BossHPAniOn)
                    BossHPUpAni();
                else
                    BossHPUpdater();
            }
            

            if (GameMng.Data._GameDate._EnemyUnitList.Count == 0)
            {
                _NowWaveTime += Time.smoothDeltaTime;
                if (_NowWaveTime <_WaveDelayTime)
                    GameMng.Data._ProgressingGaze += Time.smoothDeltaTime;

                
                if (_WaveDelayTime <= _NowWaveTime)
                    MakeWave();
            }
        }
    }

    void BossHPUpdater()
    {
        if (_BossMosnter != null)
        {
            _BossIcon.spriteName = "bossicon_" + _BossMosnter._ObjName;
            _BossHPGaze.fillAmount = (float)_BossMosnter._HP / (float)_BossMosnter._MaxHP;
        }
        else
            _BossHPBar.SetActive(false);
    }

    public void MakeWave()
    {
        _NowWaveTime = 0.0f;
        _NowWave++;
        if (_NowWave == _MaxWave)
            MakeBossWabe();
        else
        {

            if (_NowWave <= _MaxWave)
            {
                if (StaticDataMng._StoryWaveOn)
                {
                    if (GameMng.Data._StageName == "Stage_Tutorial")
                    {
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 50,3, 400.0f);
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 377), 50,3, 400.0f);
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 243), 50,3, 400.0f);
                        _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 50,3, 400.0f);
                    }
                    if (GameMng.Data._StageName == "민가")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1400, 510), 60,12, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 377), 60, 12, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 243), 60, 12, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1400, 110), 60, 12, 400.0f);
                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1400, 510), 60, 12, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 377), 60, 12, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 243), 60, 12, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1400, 110), 60, 12, 400.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 120,17, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 410), 120,17, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 120,17, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 210), 120,17, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 120,17, 350.0f);
                        }
                    }
                    if (GameMng.Data._StageName == "설산")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1400, 510), 70,20, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1350, 410), 70,20, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 310), 70,20, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1350, 210), 70,20, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1400, 110), 70,20, 400.0f);
                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 130,22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 410), 70, 20, 400.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 310), 130, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 210), 70, 20, 400.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 130, 22, 350.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 510), 70, 20, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 377), 70, 20, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 243), 70, 20, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 110), 70, 20, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 410), 130, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 210), 130, 22, 350.0f);
                        }
                    }
                    if (GameMng.Data._StageName == "선스피어")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 150,22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 150, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 150, 22, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 140,24, 300.0f);
                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 410), 150, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 210), 150, 22, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 410), 140, 24, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 210), 140, 24, 300.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 150, 22, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 140, 24, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 140, 24, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 140, 24, 300.0f);
                        }
                        if (_NowWave == 4)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 150, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 377), 150, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 243), 150, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 150, 22, 350.0f);
                        }
                    }
                    if (GameMng.Data._StageName == "불타는 숲")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 200,55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1350, 410), 200,55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 200,55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1350, 210), 200,55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 200,55, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 410), 280,80, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 210), 280, 80, 350.0f);

                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 200, 55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 200, 55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 200, 55, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 280, 80, 350.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1400, 310), 400,90, 350.0f);//중급
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 280, 80, 350.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 410), 200, 55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 210), 200, 55, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 410), 280, 80, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 210), 280, 80, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 410), 230,100, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 210), 230,100, 300.0f);
                        }
                        if (_NowWave == 4)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 510), 280, 80, 350.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 200, 55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 110), 280, 80, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 230, 100, 300.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1400, 310), 400,90, 400.0f);//중급
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 230, 100, 300.0f);
                        }
                    }
                    if (GameMng.Data._StageName == "아라드라")
                    {
                        if(GameMng.Data._QuestMng._HaveMainQuest.Count!=0)
                        {
                            if (GameMng.Data._QuestMng._HaveMainQuest[0]._QuestName == "안좋은 예감" && 
                                GameMng.Data._QuestMng._HaveMainQuest[0]._NowValue==3)
                            {
                                if (_NowWave == 1)
                                {
                                    _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 300,90, 350.0f);

                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 510), 550,85, 350.0f);//저주받은전사
                                    _UnitGenerator.MakeUnit(2, 3, new Vector2(1350, 310), 650,110, 350.0f);//중급전사
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 110), 550, 85, 350.0f);//저주받은전사

                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 410), 450,100, 300.0f);//저주받은궁수
                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 210), 450, 100, 300.0f);//저주받은궁수
                                }
                                if (_NowWave == 2)
                                {
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 410), 550, 85, 350.0f);//저주받은전사
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 210), 550, 85, 350.0f);//저주받은전사

                                    _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 410), 700, 110, 350.0f);//중급전사
                                    _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 210), 700, 110, 350.0f);//중급전사

                                    _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 460,100, 350.0f);
                                }
                                if (_NowWave == 3)
                                {
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 410), 550, 85, 350.0f);//저주받은전사
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 210), 550, 85, 350.0f);//저주받은전사

                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 410), 450, 100, 300.0f);//저주받은궁수
                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 210), 450, 100, 300.0f);//저주받은궁수

                                    _UnitGenerator.MakeUnit(2, 3, new Vector2(1350, 310), 650, 110, 350.0f);//중급전사

                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1350, 510), 450, 100, 300.0f);//저주받은궁수
                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1350, 110), 450, 100, 300.0f);//저주받은궁수
                                }
                                if (_NowWave == 4)
                                {
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 510), 550, 85, 350.0f);//저주받은전사
                                    _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 410), 300, 90, 350.0f);
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 310), 550, 85, 350.0f);//저주받은전사
                                    _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 210), 300, 90, 350.0f);
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 110), 550, 85, 350.0f);//저주받은전사

                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 510), 450, 100, 300.0f);//저주받은궁수
                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1300, 310), 450, 100, 300.0f);//저주받은궁수
                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 110), 450, 100, 300.0f);//저주받은궁수
                                }    
                            }
                            else
                            {
                                if (_NowWave == 3)
                                {
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 410), 550, 85, 350.0f);//저주받은전사
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 210), 550, 85, 350.0f);//저주받은전사

                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 410), 450, 100, 300.0f);//저주받은궁수
                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 210), 450, 100, 300.0f);//저주받은궁수

                                    _UnitGenerator.MakeUnit(2, 3, new Vector2(1350, 310), 700, 110, 350.0f);//중급전사

                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1350, 510), 450, 100, 300.0f);//저주받은궁수
                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1350, 110), 450, 100, 300.0f);//저주받은궁수
                                }
                                if (_NowWave == 4)
                                {
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 510), 550, 85, 350.0f);//저주받은전사
                                    _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 410), 300, 90, 350.0f);
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 310), 550, 85, 350.0f);//저주받은전사
                                    _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 210), 300, 90, 350.0f);
                                    _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 110), 550, 85, 350.0f);//저주받은전사

                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 510), 450, 100, 300.0f);//저주받은궁수
                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1300, 310), 450, 100, 300.0f);//저주받은궁수
                                    _UnitGenerator.MakeUnit(1, 7, new Vector2(1400, 110), 450, 100, 300.0f);//저주받은궁수
                                }                     
                            }
                        }
                        
                                                                               
                    }
                }
                else
                {
                    if (GameMng.Data._StageName == "민가")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 200,53, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 310), 200, 53, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 110), 200, 53, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 180,60, 300.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 252), 180, 60, 300.0f);
                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 200, 53, 350.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 310), 450,70, 350.0f);//중급전사
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 200, 53, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 180, 60, 300.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 200, 53, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 200, 53, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 200, 53, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 180, 60, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 180, 60, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 180, 60, 300.0f);
                        }
                        if (_NowWave == 4)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 200, 53, 350.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 310), 450, 70, 350.0f);//중급전사
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 200, 53, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 180, 60, 300.0f);
                        }
                    }
                    if (GameMng.Data._StageName == "선스피어")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 150,22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 150, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 150, 22, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 140,24, 300.0f);
                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 410), 150, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 210), 150, 22, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 410), 140, 24, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 210), 140, 24, 300.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 150, 22, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 140, 24, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 140, 24, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 140, 24, 300.0f);
                        }
                        if (_NowWave == 4)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 150, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 377), 150, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 243), 150, 22, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 150, 22, 350.0f);
                        }
                    }
                    if (GameMng.Data._StageName == "서쪽 태양들판")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 410), 100,22, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 210), 100, 22, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 410), 180,24, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 210), 180, 24, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 160,26, 300.0f);
                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 100, 22, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 100, 22, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 100, 22, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 180, 24, 350.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1350, 310), 350,28, 350.0f);//중급전사
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 180, 24, 350.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 180, 24, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 180, 24, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 180, 24, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 410), 160, 26, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 210), 160, 26, 300.0f);
                        }
                        if (_NowWave == 4)
                        {
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 160, 26, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 160, 26, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 160, 26, 300.0f);

                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 310), 400, 28, 350.0f);//중급전사
                        }
                    }
                    if (GameMng.Data._StageName == "동쪽 태양들판")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 180, 35, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 180, 35, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 180, 35, 400.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 410), 220, 65, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 210), 220, 65, 300.0f);
                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 280, 60, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 410), 280, 60, 350.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 310), 550, 75, 400.0f);//중급전사
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 210), 280, 60, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 280, 60, 350.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1340, 510), 280, 60, 350.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 180, 35, 400.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1340, 110), 280, 60, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 410), 220, 65, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 210), 220, 65, 300.0f);
                        }
                        if (_NowWave == 4)
                        {
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 220, 65, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 220, 65, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 220, 65, 300.0f);

                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 310), 650, 75, 350.0f);//중급전사
                        }
                    }
                    if (GameMng.Data._StageName == "불타는 숲")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 230, 55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1350, 410), 230, 55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 230, 55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1350, 210), 230, 55, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 230, 55, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 410), 320,80, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 210), 320, 80, 350.0f);
                           
                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 230, 80, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 230, 80, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 230, 80, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 320, 80, 350.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1400, 310), 600,90, 350.0f);//중급
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 320, 80, 350.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 410), 230, 80, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 210), 230, 80, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 410), 320, 80, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 210), 320, 80, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 410), 270,100, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 210), 270, 100, 300.0f);
                        }
                        if (_NowWave == 4)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 510), 320, 80, 350.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 230, 80, 400.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 110), 320, 80, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 270, 100, 300.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1400, 310), 400, 90, 400.0f);//중급
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 270, 100, 300.0f);
                        }
                    }
                    if (GameMng.Data._StageName == "아라드라")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 510), 230,50, 400.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 410), 300,90, 350.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 310), 230, 50, 400.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 210), 300, 90, 350.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 110), 230, 50, 400.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 460,100, 300.0f);

                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 210,60, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 310), 230, 50, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 210, 60, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 300, 90, 350.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1400, 310), 500,110, 350.0f);//중급
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 300, 90, 350.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 410), 210, 60, 400.0f);
                            _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 210), 210, 60, 400.0f);

                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1350, 310), 500, 110, 400.0f);//중급전사

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 410), 460, 100, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 210), 460, 100, 300.0f);
                        }
                        if (_NowWave == 4)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 300, 90, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 410), 300, 90, 350.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 310), 500, 110, 400.0f);//중급전사
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 210), 300, 90, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 300, 90, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 460, 100, 300.0f);
                        }
                    }
                    if (GameMng.Data._StageName == "설산")
                    {
                        if (_NowWave == 1)
                        {
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 510), 250,70, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 310), 250, 70, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 110), 250, 70, 400.0f);

                            _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 510), 450,105, 350.0f);//저주받은전사
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 310), 400,110, 350.0f);
                            _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 110), 450, 105, 350.0f);//저주받은전사

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 350,120, 300.0f);
                        }
                        if (_NowWave == 2)
                        {
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 510), 250, 70, 400.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 400, 110, 350.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 110), 250, 70, 400.0f);

                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 310), 400, 110, 350.0f);

                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1350, 310), 600,120, 350.0f);//중급전사

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 410), 350, 120, 300.0f);
                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 210), 350, 120, 300.0f);
                        }
                        if (_NowWave == 3)
                        {
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 510), 250, 70, 400.0f);
                            _UnitGenerator.MakeUnit(1, 3, new Vector2(1300, 110), 250, 70, 400.0f);

                            _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 510), 450, 105, 350.0f);//저주받은전사
                            _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 310), 450, 105, 350.0f);//저주받은전사
                            _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 110), 450, 105, 350.0f);//저주받은전사

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 350, 120, 300.0f);
                        }
                        if (_NowWave == 4)
                        {
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 510), 400, 110, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 410), 400, 110, 350.0f);
                            _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 310), 800,120, 400.0f);//중급전사
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1350, 210), 400, 110, 350.0f);
                            _UnitGenerator.MakeUnit(1, 4, new Vector2(1400, 110), 400, 110, 350.0f);

                            _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 310), 350,120, 300.0f);
                        }
                    }
                }
            }

        }
    }

    void MakeBossWabe()
    {
        _BossOn = true;
        if (StaticDataMng._StoryWaveOn)
        {

            if (GameMng.Data._StageName == "아라드라" && StaticDataMng._StoryNum == 16)
            {
                _UnitGenerator.MakeUnit(1, 7, new Vector2(1350, 510), 450,100, 300.0f);//저주받은궁수
                _UnitGenerator.MakeUnit(1, 7, new Vector2(1350, 110), 450,100, 300.0f);//저주받은궁수

                _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 300,90, 350.0f);
                _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 300,90, 350.0f);

                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 410), 460,100, 300.0f);
                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 210), 460,100, 300.0f);

                _UnitGenerator.MakeUnit_Boss(1, 6, new Vector2(1350,  310), 900,120, 350.0f);//저주받은전사단장
            }
        }
        else 
        {
            if (GameMng.Data._StageName == "민가")
            {
                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 180,60, 300.0f);
                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 180,60, 300.0f);
                _UnitGenerator.MakeUnit_Boss(2, 3, new Vector2(1300, 310), 500,70, 350.0f);//중급전사
            }
            if(GameMng.Data._StageName == "선스피어")
            {
                _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 150,22, 400.0f);//디가르하급3 중급강령1(보스)
                _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 150,22, 400.0f);
                _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 150,22, 400.0f);
                _UnitGenerator.MakeUnit_StoryMainTarget(2, 4, new Vector2(1400, 310), true, 270,30, 400.0f);//중급강령술사
            }
            if (GameMng.Data._StageName == "동쪽 태양들판")
            {
                _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 250,60, 350.0f);
                _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 310), 250,60, 350.0f);
                _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 250,60, 350.0f);

                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 200,65, 300.0f);
                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 200,65, 300.0f);
                _UnitGenerator.MakeUnit_Boss(2, 4, new Vector2(1400, 310), 600,90, 300.0f);//중급강령술사
            }
                if (GameMng.Data._StageName == "서쪽 태양들판")
            {
                _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 510), 230,28, 350.0f);
                _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 110), 230,28, 350.0f);
                _UnitGenerator.MakeUnit_Boss(2, 4, new Vector2(1400, 310), 500,32, 300.0f);//
            }
            if (GameMng.Data._StageName == "불타는 숲")
            {
                _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 510), 200,55, 400.0f);
                _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 310), 200,55, 400.0f);
                _UnitGenerator.MakeUnit(1, 2, new Vector2(1300, 110), 200,55, 400.0f);

                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 230,100, 300.0f);
                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 230,100, 300.0f);
                _UnitGenerator.MakeUnit_Boss(2, 3, new Vector2(1350, 310), 750,90, 300.0f);//중급전사
            }
            if (GameMng.Data._StageName == "아라드라")
            {
                _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 510), 300,90, 350.0f);
                _UnitGenerator.MakeUnit(1, 4, new Vector2(1300, 110), 300,90, 350.0f);
                _UnitGenerator.MakeUnit(2, 3, new Vector2(1300, 310), 500,110, 350.0f);//중급전사

                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 460,100, 300.0f);
                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 460,100, 300.0f);
                _UnitGenerator.MakeUnit_Boss(2, 4, new Vector2(1350, 310), 800,130, 300.0f);//중급강령술사
            }
            if (GameMng.Data._StageName == "설산")
            {
                _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 510), 450,105, 350.0f);//저주받은전사
                _UnitGenerator.MakeUnit(1, 6, new Vector2(1300, 310), 450,105, 350.0f);//저주받은전사
                _UnitGenerator.MakeUnit(1, 6, new Vector2(1350, 110), 450,105, 350.0f);//저주받은전사

                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 510), 400,120, 300.0f);
                _UnitGenerator.MakeUnit(1, 5, new Vector2(1400, 110), 400,120, 300.0f);
                _UnitGenerator.MakeUnit_Boss(2, 4, new Vector2(1350, 310), 1000,180, 300.0f);//중급강령술사
            }
        }
    }
    void BossHPUpAni()
    {
        _BossHPGaze.fillAmount += Time.smoothDeltaTime*0.66f;
        if (_BossHPGaze.fillAmount >= 1.0f)
            _BossHPAniOn = false;
    }
}
