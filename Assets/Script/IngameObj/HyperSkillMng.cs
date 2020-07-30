using UnityEngine;
using System.Collections;

public class HyperSkillMng : MonoBehaviour {

    public GameObject _FullEffect;
    public UISprite _HyperSkillIcon;
    public UISprite _HyperGazeBar;
    public GameObject _HyperSkill_Warrior;
    public GameObject _HyperSkill_Effect;
    public GameObject _HyperSkill_RotateEffect;
    public GameObject _HyperSkill_RotateEffect_1;
    public int _HeroHyperValue;
    public ClearAchevementMng _AchevementMng;

    public GameObject _WarriorCutin;

    bool _HyperGazeAniOn;

    void Update()
    {
        if (!_HyperGazeAniOn)
            _HyperGazeBar.fillAmount = (float)_HeroHyperValue / 100.0f;
        else
            GazeDownUpdate();
        if(_HeroHyperValue>=100)
        {
            _HyperSkill_RotateEffect.SetActive(true);
            _HyperSkill_RotateEffect_1.SetActive(true);
            _HyperSkillIcon.spriteName = "hyperskill";
        }
        else
        {
            _HyperSkill_RotateEffect.SetActive(false);
            _HyperSkill_RotateEffect_1.SetActive(false);
            _HyperSkillIcon.spriteName = "hyperskill_gray";
        }
    }

    public void UseHyperSkill()
    {
        if (_HeroHyperValue >= 100)
        {
            _AchevementMng._HyperSkillUse++;
            GameMng.Data._S_ActionMng._HyperSkillTouch = true;
            GameObject eff = NGUITools.AddChild(GameMng.Data._UIRoot, _WarriorCutin);
            eff.transform.localPosition = new Vector3(0, 0, 0);
            GameMng.Data._S_ActionMng.SetStoryMove(true);
            _HyperGazeAniOn = true;
            _HeroHyperValue = 0;
            StartCoroutine(StartHyperMotion(1.1f));
        }
    }
    void GazeDownUpdate()
    {
        _HyperGazeBar.fillAmount -= Time.smoothDeltaTime;
        if (_HyperGazeBar.fillAmount <= 0.0f)
            _HyperGazeAniOn = false;
    }

    public void FullEffectAction()
    {
        GameObject obj = NGUITools.AddChild(_HyperSkillIcon.gameObject, _FullEffect);
        _HyperSkillIcon.enabled = false;
        StartCoroutine(SetIconOn(0.4f));
    }
    IEnumerator SetIconOn(float time)
    {
        yield return new WaitForSeconds(time);

        _HyperSkillIcon.enabled = true;
    }
    IEnumerator StartHyperMotion(float time)
    {
        yield return new WaitForSeconds(time);

        //GameMng.Data._S_ActionMng.SetStoryMove_HeroExcept(true);
        GameMng.Data._S_ActionMng.SetStoryMove(false);
        
        StartCoroutine(AddEffect(0.3f));
        GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._HeroUnit.gameObject, _HyperSkill_Warrior);
        
        GameMng.Data._GameDate._HeroUnit.GetComponent<Unit>().SetSprite_SkillShot(5, 31);
        GameMng.Data._GameDate._HeroUnit.SetAction_HyperSkill_Warrior();
    }
    IEnumerator AddEffect(float time)
    {
        yield return new WaitForSeconds(time);

        GameObject Eff = NGUITools.AddChild(GameMng.Data._GameDate._HeroUnit.gameObject, _HyperSkill_Effect);
    }
}
