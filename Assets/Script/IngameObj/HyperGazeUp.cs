using UnityEngine;
using System.Collections;

public class HyperGazeUp : MonoBehaviour {

    public int _Value;
	void Start()
    {
        int nowvalue = GameMng.Data._HyperSkillMng._HeroHyperValue;
        GameMng.Data._HyperSkillMng._HeroHyperValue +=_Value;
        if(GameMng.Data._HyperSkillMng._HeroHyperValue>=100&&nowvalue<100)
            GameMng.Data._HyperSkillMng.FullEffectAction();
    }
}
