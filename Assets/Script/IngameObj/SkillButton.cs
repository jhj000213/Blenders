using UnityEngine;
using System.Collections;

public class SkillButton : MonoBehaviour 
{
    HaveList have;

    string _HeroClass;
    /// <summary>
    /// 1 - Arrow
    /// 2 - Circle
    /// 3 - SecterForm
    /// 4 - NoneTarget_Hero;
    /// </summary>
    int _shootType;
    int _ElementalType;
    string _SkillLevel;
    void Awake()
    {
        have = GetComponent<HaveList>();
        GameMng.Data.n_list.Add(have);
    }

    public void _Init(string heroclass,int shoottype,int elementaltype,string highlow)
    {
        _HeroClass = heroclass;
        _shootType = shoottype;
        _ElementalType = elementaltype;
        _SkillLevel = highlow;

        GetComponent<UISprite>().spriteName = _ElementalType + "_" + _SkillLevel.ToString();
        GetComponent<UISprite>().spriteName = "skillicon_" + heroclass + "_" + _ElementalType.ToString() + "_" + highlow;
        if (_ElementalType == 4)
            transform.Find("Elemental").GetComponent<UISprite>().color = hexToColor("FF0000FF");
        else if (_ElementalType == 21)
            transform.Find("Elemental").GetComponent<UISprite>().color = hexToColor("6CE0FFFF");
        else if (_ElementalType == 10)
            transform.Find("Elemental").GetComponent<UISprite>().color = hexToColor("653131FF");
        else if (_ElementalType == 15)
            transform.Find("Elemental").GetComponent<UISprite>().color = hexToColor("332B26FF");
        else if (_ElementalType == 9)
            transform.Find("Elemental").GetComponent<UISprite>().color = hexToColor("0008B0FF");
        else if (_ElementalType == 25)
            transform.Find("Elemental").GetComponent<UISprite>().color = hexToColor("452F1BFF");
        else if (_ElementalType == 49)
            transform.Find("Elemental").GetComponent<UISprite>().color = hexToColor("FFFFFFFF");
        else if (_ElementalType == 6)
            transform.Find("Elemental").GetComponent<UISprite>().color = hexToColor("FFD1C1FF");
        else if (_ElementalType == 35)
            transform.Find("Elemental").GetComponent<UISprite>().color = hexToColor("FFDE99FF");
        else if (_ElementalType == 14)
            transform.Find("Elemental").GetComponent<UISprite>().color = hexToColor("850000FF");

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


    public void SkillTouch()
    {
        if(GameMng.Data._GameDate._HeroUnit._HyperTime<=0.0f && GameMng.Data._GameDate._HeroUnit._CantTarget==false)
        {
            GameMng.Data._UseSkillType.Add(_ElementalType);
            AudioSource.PlayClipAtPoint(GameMng.Data._SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
            GameMng.Data._S_ActionMng._TouchSkill = true;
            GameMng.Data._CreativeTable._SkillQuantity--;
            GameMng.Data._SkillName = _HeroClass + "_" + _ElementalType + "_" + _SkillLevel;
            GameMng.Data._GameDate._touchScene = true;
            if (_shootType == 1)
                GameMng.Data._RangeArrow.SetActive(true);
            else if (_shootType == 2)
                GameMng.Data._RangeCircle.SetActive(true);
            else if (_shootType == 3)
                GameMng.Data._RangeSecterForm.SetActive(true);
            else if (_shootType == 4)
                GameMng.Data._RangeNoneTarget.SetActive(true);
            //
            Destroy(gameObject);
        }
        

    }

    public void MoveRightBlock()
    {
        MoveBy moveby = new MoveBy(gameObject, new Vector3(79, 0, 0), true, false, 0.03f);
        have.o_List.Add(moveby);
    }
}