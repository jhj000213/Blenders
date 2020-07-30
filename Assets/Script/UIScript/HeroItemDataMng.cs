using UnityEngine;
using System.Collections;

public class HeroItemDataMng : MonoBehaviour
{
    void Start()
    {
        WeaponList();
        ArmorList();
    }

    void WeaponList()
    {
        {
            Item_WarriorWeapon item = new Item_WarriorWeapon();
            item.ItemInit("warrior_lv1_common_1","흔한 도검 & 흠집난 방패","warriorweapon", 1, 23, 50, 20, 10, 0, 0,1);
            item._ItemInfo = "-미첼- 이런 싸구려 검으로 뭘하란 거에요\r\n-라기드- 뭘하긴! 적을 베는 거지!";
            StaticDataMng._AllHeroItemList_Common.Add(item);
        }
        {
            Item_WarriorWeapon item = new Item_WarriorWeapon();
            item.ItemInit("warrior_lv5_common_1", "무딘 장검 & 무딘 방패", "warriorweapon", 1, 44, 90, 40, 20, 0, 0,5);
            item._ItemInfo = "-미첼- 대장장이가 재련하다 졸앗나..";
            StaticDataMng._AllHeroItemList_Common.Add(item);
        }
        {
            Item_WarriorWeapon item = new Item_WarriorWeapon();
            item.ItemInit("warrior_lv5_rare_1", "디가르의 살육칼날 & 디가르의 전투방패", "warriorweapon", 2, 85, 120, 60, 30, 0, 0,5);
            item._ItemInfo = "-라기드- 정말 무식하게도 생겨 먹었군.\r\n-미첼- 아저씨만 하겠어요?"; 
            StaticDataMng._AllHeroItemList_Rare.Add(item);
        }
        {
            Item_WarriorWeapon item = new Item_WarriorWeapon();
            item.ItemInit("warrior_lv10_common_1", "미완성 도검 & 미완성 방패", "warriorweapon", 1, 112, 150, 90, 30, 0, 0,10);
            item._ItemInfo = "-라기드- 내가 말이야\r\n이걸 어디서 구해왓냐면~"; 
            StaticDataMng._AllHeroItemList_Common.Add(item);
        }
        {
            Item_WarriorWeapon item = new Item_WarriorWeapon();
            item.ItemInit("warrior_lv10_rare_1", "혼이 잠긴 검 & 금강방패", "warriorweapon", 2, 142, 180, 100, 110, 0, 0,10);
            item._ItemInfo = "-미스틱- 헉.. 이게 무슨 소리지?\r\n-칸- 정령이 우는 소리라네"; 
            StaticDataMng._AllHeroItemList_Rare.Add(item);
        }
        {
            Item_WarriorWeapon item = new Item_WarriorWeapon();
            item.ItemInit("warrior_lv10_rare_2", "명화검 & 암화간", "warriorweapon", 2, 142, 170, 150, 20, 0, 0,10);
            item._ItemInfo = "-미첼- 으악! 너무 밝잔아!\r\n-미스틱- 어머? 내가?"; 
            StaticDataMng._AllHeroItemList_Rare.Add(item);
        }
    }
    void ArmorList()
    {
        {
            Item_Armor item = new Item_Armor();
            item.ItemInit("armor_lv1_common_1", "구식 강철 갑옷", "armor", 1, 17, 0, 10, 10, 500, 20,1);
            item._ItemInfo = "-미첼- 아저씨 이런 건 얼마나 있어요?\r\n-라기드- 응? 한 100세트 있나?";
            StaticDataMng._AllHeroItemList_Common.Add(item);
        }
        {
            Item_Armor item = new Item_Armor();
            item.ItemInit("armor_lv5_common_1", "쓸만한 미늘 갑옷", "armor", 1, 36, 0, 40, 20, 600, 60,5);
            item._ItemInfo = "";
            StaticDataMng._AllHeroItemList_Common.Add(item);
        }
        {
            Item_Armor item = new Item_Armor();
            item.ItemInit("armor_lv5_rare_1", "디가르의 갑주", "armor", 2, 72, 0, 60, 20, 650, 80,5);
            item._ItemInfo = "-미첼- 이건.. 어떻게 벗겨왔어요?\r\n-라기드- 안 벗겨지길래 그냥 조각냈지";
            StaticDataMng._AllHeroItemList_Rare.Add(item);
        }
        {
            Item_Armor item = new Item_Armor();
            item.ItemInit("armor_lv10_common_1", "흠집난 티타늄 갑옷", "armor", 1, 78, 0, 50, 30, 700, 80,10);
            item._ItemInfo = "-라기드- 내가 옛날에 이걸 입고 얼마나 대단했는지 알아?";
            StaticDataMng._AllHeroItemList_Common.Add(item);
        }
        {
            Item_Armor item = new Item_Armor();
            item.ItemInit("armor_lv10_rare_1", "로리카", "armor", 2, 106, 0, 70, 40, 800, 100,10);
            item._ItemInfo = "-미첼- 이거.. 치마아니야?";
            StaticDataMng._AllHeroItemList_Rare.Add(item);
        }
        {
            Item_Armor item = new Item_Armor();
            item.ItemInit("armor_lv10_rare_2", "쿠야크", "armor", 2, 106, 0, 100, 40, 750, 90,10);
            item._ItemInfo = "-미스틱- 너 거북이 같아";
            StaticDataMng._AllHeroItemList_Rare.Add(item);
        }
    }
}
