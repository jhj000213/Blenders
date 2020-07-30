using UnityEngine;
using System.Collections;

public class HeroItemMng : MonoBehaviour
{
    public PublicSoundData _SoundData;
    public DataSaveMng _SaveMng;

    public int _MaxInventoryCount;
    const int _SetInventoryCount = 1;


    public GameObject _WeaponTab;
    public GameObject _ArmorTab;

    public GameObject _WeaponGrid;
    public GameObject _ArmorGrid;

    public GameObject[] _WeaponArray = new GameObject[10];
    public GameObject[] _ArmorArray = new GameObject[10];

    public GameObject _SetWeapon;
    public GameObject _SetArmor;

    bool _ItemPopupOn;
    HeroItem _NowLookItem;
    public GameObject _ItemPopupTable;
    public GameObject _SetLabel;
    public GameObject _UnsetLabel;
    public UISprite _ItemImage;
    public UILabel _ItemName;
    public UILabel _ItemInfo;
    public UILabel _ItemAttackPoint;
    public UILabel _ItemPowerPoint;
    public UILabel _ItemIntellectPoint;
    public UILabel _ItemArmorPoint;
    public UILabel _ItemHealthPoint;
    public UILabel _ItemPricePoint;
    public UILabel _ItemRating;
    public UILabel _ItemLevel;
    public UILabel _ItemStatRating;

    public GameObject _SellPopup;
    bool _SellPopupOn;

    public GameObject _InfoPopup;
    bool _InfoPopupOn;

    int _NowPopupItemNum;
    int _NowItemSlotNum;

    public int _SetArmorItemSlot = 1;
    public int _SetWarriorWeaponItemSlot = 2;
    public int _UnSetArmorItemSlot = 3;
    public int _UnSetWarriorWeaponItemSlot = 4;

    public bool _true = true;
    public bool _false = false;
    void Start()
    {
        //StaticDataMng._Tutorial = false;
        for (int i = 0; i < _MaxInventoryCount; i++)
        {
            _WeaponArray[i].name = i.ToString();
            _ArmorArray[i].name = i.ToString();
        }
    }

    public void SetSellPopup(bool value)
    {
        _SellPopupOn = value;
    }

    public void SetInfoPopup(bool value)
    {
        _InfoPopupOn = value;
    }

    public void SellItem()
    {
        AudioSource.PlayClipAtPoint(_SoundData._UsingGold, Vector2.zero, StaticDataMng._SoundOn);
        if(_NowPopupItemNum==1)
        {
            StaticDataMng._Gold += StaticDataMng._HeroHaveItem_Armor[_NowItemSlotNum]._Price;
            //StaticDataMng._HeroHaveItem_Armor.Remove(StaticDataMng._HeroHaveItem_Armor[_NowItemSlotNum]);
            StaticDataMng._HeroHaveItem_Armor.RemoveAt(_NowItemSlotNum);
        }
        if (_NowPopupItemNum == 2)
        {
            StaticDataMng._Gold += StaticDataMng._HeroHaveItem_Weapon[_NowItemSlotNum]._Price;
            //StaticDataMng._HeroHaveItem_Weapon.Remove(StaticDataMng._HeroHaveItem_Weapon[_NowItemSlotNum]);
            StaticDataMng._HeroHaveItem_Weapon.RemoveAt(_NowItemSlotNum);
        }
        if (_NowPopupItemNum == 3)
        {
            StaticDataMng._Gold += StaticDataMng._HeroSetItem_Armor[0]._Price;
            //StaticDataMng._HeroSetItem_Armor.Remove(StaticDataMng._HeroSetItem_Armor[0]);
            StaticDataMng._HeroSetItem_Armor.RemoveAt(0);
        }
        if (_NowPopupItemNum == 4)
        {
            StaticDataMng._Gold += StaticDataMng._HeroSetItem_Weapon[0]._Price;
            //StaticDataMng._HeroSetItem_Weapon.Remove(StaticDataMng._HeroSetItem_Weapon[0]);
            StaticDataMng._HeroSetItem_Weapon.RemoveAt(0);
        }
        _SaveMng.Saving();
    }

