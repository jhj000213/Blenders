using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreativeCircle : MonoBehaviour
{
    public bool _NowCreativing = false;
    public bool _NowSelecting = false;

    public string _LowGray;
    public string _HighGray;

    public GameObject _ShakeEffect;

    int[] _ElementOriginNum = { 2, 3, 5, 7 };//불 물 흙 공기

    public List<GameObject> _TempObject = new List<GameObject>();

    public GameObject[] _EleSelectButton;

    public GameObject _ShakeBoard;
    public GameObject[] _SkillTempIcon;

    public int _SkillQuantity = 0;
    public GameObject _Ball;
    public GameObject _SkillIcon;
    public GameObject _SkillGrid;
    public List<GameObject> _BallList = new List<GameObject>();
    public List<int> _ElementList = new List<int>();
    public GameObject[] _SkillIconArr = { null, null, null, null, null, null, null };

    public GameObject _Table_90;
    public GameObject _Table_60;

    public UISprite _LowSkillCoolTime;
    public GameObject _LowSkillGray;
    public UISprite _HighSkillCoolTime;
    public GameObject _HighSkillGray;


    public GameObject _AlarmParent;
    public GameObject _DoneAddBallLabel;
    public GameObject _EnoughEleBallLabel;
    public GameObject _FullSkillListLabel;

    float _FireSkillCoolTime_Low;
    float _FireSkillCoolTime_High;
    float _FireSkillCoolTime_Low_Max;
    float _FireSkillCoolTime_High_Max;

    float _WaterSkillCoolTime_Low;
    float _WaterSkillCoolTime_High;
    float _WaterSkillCoolTime_Low_Max;
    float _WaterSkillCoolTime_High_Max;

    float _AirSkillCoolTime_Low;
    float _AirSkillCoolTime_High;
    float _AirSkillCoolTime_Low_Max;
    float _AirSkillCoolTime_High_Max;

    float _GroundSkillCoolTime_Low;
    float _GroundSkillCoolTime_High;
    float _GroundSkillCoolTime_Low_Max;
    float _GroundSkillCoolTime_High_Max;

    float _FogSkillCoolTime_Low;
    float _FogSkillCoolTime_High;
    float _FogSkillCoolTime_Low_Max;
    float _FogSkillCoolTime_High_Max;

    float _MudSkillCoolTime_Low;
    float _MudSkillCoolTime_High;
    float _MudSkillCoolTime_Low_Max;
    float _MudSkillCoolTime_High_Max;

    float _SandSkillCoolTime_Low;
    float _SandSkillCoolTime_High;
    float _SandSkillCoolTime_Low_Max;
    float _SandSkillCoolTime_High_Max;

    float _FlameSkillCoolTime_Low;
    float _FlameSkillCoolTime_High;
    float _FlameSkillCoolTime_Low_Max;
    float _FlameSkillCoolTime_High_Max;

    float _IceSkillCoolTime_Low;
    float _IceSkillCoolTime_High;
    float _IceSkillCoolTime_Low_Max;
    float _IceSkillCoolTime_High_Max;

    float _RockSkillCoolTime_Low;
    float _RockSkillCoolTime_High;
    float _RockSkillCoolTime_Low_Max;
    float _RockSkillCoolTime_High_Max;

    float[] _AddAngle = { 0.0f, 180.0f, 120.0f, 90.0f };
    public float _rotationSpeed;

    string[] _ClassName = { "warrior", "mage", "shaman" };

    void Start()
    {
        _LowGray = "";
        _HighGray = "";
        //_FireSkillCoolTime_High_Max = 8.0f;
        //_FireSkillCoolTime_Low_Max = 2.0f;
        //_WaterSkillCoolTime_Low_Max = 3.0f;
        //_WaterSkillCoolTime_High_Max = 9.0f;
        //_AirSkillCoolTime_Low_Max = 1.5f;
        //_AirSkillCoolTime_High_Max = 4.0f;
        //_GroundSkillCoolTime_Low_Max = 4.0f;
        //_GroundSkillCoolTime_High_Max = 5.0f;


        _FireSkillCoolTime_Low_Max = StaticDataMng._FireSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_4 - 1];
        _FireSkillCoolTime_High_Max = StaticDataMng._FireSkill_High_CoolTime[StaticDataMng._SkillLevel_High_4 - 1];
        _WaterSkillCoolTime_Low_Max = StaticDataMng._WaterSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_9 - 1];
        _WaterSkillCoolTime_High_Max = StaticDataMng._WaterSkill_High_CoolTime[StaticDataMng._SkillLevel_High_9 - 1];
        _AirSkillCoolTime_Low_Max = StaticDataMng._AirSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_49 - 1];
        _AirSkillCoolTime_High_Max = StaticDataMng._AirSkill_High_CoolTime[StaticDataMng._SkillLevel_High_49 - 1];
        _GroundSkillCoolTime_Low_Max = StaticDataMng._GroundSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_25 - 1];
        _GroundSkillCoolTime_High_Max = StaticDataMng._GroundSkill_High_CoolTime[StaticDataMng._SkillLevel_High_25 - 1];
        _FogSkillCoolTime_Low_Max = StaticDataMng._FogSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_6 - 1];
        _FogSkillCoolTime_High_Max = StaticDataMng._FogSkill_High_CoolTime[StaticDataMng._SkillLevel_High_6 - 1];
        _MudSkillCoolTime_Low_Max = StaticDataMng._MudSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_15 - 1];
        _MudSkillCoolTime_High_Max = StaticDataMng._MudSkill_High_CoolTime[StaticDataMng._SkillLevel_High_15 - 1];
        _SandSkillCoolTime_Low_Max = StaticDataMng._SandSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_35 - 1];
        _SandSkillCoolTime_High_Max = StaticDataMng._SandSkill_High_CoolTime[StaticDataMng._SkillLevel_High_35 - 1];
        _FlameSkillCoolTime_Low_Max = StaticDataMng._FlameSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_14 - 1];
        _FlameSkillCoolTime_High_Max = StaticDataMng._FlameSkill_High_CoolTime[StaticDataMng._SkillLevel_High_14 - 1];
        _IceSkillCoolTime_Low_Max = StaticDataMng._IceSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_21 - 1];
        _IceSkillCoolTime_High_Max = StaticDataMng._IceSkill_High_CoolTime[StaticDataMng._SkillLevel_High_21 - 1];
        _RockSkillCoolTime_Low_Max = StaticDataMng._RockSkill_Low_CoolTime[StaticDataMng._SkillLevel_Low_10 - 1];
        _RockSkillCoolTime_High_Max = StaticDataMng._RockSkill_High_CoolTime[StaticDataMng._SkillLevel_High_10 - 1];
    }

    void CoolTimeMng()
    {
        _FireSkillCoolTime_Low -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _FireSkillCoolTime_High -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _WaterSkillCoolTime_Low -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _WaterSkillCoolTime_High -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _AirSkillCoolTime_Low -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _AirSkillCoolTime_High -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _GroundSkillCoolTime_Low -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _GroundSkillCoolTime_High -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _FogSkillCoolTime_Low -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _FogSkillCoolTime_High -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _MudSkillCoolTime_Low -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _MudSkillCoolTime_High -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _SandSkillCoolTime_Low -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _SandSkillCoolTime_High -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _FlameSkillCoolTime_Low -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _FlameSkillCoolTime_High -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _IceSkillCoolTime_Low -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _IceSkillCoolTime_High -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _RockSkillCoolTime_Low -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;
        _RockSkillCoolTime_High -= Time.smoothDeltaTime * GameMng.Data._SkillCoolTimeMultyple;

        if(_NowSelecting)
        {
            if(_SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber==4)//fire
            {
                _LowSkillCoolTime.fillAmount = _FireSkillCoolTime_Low / _FireSkillCoolTime_Low_Max;
                _HighSkillCoolTime.fillAmount = _FireSkillCoolTime_High / _FireSkillCoolTime_High_Max;
            }
            else if (_SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber == 9)//water
            {
                _LowSkillCoolTime.fillAmount = _WaterSkillCoolTime_Low / _WaterSkillCoolTime_Low_Max;
                _HighSkillCoolTime.fillAmount = _WaterSkillCoolTime_High / _WaterSkillCoolTime_High_Max;
            }
            else if (_SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber == 25)//ground
            {
                _LowSkillCoolTime.fillAmount = _GroundSkillCoolTime_Low / _GroundSkillCoolTime_Low_Max;
                _HighSkillCoolTime.fillAmount = _GroundSkillCoolTime_High / _GroundSkillCoolTime_High_Max;
            }
            else if (_SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber == 49)//air
            {
                _LowSkillCoolTime.fillAmount = _AirSkillCoolTime_Low / _AirSkillCoolTime_Low_Max;
                _HighSkillCoolTime.fillAmount = _AirSkillCoolTime_High / _AirSkillCoolTime_High_Max;
            }
            else if (_SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber == 6)//fog
            {
                _LowSkillCoolTime.fillAmount = _FogSkillCoolTime_Low / _FogSkillCoolTime_Low_Max;
                _HighSkillCoolTime.fillAmount = _FogSkillCoolTime_High / _FogSkillCoolTime_High_Max;
            }
            else if (_SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber == 15)//mud
            {
                _LowSkillCoolTime.fillAmount = _MudSkillCoolTime_Low / _MudSkillCoolTime_Low_Max;
                _HighSkillCoolTime.fillAmount = _MudSkillCoolTime_High / _MudSkillCoolTime_High_Max;
            }
            else if (_SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber == 35)//sand
            {
                _LowSkillCoolTime.fillAmount = _SandSkillCoolTime_Low / _SandSkillCoolTime_Low_Max;
                _HighSkillCoolTime.fillAmount = _SandSkillCoolTime_High / _SandSkillCoolTime_High_Max;
            }
            else if (_SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber == 14)//flame
            {
                _LowSkillCoolTime.fillAmount = _FlameSkillCoolTime_Low / _FlameSkillCoolTime_Low_Max;
                _HighSkillCoolTime.fillAmount = _FlameSkillCoolTime_High / _FlameSkillCoolTime_High_Max;
            }
            else if (_SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber == 21)//ice
            {
                _LowSkillCoolTime.fillAmount = _IceSkillCoolTime_Low / _IceSkillCoolTime_Low_Max;
                _HighSkillCoolTime.fillAmount = _IceSkillCoolTime_High / _IceSkillCoolTime_High_Max;
            }
            else if (_SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber == 10)//rock
            {
                _LowSkillCoolTime.fillAmount = _RockSkillCoolTime_Low / _RockSkillCoolTime_Low_Max;
                _HighSkillCoolTime.fillAmount = _RockSkillCoolTime_High / _RockSkillCoolTime_High_Max;
            }

            if (_LowSkillCoolTime.fillAmount <= 0.0f)
                _LowSkillGray.SetActive(false);
            else
                _LowSkillGray.SetActive(true);

            if (_HighSkillCoolTime.fillAmount <= 0.0f)
                _HighSkillGray.SetActive(false);
            else
                _HighSkillGray.SetActive(true);
        }
    }

    public void SetCircleClaer()
    {
        _NowSelecting = false;
        RefreshObj();
        _ElementList.Clear();
        for (int i = 0; i < _BallList.Count;i++ )
        {
            Destroy(_BallList[i]);
        }
        _BallList.Clear();
            for (int i = 0; i < 7; i++)
            {
                if (_SkillIconArr[i] != null)
                {
                    Debug.Log("DestroySkillicon");
                    Destroy(_SkillIconArr[i]);
                }
                _SkillIconArr[i] = null;
            }
            _SkillQuantity = 0;
    }

    void Update()
    {
        CoolTimeMng();
        SkillArrSort();

        for (int i = 0; i < _BallList.Count; i++)
        {
            _BallList[i].transform.localEulerAngles += new Vector3(0, 0, _rotationSpeed * Time.smoothDeltaTime);
            if (_ElementList[i] == 0)
                _BallList[i].transform.Find("BallImage").GetComponent<UISprite>().spriteName = "fireball";
            else if (_ElementList[i] == 1)
                _BallList[i].transform.Find("BallImage").GetComponent<UISprite>().spriteName = "waterball";
            else if (_ElementList[i] == 2)
                _BallList[i].transform.Find("BallImage").GetComponent<UISprite>().spriteName = "groundball";
            else if (_ElementList[i] == 3)
                _BallList[i].transform.Find("BallImage").GetComponent<UISprite>().spriteName = "airball";
        }
    }

    public void AddBall(int num)
    {
            if (_BallList.Count < 4)
            {
                GameObject ball = NGUITools.AddChild(GameMng.Data._GameDate._EleBallBoard, _Ball);
                //ball.name = _ElementList.Count.ToString();
                _BallList.Add(ball);
                _ElementList.Add(num);
                //Debug.Log("AddBall");
                RotateBallNormalization();
            
        }
        

    }

    void RotateBallNormalization()
    {
        for (int i = 0; i < _BallList.Count; i++)
        {
            _BallList[i].transform.localEulerAngles = new Vector3(0, 0, _AddAngle[_BallList.Count - 1] * i);
            //Debug.Log("SetAngle");
        }
    }

    public void Shake()//쓲으라
    {
        
        
        if (_BallList.Count > 1 && _SkillQuantity < 7 &&_NowCreativing==false)
        {

            if (_BallList.Count == 2)
            {
                //if (_ElementList[0] == _ElementList[1])
                //{
                    GameObject obj = NGUITools.AddChild(GameMng.Data._UIRoot, _ShakeEffect);
                    obj.transform.localPosition = new Vector3(0, -224, 0);
                    _NowCreativing = true;
                    CreateSkill();
                //}
                //else
                //{
                //    Debug.Log("elfsdf");
                //    GameObject obj = NGUITools.AddChild(_AlarmParent, _DoneAddBallLabel);
                //    obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                //    obj.transform.localPosition = new Vector3(0, -135, 0);
                //}
            }
            else if(_BallList.Count==3)
            {
                //if ((_ElementList[0] == _ElementList[1] ||
                //_ElementList[0] == _ElementList[2] ||
                //_ElementList[1] == _ElementList[2]))
                //{
                    GameObject obj = NGUITools.AddChild(GameMng.Data._UIRoot, _ShakeEffect);
                    obj.transform.localPosition = new Vector3(0, -224, 0);
                    _NowCreativing = true;
                    CreateSkill();
                //}
                //else
                //{
                //    GameObject obj = NGUITools.AddChild(_AlarmParent, _DoneAddBallLabel);
                //    obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                //    obj.transform.localPosition = new Vector3(0, -135, 0);
                //}
            }
            else
            {
                GameObject obj = NGUITools.AddChild(GameMng.Data._UIRoot, _ShakeEffect);
                obj.transform.localPosition = new Vector3(0, -224, 0);
                _NowCreativing = true;
                CreateSkill();
            }
            
        }
        else if(_BallList.Count==1)
        {
            GameObject obj = NGUITools.AddChild(_AlarmParent, _EnoughEleBallLabel);
            obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            obj.transform.localPosition = new Vector3(0, -135, 0);
        }
        else if(_SkillQuantity==7)
        {
            GameObject obj = NGUITools.AddChild(_AlarmParent, _FullSkillListLabel);
            obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            obj.transform.localPosition = new Vector3(0, -135, 0);
        }
    }

    void SkillArrSort()
    {
        for (int i = 6; i >0; i--)
        {
            if (_SkillIconArr[i] == null)
            {
                _SkillIconArr[i] = _SkillIconArr[i - 1];
                _SkillIconArr[i - 1] = null;
                if (_SkillIconArr[i] != null)
                {
                    _SkillIconArr[i].GetComponent<SkillButton>().MoveRightBlock();
                }

            }
        }
    }

    void CreateSkill()
    {
        for (int i = 0; i < _BallList.Count; i++)
            _BallList[i].SetActive(false);
        List<int> eleArr = new List<int>(); 
        List<int> eleball = new List<int>();
        for (int i = 0; i < _ElementList.Count; i++)
        {
            eleArr.Add(_ElementOriginNum[_ElementList[i]]);
        }
        //Debug.Log(eleArr.Count);
        //if (eleArr.Count == 4 && eleArr[0] == 2 && eleArr[1] == 3 && eleArr[2] == 5 && eleArr[3] == 7)
        //{
        //    _NowCreativing = false;//temp
        //    _BallList.Clear();//temp

        //    //210
        //    //CreateSkill_Class_High(210);
        //}
        //else
        {
            for (int i = 0; i < eleArr.Count; i++)
            {
                for (int j = i + 1; j < eleArr.Count; j++)
                {
                    if (eleArr[i] * eleArr[j] != 0)
                    {

                        bool same = false;
                        for (int e = 0; e < eleball.Count; e++)
                        {
                            if (eleball[e] == eleArr[i] * eleArr[j])
                                same = true;
                        }
                        if (!same)
                            eleball.Add(eleArr[i] * eleArr[j]);
                    }
                }
            }
        }

        //나머지 원속성 3개
        //갯수마다 다른 속성 배출

        CreateSkill_SelectElemental(eleball);

        //갯수를 재서 틀을 제시하고 선택된 속성을 받아와서 순서대로 배열함.->CreateSkill_SelectElemental()

    }

    void CreateSkill_SelectElemental(List<int> arr)
    {
        if(arr.Count==1)
        {
            _EleSelectButton[0].GetComponent<ElementleBallClick>().SetElementSelectTable(arr[0]);

            //gold
        }
        else
        {
            if(arr[arr.Count-1]==4||arr[arr.Count-1]==9||arr[arr.Count-1]==25||arr[arr.Count-1]==49)
            {
                if (arr[0] != 4 && arr[0] != 9 && arr[0] != 25 && arr[0] != 49)
                {
                    int num = arr[0];
                    arr[0] = arr[arr.Count - 1];
                    arr[arr.Count - 1] = num;
                }
            }
            string ballname = "fireball";

            for (int i = 0; i < arr.Count; i++)
            {
                if (i == 3)
                    break;
                //Debug.Log(arr[i]);
                if (arr[i] == 4)
                    ballname = "fireball";
                else if (arr[i] == 9)
                    ballname = "waterball";
                else if (arr[i] == 25)
                    ballname = "groundball";
                else if (arr[i] == 49)
                    ballname = "airball";
                else if (arr[i] == 6)
                    ballname = "fogball";
                else if (arr[i] == 15)
                    ballname = "mudball";
                else if (arr[i] == 35)
                    ballname = "sandball";
                else if (arr[i] == 14)
                    ballname = "flameball";
                else if (arr[i] == 21)
                    ballname = "iceball";
                else if (arr[i] == 10)
                    ballname = "rockball";

                

                // GameObject ball = NGUITools.AddChild(_ShakeBoard, _EleSelectButton[i]);
                _EleSelectButton[i].GetComponent<ElementleBallClick>()._SelectNumber = arr[i];
                _EleSelectButton[i].GetComponent<UISprite>().spriteName = ballname;
                _EleSelectButton[i].GetComponent<Animator>().SetTrigger("move_" + arr.Count.ToString());
                if (arr.Count == 4)
                    _EleSelectButton[i].GetComponent<Animator>().SetTrigger("move_3");
                if(true)//arr[i]==4||arr[i]==9||arr[i]==25||arr[i]==49
                {
                    _EleSelectButton[i].transform.GetChild(0).gameObject.SetActive(false);
                    _EleSelectButton[i].transform.GetChild(0).GetComponent<UISprite>().spriteName = ballname;
                }
                else
                {
                    //_EleSelectButton[i].transform.GetChild(0).gameObject.SetActive(true);
                }
                //_EleSelectButton[i].transform.localPosition = new Vector3(posx[i], posy[i], 0);
            }
        }
        


        //구슬에서 터치받아서 이 함수로 무슨 속성을 선택했는지 배출
        //float 형 쿨타임 변수를 생성해서 쿨타임별로 알파값 마스크 생성
        //쿨타임이 아니면 클릭 시 CreateSkill_Class() 함수 호출함
        
    }

    void DeleteBall(int num)
    {
        for (int i = 0; i < _ElementList.Count; i++)
        {
            if (_ElementList[i] == num)
            {
                _ElementList.Remove(_ElementList[i]);
                Destroy(_BallList[i]);
                _BallList.Remove(_BallList[i]);
                break;
            }
        }
    }

    public void CreateSkill_Select_Class(int elenum)
    {
        _NowSelecting = true;
        
        if(elenum == 4)
        {
            DeleteBall(0);
            DeleteBall(0);
        }if(elenum == 9)
        {
            DeleteBall(1);
            DeleteBall(1);
        }if (elenum == 25)
        {
            DeleteBall(2);
            DeleteBall(2);
        } if (elenum == 49)
        {
            DeleteBall(3);
            DeleteBall(3);
        }if (elenum == 6)
        {
            DeleteBall(0);
            DeleteBall(1);
        }if (elenum == 15)
        {
            DeleteBall(1);
            DeleteBall(2);
        } if (elenum == 35)
        {
            DeleteBall(2);
            DeleteBall(3);
        }if (elenum == 14)
        {
            DeleteBall(0);
            DeleteBall(3);
        }if (elenum == 21)
        {
            DeleteBall(1);
            DeleteBall(3);
        }if (elenum == 10)
        {
            DeleteBall(0);
            DeleteBall(2);
        }
        for (int i = 0; i < 3;i++ )
            _EleSelectButton[i].SetActive(false);

        for (int i = 0; i < 2; i++)
            _SkillTempIcon[i].SetActive(true);
        //GameObject obj = NGUITools.AddChild(_ShakeBoard, _Table_90);
        //obj.transform.FindChild("60").GetComponent<UISprite>().depth = 6;
        //obj.transform.FindChild("Circle").GetComponent<UISprite>().depth = 6;
        //obj.transform.localPosition = GameMng.Data._CreativeTable.transform.localPosition;
        //_TempObject.Add(obj);

        //GameObject skill_1 = NGUITools.AddChild(_ShakeBoard, _SkillTempIcon);
        //_SkillTempIcon[0].transform.localPosition = new Vector2(-60, 0);
        _SkillTempIcon[0].GetComponent<Animator>().SetTrigger("move_2");
        _SkillTempIcon[0].GetComponent<ElementleBallClick>()._SelectNumber = elenum;
        _SkillTempIcon[0].GetComponent<UISprite>().spriteName = "skillicon_" + _ClassName[GameMng.Data._GameDate._HeroUnit._Type-1] + "_" + elenum.ToString() + "_low" + _LowGray;
        //GameObject skill_2 = NGUITools.AddChild(_ShakeBoard, _SkillTempIcon);
        //_SkillTempIcon[1].transform.localPosition = new Vector2(60, 0);
        _SkillTempIcon[1].GetComponent<Animator>().SetTrigger("move_2");
        _SkillTempIcon[1].GetComponent<ElementleBallClick>()._SelectNumber = elenum;
        _SkillTempIcon[1].GetComponent<UISprite>().spriteName = "skillicon_" + _ClassName[GameMng.Data._GameDate._HeroUnit._Type-1] + "_" + elenum.ToString() + "_high" + _HighGray;
    }
    public void CreateSkill_Class_Low(int num)
    {
        //현재 Create_Skill 함수 안의 생성 if문 여기로 복사, 이곳에서 스킬분류
        RefreshObj();
        if (num==4)//Fire
        {
            _FireSkillCoolTime_Low = _FireSkillCoolTime_Low_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "low");
        }
        if (num==9)//Water
        {
            _WaterSkillCoolTime_Low = _WaterSkillCoolTime_Low_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "low");
        }
        if (num==25)//Ground
        {
            _GroundSkillCoolTime_Low = _GroundSkillCoolTime_Low_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "low");
        }
        if (num == 21)//Ice
        {
            _IceSkillCoolTime_Low = _IceSkillCoolTime_Low_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 3, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "low");
        }
        if (num == 10)//Rock
        {
            _RockSkillCoolTime_Low = _RockSkillCoolTime_Low_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "low");
        }
        if (num == 49)//Air
        {
            _AirSkillCoolTime_Low = _AirSkillCoolTime_Low_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "low");
        }
        if (num == 14)//Frame
        {
            _FlameSkillCoolTime_Low = _FlameSkillCoolTime_Low_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "low");
        }
        if (num == 6)//Fog
        {
            _FogSkillCoolTime_Low = _FogSkillCoolTime_Low_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 3, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "low");
        }
        if (num == 15)//Mud
        {
            _MudSkillCoolTime_Low = _MudSkillCoolTime_Low_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "low");
        }
        if (num == 35)//Sand
        {
            _SandSkillCoolTime_Low = _SandSkillCoolTime_Low_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 3, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "low");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "low");
        }
    }

    public void CreateSkill_Class_High(int num)
    {
        RefreshObj();
        //현재 Create_Skill 함수 안의 생성 if문 여기로 복사, 이곳에서 스킬분류
        if (num == 4)//Fire
        {
            _FireSkillCoolTime_High = _FireSkillCoolTime_High_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 2, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "high");
        }
        if (num == 9)//Water
        {
            _WaterSkillCoolTime_High = _WaterSkillCoolTime_High_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "high");
        }
        if (num == 25)//Ground
        {
            _GroundSkillCoolTime_High = _GroundSkillCoolTime_High_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "high");
        }
        if (num == 21)//Ice
        {
            _IceSkillCoolTime_High = _IceSkillCoolTime_High_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "high");
        }
        if (num == 15)//Mud
        {
            _MudSkillCoolTime_High = _MudSkillCoolTime_High_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "high");
        }
        if (num == 49)//Air
        {
            _AirSkillCoolTime_High = _AirSkillCoolTime_High_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "high");
        }
        if (num == 14)//Flame
        {
            _FlameSkillCoolTime_High = _FlameSkillCoolTime_High_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "high");
        }
        if (num == 6)//Fog
        {
            _FogSkillCoolTime_High = _FogSkillCoolTime_High_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "high");
        }
        if (num == 35)//Sand
        {
            _SandSkillCoolTime_High = _SandSkillCoolTime_High_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "high");
        }
        if (num == 10)//Rock
        {
            _RockSkillCoolTime_High = _RockSkillCoolTime_High_Max;
            if (GameMng.Data._GameDate._HeroUnit._Type == 1)
                CreateSkill_Child("warrior", 4, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 2)
                CreateSkill_Child("mage", 1, num, "high");
            if (GameMng.Data._GameDate._HeroUnit._Type == 3)
                CreateSkill_Child("shaman", 1, num, "high");
        }
    }

    void RefreshObj()
    {
        _NowCreativing = false;
        for(int i=0;i<3;i++)
        {
            _EleSelectButton[i].transform.localPosition = new Vector3(1000, 1000,0);
        }
        for(int i=0;i<2;i++)
        {
            _SkillTempIcon[i].transform.localPosition = new Vector3(1000, 1000, 0);
        }
        for(int i=0;i<_TempObject.Count;i++)
        {
            Destroy(_TempObject[i]);
        }
        _TempObject.Clear();
        for (int i = 0; i < _BallList.Count; i++)
            _BallList[i].SetActive(true);
        for (int i = 0; i < 3; i++)
            _EleSelectButton[i].SetActive(true);
        for (int i = 0; i < 2; i++)
            _SkillTempIcon[i].SetActive(false);
        GameObject obj = NGUITools.AddChild(GameMng.Data._UIRoot, _ShakeEffect);
        obj.transform.localPosition = new Vector3(0, -224, 0);
    }

    void CreateSkill_Child(string heroclass, int shoottype, int elemental, string highlow)
    {
        GameObject obj = NGUITools.AddChild(_SkillGrid, _SkillIcon);
        obj.transform.localPosition = new Vector2(0, 0);
        obj.GetComponent<SkillButton>()._Init(heroclass, shoottype, elemental, highlow);
        _SkillIconArr[0] = obj;
        _SkillQuantity++;
        RotateBallNormalization();
        _NowCreativing = false;
        _NowSelecting = false;
    }
}

