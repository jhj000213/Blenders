using UnityEngine;
using System.Collections;

public class GameStartValueSettingMng : MonoBehaviour {

    int LastMaxStory = 20;
    int MaxStory = 22;
    void Start()
    {
        GetStory();
        PlayerPrefs.DeleteAll();

        if(PlayerPrefs.GetInt("LastStoryClaer")==1)
        {
            if(StaticDataMng._StoryNum!=MaxStory)
            {
                PlayerPrefs.SetInt("LastStoryClear", 0);

                StaticDataMng._StoryNum = LastMaxStory;
                StaticDataMng._StoryOn = true;
                StaticDataMng._StoryWaveOn = true;//유동적으로
                StaticDataMng._StoryScene = "BasecampScene";//유동적으로
            }
        }
        if(StaticDataMng._StoryNum==1)
            PlayerPrefs.SetInt("FirstAppPlay", 0);
        
        GetHaveItem();
        GetSetItem();
        GetQuest();


        if (PlayerPrefs.GetInt("FirstAppPlay") == 0)
        {
            //Debug.Log("First");

            PlayerPrefs.SetString("TeamName", "");

            StaticDataMng._StoryNum = 1;
            StaticDataMng._StoryOn = true;
            StaticDataMng._StoryWaveOn = true;
            StaticDataMng._StoryScene = "GameScene";

            //StaticDataMng._StoryNum = 2;
            StaticDataMng._StoryOn = false;
            //StaticDataMng._StoryWaveOn = false;
            //StaticDataMng._StoryScene = "BasecampScene";
            //StaticDataMng._SelectStageName = "설산";

            PlayerPrefs.SetInt("SoundOn", 1);
            PlayerPrefs.SetInt("VibOn", 1);

            PlayerPrefs.SetInt("HeroLevel", 12);
            PlayerPrefs.SetInt("SkillPoint", 40);
            PlayerPrefs.SetInt("FirstAppPlay", 1);
            //StaticDataMng._Tutorial = true;//temp

            PlayerPrefs.SetInt("Gold", 23000);
            PlayerPrefs.SetFloat("HeroExp", 0.0f);
            PlayerPrefs.SetFloat("HeroExpMax", 50000);

            PlayerPrefs.SetInt("SkillLevel_Low_4", 1);
            PlayerPrefs.SetInt("SkillLevel_Low_9", 1);
            PlayerPrefs.SetInt("SkillLevel_Low_25", 1);
            PlayerPrefs.SetInt("SkillLevel_Low_49", 1);
            PlayerPrefs.SetInt("SkillLevel_Low_6", 1);
            PlayerPrefs.SetInt("SkillLevel_Low_15", 1);
            PlayerPrefs.SetInt("SkillLevel_Low_35", 1);
            PlayerPrefs.SetInt("SkillLevel_Low_14", 1);
            PlayerPrefs.SetInt("SkillLevel_Low_21", 1);
            PlayerPrefs.SetInt("SkillLevel_Low_10", 1);

            PlayerPrefs.SetInt("SkillLevel_High_4", 1);
            PlayerPrefs.SetInt("SkillLevel_High_9", 1);
            PlayerPrefs.SetInt("SkillLevel_High_25", 1);
            PlayerPrefs.SetInt("SkillLevel_High_49", 1);
            PlayerPrefs.SetInt("SkillLevel_High_6", 1);
            PlayerPrefs.SetInt("SkillLevel_High_15", 1);
            PlayerPrefs.SetInt("SkillLevel_High_35", 1);
            PlayerPrefs.SetInt("SkillLevel_High_14", 1);
            PlayerPrefs.SetInt("SkillLevel_High_21", 1);
            PlayerPrefs.SetInt("SkillLevel_High_10", 1);

            PlayerPrefs.SetInt("Soldier_Warrior_Level", 1);
            PlayerPrefs.SetInt("Soldier_Archer_Level", 1);
            PlayerPrefs.SetInt("Soldier_Mage_Level", 1);



            PlayerPrefs.SetInt("SecondWorldmapOpen", 1);//temp

        }
        else if (PlayerPrefs.GetInt("Patch_1_3v") == 0)
        {

        }
        //else if(PlayerPrefs.GetInt("Patch_1_2v")==0)
        //{
        //    PlayerPrefs.SetInt("Patch_1_2v", 1);
        //    for (int i = 0; i < 7; i++)
        //    {
        //        PlayerPrefs.SetInt("PormationIcon_Value_" + i.ToString(), 0);
        //        PlayerPrefs.SetFloat("PormationIcon_PosX_" + i.ToString(), 0);
        //        PlayerPrefs.SetFloat("PormationIcon_PosY_" + i.ToString(), 0);
        //        PlayerPrefs.SetString("PormationIcon_IconName_" + i.ToString(), "");
        //    }
        //}
        

        #region 패치 1.01
        //else if (PlayerPrefs.GetInt("Patch_1_1v") == 0)
        //{
        //    #region 버전1.1 패치노트
        //    PlayerPrefs.SetInt("Patch_1_1v", 1);
        //    PlayerPrefs.SetString("TeamName", "");
        //    for (int i = 0; i < 7; i++)
        //    {
        //        PlayerPrefs.SetInt("PormationIcon_Value_" + i.ToString(), 0);
        //        PlayerPrefs.SetFloat("PormationIcon_PosX_" + i.ToString(), 0);
        //        PlayerPrefs.SetFloat("PormationIcon_PosY_" + i.ToString(), 0);
        //        PlayerPrefs.SetString("PormationIcon_IconName_" + i.ToString(), "");
        //    }
        //    for (int i = 0; i < StaticDataMng._HaveQuestList.Count; i++)
        //    {
        //        if (StaticDataMng._HaveQuestList[i]._Target == "아라드라" && StaticDataMng._HaveQuestList[i]._MainQuest == true)
        //        {
        //            StaticDataMng._StoryOn = false;
        //            StaticDataMng._StoryWaveOn = false;
        //        }
        //    }
        //    for (int i = 0; i < StaticDataMng._HeroHaveItem_Armor.Count; i++)
        //    {
        //        HeroItem item = new HeroItem();
        //        if (StaticDataMng._HeroHaveItem_Armor[i]._ItemName == "armor_lv1_common_1")
        //        {
        //            item.ItemInit("armor_lv1_common_1", "구식 강철 갑옷", "armor", 1, 17, 0, 1, 1, 500, 20, 1);
        //            item._ItemInfo = "-미첼- 아저씨 이런 건 얼마나 있어요?\r\n-라기드- 응? 한 100세트 있나?";
        //        }
        //        else if (StaticDataMng._HeroHaveItem_Armor[i]._ItemName == "armor_lv5_common_1")
        //        {
        //            item.ItemInit("armor_lv5_common_1", "쓸만한 미늘 갑옷", "armor", 1, 36, 0, 4, 2, 600, 60, 5);
        //            item._ItemInfo = "";
        //        }
        //        else if (StaticDataMng._HeroHaveItem_Armor[i]._ItemName == "armor_lv5_rare_1")
        //        {
        //            item.ItemInit("armor_lv5_rare_1", "디가르의 갑주", "armor", 2, 72, 0, 6, 2, 650, 80, 5);
        //            item._ItemInfo = "-미첼- 이건.. 어떻게 벗겨왔어요?\r\n-라기드- 안 벗겨지길래 그냥 조각냈지";
        //        }
        //        else if (StaticDataMng._HeroHaveItem_Armor[i]._ItemName == "armor_lv10_common_1")
        //        {
        //            item.ItemInit("armor_lv10_common_1", "흠집난 티타늄 갑옷", "armor", 1, 78, 0, 5, 3, 700, 80, 10);
        //            item._ItemInfo = "-라기드- 내가 옛날에 이걸 입고 얼마나 대단했는지 알아?";
        //        }
        //        else if (StaticDataMng._HeroHaveItem_Armor[i]._ItemName == "armor_lv10_rare_1")
        //        {
        //            item.ItemInit("armor_lv10_rare_1", "로리카", "armor", 2, 106, 0, 7, 4, 800, 100, 10);
        //            item._ItemInfo = "-미첼- 이거.. 치마아니야?";
        //        }
        //        else if (StaticDataMng._HeroHaveItem_Armor[i]._ItemName == "armor_lv10_rare_2")
        //        {
        //            item.ItemInit("armor_lv10_rare_2", "쿠야크", "armor", 2, 106, 0, 10, 4, 750, 90, 10);
        //            item._ItemInfo = "-미스틱- 너 거북이 같아";
        //        }
        //        item.SetStatRankB();
        //        StaticDataMng._HeroHaveItem_Armor[i] = item;
        //    }
        //    for (int i = 0; i < StaticDataMng._HeroHaveItem_Weapon.Count; i++)
        //    {
        //        HeroItem item = new HeroItem();
        //        if (StaticDataMng._HeroHaveItem_Weapon[i]._ItemName == "warrior_lv1_common_1")
        //        {
        //            item.ItemInit("warrior_lv1_common_1", "흔한 도검 & 흠집난 방패", "warriorweapon", 1, 23, 50, 20, 10, 0, 0, 1);
        //            item._ItemInfo = "-미첼- 이런 싸구려 검으로 뭘하란 거에요\r\n-라기드- 뭘하긴! 적을 베는 거지!";
        //        }
        //        else if (StaticDataMng._HeroHaveItem_Weapon[i]._ItemName == "warrior_lv5_common_1")
        //        {
        //            item.ItemInit("warrior_lv5_common_1", "무딘 장검 & 무딘 방패", "warriorweapon", 1, 44, 90, 40, 20, 0, 0, 5);
        //            item._ItemInfo = "-미첼- 대장장이가 재련하다 졸앗나..";
        //        }
        //        else if (StaticDataMng._HeroHaveItem_Weapon[i]._ItemName == "warrior_lv5_rare_1")
        //        {
        //            item.ItemInit("warrior_lv5_rare_1", "디가르의 살육칼날 & 디가르의 전투방패", "warriorweapon", 2, 85, 120, 60, 30, 0, 0, 5);
        //            item._ItemInfo = "-라기드- 정말 무식하게도 생겨 먹었군.\r\n-미첼- 아저씨만 하겠어요?";
        //        }
        //        else if (StaticDataMng._HeroHaveItem_Weapon[i]._ItemName == "warrior_lv10_common_1")
        //        {
        //            item.ItemInit("warrior_lv10_common_1", "미완성 도검 & 미완성 방패", "warriorweapon", 1, 112, 150, 90, 30, 0, 0, 10);
        //            item._ItemInfo = "-라기드- 내가 말이야\r\n이걸 어디서 구해왓냐면~";
        //        }
        //        else if (StaticDataMng._HeroHaveItem_Weapon[i]._ItemName == "warrior_lv10_rare_1")
        //        {
        //            item.ItemInit("warrior_lv10_rare_1", "혼이 잠긴 검 & 금강방패", "warriorweapon", 2, 142, 180, 100, 110, 0, 0, 10);
        //            item._ItemInfo = "-미스틱- 헉.. 이게 무슨 소리지?\r\n-칸- 정령이 우는 소리라네";
        //        }
        //        else if (StaticDataMng._HeroHaveItem_Weapon[i]._ItemName == "warrior_lv10_rare_2")
        //        {
        //            item.ItemInit("warrior_lv10_rare_2", "명화검 & 암화간", "warriorweapon", 2, 142, 170, 150, 20, 0, 0, 10);
        //            item._ItemInfo = "-미첼- 으악! 너무 밝잔아!\r\n-미스틱- 어머? 내가?";
        //        }
        //        item.SetStatRankB();
        //        StaticDataMng._HeroHaveItem_Weapon[i] = item;
        //    }
        //    for (int i = 0; i < StaticDataMng._HeroSetItem_Armor.Count; i++)
        //    {
        //        HeroItem item = new HeroItem();
        //        if (StaticDataMng._HeroSetItem_Armor[i]._ItemName == "armor_lv1_common_1")
        //        {
        //            item.ItemInit("armor_lv1_common_1", "구식 강철 갑옷", "armor", 1, 17, 0, 1, 1, 50, 2, 1);
        //            item._ItemInfo = "-미첼- 아저씨 이런 건 얼마나 있어요?\r\n-라기드- 응? 한 100세트 있나?";
        //        }
        //        else if (StaticDataMng._HeroSetItem_Armor[i]._ItemName == "armor_lv5_common_1")
        //        {
        //            item.ItemInit("armor_lv5_common_1", "쓸만한 미늘 갑옷", "armor", 1, 36, 0, 4, 2, 60, 6, 5);
        //            item._ItemInfo = "";
        //        }
        //        else if (StaticDataMng._HeroSetItem_Armor[i]._ItemName == "armor_lv5_rare_1")
        //        {
        //            item.ItemInit("armor_lv5_rare_1", "디가르의 갑주", "armor", 2, 72, 0, 6, 2, 65, 8, 5);
        //            item._ItemInfo = "-미첼- 이건.. 어떻게 벗겨왔어요?\r\n-라기드- 안 벗겨지길래 그냥 조각냈지";
        //        }
        //        else if (StaticDataMng._HeroSetItem_Armor[i]._ItemName == "armor_lv10_common_1")
        //        {
        //            item.ItemInit("armor_lv10_common_1", "흠집난 티타늄 갑옷", "armor", 1, 78, 0, 5, 3, 70, 8, 10);
        //            item._ItemInfo = "-라기드- 내가 옛날에 이걸 입고 얼마나 대단했는지 알아?";
        //        }
        //        else if (StaticDataMng._HeroSetItem_Armor[i]._ItemName == "armor_lv10_rare_1")
        //        {
        //            item.ItemInit("armor_lv10_rare_1", "로리카", "armor", 2, 106, 0, 7, 4, 80, 10, 10);
        //            item._ItemInfo = "-미첼- 이거.. 치마아니야?";
        //        }
        //        else if (StaticDataMng._HeroSetItem_Armor[i]._ItemName == "armor_lv10_rare_2")
        //        {
        //            item.ItemInit("armor_lv10_rare_2", "쿠야크", "armor", 2, 106, 0, 10, 4, 75, 9, 10);
        //            item._ItemInfo = "-미스틱- 너 거북이 같아";
        //        }
        //        item.SetStatRankB();
        //        StaticDataMng._HeroSetItem_Armor[i] = item;
        //    }
        //    for (int i = 0; i < StaticDataMng._HeroSetItem_Weapon.Count; i++)
        //    {
        //        HeroItem item = new HeroItem();
        //        if (StaticDataMng._HeroSetItem_Weapon[i]._ItemName == "warrior_lv1_common_1")
        //        {
        //            item.ItemInit("warrior_lv1_common_1", "흔한 도검 & 흠집난 방패", "warriorweapon", 1, 23, 5, 2, 1, 0, 0, 1);
        //            item._ItemInfo = "-미첼- 이런 싸구려 검으로 뭘하란 거에요\r\n-라기드- 뭘하긴! 적을 베는 거지!";
        //        }
        //        else if (StaticDataMng._HeroSetItem_Weapon[i]._ItemName == "warrior_lv5_common_1")
        //        {
        //            item.ItemInit("warrior_lv5_common_1", "무딘 장검 & 무딘 방패", "warriorweapon", 1, 44, 9, 4, 2, 0, 0, 5);
        //            item._ItemInfo = "-미첼- 대장장이가 재련하다 졸앗나..";
        //        }
        //        else if (StaticDataMng._HeroSetItem_Weapon[i]._ItemName == "warrior_lv5_rare_1")
        //        {
        //            item.ItemInit("warrior_lv5_rare_1", "디가르의 살육칼날 & 디가르의 전투방패", "warriorweapon", 2, 85, 12, 6, 3, 0, 0, 5);
        //            item._ItemInfo = "-라기드- 정말 무식하게도 생겨 먹었군.\r\n-미첼- 아저씨만 하겠어요?";
        //        }
        //        else if (StaticDataMng._HeroSetItem_Weapon[i]._ItemName == "warrior_lv10_common_1")
        //        {
        //            item.ItemInit("warrior_lv10_common_1", "미완성 도검 & 미완성 방패", "warriorweapon", 1, 112, 15, 9, 3, 0, 0, 10);
        //            item._ItemInfo = "-라기드- 내가 말이야\r\n이걸 어디서 구해왓냐면~";
        //        }
        //        else if (StaticDataMng._HeroSetItem_Weapon[i]._ItemName == "warrior_lv10_rare_1")
        //        {
        //            item.ItemInit("warrior_lv10_rare_1", "혼이 잠긴 검 & 금강방패", "warriorweapon", 2, 142, 18, 10, 11, 0, 0, 10);
        //            item._ItemInfo = "-미스틱- 헉.. 이게 무슨 소리지?\r\n-칸- 정령이 우는 소리라네";
        //        }
        //        else if (StaticDataMng._HeroSetItem_Weapon[i]._ItemName == "warrior_lv10_rare_2")
        //        {
        //            item.ItemInit("warrior_lv10_rare_2", "명화검 & 암화간", "warriorweapon", 2, 142, 17, 15, 2, 0, 0, 10);
        //            item._ItemInfo = "-미첼- 으악! 너무 밝잔아!\r\n-미스틱- 어머? 내가?";
        //        }
        //        item.SetStatRankB();
        //        StaticDataMng._HeroSetItem_Weapon[i] = item;
        //    }
        //    #endregion
        //}
        #endregion 패치 1.1
        GetSkillLevel();
        GetSoldierLevel();

        

        GetPormationInfo();
        
        StaticDataMng._PlayingDead = ReturnIntToBool(PlayerPrefs.GetInt("PlayingDead"));
        StaticDataMng._LastStoryNum = PlayerPrefs.GetInt("LastStoryNum");
        StaticDataMng._LastStageName = PlayerPrefs.GetString("LastStageName");
        StaticDataMng._SoundOn = PlayerPrefs.GetInt("SoundOn");
        StaticDataMng._VibOn = PlayerPrefs.GetInt("VibOn");
        StaticDataMng._HeroExpValue = PlayerPrefs.GetFloat("HeroExp");
        StaticDataMng._HeroMaxExpValue = PlayerPrefs.GetFloat("HeroExpMax");
        StaticDataMng._Gold = PlayerPrefs.GetInt("Gold");
        StaticDataMng._HeroSkillPoint = PlayerPrefs.GetInt("SkillPoint");
        StaticDataMng._HeroLevel = PlayerPrefs.GetInt("HeroLevel");
        StaticDataMng._TeamName = PlayerPrefs.GetString("TeamName");
    }

