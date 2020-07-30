using UnityEngine;
using System.Collections;
using GooglePlayGames;

public class ClearAchevementMng : MonoBehaviour
{
    public int _HyperSkillUse;

    void Start()
    {
        _HyperSkillUse = 0;
    }

    public void ShowAchievement()
    {
        Social.ShowAchievementsUI();
    }

    void Update()
    {

        if(StaticDataMng._OnlyElementClear>=3)
        {
            postAchievement("CgkIkdytgOoMEAIQBA");
        }
        if(StaticDataMng._OnlySoldier_A_Clear>=3)
        {
            postAchievement("CgkIkdytgOoMEAIQAg");
        }
        if(StaticDataMng._OnlySoldier_W_Clear>=3)
        {
            postAchievement("CgkIkdytgOoMEAIQAQ");
        }
        if(StaticDataMng._In30SecondClear>=3)
        {
            postAchievement("CgkIkdytgOoMEAIQBQ");
        }
        if(_HyperSkillUse>=2)
        {
            postAchievement("CgkIkdytgOoMEAIQAw");
        }
    }


    private void postAchievement(string key)
    {
        if (PlayerPrefs.GetInt(key) == 0)
        {
            Social.ReportProgress(key, 100, (bool success) =>
            {
                if (success)
                {
                    PlayerPrefs.SetInt(key, 1);
                }
            });
        }

    }

}
