using UnityEngine;
using System.Collections;

public class Boss_GameClear : MonoBehaviour {

	void Start()
    {
        if (GameMng.Data._QuestMng._HaveMainQuest.Count != 0)
        {
            if (GameMng.Data._QuestMng._HaveMainQuest[0]._QuestName == "불타는 숲 소탕" && GameMng.Data._QuestMng._HaveMainQuest[0]._NowValue == 4 && StaticDataMng._SelectStageName=="불타는 숲")
                GameMng.Data._BossKill = false;
            else if (GameMng.Data._QuestMng._HaveMainQuest[0]._QuestName == "크나큰 충격" && GameMng.Data._QuestMng._HaveMainQuest[0]._NowValue == 1 && StaticDataMng._SelectStageName=="설산")
                GameMng.Data._BossKill = false;
            else
                GameMng.Data._BossKill = true;


        }
        else
            GameMng.Data._BossKill = true;
    }
}