    void GetSoldierLevel()
    {
        StaticDataMng._Soldier_Warrior_Level = PlayerPrefs.GetInt("Soldier_Warrior_Level");
        StaticDataMng._Soldier_Archer_Level = PlayerPrefs.GetInt("Soldier_Archer_Level");
        StaticDataMng._Soldier_Mage_Level = PlayerPrefs.GetInt("Soldier_Mage_Level");
    }

    void GetSkillLevel()
    {
        StaticDataMng._SkillLevel_Low_4 = PlayerPrefs.GetInt("SkillLevel_Low_4");
        StaticDataMng._SkillLevel_Low_9 = PlayerPrefs.GetInt("SkillLevel_Low_9");
        StaticDataMng._SkillLevel_Low_25 = PlayerPrefs.GetInt("SkillLevel_Low_25");
        StaticDataMng._SkillLevel_Low_49 = PlayerPrefs.GetInt("SkillLevel_Low_49");
        StaticDataMng._SkillLevel_Low_6 = PlayerPrefs.GetInt("SkillLevel_Low_6");
        StaticDataMng._SkillLevel_Low_15 = PlayerPrefs.GetInt("SkillLevel_Low_15");
        StaticDataMng._SkillLevel_Low_35 = PlayerPrefs.GetInt("SkillLevel_Low_35");
        StaticDataMng._SkillLevel_Low_14 = PlayerPrefs.GetInt("SkillLevel_Low_14");
        StaticDataMng._SkillLevel_Low_21 = PlayerPrefs.GetInt("SkillLevel_Low_21");
        StaticDataMng._SkillLevel_Low_10 = PlayerPrefs.GetInt("SkillLevel_Low_10");

        StaticDataMng._SkillLevel_High_4 = PlayerPrefs.GetInt("SkillLevel_High_4");
        StaticDataMng._SkillLevel_High_9 = PlayerPrefs.GetInt("SkillLevel_High_9");
        StaticDataMng._SkillLevel_High_25 = PlayerPrefs.GetInt("SkillLevel_High_25");
        StaticDataMng._SkillLevel_High_49 = PlayerPrefs.GetInt("SkillLevel_High_49");
        StaticDataMng._SkillLevel_High_6 = PlayerPrefs.GetInt("SkillLevel_High_6");
        StaticDataMng._SkillLevel_High_15 = PlayerPrefs.GetInt("SkillLevel_High_15");
        StaticDataMng._SkillLevel_High_35 = PlayerPrefs.GetInt("SkillLevel_High_35");
        StaticDataMng._SkillLevel_High_14 = PlayerPrefs.GetInt("SkillLevel_High_14");
        StaticDataMng._SkillLevel_High_21 = PlayerPrefs.GetInt("SkillLevel_High_21");
        StaticDataMng._SkillLevel_High_10 = PlayerPrefs.GetInt("SkillLevel_High_10");
    }

