using UnityEngine;
using System.Collections;

public class RangeArrow : MonoBehaviour {

    public bool _Set90Angle;

    public GameObject _Parent;
    public GameObject _Skill_FireBall;
    public GameObject _Skill_RockThrow;
    public GameObject _Skill_FrameLush;
    public GameObject _Skill_FrameLushLoad;



	void Update () 
    {
   
        transform.localPosition = GameMng.Data._GameDate._HeroUnit.transform.localPosition;
        double pointX = getAngle(new Vector2(GameMng.Data._GameDate._HeroUnit.transform.localPosition.x, GameMng.Data._GameDate._HeroUnit.transform.localPosition.y), new Vector2(Input.mousePosition.x * (1280.0f / Screen.width), Input.mousePosition.y * (720.0f / Screen.height)));
 
        if(_Set90Angle)
        {
            //Debug.Log(radi);
            if (pointX > 45 && pointX <= 135)
                pointX = 90;
            else if ((pointX > 135 && pointX <= 180) || (pointX <= -135))
                pointX = -180;
            else if (pointX <= -45 && pointX >= -135)
                pointX = -90;//임시
            else
                pointX = 0;
        }

        //if (pointX >= 90)
        //    pointX = 90.0;
        //if (pointX <= -90)
        //    pointX = -90.0;
        transform.localEulerAngles = new Vector3(0, 0, -(float)pointX);
        if(Input.GetMouseButtonUp(0)==true)
        {
            _ShootSkill((float)pointX);
            gameObject.SetActive(false);
            GameMng.Data._GameDate._touchScene = false;
        }
	}

    void _ShootSkill(float angle)
    {
        switch (GameMng.Data._SkillName)
        {
            case "warrior_10_low":
                {
                    GameObject skill = NGUITools.AddChild(_Parent, _Skill_RockThrow);
                    skill.GetComponent<Skill_Projectiles>()._init(GameMng.Data._GameDate._HeroUnit, gameObject.transform.localEulerAngles, transform.localPosition, 1, 0, 1, 140, true,25);
                    skill.GetComponent<Skill_Projectiles>()._CCType = 1;
                    skill.GetComponent<Skill_Projectiles>()._CCTime = 1.0f;
                    GameMng.Data._GameDate._SkillList.Add(skill.GetComponent<Skill_Projectiles>());
                    break;
                }
            case "warrior_14_low":
                {
                    float seta = (-angle + 90) * Mathf.Deg2Rad;
                    float x = Mathf.Cos(seta) * (float)(400);
                    float y = Mathf.Sin(seta) * (float)(400);

                    GameObject skill1 = NGUITools.AddChild(_Parent, _Skill_FrameLushLoad);
                    skill1.transform.localPosition = GameMng.Data._GameDate._HeroUnit.transform.localPosition + new Vector3(0,80,0);
                    skill1.transform.localEulerAngles = new Vector3(0, 0, -angle);

                    GameObject skill = NGUITools.AddChild(GameMng.Data._GameDate._HeroUnit.gameObject, _Skill_FrameLush);
                    skill.transform.localPosition = new Vector3(0, 80, 0);
                    skill.GetComponent<Skill_Circle>()._init(GameMng.Data._GameDate._HeroUnit, GameMng.Data._GameDate._HeroUnit.transform.localPosition , 1, 0, 1, 90,4);
                    skill.GetComponent<Skill_Circle>()._CCType = 2;
                    skill.GetComponent<Skill_Circle>()._CCTime = 0.2f;
                    skill.transform.localEulerAngles = new Vector3(0, 0, -angle);

                    GameMng.Data._GameDate._HeroUnit.SetSkillAction(0.6f);
                    GameMng.Data._GameDate._HeroUnit.have.o_List.Clear();
                    GameMng.Data._GameDate._HeroUnit.SetMoveAction(x, y, 0.6f);

                    GameMng.Data._GameDate._SkillList.Add(skill.GetComponent<Skill_Circle>());
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