    void Update()
    {
        _ItemPopupTable.SetActive(_ItemPopupOn);
        if(_ItemPopupOn)
        {
            //if (_NowPopupItemNum == 1 || _NowPopupItemNum == 3)
            //    nameplus = "item_armor_";
            //else
            //    nameplus = "item_weapon_" + _NowLookItem._UseClass + "_";

            if(_NowPopupItemNum<=2)
            {
                _SetLabel.SetActive(true);
                _UnsetLabel.SetActive(false);
            }
            else
            {
                _SetLabel.SetActive(false);
                _UnsetLabel.SetActive(true);
            }

            _ItemImage.spriteName = "heroitem_" + _NowLookItem._ItemName;
            _ItemName.text = _NowLookItem._ItemKoreanName;
            _ItemInfo.text = _NowLookItem._ItemInfo;

            //itemInfo

            _ItemAttackPoint.text = _NowLookItem._AttackPoint.ToString();
            _ItemPowerPoint.text = _NowLookItem._PowerPoint.ToString();
            _ItemIntellectPoint.text = _NowLookItem._IntellectPoint.ToString();
            _ItemArmorPoint.text = _NowLookItem._ArmorPoint.ToString();
            _ItemHealthPoint.text = _NowLookItem._HealthPoint.ToString();
            _ItemPricePoint.text = _NowLookItem._Price.ToString();

            if(_NowLookItem._Rating==1)
            {
                _ItemRating.text = "커먼";
                _ItemRating.GetComponent<UILabel>().color = hexToColor("00CAFFFF");
            }
            else if(_NowLookItem._Rating == 2)
            {
                _ItemRating.text = "레어";
                _ItemRating.GetComponent<UILabel>().color = hexToColor("BC00FFFF");
            }
            else if (_NowLookItem._Rating == 3)
            {
                _ItemRating.text = "레전더리";
                _ItemRating.GetComponent<UILabel>().color = hexToColor("FFAE00FF");
            }

            if(_NowLookItem._StatRating==1)
            {
                _ItemStatRating.text = "D";
                _ItemStatRating.GetComponent<UILabel>().color = hexToColor("A5A5A5FF");
            }
            else if (_NowLookItem._StatRating == 2)
            {
                _ItemStatRating.text = "C";
                _ItemStatRating.GetComponent<UILabel>().color = hexToColor("FFFFFFFF");
            }
            else if (_NowLookItem._StatRating == 3)
            {
                _ItemStatRating.text = "B";
                _ItemStatRating.GetComponent<UILabel>().color = hexToColor("00CAFFFF");
            }
            else if (_NowLookItem._StatRating == 4)
            {
                _ItemStatRating.text = "A";
                _ItemStatRating.GetComponent<UILabel>().color = hexToColor("D359FFFF");
            }
            else if (_NowLookItem._StatRating == 5)
            {
                _ItemStatRating.text = "S";
                _ItemStatRating.GetComponent<UILabel>().color = hexToColor("FFAE00FF");
            }

            _ItemLevel.text = _NowLookItem._ItemLevel.ToString() + " 레벨 착용가능";
            if(_NowLookItem._ItemLevel>StaticDataMng._HeroLevel)
                _ItemLevel.color = hexToColor("FF0000FF");
            else
                _ItemLevel.color = hexToColor("33FF00FF");


            _SellPopup.SetActive(_SellPopupOn);
            _InfoPopup.SetActive(_InfoPopupOn);
        }
        SetList_Weapon();
        SetList_Armor();
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

    void SetList_Weapon()
    {
        for (int i = 0; i < _WeaponGrid.transform.childCount; i++)
            _WeaponArray[i].SetActive(false);
        _SetWeapon.SetActive(false);

        if (StaticDataMng._HeroSetItem_Weapon.Count == 1)
        {
            _SetWeapon.SetActive(true);
            _SetWeapon.GetComponent<UISprite>().spriteName = "heroitem_"+StaticDataMng._HeroSetItem_Weapon[0]._ItemName;
            //_SetWeapon.name = "SetWeapon";
        }
        for (int i = 0; i < StaticDataMng._HeroHaveItem_Weapon.Count; i++)
        {
            _WeaponArray[i].SetActive(true);
            _WeaponArray[i].GetComponent<UISprite>().spriteName = "heroitem_" + StaticDataMng._HeroHaveItem_Weapon[i]._ItemName;
            _WeaponArray[i].name = i.ToString();
            
        }
        //_WeaponGrid.GetComponent<UIGrid>().hideInactive = !_WeaponGrid.GetComponent<UIGrid>().hideInactive;
    }
    void SetList_Armor()
    {
        for (int i = 0; i < _ArmorGrid.transform.childCount; i++)
            _ArmorArray[i].SetActive(false);
        _SetArmor.SetActive(false);

        if (StaticDataMng._HeroSetItem_Armor.Count == 1)
        {
            _SetArmor.SetActive(true);
            _SetArmor.GetComponent<UISprite>().spriteName = "heroitem_"+ StaticDataMng._HeroSetItem_Armor[0]._ItemName;
            //_SetWeapon.name = "SetWeapon";
        }
        for (int i = 0; i < StaticDataMng._HeroHaveItem_Armor.Count; i++)
        {
            _ArmorArray[i].SetActive(true);
            _ArmorArray[i].GetComponent<UISprite>().spriteName = "heroitem_" +StaticDataMng._HeroHaveItem_Armor[i]._ItemName;
            _ArmorArray[i].name = i.ToString();
        }
        //_WeaponGrid.GetComponent<UIGrid>().hideInactive = !_WeaponGrid.GetComponent<UIGrid>().hideInactive;
    }

    public void ItemPopupOn(int slotnamenum, string slotnum)
    {
        int num = 1;
        if(slotnamenum<=2)
        {
            num = int.Parse(slotnum);
            _NowItemSlotNum = num;
        }
        _ItemPopupOn = true;
        _NowPopupItemNum = slotnamenum;
        
        if (slotnamenum == 1)//ArmorSet
            _NowLookItem = StaticDataMng._HeroHaveItem_Armor[num];
        if (slotnamenum == 2)//WeaponSet
            _NowLookItem = StaticDataMng._HeroHaveItem_Weapon[num];
        if (slotnamenum == 3)//ArmorUnSet
            _NowLookItem = StaticDataMng._HeroSetItem_Armor[0];
        if (slotnamenum == 4)//WeaponUnSet
            _NowLookItem = StaticDataMng._HeroSetItem_Weapon[0];
    }

    public void ItemPopupOff()
    {
        _ItemPopupOn = false;
    }

    public void SetItem()
    {
        if (_NowPopupItemNum == 1)
            SetArmor(_NowItemSlotNum);
        else if (_NowPopupItemNum == 2)
            SetWeapon(_NowItemSlotNum);
        else if (_NowPopupItemNum == 3)
            UnsetArmor();
        else if (_NowPopupItemNum == 4)
            UnsetWeapon();

        ItemPopupOff();
        _SaveMng.Saving();
    }

    public void SetWeapon(int name)
    {
        if (StaticDataMng._HeroSetItem_Weapon.Count == 0)
        {
            //Item_Weapon item = StaticDataMng._HeroHaveItem_Weapon[num];
            StaticDataMng._HeroSetItem_Weapon.Add(StaticDataMng._HeroHaveItem_Weapon[name]);
            //Debug.Log(num);
            //if (StaticDataMng._HeroHaveItem_Weapon[num] == null)
            //    Debug.Log("null");
            StaticDataMng._HeroHaveItem_Weapon.RemoveAt(name);
        }
        else
        {
            HeroItem Temp = StaticDataMng._HeroHaveItem_Weapon[name];
            StaticDataMng._HeroHaveItem_Weapon[name] = StaticDataMng._HeroSetItem_Weapon[0];
            StaticDataMng._HeroSetItem_Weapon[0] = Temp;
        }
    }
    public void SetArmor(int name)
    {
        if (StaticDataMng._HeroSetItem_Armor.Count == 0)
        {
            StaticDataMng._HeroSetItem_Armor.Add(StaticDataMng._HeroHaveItem_Armor[name]);
            StaticDataMng._HeroHaveItem_Armor.RemoveAt(name);
        }
        else
        {
            HeroItem Temp = StaticDataMng._HeroHaveItem_Armor[name];
            StaticDataMng._HeroHaveItem_Armor[name] = StaticDataMng._HeroSetItem_Armor[0];
            StaticDataMng._HeroSetItem_Armor[0] = Temp;
        }
    }

    public void UnsetWeapon()
    {
        if (StaticDataMng._HeroHaveItem_Weapon.Count < _MaxInventoryCount)
        {
            StaticDataMng._HeroHaveItem_Weapon.Add(StaticDataMng._HeroSetItem_Weapon[0]);
            StaticDataMng._HeroSetItem_Weapon.Clear();
        }
    }
    public void UnsetArmor()
    {
        if (StaticDataMng._HeroHaveItem_Armor.Count < _MaxInventoryCount)
        {
            StaticDataMng._HeroHaveItem_Armor.Add(StaticDataMng._HeroSetItem_Armor[0]);
            StaticDataMng._HeroSetItem_Armor.Clear();
        }
    }


    public void AddWeapon()
    {
        if (StaticDataMng._HeroHaveItem_Weapon.Count < _MaxInventoryCount)
        {
            HeroItem Item = new HeroItem();
            int itemrarity = Random.Range(0, 100);
            if (itemrarity < 5)
            {
                //레전
                //int itemnum = Random.Range(0, StaticDataMng._AllHeroItemList_Legendery.Count);
                //Item = StaticDataMng._AllHeroItemList_Legendery[itemnum];
                int itemnum = Random.Range(0, StaticDataMng._AllHeroItemList_Rare.Count);
                Item.ItemInit(StaticDataMng._AllHeroItemList_Rare[itemnum]._ItemName, StaticDataMng._AllHeroItemList_Rare[itemnum]._ItemKoreanName,
                    StaticDataMng._AllHeroItemList_Rare[itemnum]._ItemType, StaticDataMng._AllHeroItemList_Rare[itemnum]._Rating,
                    StaticDataMng._AllHeroItemList_Rare[itemnum]._Price, StaticDataMng._AllHeroItemList_Rare[itemnum]._OriginAttackPoint,
                    StaticDataMng._AllHeroItemList_Rare[itemnum]._OriginPowerPoint, StaticDataMng._AllHeroItemList_Rare[itemnum]._OriginIntellectPoint,
                    StaticDataMng._AllHeroItemList_Rare[itemnum]._OriginArmorPoint, StaticDataMng._AllHeroItemList_Rare[itemnum]._OriginHealthPoint,
                    StaticDataMng._AllHeroItemList_Rare[itemnum]._ItemLevel);
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
            }
            Item.ItemStatSet();
            if (Item._ItemType == "warriorweapon")
                StaticDataMng._HeroHaveItem_Weapon.Add(Item);
            else
                StaticDataMng._HeroHaveItem_Armor.Add(Item);
        }
    }
    public void AddArmor()
    {
        if (StaticDataMng._HeroHaveItem_Armor.Count < _MaxInventoryCount)
        {
            //Item_Armor item = new Item_Armor();
            //item.ItemInit("normal", "armor", 1, 300,0,0,0,0,0);
            //StaticDataMng._HeroHaveItem_Armor.Add(item);
        }
    }



}