    void GetStory()
    {
        StaticDataMng._StoryNum = PlayerPrefs.GetInt("StoryNum");
        StaticDataMng._StoryOn = ReturnIntToBool(PlayerPrefs.GetInt("StoryOn"));
        StaticDataMng._StoryWaveOn = ReturnIntToBool(PlayerPrefs.GetInt("StoryWaveOn"));
        StaticDataMng._SelectStageName = PlayerPrefs.GetString("SelectStageName");
        StaticDataMng._StoryScene = PlayerPrefs.GetString("StoryScene");
    }

    bool ReturnIntToBool(int num)
    {
        if (num == 1)
            return true;
        else
            return false;
    }
    void GetQuest()
    {
        if (PlayerPrefs.GetString("MainQuest_Target") != "")
        {
            //Debug.Log("GetMain");
            Quest _quest = new Quest();
            _quest._MainQuest = true;
            _quest._QuestName = PlayerPrefs.GetString("MainQuest_QuestName");
            _quest._Target = PlayerPrefs.GetString("MainQuest_Target");
            _quest._TargetName = PlayerPrefs.GetString("MainQuest_TargetName");
            _quest._QuestType = PlayerPrefs.GetInt("MainQuest_Type");
            _quest._GoalValue = PlayerPrefs.GetInt("MainQuest_GoalValue");
            _quest._NowValue = PlayerPrefs.GetInt("MainQuest_NowValue");
            StaticDataMng._HaveQuestList.Add(_quest);
        }

        for(int i=0;i<2;i++)
        {
            if (PlayerPrefs.GetString("MainQuest_"+i.ToString()+"_Target") != "")
            {
                Quest _quest = new Quest();
                _quest._MainQuest = false;
                _quest._Target = PlayerPrefs.GetString("MainQuest_" + i.ToString() + "_Target");
                _quest._TargetName = PlayerPrefs.GetString("MainQuest_" + i.ToString() + "_TargetName");
                _quest._QuestType = PlayerPrefs.GetInt("MainQuest_" + i.ToString() + "_Type");
                _quest._GoalValue = PlayerPrefs.GetInt("MainQuest_" + i.ToString() + "_GoalValue");
                _quest._NowValue = PlayerPrefs.GetInt("MainQuest_" + i.ToString() + "_NowValue");
                StaticDataMng._HaveQuestList.Add(_quest);
            }
        }
    }

