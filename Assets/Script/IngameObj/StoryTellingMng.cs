using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class StoryTellingMng : MonoBehaviour
{
    public StoryActionMng _ActionMng;
    public GameObject _StoryObject;
    public UILabel _StoryLabel;
    public UILabel _NameLabel;

    //
    public GameObject _Illust_Michel;
    public GameObject _Illust_Ragid;
    public GameObject _Illust_Mistic;
    public GameObject _Illust_Mistic_Heart;

    public GameObject _Illust_Michel_Color;
    public GameObject _Illust_Ragid_Color;
    public GameObject _Illust_Mistic_Color;
    public GameObject _Illust_Mistic_Heart_Color;
    //
    public string _FileNum;
    char[] txtarr;
    int _LineClearing;
    public int _CharArrClearing;//temp public
    public int _ActionClearing;//temp public
    float _delayTime;
    public List<string> LineList = new List<string>();

    public bool _skip;
    public bool _oneLineEnd;

    List<string> _CharNameList = new List<string>();

    void Start()
    {
        if (StaticDataMng._StoryOn == true)
            Calltxt("story_" + StaticDataMng._StoryNum.ToString());
    }

    public void Calltxt(string filename)
    {
        //StaticDataMng._StoryOn = false;
        _ActionMng.SetStoryStart();
        _StoryObject.SetActive(true);
        if (_ActionMng._GameScene)
        {
            GameMng.Data._MoveBg = false;
            for (int i = 0; i < GameMng.Data._GameDate._SoldierUnitList.Count; i++)
                GameMng.Data._GameDate._SoldierUnitList[i]._StoryActioning = true;
            for (int i = 0; i < GameMng.Data._GameDate._EnemyUnitList.Count; i++)
                GameMng.Data._GameDate._EnemyUnitList[i]._StoryActioning = true;
        }
            


        char[] temparr = filename.ToCharArray();
        if (temparr.Length == 7)
            _FileNum = temparr[temparr.Length - 1].ToString();
        else
        {
            _FileNum = temparr[temparr.Length - 2].ToString() + temparr[temparr.Length - 1].ToString();
        }
        _delayTime = 0.1f;
        LineList.Clear();
        _LineClearing = 0;
        _CharArrClearing = 0;
        _ActionClearing = 0;

        TextAsset story = Resources.Load<TextAsset>("Story/" + filename);
        StreamReader sr = new StreamReader(new MemoryStream(story.bytes));
        while (sr.Peek() >= 0)
            LineList.Add(sr.ReadLine());

        TextAsset story1 = Resources.Load<TextAsset>("Story/" + filename + "_name");
        StreamReader sr1 = new StreamReader(new MemoryStream(story1.bytes));
        while (sr1.Peek() >= 0)
            _CharNameList.Add(sr1.ReadLine());

        SetCharArr();
    }

    public void SetCharArr()
    {
        _NameLabel.text = _CharNameList[_LineClearing];

        _Illust_Michel_Color.SetActive(false);
        _Illust_Mistic_Color.SetActive(false);
        _Illust_Mistic_Heart_Color.SetActive(false);
        _Illust_Ragid_Color.SetActive(false);

        if (_CharNameList[_LineClearing] == "미첼")
        {
            _Illust_Michel.SetActive(true);
            _Illust_Michel_Color.SetActive(true);
        }
        if (_CharNameList[_LineClearing] == "미스틱")
        {
            _Illust_Mistic.SetActive(true);
            _Illust_Mistic_Color.SetActive(true);
        }
        if(_CharNameList[_LineClearing] == "어린 소녀")
        {
            _Illust_Mistic_Heart.SetActive(true);
            _Illust_Mistic_Heart_Color.SetActive(true);
        }
        if (_CharNameList[_LineClearing] == "라기드")
        {
            _Illust_Ragid.SetActive(true);
            _Illust_Ragid_Color.SetActive(true);
        }
        if (_CharNameList[_LineClearing] == "미첼, 라기드, 미스틱")
        {
            _Illust_Ragid.SetActive(true);
            _Illust_Ragid_Color.SetActive(true);
            _Illust_Mistic.SetActive(true);
            _Illust_Mistic_Color.SetActive(true);
            _Illust_Michel.SetActive(true);
            _Illust_Michel_Color.SetActive(true);
        }


        if(LineList.Count<=_LineClearing)
        {
            Debug.Log("clear");
            _StoryObject.SetActive(false);
        }
        else
        {
            _StoryLabel.text = "";
            _oneLineEnd = false;
            _skip = false;
            txtarr = null;
            txtarr = LineList[_LineClearing].ToCharArray();
            
            _CharArrClearing = 0;
            if (LineList[_LineClearing] == "()")
            {
                RunningNextAction();
                _LineClearing++;
            }
            else if (LineList[_LineClearing] == "//")
            {
                _LineClearing++;
                SetCharArr();
            }
            else if(LineList[_LineClearing] == "**")
            {
                _LineClearing++;
                StartCoroutine(AddChar(_delayTime, "우리의 새로운 이름은 '"+StaticDataMng._TeamName+"'다."));
            }
            else
            {
                _LineClearing++;
                if (txtarr[0] == '-')
                {

                }
                else
                    StartCoroutine(AddChar(_delayTime, txtarr[_CharArrClearing].ToString()));
            }
        }
    }

    IEnumerator AddChar(float time, string c)
    {
        yield return new WaitForSeconds(time);

        _StoryLabel.text = _StoryLabel.text + c.ToString();

        string nexttxt;
        _CharArrClearing++;
        if (txtarr.Length <= _CharArrClearing)
            _oneLineEnd = true;
        else
        {
            nexttxt = txtarr[_CharArrClearing].ToString();
            if (txtarr[_CharArrClearing] == '=')
                nexttxt = "\r\n";
            

            if (nexttxt == " " || nexttxt == "\r\n")
                _delayTime = 0.0f;
            else
                _delayTime = 0.05f;
            if (_skip)
                AddChar(nexttxt);
            else
                StartCoroutine(AddChar(_delayTime, nexttxt));
        }
    }

    void AddChar(string c)
    {
        _StoryLabel.text = _StoryLabel.text + c.ToString();

        string nexttxt;
        _CharArrClearing++;
        if (txtarr.Length <= _CharArrClearing)
            _oneLineEnd = true;
        else
        {
            nexttxt = txtarr[_CharArrClearing].ToString();
            if (txtarr[_CharArrClearing] == '=')
                nexttxt = "\r\n";
            AddChar(nexttxt);
        }
    }

    void RunningNextAction()
    {
        _Illust_Michel_Color.SetActive(false);
        _Illust_Mistic_Color.SetActive(false);
        _Illust_Mistic_Heart_Color.SetActive(false);
        _Illust_Ragid_Color.SetActive(false);
        _Illust_Michel.SetActive(false);
        _Illust_Mistic.SetActive(false);
        _Illust_Mistic_Heart.SetActive(false);
        _Illust_Ragid.SetActive(false);

        _ActionClearing++;
        _StoryObject.SetActive(false);
        if (_FileNum.Length == 1)
            _ActionMng._StoryNum = int.Parse(_FileNum);
        else
        {
            _ActionMng._StoryNum = (int.Parse(_FileNum[0].ToString())*10)+(int.Parse(_FileNum[1].ToString()));
        }
        _ActionMng._ActionClearing = _ActionClearing;
        _ActionMng.SetStoryMove(false);
        _ActionMng.StoryAction();
    }
}