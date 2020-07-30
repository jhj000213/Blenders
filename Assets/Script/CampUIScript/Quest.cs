using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

    public bool _MainQuest;
    public string _QuestName;
    public string _Target;

    public string _TargetName;

    public int _QuestType;
    public int _GoalValue;
    public int _NowValue;


    public void Init(string questname,string targetstring,string targetname,int type,int goalvalue,bool mainquset)
    {
        _QuestName = questname;  
        _MainQuest = mainquset;
        _Target = targetstring;
        _QuestType = type;
        _GoalValue = goalvalue;
        _NowValue = 0;
        _TargetName = targetname;
    }

    public void QuestValuePlus()
    {
        if (_NowValue < _GoalValue)
            _NowValue++;
    }

    public bool QuestClear()
    {
        if (_NowValue >= _GoalValue)
            return true;
        else
            return false;
    }
}
