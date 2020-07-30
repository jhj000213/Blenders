using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeNoneTargetUpdate : MonoBehaviour {

    List<Unit> _SandtargetUnit = new List<Unit>();
    public GameObject[] _SandAfterImage;
    public GameObject _FogLush;

    public void SetSandAfterImage(List<Unit> targetlist)
    {
        _SandtargetUnit = targetlist;
        
        if (_SandtargetUnit.Count != 0)
        {
            StartCoroutine(AddAfterImage(0.625f));
        }
        StartCoroutine(SetHeroAlpha(0.625f + _SandtargetUnit.Count * 0.3f, true));
        StartCoroutine(SetHeroAlpha(0.625f, false));
        GameMng.Data._GameDate._HeroUnit.SetCantTarget_False(0.625f + _SandtargetUnit.Count * 0.3f);
    }

    public void SetFogLushImage()
    {
        StartCoroutine(StartFogLush(0.5f));
    }

    IEnumerator StartFogLush(float time)
    {
        yield return new WaitForSeconds(time);

        float angle = 0.0f;
        if (GameMng.Data._GameDate._EnemyUnitList.Count != 0)
        {
            Unit target = GameMng.Data._GameDate._EnemyUnitList[0];
            for (int i = 1; i < GameMng.Data._GameDate._EnemyUnitList.Count; i++)
            {
                if (target._Rating < GameMng.Data._GameDate._EnemyUnitList[i]._Rating)
                {
                    target = GameMng.Data._GameDate._EnemyUnitList[i];
                }
                else if (target._Rating == GameMng.Data._GameDate._EnemyUnitList[i]._Rating && target._HP <= GameMng.Data._GameDate._EnemyUnitList[i]._HP)
                {
                    target = GameMng.Data._GameDate._EnemyUnitList[i];
                }

            }
            angle = Mathf.Atan2(target._getPosition().y - GameMng.Data._GameDate._HeroUnit.transform.localPosition.y, target._getPosition().x - GameMng.Data._GameDate._HeroUnit.transform.localPosition.x);

        }
        else
        {
            angle = Mathf.Atan2(0, 90);
        }
        float seta = angle;
        float x = Mathf.Cos(seta) * (float)(400);
        float y = Mathf.Sin(seta) * (float)(400);



        GameObject skill = NGUITools.AddChild(GameMng.Data._GameDate._HeroUnit.gameObject, _FogLush);
        skill.transform.localPosition = new Vector3(0, 80, 0);
        skill.GetComponent<Skill_Circle>()._init(GameMng.Data._GameDate._HeroUnit, GameMng.Data._GameDate._HeroUnit.transform.localPosition, 1, 0, 1, 1.5f, 9);
        skill.GetComponent<Skill_Circle>()._CCType = 2;
        skill.GetComponent<Skill_Circle>()._CCTime = 0.2f;
        skill.transform.localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg - 90);

        GameMng.Data._GameDate._HeroUnit.SetSkillAction(0.6f);
        GameMng.Data._GameDate._HeroUnit.have.o_List.Clear();
        GameMng.Data._GameDate._HeroUnit.SetMoveAction(x, y, 0.6f);

        GameMng.Data._GameDate._SkillList.Add(skill.GetComponent<Skill_Circle>());
    }

    IEnumerator SetHeroAlpha(float time, bool value)
    {
        yield return new WaitForSeconds(time);


        GameMng.Data._GameDate._HeroUnit._SpriteOn = value;
    }

    IEnumerator AddAfterImage(float time)
    {
        yield return new WaitForSeconds(time);
        if (_SandtargetUnit.Count != 0)
        {
            Unit target = _SandtargetUnit[0];
            _SandtargetUnit.RemoveAt(0);

            StartCoroutine(AddAfterImage_Effect(0.0f, target, 1));
            StartCoroutine(AddAfterImage_Effect(0.07f, target, -1));
            StartCoroutine(AddAfterImage_Effect(0.14f, target, 1));
            StartCoroutine(AddAfterImage_Effect(0.21f, target, -1));
            StartCoroutine(AddAfterImage_Effect(0.28f, target, 1));

            StartCoroutine(AddAfterImage(0.3f));
        }
        else
        {

        }
    }

    IEnumerator AddAfterImage_Effect(float time, Unit parent, int value)
    {
        yield return new WaitForSeconds(time);

        int randnum = Random.Range(0, 3);
        if (parent != null)
        {
            parent.DmgCalculation(0.5f, GameMng.Data._GameDate._HeroUnit, parent, false, true, 0);
            parent.EffectCreate(GameMng.Data._GameDate._Parent, GameMng.Data._EffectAnimation._AfterHitEffect, parent.gameObject,false,new Vector2(Random.Range(-30.0f,30.0f),Random.Range(-50.0f,50.0f)));
            GameObject obj = NGUITools.AddChild(parent.gameObject, _SandAfterImage[randnum]);
            obj.transform.localPosition = new Vector3(0, parent.GetComponent<UISprite>().height / 2, 0);
            obj.transform.localPosition += new Vector3(Random.Range(-40.0f, 20.0f), Random.Range(-100.0f, 100.0f), 0);
            obj.transform.localScale = new Vector3(value, 1, 1);
        }

    }
}
