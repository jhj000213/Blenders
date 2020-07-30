using UnityEngine;
using System.Collections;

public class HeroItem : MonoBehaviour {

    public int _Price;
    /// <summary>
    /// 1 - common
    /// 2 - rare
    /// 3 - legendery
    /// </summary>
    public int _Rating;
    public string _ItemName;
    public string _ItemKoreanName;
    public string _ItemType;
    public int _ItemLevel;

    public string _ItemInfo;

    public int _OriginAttackPoint;
    public int _OriginPowerPoint;
    public int _OriginIntellectPoint;
    public int _OriginArmorPoint;
    public int _OriginHealthPoint;

    public int _AttackPoint;
    public int _PowerPoint;
    public int _IntellectPoint;
    public int _ArmorPoint;
    public int _HealthPoint;
    public int _StatRating;

    public void ItemInit(string name,string koreanname,string _type, int rating, int price,int attackpoint,int powerpoint,int intellectpoint,int armorpoint,int healthpoint,int itemlevel)
    {
        _ItemName = name;
        _ItemKoreanName = koreanname;
        _ItemType = _type;
        _Rating = rating;
        _Price = price;
        //_AttackPoint = attackpoint;
        //_PowerPoint = powerpoint;
        //_IntellectPoint = intellectpoint;
        //_ArmorPoint = armorpoint;
        //_HealthPoint = healthpoint;

        _OriginAttackPoint = attackpoint;
        _OriginPowerPoint = powerpoint;
        _OriginIntellectPoint = intellectpoint;
        _OriginArmorPoint = armorpoint;
        _OriginHealthPoint = healthpoint;

        _ItemLevel = itemlevel;
    }

    public void ItemSaveGet(string name,string koreanname,string _type, int rating, int price,int attackpoint,int powerpoint,int intellectpoint,int armorpoint,int healthpoint,
        int originattackpoint, int originpowerpoint, int originintellectpoint, int originarmorpoint, int originhealthpoint, int itemlevel, int statrating)
    {
        _ItemName = name;
        _ItemKoreanName = koreanname;
        _ItemType = _type;
        _Rating = rating;
        _Price = price;
        _AttackPoint = attackpoint;
        _PowerPoint = powerpoint;
        _IntellectPoint = intellectpoint;
        _ArmorPoint = armorpoint;
        _HealthPoint = healthpoint;

        _OriginAttackPoint = originattackpoint;
        _OriginPowerPoint = originpowerpoint;
        _OriginIntellectPoint = originintellectpoint;
        _OriginArmorPoint = originarmorpoint;
        _OriginHealthPoint = originhealthpoint;

        _ItemLevel = itemlevel;
        _StatRating = statrating;
    }

    public void ItemStatSet()
    {
        int num = Random.Range(0, 100);
        if(num<20)//D
        {
            _StatRating = 1;
            _AttackPoint = ValuePercent(_OriginAttackPoint, 0.9f);
            _PowerPoint = ValuePercent(_OriginPowerPoint, 0.9f);
            _IntellectPoint = ValuePercent(_OriginIntellectPoint, 0.9f);
            _ArmorPoint = ValuePercent(_OriginArmorPoint, 0.9f);
            _HealthPoint = ValuePercent(_OriginHealthPoint, 0.9f);
        }
        else if(num>19&&num<40)//C
        {
            _StatRating = 2;
            _AttackPoint = ValuePercent(_OriginAttackPoint, 0.95f);
            _PowerPoint = ValuePercent(_OriginPowerPoint, 0.95f);
            _IntellectPoint = ValuePercent(_OriginIntellectPoint, 0.95f);
            _ArmorPoint = ValuePercent(_OriginArmorPoint, 0.95f);
            _HealthPoint = ValuePercent(_OriginHealthPoint, 0.95f);
        }
        else if (num>39&&num<60)//A
        {
            _StatRating = 4;
            _AttackPoint = ValuePercent(_OriginAttackPoint, 1.1f);
            _PowerPoint = ValuePercent(_OriginPowerPoint, 1.1f);
            _IntellectPoint = ValuePercent(_OriginIntellectPoint, 1.1f);
            _ArmorPoint = ValuePercent(_OriginArmorPoint, 1.1f);
            _HealthPoint = ValuePercent(_OriginHealthPoint, 1.1f);
        }
        else if (num > 79 && num < 100)//S
        {
            _StatRating = 5;
            _AttackPoint = ValuePercent(_OriginAttackPoint, 1.2f);
            _PowerPoint = ValuePercent(_OriginPowerPoint, 1.2f);
            _IntellectPoint = ValuePercent(_OriginIntellectPoint, 1.2f);
            _ArmorPoint = ValuePercent(_OriginArmorPoint, 1.2f);
            _HealthPoint = ValuePercent(_OriginHealthPoint, 1.2f);
        }
        else //B
        {
            _StatRating = 3;
            _AttackPoint = _OriginAttackPoint;
            _PowerPoint = _OriginPowerPoint;
            _IntellectPoint = _OriginIntellectPoint;
            _ArmorPoint = _OriginArmorPoint;
            _HealthPoint = _OriginHealthPoint;
        }
    }
    public void SetStatRankB()
    {
        _StatRating = 3;
        _AttackPoint = _OriginAttackPoint;
        _PowerPoint = _OriginPowerPoint;
        _IntellectPoint = _OriginIntellectPoint;
        _ArmorPoint = _OriginArmorPoint;
        _HealthPoint = _OriginHealthPoint;
    }
    int ValuePercent(int value, float percent)
    {
        float num = value;
        num *= percent;
        value = (int)num;

        return value;
    }
    //public void ItemInit(string name, string koreanname, int rating, int price, int attackpoint, int powerpoint, int intellectpoint, int armorpoint, int healthpoint)
    //{
    //    _ItemName = name;
    //    _Rating = rating;
    //    _Price = price;
    //}
}