    void GetPormationInfo()
    {
        for (int i = 0; i < 7; i++)
        {
            if (PlayerPrefs.GetInt("PormationIcon_Value_" + i.ToString()) != 0)
            {
                PormationIcon icon = new PormationIcon();
                icon._IconName = PlayerPrefs.GetString("PormationIcon_IconName_" + i.ToString());
                //Debug.Log(PlayerPrefs.GetString("PormationIcon_IconName_" + i.ToString()));
                icon._nowPos.x = PlayerPrefs.GetFloat("PormationIcon_PosX_" + i.ToString());
                icon._nowPos.y = PlayerPrefs.GetFloat("PormationIcon_PosY_" + i.ToString());
                icon._UnitNum = PlayerPrefs.GetInt("PormationIcon_Value_" + i.ToString());
                StaticDataMng._PormationList.Add(icon);
                //if (icon._UnitNum == 1)
                //    StaticDataMng._nowHeroUnitNum++;
                //else
                //    StaticDataMng._nowUnitNum++;
            }
        }
    }
    void GetHaveItem()
    {
        for (int i = 0; i < 16; i++)
        {
            if (PlayerPrefs.GetString("HaveItem_Armor_Name_" + i.ToString()) != "")
            {
                Item_Armor item = new Item_Armor();
                item.ItemSaveGet(PlayerPrefs.GetString("HaveItem_Armor_Name_" + i.ToString()), PlayerPrefs.GetString("HaveItem_Armor_KoreamName_" + i.ToString()),
                PlayerPrefs.GetString("HaveItem_Armor_Type_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_Armor_Rating_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_Armor_Price_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_Armor_AttackPoint_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_Armor_PowerPoint_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_Armor_Intellect_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_Armor_ArmorPoint_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_Armor_HealthPoint_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_Armor_OriginAttackPoint_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_Armor_OriginPowerPoint_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_Armor_OriginIntellect_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_Armor_OriginArmorPoint_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_Armor_OriginHealthPoint_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_Armor_ItemLevel_"+i.ToString()),PlayerPrefs.GetInt("HaveItem_Armor_StatRating_"+i.ToString()));
                item._ItemInfo = PlayerPrefs.GetString("HaveItem_Armor_ItemInfo_" + i.ToString());
                item._ItemKoreanName = PlayerPrefs.GetString("HaveItem_Armor_KoreamName_" + i.ToString());
                StaticDataMng._HeroHaveItem_Armor.Add(item);
            }
            if (PlayerPrefs.GetString("HaveItem_WarriorWeapon_Name_" + i.ToString()) != "")
            {
                Item_WarriorWeapon item = new Item_WarriorWeapon();
                item.ItemSaveGet(PlayerPrefs.GetString("HaveItem_WarriorWeapon_Name_" + i.ToString()), PlayerPrefs.GetString("HaveItem_WarriorWeapon_KoreamName_" + i.ToString()),
                PlayerPrefs.GetString("HaveItem_WarriorWeapon_Type_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_WarriorWeapon_Rating_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_WarriorWeapon_Price_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_WarriorWeapon_AttackPoint_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_WarriorWeapon_PowerPoint_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_WarriorWeapon_Intellect_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_WarriorWeapon_ArmorPoint_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_WarriorWeapon_HealthPoint_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_WarriorWeapon_OriginAttackPoint_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_WarriorWeapon_OriginPowerPoint_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_WarriorWeapon_OriginIntellect_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_WarriorWeapon_OriginArmorPoint_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_WarriorWeapon_OriginHealthPoint_" + i.ToString()),
                PlayerPrefs.GetInt("HaveItem_WarriorWeapon_ItemLevel_" + i.ToString()), PlayerPrefs.GetInt("HaveItem_WarriorWeapon_StatRating_" + i.ToString()));
                item._ItemInfo = PlayerPrefs.GetString("HaveItem_WarriorWeapon_ItemInfo_" + i.ToString());
                item._ItemKoreanName = PlayerPrefs.GetString("HaveItem_WarriorWeapon_KoreamName_" + i.ToString());
                StaticDataMng._HeroHaveItem_Weapon.Add(item);
            }
        }
    }

