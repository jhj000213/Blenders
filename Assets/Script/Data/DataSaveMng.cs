using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class DataSaveMng : MonoBehaviour {


    void Start()
    {
        Saving();
        StartCoroutine(SavingCor(5.0f));
    }

    IEnumerator SavingCor(float time)
    {
        yield return new WaitForSeconds(time);
        
        Saving();
        StartCoroutine(SavingCor(5.0f));
    }
	
	public void Saving () 
    {
        PlayerPrefs.SetString("TramName", StaticDataMng._TeamName);

        PlayerPrefs.SetInt("Achevement_OnlySoldier_W", StaticDataMng._OnlySoldier_W_Clear);
        PlayerPrefs.SetInt("Achevement_OnlySoldier_A", StaticDataMng._OnlySoldier_A_Clear);
        PlayerPrefs.SetInt("Achevement_OnlyElement", StaticDataMng._OnlyElementClear);
        PlayerPrefs.SetInt("Achevement_In30Second", StaticDataMng._In30SecondClear);

        PlayerPrefs.SetInt("HeroLevel", StaticDataMng._HeroLevel);
        PlayerPrefs.SetFloat("HeroExp", StaticDataMng._HeroExpValue);
        PlayerPrefs.SetFloat("HeroExpMax", StaticDataMng._HeroMaxExpValue);
        PlayerPrefs.SetInt("Gold", StaticDataMng._Gold);


        PlayerPrefs.SetInt("StoryNum", StaticDataMng._StoryNum);
        PlayerPrefs.SetInt("StoryOn", ReturnBoolToInt(StaticDataMng._StoryOn));
        PlayerPrefs.SetInt("StoryWaveOn", ReturnBoolToInt(StaticDataMng._StoryWaveOn));
        PlayerPrefs.SetInt("StoryWaveOn_Save", ReturnBoolToInt(StaticDataMng._StoryWaveOn_Save));
        PlayerPrefs.SetString("StoryScene", StaticDataMng._StoryScene);
        PlayerPrefs.SetString("SelectStageName", StaticDataMng._SelectStageName);
        PlayerPrefs.SetInt("StoryGoGameScene", ReturnBoolToInt(StaticDataMng._StoryGoGameScene));

        PlayerPrefs.SetInt("PlayingDead", ReturnBoolToInt(StaticDataMng._PlayingDead));
        PlayerPrefs.SetInt("LastStoryNum", StaticDataMng._LastStoryNum);
        PlayerPrefs.SetString("LastStageName", StaticDataMng._LastStageName);

        PlayerPrefs.SetInt("SoundOn", StaticDataMng._SoundOn);
        PlayerPrefs.SetInt("VibOn", StaticDataMng._VibOn);

        if (SceneManager.GetActiveScene().name != "TitleScene")
            SetPormationInfo();
        SetSkillLevel();
        SetSoldierLevel();
        SaveHaveItem();
	}
    
    void SetSoldierLevel()
    {
        PlayerPrefs.SetInt("Soldier_Warrior_Level", StaticDataMng._Soldier_Warrior_Level);
        PlayerPrefs.SetInt("Soldier_Archer_Level", StaticDataMng._Soldier_Archer_Level);
        PlayerPrefs.SetInt("Soldier_Mage_Level", StaticDataMng._Soldier_Mage_Level);
    }
    void SetSkillLevel()
    {
        PlayerPrefs.SetInt("SkillLevel_Low_4", StaticDataMng._SkillLevel_Low_4 );
        PlayerPrefs.SetInt("SkillLevel_Low_9", StaticDataMng._SkillLevel_Low_9 );
        PlayerPrefs.SetInt("SkillLevel_Low_25",StaticDataMng._SkillLevel_Low_25);
        PlayerPrefs.SetInt("SkillLevel_Low_49",StaticDataMng._SkillLevel_Low_49);
        PlayerPrefs.SetInt("SkillLevel_Low_6", StaticDataMng._SkillLevel_Low_6 );
        PlayerPrefs.SetInt("SkillLevel_Low_15",StaticDataMng._SkillLevel_Low_15);
        PlayerPrefs.SetInt("SkillLevel_Low_35",StaticDataMng._SkillLevel_Low_35);
        PlayerPrefs.SetInt("SkillLevel_Low_14",StaticDataMng._SkillLevel_Low_14);
        PlayerPrefs.SetInt("SkillLevel_Low_21",StaticDataMng._SkillLevel_Low_21);
        PlayerPrefs.SetInt("SkillLevel_Low_10", StaticDataMng._SkillLevel_Low_10);

        PlayerPrefs.SetInt("SkillLevel_High_4", StaticDataMng._SkillLevel_High_4 );
        PlayerPrefs.SetInt("SkillLevel_High_9", StaticDataMng._SkillLevel_High_9 );
        PlayerPrefs.SetInt("SkillLevel_High_25",StaticDataMng._SkillLevel_High_25);
        PlayerPrefs.SetInt("SkillLevel_High_49",StaticDataMng._SkillLevel_High_49);
        PlayerPrefs.SetInt("SkillLevel_High_6", StaticDataMng._SkillLevel_High_6 );
        PlayerPrefs.SetInt("SkillLevel_High_15",StaticDataMng._SkillLevel_High_15);
        PlayerPrefs.SetInt("SkillLevel_High_35",StaticDataMng._SkillLevel_High_35);
        PlayerPrefs.SetInt("SkillLevel_High_14",StaticDataMng._SkillLevel_High_14);
        PlayerPrefs.SetInt("SkillLevel_High_21",StaticDataMng._SkillLevel_High_21);
        PlayerPrefs.SetInt("SkillLevel_High_10", StaticDataMng._SkillLevel_High_10);
    }

    int ReturnBoolToInt(bool num)
    {
        if (num)
            return 1;
        else
            return 0;
    }

    void SetPormationInfo()
    {
        for (int i = 0; i < 7; i++)
        {
            PlayerPrefs.SetInt("PormationIcon_Value_" + i.ToString(), 0);
            PlayerPrefs.SetFloat("PormationIcon_PosX_" + i.ToString(), 0);
            PlayerPrefs.SetFloat("PormationIcon_PosY_" + i.ToString(), 0);
            PlayerPrefs.SetString("PormationIcon_IconName_" + i.ToString(), "");
        }

        for (int i = 0; i < StaticDataMng._PormationList.Count; i++)
        {
            PlayerPrefs.SetInt("PormationIcon_Value_" + i.ToString(), StaticDataMng._PormationList[i]._UnitNum);
            PlayerPrefs.SetFloat("PormationIcon_PosX_" + i.ToString(), StaticDataMng._PormationList[i]._nowPos.x);
            PlayerPrefs.SetFloat("PormationIcon_PosY_" + i.ToString(), StaticDataMng._PormationList[i]._nowPos.y);
            PlayerPrefs.SetString("PormationIcon_IconName_" + i.ToString(), StaticDataMng._PormationList[i]._IconName);
        }
    }

    void SaveHaveItem()
    {
        for (int i = 0; i < 16; i++)
        {
            PlayerPrefs.SetString("HaveItem_Armor_Name_" + i.ToString(), "");
            PlayerPrefs.SetString("HaveItem_Armor_KoreanName_" + i.ToString(), "");
            PlayerPrefs.SetString("HaveItem_Armor_Type_" + i.ToString(), "");
            PlayerPrefs.SetInt("HaveItem_Armor_Rating_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_Price_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginAttackPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginPowerPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginIntellectPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginArmorPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginHealthPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_StatRating_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_AttackPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_PowerPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_IntellectPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_ArmorPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_Armor_HealthPoint_" + i.ToString(), 0);
            PlayerPrefs.SetString("HaveItem_Armor_ItemInfo_" + i.ToString(), "");


            PlayerPrefs.SetString("HaveItem_WarriorWeapon_Name_" + i.ToString(), "");
            PlayerPrefs.SetString("HaveItem_WarriorWeapon_KoreanName_" + i.ToString(), "");
            PlayerPrefs.SetString("HaveItem_WarriorWeapon_Type_" + i.ToString(), "");
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_Rating_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_Price_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginAttackPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginPowerPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginIntellectPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginArmorPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginHealthPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_StatRating_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_AttackPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_PowerPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_IntellectPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_ArmorPoint_" + i.ToString(), 0);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_HealthPoint_" + i.ToString(), 0);
            PlayerPrefs.SetString("HaveItem_WarriorWeapon_ItemInfo_" + i.ToString(), "");
        }
        PlayerPrefs.SetString("SetItem_Armor_Name_0", "");
        PlayerPrefs.SetString("SetItem_Armor_KoreanName_0", "");
        PlayerPrefs.SetString("SetItem_Armor_Type_0", "");
        PlayerPrefs.SetInt("SetItem_Armor_Rating_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_Price_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_OriginAttackPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_OriginPowerPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_OriginIntellectPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_OriginArmorPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_OriginHealthPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_StatRating_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_AttackPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_PowerPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_IntellectPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_ArmorPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_Armor_HealthPoint_0", 0);
        PlayerPrefs.SetString("SetItem_Armor_ItemInfo_0", "");

        PlayerPrefs.SetString("SetItem_WarriorWeapon_Name_0", "");
        PlayerPrefs.SetString("SetItem_WarriorWeapon_KoreanName_0", "");
        PlayerPrefs.SetString("SetItem_WarriorWeapon_Type_0", "");
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_Rating_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_Price_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_OriginAttackPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_OriginPowerPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_OriginIntellectPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_OriginArmorPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_OriginHealthPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_StatRating_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_AttackPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_PowerPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_IntellectPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_ArmorPoint_0", 0);
        PlayerPrefs.SetInt("SetItem_WarriorWeapon_HealthPoint_0", 0);
        PlayerPrefs.SetString("SetItem_WarriorWeapon_ItemInfo_0", "");






        for (int i = 0; i < StaticDataMng._HeroHaveItem_Armor.Count; i++)//보유중인 방어구 아이템
        {
            PlayerPrefs.SetString("HaveItem_Armor_Name_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._ItemName);
            PlayerPrefs.SetString("HaveItem_Armor_KoreanName_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._ItemKoreanName);
            PlayerPrefs.SetString("HaveItem_Armor_Type_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._ItemType);
            PlayerPrefs.SetInt("HaveItem_Armor_Rating_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._Rating);
            PlayerPrefs.SetInt("HaveItem_Armor_Price_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._Price);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginAttackPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._OriginAttackPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginPowerPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._OriginPowerPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginIntellectPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._OriginIntellectPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginArmorPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._OriginArmorPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginHealthPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._OriginHealthPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_StatRating_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._StatRating);
            PlayerPrefs.SetInt("HaveItem_Armor_AttackPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._AttackPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_PowerPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._PowerPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_IntellectPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._IntellectPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_ArmorPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._ArmorPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_HealthPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._HealthPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_ItemLevel_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._ItemLevel);
            PlayerPrefs.SetString("HaveItem_Armor_ItemInfo_" + i.ToString(), StaticDataMng._HeroHaveItem_Armor[i]._ItemInfo);
        }
        for (int i = 0; i < StaticDataMng._HeroHaveItem_Weapon.Count; i++)//보유중인 무기 아이템
        {
            PlayerPrefs.SetString("HaveItem_WarriorWeapon_Name_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._ItemName);
            PlayerPrefs.SetString("HaveItem_WarriorWeapon_KoreanName_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._ItemKoreanName);
            PlayerPrefs.SetString("HaveItem_WarriorWeapon_Type_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._ItemType);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_Rating_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._Rating);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_Price_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._Price);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginAttackPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._OriginAttackPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginPowerPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._OriginPowerPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginIntellectPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._OriginIntellectPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginArmorPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._OriginArmorPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginHealthPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._OriginHealthPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_StatRating_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._StatRating);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_AttackPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._AttackPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_PowerPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._PowerPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_IntellectPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._IntellectPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_ArmorPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._ArmorPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_HealthPoint_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._HealthPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_ItemLevel_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._ItemLevel);
            PlayerPrefs.SetString("HaveItem_WarriorWeapon_ItemInfo_" + i.ToString(), StaticDataMng._HeroHaveItem_Weapon[i]._ItemInfo);
        }

        if (StaticDataMng._HeroSetItem_Weapon.Count != 0)//장착중인 무기 아이템
        {
            PlayerPrefs.SetString("SetItem_WarriorWeapon_Name_0", StaticDataMng._HeroSetItem_Weapon[0]._ItemName);
            PlayerPrefs.SetString("SetItem_WarriorWeapon_KoreanName_0", StaticDataMng._HeroSetItem_Weapon[0]._ItemKoreanName);
            PlayerPrefs.SetString("SetItem_WarriorWeapon_Type_0", StaticDataMng._HeroSetItem_Weapon[0]._ItemType);
            PlayerPrefs.SetInt("SetItem_WarriorWeapon_Rating_0", StaticDataMng._HeroSetItem_Weapon[0]._Rating);
            PlayerPrefs.SetInt("SetItem_WarriorWeapon_Price_0", StaticDataMng._HeroSetItem_Weapon[0]._Price);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginAttackPoint_0", StaticDataMng._HeroSetItem_Weapon[0]._OriginAttackPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginPowerPoint_0", StaticDataMng._HeroSetItem_Weapon[0]._OriginPowerPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginIntellectPoint_0", StaticDataMng._HeroSetItem_Weapon[0]._OriginIntellectPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginArmorPoint_0", StaticDataMng._HeroSetItem_Weapon[0]._OriginArmorPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_OriginHealthPoint_0", StaticDataMng._HeroSetItem_Weapon[0]._OriginHealthPoint);
            PlayerPrefs.SetInt("HaveItem_WarriorWeapon_StatRating_0", StaticDataMng._HeroSetItem_Weapon[0]._StatRating);
            PlayerPrefs.SetInt("SetItem_WarriorWeapon_AttackPoint_0", StaticDataMng._HeroSetItem_Weapon[0]._AttackPoint);
            PlayerPrefs.SetInt("SetItem_WarriorWeapon_PowerPoint_0", StaticDataMng._HeroSetItem_Weapon[0]._PowerPoint);
            PlayerPrefs.SetInt("SetItem_WarriorWeapon_IntellectPoint_0", StaticDataMng._HeroSetItem_Weapon[0]._IntellectPoint);
            PlayerPrefs.SetInt("SetItem_WarriorWeapon_ArmorPoint_0", StaticDataMng._HeroSetItem_Weapon[0]._ArmorPoint);
            PlayerPrefs.SetInt("SetItem_WarriorWeapon_HealthPoint_0", StaticDataMng._HeroSetItem_Weapon[0]._HealthPoint);
            PlayerPrefs.SetInt("SetItem_WarriorWeapon_ItemLevel_0", StaticDataMng._HeroSetItem_Weapon[0]._ItemLevel);
            PlayerPrefs.SetString("SetItem_WarriorWeapon_ItemInfo_0", StaticDataMng._HeroSetItem_Weapon[0]._ItemInfo);
        }

        if (StaticDataMng._HeroSetItem_Armor.Count != 0)
        {
            PlayerPrefs.SetString("SetItem_Armor_Name_0", StaticDataMng._HeroSetItem_Armor[0]._ItemName);
            PlayerPrefs.SetString("SetItem_Armor_KoreanName_0", StaticDataMng._HeroSetItem_Armor[0]._ItemKoreanName);
            PlayerPrefs.SetString("SetItem_Armor_Type_0", StaticDataMng._HeroSetItem_Armor[0]._ItemType);
            PlayerPrefs.SetInt("SetItem_Armor_Rating_0", StaticDataMng._HeroSetItem_Armor[0]._Rating);
            PlayerPrefs.SetInt("SetItem_Armor_Price_0", StaticDataMng._HeroSetItem_Armor[0]._Price);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginAttackPoint_0", StaticDataMng._HeroSetItem_Armor[0]._OriginAttackPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginPowerPoint_0", StaticDataMng._HeroSetItem_Armor[0]._OriginPowerPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginIntellectPoint_0", StaticDataMng._HeroSetItem_Armor[0]._OriginIntellectPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginArmorPoint_0", StaticDataMng._HeroSetItem_Armor[0]._OriginArmorPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_OriginHealthPoint_0", StaticDataMng._HeroSetItem_Armor[0]._OriginHealthPoint);
            PlayerPrefs.SetInt("HaveItem_Armor_StatRating_0", StaticDataMng._HeroSetItem_Armor[0]._StatRating);
            PlayerPrefs.SetInt("SetItem_Armor_AttackPoint_0", StaticDataMng._HeroSetItem_Armor[0]._AttackPoint);
            PlayerPrefs.SetInt("SetItem_Armor_PowerPoint_0", StaticDataMng._HeroSetItem_Armor[0]._PowerPoint);
            PlayerPrefs.SetInt("SetItem_Armor_IntellectPoint_0", StaticDataMng._HeroSetItem_Armor[0]._IntellectPoint);
            PlayerPrefs.SetInt("SetItem_Armor_ArmorPoint_0", StaticDataMng._HeroSetItem_Armor[0]._ArmorPoint);
            PlayerPrefs.SetInt("SetItem_Armor_HealthPoint_0", StaticDataMng._HeroSetItem_Armor[0]._HealthPoint);
            PlayerPrefs.SetInt("SetItem_Armor_ItemLevel_0", StaticDataMng._HeroSetItem_Armor[0]._ItemLevel);
            PlayerPrefs.SetString("SetItem_Armor_ItemInfo_0", StaticDataMng._HeroSetItem_Armor[0]._ItemInfo);
        }
    }
}
