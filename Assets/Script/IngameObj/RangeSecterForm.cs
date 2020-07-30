using UnityEngine;
using System.Collections;

public class RangeSecterForm : MonoBehaviour
{
    public RangeNoneTargetUpdate _UpdateMng;
    public GameObject _Parent;
    public GameObject _Skill_1_IceArrow;
    public GameObject _SandDustEffect;
    public GameObject _FogDustEffect;


    void Update()
    {
        transform.localPosition = GameMng.Data._GameDate._HeroUnit.transform.localPosition;
        double pointX = getAngle(new Vector2(GameMng.Data._GameDate._HeroUnit.transform.localPosition.x, GameMng.Data._GameDate._HeroUnit.transform.localPosition.y), new Vector2(Input.mousePosition.x * (1280.0f / Screen.width), Input.mousePosition.y * (720.0f / Screen.height)));

        //if (pointX >= 90)
        //    pointX = 90.0;
        //if (pointX <= -90)
        //    pointX = -90.0;
        transform.localEulerAngles = new Vector3(0, 0, -(float)pointX);
        if (Input.GetMouseButtonUp(0) == true)
        {
            _ShootSkill();
            gameObject.SetActive(false);
            GameMng.Data._GameDate._touchScene = false;
        }
    }

    void _ShootSkill()
    {
        switch (GameMng.Data._SkillName)
        {
            case "warrior_21_low":
                {
                    GameObject skill = NGUITools.AddChild(_Parent, _Skill_1_IceArrow);
                    skill.GetComponent<Skill_SecterForm>()._init(GameMng.Data._GameDate._HeroUnit, gameObject.transform.localEulerAngles, transform.localPosition, 1, 0, 1, 80, true, 9);
                    GameMng.Data._GameDate._SkillList.Add(skill.GetComponent<Skill_SecterForm>());
                    break;
                }
            case "warrior_35_low":
                {
                    GameObject skill = NGUITools.AddChild(_Parent, _SandDustEffect);
                    skill.GetComponent<Skill_SecterForm>()._init(GameMng.Data._GameDate._HeroUnit, gameObject.transform.localEulerAngles+new Vector3(0,0,90), transform.localPosition, 1, 0, 1, 1, true, 25);
                    skill.GetComponent<Skill_SecterForm>()._RectBuff = true;
                    skill.GetComponent<Skill_SecterForm>()._BuffType_R = 7;
                    skill.GetComponent<Skill_SecterForm>()._BuffTime_R = 2.0f;
                    skill.GetComponent<Skill_SecterForm>()._BuffNum_R = -40;
                    GameMng.Data._GameDate._SkillList.Add(skill.GetComponent<Skill_SecterForm>());

                    GameMng.Data._GameDate._HeroUnit.GetComponent<Unit>().SetSprite_SkillShot(7, 5);
                    break;
                }
            case "warrior_6_low":
                {
                    GameObject skill = NGUITools.AddChild(_Parent, _FogDustEffect);
                    skill.GetComponent<Skill_SecterForm>()._init(GameMng.Data._GameDate._HeroUnit, gameObject.transform.localEulerAngles + new Vector3(0, 0, 90), transform.localPosition, 1, 0, 1, 1, true, 9);
                    skill.GetComponent<Skill_SecterForm>()._RectBuff = true;
                    skill.GetComponent<Skill_SecterForm>()._BuffType_R = 7;
                    skill.GetComponent<Skill_SecterForm>()._BuffTime_R = 2.0f;
                    skill.GetComponent<Skill_SecterForm>()._BuffNum_R = -40;
                    GameMng.Data._GameDate._SkillList.Add(skill.GetComponent<Skill_SecterForm>());

                    GameMng.Data._GameDate._HeroUnit.GetComponent<Unit>().SetSprite_SkillShot(9, 4);

                    _UpdateMng.SetFogLushImage();
                    break;
                }
        }
    }
    private static double getAngle(Vector2 pos1, Vector2 pos2)
    {
        float dx = pos2.x - pos1.x;
        float dy = pos2.y - pos1.y;

        double rad = Mathf.Atan2(dx, dy);
        double degree = (rad * 180) / Mathf.PI;

        return degree;
    }
}
