using UnityEngine;
using System.Collections;

public class ElementleBallClick : MonoBehaviour {

    public int _zero = 0;
    public int _one = 1;
    public int _two = 2;
    public int _three = 3;

    

    
    public int _Fire_Origin = 4;
    public int _Water_Origin = 9;
    public int _Ground_Origin = 25;
    public int _Air_Origin = 49;
    public int _Fog_Origin = 6;
    public int _Mud_Origin = 15;
    public int _Sand_Origin = 35;
    public int _Flame_Origin = 14;
    public int _Ice_Origin = 21;
    public int _Rock_Origin = 10;

    public int _SelectNumber;

    public void AddElementBall(int num)
    {
        if (!GameMng.Data._CreativeTable._NowCreativing)
        {
            if (GameMng.Data._CreativeTable._BallList.Count == 3) 
            {
                //if ((GameMng.Data._CreativeTable._ElementList[0] == GameMng.Data._CreativeTable._ElementList[1] ||
                //GameMng.Data._CreativeTable._ElementList[0] == GameMng.Data._CreativeTable._ElementList[2] ||
                //GameMng.Data._CreativeTable._ElementList[1] == GameMng.Data._CreativeTable._ElementList[2] ||
                //GameMng.Data._CreativeTable._ElementList[0]==num||
                //GameMng.Data._CreativeTable._ElementList[1]==num||
                //GameMng.Data._CreativeTable._ElementList[2]==num))
                //{
                    GameMng.Data._CreativeTable.AddBall(num);

                //}
                //else
                //{
                //    GameObject obj = NGUITools.AddChild(GameMng.Data._CreativeTable._AlarmParent, GameMng.Data._CreativeTable._DoneAddBallLabel);
                //    obj.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                //    obj.transform.localPosition = new Vector3(0, -135, 0);
                //}
            }
            else
            {
                GameMng.Data._CreativeTable.AddBall(num);
            }
            
        }
    }

    public void SetElementSelectTable(int elenum)
    {
        if (!GameMng.Data._CreativeTable._NowSelecting)
            GameMng.Data._CreativeTable.CreateSkill_Select_Class(elenum);
    }
}
