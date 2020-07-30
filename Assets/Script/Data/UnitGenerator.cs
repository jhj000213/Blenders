using UnityEngine;
using System.Collections;

public class UnitGenerator : MonoBehaviour {

    public GameObject _GameRoot;
    public GameObject _Parent;
    public GameObject _Unit;
    public GameObject _HPBar;
    public GameObject _GroundBarrior;

    public GameObject _IceFiled;
    public GameObject _SteamFiled;

    public StoryActionMng _StoryActionMng;

    void Start()
    {
        if(StaticDataMng._StoryOn)
            GameMng.Data._MosnterWaveMng._WaveOn = false;
        else
            GameMng.Data._MosnterWaveMng._WaveOn = true;

        if(!StaticDataMng._Tutorial)//temp
        {
            
            for (int i = 0; i < StaticDataMng._PormationList.Count; i++)
            {
                int rating = 1;
                int type = 1;
                int hp = 0;
                int damage = 0;
                float movespeed = 0.0f;
                Vector2 pos = new Vector2();
                if (StaticDataMng._PormationList[i]._UnitNum == 1)
                {
                    rating = 4;
                    type = 1;
                    
                    
                }
                else if (StaticDataMng._PormationList[i]._UnitNum == 2)
                {
                    rating = 3;
                    type = 1;

                    hp = StaticDataMng._Soldier_W_HP[StaticDataMng._Soldier_Warrior_Level - 1];//hp계산
                    damage = StaticDataMng._Soldier_W_Damage[StaticDataMng._Soldier_Warrior_Level - 1];//damage계산
                    movespeed = 220.0f;
                }
                else if (StaticDataMng._PormationList[i]._UnitNum == 3)
                {
                    rating = 3;
                    type = 2;

                    hp = StaticDataMng._Soldier_A_HP[StaticDataMng._Soldier_Archer_Level - 1];//hp계산
                    damage = StaticDataMng._Soldier_A_Damage[StaticDataMng._Soldier_Archer_Level - 1];//damage계산
                    movespeed = 120.0f;

                }
                else if (StaticDataMng._PormationList[i]._UnitNum == 4)
                {
                    rating = 3;
                    type = 3;

                    hp = StaticDataMng._Soldier_M_HP[StaticDataMng._Soldier_Mage_Level - 1];//hp계산
                    damage = StaticDataMng._Soldier_M_Damage[StaticDataMng._Soldier_Mage_Level - 1];//damage계산
                    movespeed = 250.0f;

                }
                pos.x = ((StaticDataMng._PormationList[i]._nowPos.x - 257) / 627) * 1280;
                pos.y = (((StaticDataMng._PormationList[i]._nowPos.y - 74) / 349) * 395) + 90;
                MakeUnit(rating, type, pos, hp, damage, movespeed);


                
            }
        }
        else
        {
            MakeUnit(3, 1, new Vector2(180, 161), StaticDataMng._Soldier_W_HP[StaticDataMng._Soldier_Warrior_Level - 1], StaticDataMng._Soldier_W_Damage[StaticDataMng._Soldier_Warrior_Level - 1], 220.0f);
            MakeUnit(3, 1, new Vector2(230, 240), StaticDataMng._Soldier_W_HP[StaticDataMng._Soldier_Warrior_Level - 1], StaticDataMng._Soldier_W_Damage[StaticDataMng._Soldier_Warrior_Level - 1], 220.0f);
            MakeUnit(3, 1, new Vector2(230, 400), StaticDataMng._Soldier_W_HP[StaticDataMng._Soldier_Warrior_Level - 1], StaticDataMng._Soldier_W_Damage[StaticDataMng._Soldier_Warrior_Level - 1], 220.0f);
            MakeUnit(3, 1, new Vector2(180, 480), StaticDataMng._Soldier_W_HP[StaticDataMng._Soldier_Warrior_Level - 1], StaticDataMng._Soldier_W_Damage[StaticDataMng._Soldier_Warrior_Level - 1], 220.0f);
            MakeUnit(3, 2, new Vector2(100, 220), StaticDataMng._Soldier_A_HP[StaticDataMng._Soldier_Archer_Level - 1], StaticDataMng._Soldier_A_Damage[StaticDataMng._Soldier_Archer_Level - 1], 120.0f);
            MakeUnit(3, 2, new Vector2(100, 420), StaticDataMng._Soldier_A_HP[StaticDataMng._Soldier_Archer_Level - 1], StaticDataMng._Soldier_A_Damage[StaticDataMng._Soldier_Archer_Level - 1], 120.0f);
            
            
            MakeUnit(4, 1, new Vector2(300,320),0,0,300.0f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            MakeMosnter();
    }

    public void MakeMosnter()
    {
        //MakeUnit(1, 2, new Vector2(1080, 144));
        //MakeUnit(1, 2, new Vector2(1180, 288));
        //MakeUnit(1, 2, new Vector2(1180, 432));
        //MakeUnit(1, 2, new Vector2(1080, 576));
        //MakeUnit(1, 2, new Vector2(1200, 360));
    }
    public void MakeSoldier()
    {
        //MakeUnit(3, 1, new Vector2(150, 144));
        //MakeUnit(3, 1, new Vector2(200, 288));
        //MakeUnit(3, 1, new Vector2(200, 432));
        //MakeUnit(3, 1, new Vector2(150, 576));
    }

    IEnumerator MakeUnit_Delay(float time, int rating, int type, Vector2 pos, int hp, int damage, float movespeed)
    {
        yield return new WaitForSeconds(time);

        MakeUnit(rating, type, pos,hp,damage,movespeed);
    }
    
    public void MakeUnit(int rating,int type,Vector2 Pos,int hp,int damage,float movespeed)
    {
        GameObject unit = NGUITools.AddChild(_Parent, _Unit);
        Unit obj = unit.GetComponent<Unit>();
        obj.SetInitValue(hp*10, damage*10, movespeed);
        obj._Rating = rating;
        obj._Type = type;
        //unit.GetComponent<UISprite>().pivot = UIWidget.Pivot.Bottom;
        obj._startPos = Pos;
        if (rating <= 2)
            GameMng.Data._GameDate._EnemyUnitList.Add(obj);
        if (rating == 3)
            GameMng.Data._GameDate._SoldierUnitList.Add(obj);
        if(rating==4)
        {
            GameObject barrior = NGUITools.AddChild(obj.gameObject, _GroundBarrior);
            obj._GroundBarrior = barrior;
            obj._GroundBarrior.SetActive(false);
            GameMng.Data._GameDate._HeroUnit = obj;
            obj.GetComponent<UISprite>().depth = 10;

            GameObject zone1 = NGUITools.AddChild(unit, _IceFiled);
            zone1.SetActive(false);
            GameObject zone2 = NGUITools.AddChild(unit, _SteamFiled);
            zone2.SetActive(false);
            obj._IceFiledZone = zone1;
            obj._SteamFiledZone = zone2;
            
            if (type == 1)
                GameMng.Data._GameDate._SoldierUnitList.Add(obj);
        }
        

        if(rating!=4)
        {
            GameObject hpb = NGUITools.AddChild(unit, _HPBar);
        }
    }
    public void MakeUnit_StoryMainTarget(int rating, int type, Vector2 Pos, bool boss, int hp, int damage, float movespeed)
    {
        GameObject unit = NGUITools.AddChild(_Parent, _Unit);
        Unit obj = unit.GetComponent<Unit>();
        obj.SetInitValue(hp * 10, damage * 10, movespeed);
        obj._Rating = rating;
        obj._Type = type;
        //unit.GetComponent<UISprite>().pivot = UIWidget.Pivot.Bottom;
        obj._startPos = Pos;
        if (rating <= 2)
            GameMng.Data._GameDate._EnemyUnitList.Add(obj);
        if (rating == 3)
            GameMng.Data._GameDate._SoldierUnitList.Add(obj);
        if (rating == 4)
        {
            GameMng.Data._GameDate._HeroUnit = obj;
            obj.GetComponent<UISprite>().depth = 10;
            if (type == 1)
                GameMng.Data._GameDate._SoldierUnitList.Add(obj);
        }
        if (rating != 4)
        {
            GameObject hpb = NGUITools.AddChild(unit, _HPBar);
        }
        _StoryActionMng._MainEnemy = obj;
        if(boss)
        {
            GameMng.Data._MosnterWaveMng._BossMosnter = obj;
            _StoryActionMng.BossWaring();
        }
    }

    public void MakeUnit_Boss(int rating, int type, Vector2 Pos, int hp, int damage, float movespeed)
    {
        GameObject unit = NGUITools.AddChild(_Parent, _Unit);
        Unit obj = unit.GetComponent<Unit>();
        obj.SetInitValue(hp * 10, damage * 10, movespeed);
        obj._Rating = rating;
        obj._Type = type;
        //unit.GetComponent<UISprite>().pivot = UIWidget.Pivot.Bottom;
        obj._startPos = Pos;
        if (rating <= 2)
            GameMng.Data._GameDate._EnemyUnitList.Add(obj);
        if (rating == 3)
            GameMng.Data._GameDate._SoldierUnitList.Add(obj);
        if (rating == 4)
        {
            GameMng.Data._GameDate._HeroUnit = obj;
            obj.GetComponent<UISprite>().depth = 10;
            if (type == 1)
                GameMng.Data._GameDate._SoldierUnitList.Add(obj);
        }
            GameObject hpb = NGUITools.AddChild(unit, _HPBar);
        GameMng.Data._MosnterWaveMng._BossMosnter = obj;
        _StoryActionMng.BossWaring();
    }
}