    void GetSetItem()
    {
            if (PlayerPrefs.GetString("SetItem_Armor_Name_0") != "")
            {
                Item_Armor item = new Item_Armor();
                item.ItemSaveGet(PlayerPrefs.GetString("SetItem_Armor_Name_0"), PlayerPrefs.GetString("SetItem_Armor_KoreamName_0"),
                PlayerPrefs.GetString("SetItem_Armor_Type_0"), PlayerPrefs.GetInt("SetItem_Armor_Rating_0"),
                PlayerPrefs.GetInt("SetItem_Armor_Price_0"), PlayerPrefs.GetInt("SetItem_Armor_AttackPoint_0"),
                PlayerPrefs.GetInt("SetItem_Armor_PowerPoint_0"), PlayerPrefs.GetInt("SetItem_Armor_Intellect_0"),
                PlayerPrefs.GetInt("SetItem_Armor_ArmorPoint_0"), PlayerPrefs.GetInt("SetItem_Armor_HealthPoint_0"),
                PlayerPrefs.GetInt("HaveItem_Armor_OriginAttackPoint_0"),
                PlayerPrefs.GetInt("HaveItem_Armor_OriginPowerPoint_0"), PlayerPrefs.GetInt("HaveItem_Armor_OriginIntellect_0"),
                PlayerPrefs.GetInt("HaveItem_Armor_OriginArmorPoint_0"), PlayerPrefs.GetInt("HaveItem_Armor_OriginHealthPoint_0"),
                PlayerPrefs.GetInt("SetItem_Armor_ItemLevel_0"), PlayerPrefs.GetInt("HaveItem_Armor_StatRating_0"));
                item._ItemInfo = PlayerPrefs.GetString("SetItem_Armor_ItemInfo_0");
                item._ItemKoreanName = PlayerPrefs.GetString("SetItem_Armor_KoreamName_0");
                StaticDataMng._HeroSetItem_Armor.Add(item);
            }
            if (PlayerPrefs.GetString("SetItem_WarriorWeapon_Name_0") != "")
            {
                Item_WarriorWeapon item = new Item_WarriorWeapon();
                item.ItemSaveGet(PlayerPrefs.GetString("SetItem_WarriorWeapon_Name_0"), PlayerPrefs.GetString("SetItem_WarriorWeapon_KoreamName_0"),
                PlayerPrefs.GetString("SetItem_WarriorWeapon_Type_0"), PlayerPrefs.GetInt("SetItem_WarriorWeapon_Rating_0"),
                PlayerPrefs.GetInt("SetItem_WarriorWeapon_Price_0"), PlayerPrefs.GetInt("SetItem_WarriorWeapon_AttackPoint_0"),
                PlayerPrefs.GetInt("SetItem_WarriorWeapon_PowerPoint_0"), PlayerPrefs.GetInt("SetItem_WarriorWeapon_Intellect_0"),
                PlayerPrefs.GetInt("SetItem_WarriorWeapon_ArmorPoint_0"), PlayerPrefs.GetInt("SetItem_WarriorWeapon_HealthPoint_0"),
                PlayerPrefs.GetInt("HaveItem_WarriorWeapon_OriginAttackPoint_0"),
                PlayerPrefs.GetInt("HaveItem_WarriorWeapon_OriginPowerPoint_0"), PlayerPrefs.GetInt("HaveItem_WarriorWeapon_OriginIntellect_0"),
                PlayerPrefs.GetInt("HaveItem_WarriorWeapon_OriginArmorPoint_0"), PlayerPrefs.GetInt("HaveItem_WarriorWeapon_OriginHealthPoint_0"),
                PlayerPrefs.GetInt("SetItem_WarriorWeapon_ItemLevel_0"), PlayerPrefs.GetInt("HaveItem_WarriorWeapon_StatRating_0"));
                item._ItemInfo = PlayerPrefs.GetString("SetItem_WarriorWeapon_ItemInfo_0");
                item._ItemKoreanName = PlayerPrefs.GetString("SetItem_WarriorWeapon_KoreamName_0");
                StaticDataMng._HeroSetItem_Weapon.Add(item);
            }
        }
}
