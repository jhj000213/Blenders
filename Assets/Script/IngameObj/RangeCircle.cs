using UnityEngine;
using System.Collections;

public class RangeCircle : MonoBehaviour
{

    public GameObject _GameRoot;
    public GameObject _Skill_1_FireSwordDrop;

    public int _SkillNum;

    void Update()
    {
        transform.localPosition = new Vector2(Input.mousePosition.x * (1280.0f / Screen.width), Input.mousePosition.y * (720.0f / Screen.height));


        if (Input.GetMouseButtonUp(0) == true)
        {
            _ShootSkill();
            gameObject.SetActive(false);
            GameMng.Data._GameDate._touchScene = false;
        }
    }

    void _ShootSkill()
    {
        //switch(GameMng.Data._SkillName)
        //{
        //    case 1:
        //        {
        GameObject skill = NGUITools.AddChild(_GameRoot, _Skill_1_FireSwordDrop);
        skill.transform.Find("FireSwordEffect").GetComponent<Skill_Circle>()._init(GameMng.Data._GameDate._HeroUnit, transform.localPosition, 1, 0, 1, StaticDataMng._FireSkill_High_First[StaticDataMng._SkillLevel_High_4 - 1], 4);
        skill.transform.Find("BoomCollider").GetComponent<Skill_Circle>()._ParentUnit = GameMng.Data._GameDate._HeroUnit;
        skill.transform.Find("BoomCollider").GetComponent<Skill_Circle>()._Damage = StaticDataMng._FireSkill_High_Second[StaticDataMng._SkillLevel_High_4 - 1];
        GameMng.Data._GameDate._SkillList.Add(skill.GetComponent<Skill_Circle>());

        GameMng.Data._GameDate._HeroUnit.GetComponent<Unit>().SetSprite_SkillShot(1,6);
        //break;
        //}
        //}
    }
}
