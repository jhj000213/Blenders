using UnityEngine;
using System.Collections;

public class LastStoryPlayMng : MonoBehaviour
{

    public GameObject _LastStoryPopup;
    public string _LastStageName;

    void Start()
    {
        if (StaticDataMng._PlayingDead)
        {
            _LastStoryPopup.SetActive(true);
            _LastStageName = StaticDataMng._LastStageName;
        }
    }

    public void StartLastStory()
    {
        if (StaticDataMng._PlayingDead && StaticDataMng._LastStageName==StaticDataMng._SelectStageName)
        {
            StaticDataMng._StoryOn = true;
            StaticDataMng._StoryWaveOn = true;
            StaticDataMng._StoryWaveOn_Save = false;
            StaticDataMng._LastStageName = "";
            StaticDataMng._StoryNum = StaticDataMng._LastStoryNum;
            StaticDataMng._LastStoryNum=0;
            StaticDataMng._PlayingDead = false;
        }
    }
}
