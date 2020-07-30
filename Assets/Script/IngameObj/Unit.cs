using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour
{

    public HaveList have;
    List<HitCount> _DmgCalculation = new List<HitCount>();//다단히트 스킬 계산
    public List<Skill_Buff> _BuffList = new List<Skill_Buff>();
    public GameObject _DamageLabel_Soldier;
    public GameObject _DamageLabel_Enemy;
    public GameObject _DamageLabel_Heal;

    public GameObject _GroundBarrior;

    public bool _StoryActioning;

    public int _frame;

    int _Init_Hp;
    int _Init_Damage;
    float _Init_MoveSpeed;

    //stat
    public string _ObjName;
    public int _MaxHP;
    public float _HP;
    public float _Range;
    public float _HitRange;
    float _MoveSpeed;

    int _Stat_BaseHp;
    int _Stat_Power;
    int _Stat_Intellect;
    int _Stat_Health;
    int _Stat_Armor;

    int _Damage;

    float _DamageGrowth;//데미지 증가율(%)
    float _CriticalLuck;//크리티컬확률(%)
    public float _AttackSpeed;//공속(%)
    public float _MoveSpeedAdding;//이속비율(%)
    float _Armor;//방어력(%)
    float _Evasion;//적중률(%)
    float _AvoidLate;//회피율(%)

    int _Element;//유닛 속성

    bool _RangeAttack;//원거리 공격
    public bool _OneInvincibleShield;//1회용 무적방어막

    /// <summary>
    /// 1 - Monster
    /// 2 - BossMonster
    /// 3 - Soldier
    /// 4 - Hero
    /// </summary>
    public int _Rating;
    public int _Type;
    public int _Depth;
    int _maxStayFrame;
    int _maxWalkFrame;
    public int[] _maxAttackFrameArr;//temp
    int _maxAttackFrame;
    /// <summary>
    /// 공격버프시에 이펙트가 나가는 프레임
    /// </summary>
    int _AttactStartFrame;
    int _AttactDamageFrame;
    int _maxSkill_1_Frame;
    int _maxSkill_2_Frame;
    float _redingAlpha;
    public float _spriteAlpha;
    public bool _nowMove;
    public float _Updown;
    public Vector2 _startPos;
    public Vector2 _CenterPos;
    public Vector2 _FootPos;

    UISprite _MySprite;
    GameObject _Shadow;
    public GameObject _IceFiledZone;
    public GameObject _SteamFiledZone;
    public int _HeroFiledSkillNum;
    UISprite _ShadowSprite;
    Vector3 _ShadowPos;

    float _StunTime;
    public bool _SkillAction;

    public int _AttackMotionKind;
    public int _AttackMotionKindMax;


    List<float> _HitSkillList = new List<float>();

    //Animation
    /// <summary>
    /// 1 - up
    /// 2 - left
    /// 3 - down
    /// 4 - right
    /// </summary>
    public string _directionFrame;
    public string _NowState;
    float _delayTime;
    float _AttackDelayTime;
    public float _AttackActionTime;
    float _nowTime;
    public int _nowFrame;
    public int _maxFrame;//temp
    bool _AniLoop;

    bool _Dead;

    int _AttackValue;

    //Action
    public Unit _targetObject;
    GameData _gameData;
    EffectAnimation _EffectAni;
    float _radi;
    public float _speedX;
    public float _speedY;

    public float _HyperTime;
    bool _UsingHyperSkill;

    public Rigidbody2D _MyRigidBody;
    CircleCollider2D _MyCollider;

    public GameObject _BossDeadAction;

    public bool _CantTarget;
    public bool _SpriteOn;
    void Start()
    {
        _SpriteOn = true;
        _CantTarget = false;
        _HyperTime = 0.0f;
        _AttackMotionKindMax = 4;//temp
        _HeroFiledSkillNum = 0;


        _AvoidLate = 30;
        _spriteAlpha = 1;

        have = GetComponent<HaveList>();
        GameMng.Data.n_list.Add(have);

        _MySprite = GetComponent<UISprite>();
        _gameData = GameMng.Data._GameDate;
        _EffectAni = GameMng.Data._EffectAnimation;
        
        GetComponent<UISprite>().MakePixelPerfect();
        _MyRigidBody = GetComponent<Rigidbody2D>();
        _MyCollider = GetComponent<CircleCollider2D>();

        _redingAlpha = 1.0f;
        //Hold
        SetSprite_Stay();
        _AttackDelayTime = 0.0f;//캐릭터마다 다름
        _AttackActionTime = _AttackDelayTime;
        _nowTime = 0.0f;
        _nowFrame = 0;
        _nowMove = true;
        //GetComponent<UISprite>().pivot = UIWidget.Pivot.Bottom;
        _Shadow = transform.Find("UnitShadow").gameObject;
        _ShadowSprite = _Shadow.GetComponent<UISprite>();
        SetInformation(_Init_Damage,_Init_Hp,_Init_MoveSpeed);
        SetFrame();
        
    }

    public void SetInitValue(int hp,int damage,float movespeed)
    {
        _Init_Damage = damage;
        _Init_Hp = hp;
        _Init_MoveSpeed = movespeed;
    }

    void MonsterSkillUpdate()
    {
        if(_ObjName=="wolfboss")
        {
            if(_AttackValue>=2)
            {
                EffectCreate(_gameData._Parent, GameMng.Data._EffectAnimation._WolfBossBiteEffect, _targetObject.gameObject,true,Vector2.zero);
                _AttackValue = 0;
                SetSprite_SkillShot(1, 5);
                StartCoroutine(Skill_HitDamage(0.3f, _Damage * 1.5f));
            }
        }
    }

    IEnumerator Skill_HitDamage(float time,float damage)
    {
        yield return new WaitForSeconds(time);

        if(_targetObject!=null)
        {
            DmgCalculation(damage, GetComponent<Unit>(), _targetObject.GetComponent<Unit>(), Attack_Miss(_targetObject.GetComponent<Unit>()), false,0);
            if (!Attack_Miss(_targetObject.GetComponent<Unit>()))
                Effect_Attack();
        }
    }

    void Update()
    {
        MonsterSkillUpdate();
        if (_Rating <= 2)//임시
            _directionFrame = "left";
        if (_Rating == 3)//임시
            _directionFrame = "right";
        if (_Rating == 4)
        {
            _directionFrame = "right";


            if (_HeroFiledSkillNum == 0)
            {
                _IceFiledZone.SetActive(false);
                _SteamFiledZone.SetActive(false);
            }
            else if (_HeroFiledSkillNum == 1)
            {
                _IceFiledZone.SetActive(true);
                _SteamFiledZone.SetActive(false);
            }
            else if (_HeroFiledSkillNum == 2)
            {
                _IceFiledZone.SetActive(false);
                _SteamFiledZone.SetActive(true);
            }
        }

        

        if (_HP > _MaxHP)
            _HP = _MaxHP;
        _frame++;
        _Shadow.transform.localPosition = _FootPos;
        _CenterPos = transform.localPosition + new Vector3(0, GetComponent<UISprite>().height / 2, 0);
        
        _MySprite.depth = _Depth = 1300 - (int)transform.localPosition.y;

        if (!_StoryActioning)
            _StunTime -= Time.smoothDeltaTime;

        BuffUpdate();//BUFF

            //HitRed
            _redingAlpha += Time.smoothDeltaTime * 4;
            if (!_CantTarget)
                _spriteAlpha += Time.smoothDeltaTime;
        if (_redingAlpha >= 1.0f)
            _redingAlpha = 1.0f;
        if (_spriteAlpha >= 1.0f)
            _spriteAlpha = 1.0f;
        _MySprite.enabled = _SpriteOn;
        _MySprite.color = new Color(_MySprite.color.r, _redingAlpha, _redingAlpha, _spriteAlpha);

        if (!(_Rating == 4 && _Type >= 2))
            HPBarUpdate();//스턴에 관계없이 돌아가야 하는 것

        if (_StunTime <= 0.0f)
        {
            _nowTime += Time.smoothDeltaTime * ((_AttackSpeed + 100.0f) / 100.0f);

            if (_nowTime >= _delayTime)
                SpriteUpdate();
            if(!_StoryActioning)
            {
                if (_UsingHyperSkill)
                {
                    _HyperTime -= Time.smoothDeltaTime;
                    if (_HyperTime <= 0.0f)
                    {
                        //Debug.Log("off");
                        _UsingHyperSkill = false;
                        _delayTime = 0.125f;
                    }
                    else
                    {
                        if (Input.GetMouseButton(0))
                        {
                            Vector2 mousepos = new Vector2(Input.mousePosition.x * (1280.0f / Screen.width), Input.mousePosition.y * (720.0f / Screen.height));
                            float radi = Mathf.Atan2(mousepos.y - transform.localPosition.y,
                                       mousepos.x - transform.localPosition.x);
                            _speedX = (Mathf.Cos(radi) * 200.0f);
                            _speedY = (Mathf.Sin(radi) * 200.0f);
                            transform.localPosition += new Vector3(_speedX * Time.smoothDeltaTime, _speedY * Time.smoothDeltaTime, 0);
                        }
                    }
                }
                if (!_SkillAction)
                {
                    if (!(_Rating >= 4 && _Type >= 2))
                    {
                        HPBarUpdate();
                        SetTarget();
                        if (_targetObject != null)
                        {
                            _MyRigidBody.isKinematic = false;
                            _radi = Mathf.Atan2(_targetObject.transform.localPosition.y - transform.localPosition.y,
                                    _targetObject.transform.localPosition.x - transform.localPosition.x);
                            _speedX = (Mathf.Cos(_radi) * _getMoveSpeed());
                            _speedY = (Mathf.Sin(_radi) * _getMoveSpeed());

                            if (_Rating >= 4)//임시
                                SetDirection(_radi);

                            if (!InRange())
                            {
                                //if (_Rating == 3 || _Rating == 4)
                                //    GameMng.Data._MoveBg = true;

                                //Vector2 temppos = transform.localPosition + new Vector3(_speedX * Time.smoothDeltaTime, _speedY * Time.smoothDeltaTime, 0);
                                //if (temppos.x - 2 * _HitRange >= 0.0f && temppos.x + 2 * _HitRange <= 720.0f)

                                transform.localPosition += new Vector3(_speedX * Time.smoothDeltaTime, _speedY * Time.smoothDeltaTime, 0);
                                SetSprite_Walk();
                                _nowMove = true;

                                _MyRigidBody.constraints = RigidbodyConstraints2D.None;

                            }
                            else
                            {
                                GameMng.Data._MoveBg = false;
                                _nowMove = false;
                                _MyRigidBody.constraints = RigidbodyConstraints2D.FreezePosition;
                            }
                        }
                        else if (_targetObject == null)
                        {
                            _MyRigidBody.isKinematic = true;
                            if ((_Rating == 4 && _Type == 1) || _Rating == 3)
                            {
                                _radi = Mathf.Atan2(_startPos.y - transform.localPosition.y, _startPos.x - transform.localPosition.x);
                               
                                if(_Rating==4)
                                {
                                    _speedX = (Mathf.Cos(_radi) * _getMoveSpeed()*0.75f);
                                    _speedY = (Mathf.Sin(_radi) * _getMoveSpeed()*0.75f);
                                }
                                else
                                {
                                    _speedX = (Mathf.Cos(_radi) * _getMoveSpeed()*1.2f);
                                    _speedY = (Mathf.Sin(_radi) * _getMoveSpeed()*1.2f);

                                }
                               
                                
                                
                                if (_Rating >= 4)//임시
                                    SetDirection(_radi);

                                if (Mathf.Sqrt(Mathf.Pow(transform.localPosition.x - _startPos.x, 2) +
                                     Mathf.Pow(transform.localPosition.y - _startPos.y, 2)) <= 4.0f)
                                    transform.localPosition = _startPos;
                                else
                                    transform.localPosition += new Vector3(_speedX * Time.smoothDeltaTime, _speedY * Time.smoothDeltaTime, 0);
                                SetSprite_Walk();
                            }
                            else
                                SetSprite_Stay();

                            if (_Rating == 3 || _Rating == 4)
                                GameMng.Data._MoveBg = true;
                        }
                    }
                }
            }
            else
            {
                SetSprite_Stay();
            }
        }
        else
            GetComponent<UISprite>().MakePixelPerfect();

        if (_Rating == 1)
        {
            if (_ObjName == "wolf"||_ObjName == "whitewolf")
                transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            if (_ObjName == "digarr_w" || _ObjName == "digarr_m")
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
        if(_Rating==4)
        {
            if (GameMng.Data._S_ActionMng._HeroOnemanShow)
                _MyRigidBody.isKinematic = true;
        }
    }

    void BuffUpdate()
    {
        
        _CriticalLuck = 0;//크리티컬확률(%)
        _AttackSpeed = 0;//공속(%)
        _MoveSpeedAdding = 0;//이속비율(%)
        _Armor = 0;//방어력(%)
        _Evasion = 0;//적중률(%)
        _AvoidLate = 0;//회피율(%)
        for (int i = 0; i < _BuffList.Count; i++)
        {
            if (_BuffList[i]._Timebuff)
            {
                _BuffList[i]._BuffTime -= Time.smoothDeltaTime;
                if (_BuffList[i]._BuffTime <= 0.0f)
                {
                    _BuffList.RemoveAt(i);
                    break;
                }
            }
            else
            {
                if (_BuffList[i]._BuffLoopCount <= 0)
                {
                    _BuffList.RemoveAt(i);
                    break;
                }
            }

            //debuff
            //if (_BuffList[i]._BuffType == 1)
            //    _DamageGrowth += _BuffList[i]._BuffNum;
            if (_BuffList[i]._BuffType == 2)
                _CriticalLuck += _BuffList[i]._BuffNum;
            if (_BuffList[i]._BuffType == 3)
            {
                _BuffList[i]._DotDelay += Time.smoothDeltaTime;
                if (_BuffList[i]._DotDelay >= _BuffList[i]._DotDelayMax)
                {
                    //_HP += _BuffList[i]._BuffNum;
                    HealCalculation(_BuffList[i]._BuffNum, GetComponent<Unit>());
                    _BuffList[i]._DotDelay = 0.0f;
                    _BuffList[i]._BuffLoopCount--;
                }
            }
            else if (_BuffList[i]._BuffType == 4)
            {
                _AttackSpeed += _BuffList[i]._BuffNum;
            }
            else if (_BuffList[i]._BuffType == 5)
                _MoveSpeedAdding += _BuffList[i]._BuffNum;
            else if (_BuffList[i]._BuffType == 6)
                _Armor += _BuffList[i]._BuffNum;
            else if (_BuffList[i]._BuffType == 7)
                _Evasion += _BuffList[i]._BuffNum;
            else if (_BuffList[i]._BuffType == 8)
                _AvoidLate += _BuffList[i]._BuffNum;
        }

        //_MoveSpeed = _MoveSpeed + (_MoveSpeed * (_MoveSpeedAdding / 100));
    }

    public void BuffIconEffect(float delayTime,List<string> slist,List<Vector2> ipos)
    {
        StartCoroutine(BuffIconEffect_1(delayTime,slist, ipos));
    }
    IEnumerator BuffIconEffect_1(float delayTime,List<string> slist,List<Vector2> ipos)
    {
        yield return new WaitForSeconds(delayTime);

        for (int i = 0; i < slist.Count; i++) 
        {
            switch (slist[i])
            {
                case "1":
                    {
                        GameObject icon = NGUITools.AddChild(gameObject, GameMng.Data._EffectAnimation._BuffIcon_AttackDamage);
                        icon.transform.localPosition = ipos[i];
                        break;
                    }
                case "4":
                    {
                        GameObject icon = NGUITools.AddChild(gameObject, GameMng.Data._EffectAnimation._BuffIcon_AttackSpeed);
                        icon.transform.localPosition = ipos[i];
                        break;
                    }
                case "5":
                    {
                        GameObject icon = NGUITools.AddChild(gameObject, GameMng.Data._EffectAnimation._BuffIcon_MoveSpeed);
                        icon.transform.localPosition = ipos[i];
                        break;
                    }
                case "8":
                    {
                        GameObject icon = NGUITools.AddChild(gameObject, GameMng.Data._EffectAnimation._BuffIcon_Avoid);
                        icon.transform.localPosition = ipos[i];
                        break;
                    }
            }
            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "skill")
        {
            ////Debug.Log("skillhit");
            HitListAdd(other.GetComponent<Skill>());
            if (other.GetComponent<Skill>()._RectBuff)
                HitAddBuff(other.GetComponent<Skill>());
        }
    }

    void HitAddBuff(Skill skill)
    {
        if ((_Rating == 1 || _Rating == 2) && (skill._targetGroup == 1 || skill._targetGroup == 3))
        {
            if(skill._HitType==1)
            {
                Skill_Buff buff1 = new Skill_Buff();
                buff1._BuffSetting(skill._BuffTime_R,false,skill._BuffType_R,skill._BuffNum_R);
                _BuffList.Add(buff1);
            }
        }
        //몬스터의 디버프 스킬시 추가
    }

    void HitListAdd(Skill skill)
    {
        if ((_Rating == 1 || _Rating == 2) && (skill._targetGroup == 1 || skill._targetGroup == 3))
        {

            if (skill._HitType == 1)
            {
                if(skill._TargetLockonSkill)
                {
                    if(skill._TargetUnit == GetComponent<Unit>())
                    {
                        EffectCreate(_gameData._Parent, skill._Effect, gameObject, true, Vector2.zero);
                        DmgCalculation(skill._Damage, skill._ParentUnit, GetComponent<Unit>(), false, true, skill._ElementType);
                        if (skill._oneTarget)
                            Destroy(skill.gameObject);
                    }
                }
                else
                {
                    EffectCreate(_gameData._Parent, skill._Effect, gameObject, true, Vector2.zero);
                    DmgCalculation(skill._Damage, skill._ParentUnit, GetComponent<Unit>(), false, true, skill._ElementType);
                    if (skill._oneTarget)
                        Destroy(skill.gameObject);
                }
            }
            else if (skill._HitType == 2)
            {
                //_DmgCalculation.Add(new HitCount(skill._HitDelayTime, skill._Damage));
            }
            HitCCSkill(skill._CCType, skill._CCTime);
        }

        if (_Rating == 3 && (skill._targetGroup == 2 || skill._targetGroup == 3))
        {

            if (skill._HitType == 1)
            {
                EffectCreate(_gameData._Parent, skill._Effect, gameObject, true, Vector2.zero);
                DmgCalculation(skill._Damage, skill._ParentUnit, GetComponent<Unit>(), false, true, skill._ElementType);
                if (skill._oneTarget)
                    Destroy(skill.gameObject);
            }
            else if (skill._HitType == 2)
            {
                //_DmgCalculation.Add(new HitCount(skill._HitDelayTime, skill._Damage));
            }
            HitCCSkill(skill._CCType, skill._CCTime);
        }

        if (_Rating == 4 && skill._targetGroup == 2)
        {

            if (skill._HitType == 1)
            {
                EffectCreate(_gameData._Parent, skill._Effect, gameObject, true, Vector2.zero);
                DmgCalculation(skill._Damage, skill._ParentUnit, GetComponent<Unit>(), false, true,skill._ElementType);
                if (skill._oneTarget)
                    Destroy(skill.gameObject);
            }
            else if (skill._HitType == 2)
            {
                //_DmgCalculation.Add(new HitCount(skill._HitDelayTime, skill._Damage));
            }
            HitCCSkill(skill._CCType, skill._CCTime);
        }
    }

    void HitCCSkill(int cctype,float cctime)
    {
        if (cctype != 0)
        {
            if (cctype == 1)
                Action_Stun(cctime);
            else if (cctype == 2)
                Action_KnockBack(cctime,100);
        }
    }

    public void EffectCreate(GameObject parent, GameObject effect, GameObject targetObj,bool setdepth,Vector2 addpos)
    {
        if(!targetObj.GetComponent<Unit>()._CantTarget)
        {
            targetObj.GetComponent<Unit>().Hit_Reding();
            GameObject eff = NGUITools.AddChild(parent, effect);
            if (setdepth)
                eff.GetComponent<UI2DSprite>().depth = 1310 - (int)targetObj.transform.localPosition.y;
            eff.transform.localPosition = targetObj.GetComponent<Unit>()._CenterPos + addpos;
        }
        
    }

    void SpriteUpdate()
    {
        if (_NowState == "attack" && _nowFrame == 0)
            _AttackValue++;
        _nowTime = 0.0f;
        _nowFrame++;
        if (_Rating == 4)
        {
            if (_NowState == "attack")
            {
                if(_AttackMotionKind == 0)
                {
                    _nowFrame = 0;
                    _AttackMotionKind = Random.Range(1, _AttackMotionKindMax);
                }
                _maxFrame = _maxAttackFrameArr[_AttackMotionKind-1];
            }
        }
        
        if(_nowFrame == _AttactStartFrame && _NowState == "attack")
        {
            for (int i = 0; i < _BuffList.Count; i++)
            {
                if (_BuffList[i]._BuffType == 1) 
                {
                    GameMng.Data.ShakeGameCamera();
                    //Debug.Log("Attack");
                    GameObject eff = new GameObject();
                    if (_BuffList[i]._AttackSubEffectNum == 1)
                    {
                        if(_targetObject!=null)
                        {
                            eff = NGUITools.AddChild(gameObject, _EffectAni._AirSubAttackEffect);
                            eff.transform.localPosition = new Vector3(60, 60, 0);
                            float z = Mathf.Atan2(_targetObject.transform.localPosition.y - transform.localPosition.y, _targetObject.transform.localPosition.x - transform.localPosition.x) * Mathf.Rad2Deg;
                            eff.transform.localEulerAngles = new Vector3(0, 0, z - 90);
                            //eff.GetComponent<DelayMakeObject>()._Parent = gameObject;
                        }
                        
                    }

                }
            }
        }
        if (_nowFrame == _AttactDamageFrame && _NowState == "attack")
        {
            if (_targetObject != null)
            {
                if(_Rating == 3&&_Type == 3)
                {
                    HealCalculation(_Damage, _targetObject);
                }
                else
                {
                    if (_RangeAttack)//원거리공격
                    {
                        if (_targetObject != null)
                        {
                            if (_ObjName == "soldier_a")
                            {
                                AudioSource.PlayClipAtPoint(GameMng.Data._ShootArrow, Vector2.zero, StaticDataMng._SoundOn);
                                GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._Parent, GameMng.Data._TargetObjList._SoldierArrow);
                                float radi = Mathf.Atan2(_targetObject.transform.localPosition.y - obj.transform.localPosition.y,
                                    _targetObject.transform.localPosition.x - obj.transform.localPosition.x);
                                obj.GetComponent<Skill_TargettingProjectiles>()._init(GetComponent<Unit>(), _targetObject, _CenterPos, 1, 0, 1, _Damage, true, 0);
                            }
                            if (_ObjName == "digarr_m")
                            {
                                //AudioSource.PlayClipAtPoint(GameMng.Data._ShootArrow, Vector2.zero);
                                GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._Parent, GameMng.Data._TargetObjList._DiraggMageMissail);
                                float radi = Mathf.Atan2(_targetObject.transform.localPosition.y - obj.transform.localPosition.y,
                                    _targetObject.transform.localPosition.x - obj.transform.localPosition.x);
                                obj.transform.localEulerAngles = new Vector3(0, 0, radi);
                                obj.GetComponent<Skill_TargettingProjectiles>()._init(GetComponent<Unit>(), _targetObject, _CenterPos, 1, 0, 2, _Damage, true, 0);
                            }
                            if (_ObjName == "digarr_middle_m")
                            {
                                //AudioSource.PlayClipAtPoint(GameMng.Data._ShootArrow, Vector2.zero);
                                GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._Parent, GameMng.Data._TargetObjList._DiraggMageMissail);
                                float radi = Mathf.Atan2(_targetObject.transform.localPosition.y - obj.transform.localPosition.y,
                                    _targetObject.transform.localPosition.x - obj.transform.localPosition.x);
                                obj.transform.localEulerAngles = new Vector3(0, 0, radi);
                                obj.GetComponent<Skill_TargettingProjectiles>()._init(GetComponent<Unit>(), _targetObject, _CenterPos, 1, 0, 2, _Damage, true, 0);
                            }
                            if (_ObjName == "unsoldier_a")
                            {
                                AudioSource.PlayClipAtPoint(GameMng.Data._ShootArrow, Vector2.zero, StaticDataMng._SoundOn);
                                GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._Parent, GameMng.Data._TargetObjList._UnSoldierArrow);
                                float radi = Mathf.Atan2(_targetObject.transform.localPosition.y - obj.transform.localPosition.y,
                                    _targetObject.transform.localPosition.x - obj.transform.localPosition.x);
                                obj.transform.localEulerAngles = new Vector3(0, 0, radi);
                                obj.GetComponent<Skill_TargettingProjectiles>()._init(GetComponent<Unit>(), _targetObject, _CenterPos, 1, 0, 2, _Damage, true, 0);
                            }
                        }
                    }
                    else
                    {
                        DmgCalculation(_Damage, GetComponent<Unit>(), _targetObject.GetComponent<Unit>(), Attack_Miss(_targetObject.GetComponent<Unit>()), false, 0);
                        if (!Attack_Miss(_targetObject.GetComponent<Unit>()))
                            Effect_Attack();
                    }
                }
            }
        }
        if (_nowFrame >= _maxFrame)
        {
            _nowFrame = 0;
            _AttackMotionKind = 0;
            if (!_AniLoop)
            {
                if (_NowState == "attack")
                {
                    _AttackActionTime = 0.0f;
                }
                if (_NowState == "skill_1" || _NowState == "skill_2" || _NowState == "skill_3" || _NowState == "skill_4" || _NowState == "skill_5" || _NowState == "skill_6" || _NowState == "skill_7" || _NowState == "skill_8")
                {
                    _SkillAction = false;
                }
                SetSprite_Stay();
            }

        }
        SetFrame();
        GetComponent<UISprite>().MakePixelPerfect();
    }

    void HPBarUpdate()
    {
        if (_Rating != 4)
        {
            ////Debug.Log(_Rating);
            ////Debug.Log(gameObject.name);
            ////Debug.Log(transform.parent.name);
            if (GameMng.Data._MosnterWaveMng._BossMosnter != GetComponent<Unit>())
            {
                transform.Find("UnitHpBar(Clone)").transform.Find("Red").transform.localScale = new Vector3(((float)_HP / (float)_MaxHP), 1, 1);
                if (_Rating == 3)
                    transform.Find("UnitHpBar(Clone)").transform.Find("Red").GetComponent<UISprite>().color = new Color(0, 255, 0, 200);
                
            }
            else
                transform.Find("UnitHpBar(Clone)").gameObject.SetActive(false);

            if (_HP <= 0 && _Dead == false)
            {
                _Dead = true;
                DeadEffect();
                if (_Rating <= 2)
                    _gameData._EnemyUnitList.Remove(GetComponent<Unit>());
                else if (_Rating == 3)
                    _gameData._SoldierUnitList.Remove(GetComponent<Unit>());
                Destroy(gameObject);


            }
        }
        else
        {
            _gameData._HeroHPBar.fillAmount = _HP / (float)_MaxHP;
            if (_HP <= 0 && _Dead == false)
            {
                //_Dead = true;
                //transform.localPosition = new Vector3(-4000, 0, 0);
                //_MySprite.enabled = false;
                //_Shadow.SetActive(false);
                //GameOver();
                //DeadEffect();
            }
        }
    }

    void GameOver()
    {
        GameObject obj = NGUITools.AddChild(GameMng.Data._UIRoot, GameMng.Data._EffectAnimation._GameOverEffect);
        StartCoroutine(GoMenu(3.0f));
    }

    IEnumerator GoMenu(float time)
    {
        yield return new WaitForSeconds(time);

        if(GameMng.Data._QuestMng._HaveMainQuest.Count==0 && StaticDataMng._StoryNum!=1)
        {
            if (StaticDataMng._StoryOn)
            {
                StaticDataMng._LastStageName = StaticDataMng._SelectStageName;
                StaticDataMng._LastStoryNum = StaticDataMng._StoryNum;
                StaticDataMng._PlayingDead = true;
                StaticDataMng._StoryOn = false;
            }
        }
        

        GameMng.Data._SceneMng.SceneChange(4);
    }

    void DeadEffect()
    {
        if (_ObjName == "warrior")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._Warrior_Dead);
            obj.transform.localPosition = transform.localPosition;
        }

        if (_ObjName == "wolf")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent,_gameData._WolfDead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "wolfboss")
        {
            ////Debug.Log("BossDead");
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._WolfBossDead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "whitewolf")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._WhiteWolfDead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "whitewolfboss")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._WhiteWolfBossDead);
            obj.transform.localPosition = transform.localPosition;
        }
        if(_ObjName=="digarr_w")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._Digarr_W_Dead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "digarr_m")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._Digarr_M_Dead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "digarr_middle_w")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._Digarr_Middle_W_Dead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "digarr_middle_m")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._Digarr_Middle_M_Dead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "unsoldier_w")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._UnSoldier_W_Dead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "unsoldier_a")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._UnSoldier_A_Dead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "pirate")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._Pirate_Dead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "pirate_leader")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._PirateLeader_Dead);
            obj.transform.localPosition = transform.localPosition;
        }

        if (_ObjName == "soldier_w")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._Soldier_W_Dead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "soldier_a")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._Soldier_A_Dead);
            obj.transform.localPosition = transform.localPosition;
        }
        if (_ObjName == "soldier_m")
        {
            GameObject obj = NGUITools.AddChild(_gameData._Parent, _gameData._Soldier_M_Dead);
            obj.transform.localPosition = transform.localPosition;
        }

        if (GameMng.Data._MosnterWaveMng._BossMosnter == GetComponent<Unit>())
        { 
            GameObject action = NGUITools.AddChild(GameMng.Data._GameDate._Parent, _BossDeadAction);  
        }
    }

    void SetTarget()
    {
        if (_Rating <= 2)//Monster
        {
            if (_gameData._SoldierUnitList.Count != 0)
            {
                Unit target = _gameData._SoldierUnitList[0];
                for (int i = 1; i < _gameData._SoldierUnitList.Count; i++)//유닛정보 수집
                {
                    float dis0 = Mathf.Sqrt(Mathf.Pow(target._getPosition().x - transform.localPosition.x, 2)
                        + Mathf.Pow(target._getPosition().y - transform.localPosition.y, 2));
                    float dis1 = Mathf.Sqrt(Mathf.Pow(_gameData._SoldierUnitList[i]._getPosition().x - transform.localPosition.x, 2)
                        + Mathf.Pow(_gameData._SoldierUnitList[i]._getPosition().y - transform.localPosition.y, 2));
                    if (dis1 < dis0)
                        target = _gameData._SoldierUnitList[i];//전 것과 거리 비교
                }
                _targetObject = target;//타겟 지정
            }
            else
                _targetObject = _gameData._HeroUnit;

            _radi = Mathf.Atan2(_targetObject.transform.localPosition.y - transform.localPosition.y,
                _targetObject.transform.localPosition.x - transform.localPosition.x);
            _speedX = (Mathf.Cos(_radi) * _MoveSpeed);
            _speedY = (Mathf.Sin(_radi) * _MoveSpeed);
        }
        else if (_Rating >= 3)//Soldier
        {
            if(_Rating==3 && _Type==3)
            {
                if (_gameData._EnemyUnitList.Count == 0)
                    _targetObject = null;
                else
                {
                    if (_gameData._SoldierUnitList.Count != 0)
                    {
                        Unit target = _gameData._HeroUnit;
                        for (int i = 0; i < _gameData._SoldierUnitList.Count; i++)//유닛정보 수집
                        {
                            //float dis0 = Mathf.Sqrt(Mathf.Pow(target._getPosition().x - transform.localPosition.x, 2)
                            //    + Mathf.Pow(target._getPosition().y - transform.localPosition.y, 2));
                            //float dis1 = Mathf.Sqrt(Mathf.Pow(_gameData._SoldierUnitList[i]._getPosition().x - transform.localPosition.x, 2)
                            //    + Mathf.Pow(_gameData._SoldierUnitList[i]._getPosition().y - transform.localPosition.y, 2));
                            //if (dis1 < dis0)
                            //    target = _gameData._SoldierUnitList[i];//전 것과 거리 비교

                            float hpper0 = target._HP / target._MaxHP;
                            float hpper1 = _gameData._SoldierUnitList[i]._HP / _gameData._SoldierUnitList[i]._MaxHP;
                            if (hpper1 < hpper0)
                                target = _gameData._SoldierUnitList[i];
                        }
                        _targetObject = target;//타겟 지정
                    }
                }
            }
            else
            {
                if (_gameData._EnemyUnitList.Count != 0)
                {
                    Unit target = _gameData._EnemyUnitList[0];
                    for (int i = 1; i < _gameData._EnemyUnitList.Count; i++)//유닛정보 수집
                    {
                        float dis0 = Mathf.Sqrt(Mathf.Pow(target._getPosition().x - transform.localPosition.x, 2)
                            + Mathf.Pow(target._getPosition().y - transform.localPosition.y, 2));
                        float dis1 = Mathf.Sqrt(Mathf.Pow(_gameData._EnemyUnitList[i]._getPosition().x - transform.localPosition.x, 2)
                            + Mathf.Pow(_gameData._EnemyUnitList[i]._getPosition().y - transform.localPosition.y, 2));
                        if (dis1 < dis0)
                            target = _gameData._EnemyUnitList[i];//전 것과 거리 비교
                    }
                    _targetObject = target;//타겟 지정
                }
            }
            
        }
    }

    public void SetSprite_Stay()
    {
        _maxFrame = _maxStayFrame;
        _AniLoop = true;
        _NowState = "stay";
    }

    public void SetSprite_Walk()
    {
        _maxFrame = _maxWalkFrame;
        _AniLoop = true;
        _NowState = "walk";
    }

    public void SetSprite_Attack()
    {
        _maxFrame = _maxAttackFrame;
        _AniLoop = true;
        _NowState = "attack";
        
    }

    public void SetMoveAction(float x,float y,float time)
    {
        MoveBy moveby = new MoveBy(gameObject, new Vector3(x, y, 0), true, false, time);
        have.o_List.Add(moveby);
    }

    public void SetSkillAction(float retime)
    {
        _SkillAction = true;
        StartCoroutine(SetSkillActionFalse(retime));
    }

    IEnumerator SetSkillActionFalse(float time)
    {
        yield return new WaitForSeconds(time);

        _SkillAction = false;
    }

    public void SetSprite_SkillShot(int num,int max)
    {
        _maxFrame = max;

        _NowState = "skill_" + num.ToString();
        _AniLoop = false;
        _SkillAction = true;
        _nowFrame = 0;
    }

    public void SetAction_HyperSkill_Warrior()
    {
        _HyperTime = 3.5f;
        _UsingHyperSkill = true;
        _delayTime = 0.0875f;
    }

    void Effect_Attack()
    {
        if (_ObjName == "seed")
        {
            EffectCreate(_gameData._Parent, _EffectAni._SeedMobHit, _targetObject.gameObject, true, Vector2.zero);
        }
        if (_ObjName == "soldier_w")
        {
            EffectCreate(_gameData._Parent, _EffectAni._Soldier_W_Hit, _targetObject.gameObject, true, Vector2.zero);
        }
        if (_ObjName == "unsoldier_w")
        {
            EffectCreate(_gameData._Parent, _EffectAni._Soldier_W_Hit, _targetObject.gameObject, true, Vector2.zero);
        }
        if(_ObjName == "wolf")
        {
            EffectCreate(_gameData._Parent, _EffectAni._WolfHit, _targetObject.gameObject, true, Vector2.zero);
        }
        if (_ObjName == "wolfboss")
        {
            EffectCreate(_gameData._Parent, _EffectAni._WolfHit, _targetObject.gameObject, true, Vector2.zero);
        }
        if (_ObjName == "whitewolf")
        {
            EffectCreate(_gameData._Parent, _EffectAni._WolfHit, _targetObject.gameObject, true, Vector2.zero);
        }
        if (_ObjName == "whitewolfboss")
        {
            EffectCreate(_gameData._Parent, _EffectAni._WolfHit, _targetObject.gameObject, true, Vector2.zero);
        }
        if(_ObjName == "digarr_w")
        {
            EffectCreate(_gameData._Parent, _EffectAni._Soldier_W_Hit, _targetObject.gameObject, true, Vector2.zero);
        }
        if (_ObjName == "pirate")
        {
            EffectCreate(_gameData._Parent, _EffectAni._Soldier_W_Hit, _targetObject.gameObject, true, Vector2.zero);
        }
        if (_ObjName == "pirate_leader")
        {
            EffectCreate(_gameData._Parent, _EffectAni._Soldier_W_Hit, _targetObject.gameObject, true, Vector2.zero);
        }
        if(_ObjName == "warrior")
        {
            EffectCreate(_gameData._Parent, _EffectAni._WarriorHitEffect[_AttackMotionKind - 1], _targetObject.gameObject, true, Vector2.zero);
        }
    }

    void Action_Stun(float time)
    {
        ////Debug.Log("Stun");
        GameObject obj = NGUITools.AddChild(gameObject, GameMng.Data._EffectAnimation._StunEff);
        obj.transform.localPosition = new Vector3(0, _MySprite.height / 2);
        obj.GetComponent<UI2DSprite>().depth = _MySprite.depth + 20;
        obj.GetComponent<RemoveSelfTimer>().DestroyTime = time;
        _StunTime = time;
        _MySprite.spriteName = _ObjName + "_stay_" + _directionFrame + "_" + "0";
    }

    void Action_KnockBack(float time,float range)
    {
        ////Debug.Log("KnockBack");
        if(_Rating<=2)
        {
            have.o_List.Clear();
            MoveBy move = new MoveBy(gameObject, new Vector3(range,0,0), true, false, time);
            have.o_List.Add(move);
        }
        else
        {
            have.o_List.Clear();
            MoveBy move = new MoveBy(gameObject, new Vector3(-range, 0, 0), true, false, time);
            have.o_List.Add(move);
        }
    }


    public void DmgCalculation(float dmg, Unit Attackobj, Unit Hitobj, bool miss,bool skill,int eletype)//Unit
    {
        if (Attackobj != null && Hitobj != null)
        {
            if(!Hitobj._CantTarget)
            {
                GameObject label;
                _DamageGrowth = 0;//데미지 증가율(%)
                for (int i = 0; i < _BuffList.Count; i++)
                {
                    if (_BuffList[i]._BuffType == 1)
                    {

                        _DamageGrowth += _BuffList[i]._BuffNum;
                        _BuffList[i]._BuffLoopCount--;
                    }
                }
                float tempdmg = dmg;
                if (Attackobj._Rating == 4)
                {
                    float mainstat = Attackobj._Stat_Power;
                    if (Attackobj._Type == 2)
                        mainstat = Attackobj._Stat_Intellect;


                    if (skill)
                    {
                        tempdmg = (float)Attackobj._Damage;
                        tempdmg = (tempdmg / 2) + (Attackobj._Stat_Power / 2);
                        tempdmg *= dmg;
                        ////Debug.Log((float)Attackobj._Damage);
                        ////Debug.Log(mainstat);
                        ////Debug.Log(dmg);
                        ////Debug.Log(tempdmg);
                        tempdmg += (Random.Range(-3.0f, 3.0f) / 100.0f) * tempdmg;
                        if (StaticDataMng._StoryOn)
                            tempdmg *= GameMng.Data._SkillDmgMultyple;
                        if (eletype != 0)
                        {
                            if (eletype == 4)
                            {
                                if (_Element == 9)
                                    tempdmg *= 0.8f;//임시
                                else if (_Element == 49)
                                    tempdmg *= 1.2f;//임시
                            }
                            if (eletype == 9)
                            {
                                if (_Element == 25)
                                    tempdmg *= 0.8f;//임시
                                else if (_Element == 4)
                                    tempdmg *= 1.2f;//임시
                            }
                            if (eletype == 25)
                            {
                                if (_Element == 49)
                                    tempdmg *= 0.8f;//임시
                                else if (_Element == 9)
                                    tempdmg *= 1.2f;//임시
                            }
                            if (eletype == 49)
                            {
                                if (_Element == 4)
                                    tempdmg *= 0.8f;//임시
                                else if (_Element == 25)
                                    tempdmg *= 1.2f;//임시
                            }
                        }
                    }
                    else
                    {
                        tempdmg = (tempdmg / 2) + (Attackobj._Stat_Power / 2);
                        tempdmg += (Random.Range(-10.0f, 10.0f) / 100.0f) * tempdmg;
                        tempdmg += (tempdmg * (Attackobj._DamageGrowth / 100.0f));
                    }
                }
                if (Attackobj._Rating <= 3)
                {
                    tempdmg += (Random.Range(-5.0f, 5.0f) / 100.0f) * tempdmg;
                }
                tempdmg = tempdmg - (tempdmg * (Hitobj._Armor / 100.0f));
                //tempdmg *= 10;
                dmg = (int)tempdmg;
                int intdmg = (int)dmg;
                float plus = 0.0f;
                GameObject _label = _DamageLabel_Enemy;
                if (Hitobj._Rating <= 2)
                    _label = _DamageLabel_Soldier;
                if (Hitobj._Rating >= 3)
                    _label = _DamageLabel_Enemy;

                if(dmg>0)
                {
                    if (Hitobj._Rating == 4 && Hitobj._HyperTime > 0.0f)
                    {
                        label = NGUITools.AddChild(_gameData._Parent, _label);
                        label.transform.Find("DamageLabel").GetComponent<UILabel>().text = "Miss!";
                    }
                    else
                    {
                        if (Hitobj._OneInvincibleShield)
                        {
                            Hitobj.Break_OneInvincibleShield();
                            label = NGUITools.AddChild(_gameData._Parent, _label);
                            label.transform.localScale = new Vector3(1.5f, 1.5f, 2);
                            label.transform.Find("DamageLabel").GetComponent<UILabel>().text = "Guard!";
                        }
                        else
                        {
                            if (miss)
                            {

                                label = NGUITools.AddChild(_gameData._Parent, _label);
                                label.transform.Find("DamageLabel").GetComponent<UILabel>().text = "Miss!";
                            }
                            else
                            {
                                Hitobj._HP -= intdmg;
                                label = NGUITools.AddChild(_gameData._Parent, _label);
                                label.transform.Find("DamageLabel").GetComponent<UILabel>().text = intdmg.ToString();
                            }
                        }
                    }



                    if (Hitobj._Rating <= 2)
                    {
                        plus = 80.0f;
                        if (Hitobj._Type == 4 || Hitobj._Type == 5)
                            plus = 180.0f;
                        else if (Hitobj._Type == 6 || Hitobj._Type == 7)
                            plus = 100.0f;
                    }
                    else if (Hitobj._Rating >= 3)
                    {
                        plus = 100.0f;
                    }
                    //  + plus
                    float randfloatx = Random.Range(-30.0f, 30.0f);
                    float randfloaty = Random.Range(-10.0f, 10.0f);
                    label.transform.localPosition = new Vector3(Hitobj.transform.localPosition.x + randfloatx, Hitobj.transform.localPosition.y + plus, 0);
                }
            }
        }
    }

    void HealCalculation(float heal,Unit Hitobj)
    {
        if(Hitobj!=null)
        {
            GameObject label;
            float plus = 0.0f;
            Hitobj._HP += heal;
            if (Hitobj._HP >= Hitobj._MaxHP)
                Hitobj._HP = Hitobj._MaxHP;
            label = NGUITools.AddChild(_gameData._Parent, _DamageLabel_Heal);
            label.transform.Find("DamageLabel").GetComponent<UILabel>().text = ((int)heal).ToString();
            if (Hitobj._Rating <= 2)
            {

                if (_Rating == 4)
                {
                    plus = 30.0f;
                }
            }
            else if (Hitobj._Rating >= 3)
            {
                if (Hitobj._Rating == 4)
                {
                    plus = 30.0f;
                }
            }
            label.transform.localPosition = new Vector3(Hitobj.transform.localPosition.x, Hitobj.transform.localPosition.y + (Hitobj.GetComponent<UISprite>().height * 1.05f) + plus, 0);
        }
    }
    
    void SetInformation(int damage,int hp,float movespeed)
    {
        switch (_Rating)
        {
            case 1://Monster
                {
                    switch (_Type)
                    {
                        case 1://SeedMob
                            {
                                SetState("seed", "SeedMob", _gameData._SeedMobAtlas, hp, new Vector2(0, 120), new Vector2(0, 0), damage, 120.0f, 120.0f, movespeed, 2, 2, 6, 3, 3, 100, 0.0875f, false,1);
                                break;
                            }
                        case 2://Wolf
                            {
                                SetState("wolf", "SmallWolf", _gameData._WolfAtlas, hp, new Vector2(0, 160), new Vector2(0, 0), damage, 70.0f, 70.0f, movespeed, 1, 4, 6, 3, 3, 150, 0.0875f, false,4);
                                break;
                            }
                        case 3://WhiteWolf
                            {
                                SetState("whitewolf", "SmallWhiteWolf", _gameData._WhiteWolfAtlas, hp, new Vector2(0, 160), new Vector2(0, 0), damage, 70.0f, 70.0f, movespeed, 1, 4, 6, 3, 3, 150, 0.0875f, false,9);
                                break;
                            }
                        case 4://DigarrWarrior
                            {
                                SetState("digarr_w", "DigarrWarrior", _gameData._DigarrWarriorAtlas, hp, new Vector2(0, 250), new Vector2(28, 20), damage, 60.0f, 60.0f, movespeed, 1, 6, 4, 2, 0, 75, 0.2f, false,25);
                                break;
                            }
                        case 5://DigarrMage
                            {
                                SetState("digarr_m", "DigarrMage", _gameData._DigarrMageAtlas, hp, new Vector2(0, 250), new Vector2(0, 20), damage, 300.0f, 50.0f, movespeed, 1, 6, 4, 2, 0, 75, 0.125f, true, 4);
                                break;
                            }
                        case 6://UnSoldier_W
                            {
                                SetState("unsoldier_w", "UnSoldier_W", _gameData._UnSoldier_W_Atlas, hp, new Vector2(0, 120), new Vector2(0, 20), damage, 50.0f, 50.0f, movespeed, 1, 6, 4, 2, 1, 40, 0.125f, false,25);
                                break;
                            }
                        case 7://UnSoldier_A
                            {
                                SetState("unsoldier_a", "UnSoldier_A", _gameData._UnSoldier_A_Atlas, hp, new Vector2(0, 120), new Vector2(0, 20), damage, 300.0f, 50.0f, movespeed, 1, 6, 5, 3, 0, 40, 0.125f, true, 49);
                                break;
                            }
                        case 8://Pirate
                            {
                                SetState("pirate", "Pirate", _gameData._PirateAtlas, hp, new Vector2(0, 250), new Vector2(0, 20), damage, 300.0f, 50.0f, movespeed, 1, 6, 5, 3, 0, 75, 0.125f, true, 25);
                                break;
                            }
                    }
                    break;
                }
            case 2://BossMonster
                {
                    switch (_Type)
                    {
                        case 1://WolfMob_Boss
                            {
                                SetState("wolfboss", "Wolf_Boss", _gameData._WolfBossAtlas, hp, new Vector2(0, 100), new Vector2(0, 0), damage, 90.0f, 90.0f, movespeed, 1, 4, 6, 3, 3, 200, 0.0875f, false,4);
                                break;
                            }
                        case 2://WhiteWolfMob_Boss
                            {
                                SetState("whitewolfboss", "WhiteWolf_Boss", _gameData._WhiteWolfBossAtlas, hp, new Vector2(0, 100), new Vector2(0, 0), damage, 90.0f, 90.0f, movespeed, 1, 4, 6, 3, 3, 200, 0.0875f, false,9);
                                break;
                            }
                        case 3://Digarr_Middle_W
                            {
                                SetState("digarr_middle_w", "Digarr_Middle_W", _gameData._DigarrWarriorMiddleAtlas, hp, new Vector2(0, 250), new Vector2(28, 20), damage, 50.0f, 50.0f, movespeed, 1, 6, 4, 2, 0, 75, 0.125f, false,25);
                                break;
                            }
                        case 4://Digarr_Middle_M
                            {
                                SetState("digarr_middle_m", "Digarr_Middle_M", _gameData._DigarrMageMiddleAtlas, hp, new Vector2(0, 250), new Vector2(0, 20), damage, 300.0f, 50.0f, movespeed, 1, 6, 5, 2, 0, 75, 0.125f, true, 4);
                                break;
                            }
                        case 5://PirateLeader
                            {
                                SetState("pirate_leader", "Pirate_Leader", _gameData._PirateLeaderAtlas, hp, new Vector2(0, 250), new Vector2(0, 20), damage, 300.0f, 50.0f, movespeed, 1, 6, 5, 3, 0, 75, 0.125f, true, 25);
                                break;
                            }
                    }
                    break;
                }
            case 3://Soldier
                {
                    switch (_Type)
                    {
                        case 1://Soldier_Warrior
                            {
                                SetState("soldier_w", "Soldier_Warrior", _gameData._Soldier_Warrior_Atlas, hp, new Vector2(0, 120), new Vector2(0, 20), damage, 45.0f, 45.0f, movespeed, 1, 6, 4, 2, 1, 40, 0.125f, false,0);

                                break;
                            }
                        case 2://Soldier_Archer
                            {
                                SetState("soldier_a", "Soldier_Archer", _gameData._Soldier_Archer_Atlas, hp, new Vector2(0, 120), new Vector2(0, 20), damage, 450.0f, 45.0f, movespeed, 1, 6, 5, 3, 0, 40, 0.125f, true,0);
                                break;
                            }
                        case 3://Soldier_Mage
                            {
                                SetState("soldier_m", "Soldier_Mage", _gameData._Soldier_Mage_Atlas, hp, new Vector2(0, 120), new Vector2(0, 20), damage, 450.0f, 45.0f, movespeed, 1, 6, 4, 2, 0, 40, 0.125f, false, 0);
                                break;
                            }
                    }
                    break;
                }
            case 4://Hero
                {
                    switch (_Type)
                    {
                        case 1://Warrior
                            {
                                int[] maxattackarr = {4,4,4};
                                SetState("warrior", "Hero", _gameData._HeroAtlas,  60.0f, 60.0f,  300.0f, 1, 6, maxattackarr, 2, 1, 40, 0.125f, false);

                                break;
                            }
                        case 2://Mage
                            {
                                int[] maxattackarr = { 4, 4, 4 };
                                SetState("mage", "Hero", _gameData._HeroAtlas, 75.0f, 75.0f,  100.0f, 1, 6, maxattackarr, 3, 1, 40, 0.125f, false);

                                break;
                            }
                    }
                    break;
                }
        }
    }

    void SetState(string name, string enginename, UIAtlas atlas, int hp, Vector2 hpbarpos,Vector2 footpos, int damage, float range, float hitrange,
        float movespeed, int maxstay, int maxwalk, int maxattack, int attactdamageframe , int attackstartframe,int shadowwidth,float delaytime,bool rangeattack,int elementtype)//Unit
    {
        
        _ObjName = name;
        gameObject.name = enginename;
        GetComponent<UISprite>().atlas = atlas;

        _MaxHP = hp;
        _HP = hp;
        _Damage = damage;
        _Range = range;
        _HitRange = hitrange;
        _MoveSpeed = movespeed;
        _maxStayFrame = maxstay;
        _maxWalkFrame = maxwalk;
        _maxAttackFrame = maxattack;
        _AttactDamageFrame = attactdamageframe;
        _AttactStartFrame = attackstartframe;
        gameObject.transform.localPosition = _startPos;
        transform.Find("UnitHpBar(Clone)").transform.localPosition = hpbarpos;
        _FootPos = footpos;
        _ShadowSprite.width = shadowwidth;
        _delayTime = delaytime;
        _RangeAttack = rangeattack;
        _Element = elementtype;
    }

    void SetState(string name, string enginename, UIAtlas atlas,  float range, float hitrange, 
        float movespeed, int maxstay, int maxwalk, int[] maxattack, int attactdamageframe, int attackstartframe, int shadowwidth,float delaytime,bool rangeattack)//Hero
    {
        
        _ObjName = name;
        gameObject.name = enginename;
        GetComponent<UISprite>().atlas = atlas;
        
        _Range = range;
        _HitRange = hitrange;

        int basepower = 1;
        int basepowermultyple = 1;
        int baseintellect = 1;
        int baseintellectmultyple = 1;
        int basehealth = 1;
        int basehealthmultyple = 1;
        int basehpmultyple = 1;

        if(_Type==1)
        {
            basepower = 30;
            basepowermultyple = 30;
            baseintellect = 10;
            baseintellectmultyple = 10;
            basehealth = 40;
            basehealthmultyple = 40;
            basehpmultyple = 1000;
        }
        if(_Type==2)
        {
            basepower = 1;
            basepowermultyple = 1;
            baseintellect = 4;
            baseintellectmultyple = 5;
            basehealth = 2;
            basehealthmultyple = 1;
            basehpmultyple = 50;
        }

        HeroItem weapon = new HeroItem();
        HeroItem armor = new HeroItem();
        if (StaticDataMng._HeroSetItem_Armor.Count != 0)
        {
            armor._AttackPoint = StaticDataMng._HeroSetItem_Armor[0]._AttackPoint;
            armor._PowerPoint = StaticDataMng._HeroSetItem_Armor[0]._PowerPoint;
            armor._IntellectPoint = StaticDataMng._HeroSetItem_Armor[0]._IntellectPoint;
            armor._ArmorPoint = StaticDataMng._HeroSetItem_Armor[0]._ArmorPoint;
            armor._HealthPoint = StaticDataMng._HeroSetItem_Armor[0]._HealthPoint;
        }
        if (StaticDataMng._HeroSetItem_Weapon.Count != 0)
        {
            weapon = StaticDataMng._HeroSetItem_Weapon[0];
            weapon._AttackPoint = StaticDataMng._HeroSetItem_Weapon[0]._AttackPoint;
            weapon._PowerPoint = StaticDataMng._HeroSetItem_Weapon[0]._PowerPoint;
            weapon._IntellectPoint = StaticDataMng._HeroSetItem_Weapon[0]._IntellectPoint;
            weapon._ArmorPoint = StaticDataMng._HeroSetItem_Weapon[0]._ArmorPoint;
            weapon._HealthPoint = StaticDataMng._HeroSetItem_Weapon[0]._HealthPoint;
        }

        _Damage = 20+ weapon._AttackPoint;
        _Stat_Power = basepower + (StaticDataMng._HeroLevel * basepowermultyple) + armor._PowerPoint + weapon._PowerPoint;
        _Stat_Intellect = baseintellect + (StaticDataMng._HeroLevel * baseintellectmultyple) + armor._IntellectPoint + weapon._IntellectPoint;
        _Stat_Health = basehealth + (StaticDataMng._HeroLevel * basehealthmultyple) + armor._HealthPoint + weapon._HealthPoint;
        _Stat_Armor = armor._ArmorPoint + weapon._ArmorPoint;
        _Stat_BaseHp = 2000 + basehpmultyple * StaticDataMng._HeroLevel;

        _MaxHP = (_Stat_BaseHp + ((2 * _Stat_Armor * _Stat_Health)/10));
        _HP = _MaxHP;

        if(StaticDataMng._StoryNum == 1)
        {
            _MaxHP *=2;
            _HP = _MaxHP;
        }

        //Debug.Log(_Damage);
        //Debug.Log(_Stat_Power);

        //_Damage = damage;
        _MoveSpeed = movespeed;
        _maxStayFrame = maxstay;
        _maxWalkFrame = maxwalk;
        _maxAttackFrameArr = maxattack;
        _AttactDamageFrame = attactdamageframe;
        _AttactStartFrame = attackstartframe;
        gameObject.transform.localPosition = _startPos;
        //Debug.Log(name+_startPos.ToString());
        _FootPos = new Vector2(0, 20);
        _ShadowSprite.width = shadowwidth;
        _delayTime = delaytime;
        _RangeAttack = rangeattack;
    }

    bool Attack_Miss(Unit targetUnit)
    {
        if (Random.Range(0, 100) < 100 - targetUnit._AvoidLate + _Evasion)
            return false;
        else
            return true;
    }

    float _getMoveSpeed()
    {
        return _MoveSpeed + (_MoveSpeed * (_MoveSpeedAdding / 100));
    }

    public Vector2 _getPosition()
    {
        return gameObject.transform.localPosition;
    }


    bool InRange()
    {
        if (Mathf.Sqrt(Mathf.Pow(transform.localPosition.x - _targetObject.transform.localPosition.x, 2) +
            Mathf.Pow(transform.localPosition.y - _targetObject.transform.localPosition.y, 2)) - (_Range + _targetObject._HitRange) <= 0.0f)
        {
            if (_NowState != "skill_1" && _NowState != "skill_2" && _NowState != "skill_3" && _NowState != "skill_4" && _NowState != "skill_5" && _NowState != "skill_6" || _NowState == "skill_7" || _NowState == "skill_8") 
            {
                _AttackActionTime += Time.smoothDeltaTime;
                if (_AttackActionTime >= _AttackDelayTime)
                {
                    if (_Rating == 4)
                    {
                        _AniLoop = false;
                        _NowState = "attack";
                    }
                    else
                        SetSprite_Attack();

                }
            }
            return true;
        }
        return false;
    }

    public void Hit_Reding()
    {
        _redingAlpha = 0;
        //if (have.o_List.Count == 0)
        //{
        //    MoveBy moveby = new MoveBy(gameObject, new Vector3(-2.5f, 0, 0), true, false, 0.1f);
        //    have.o_List.Add(moveby);
        //    moveby = new MoveBy(gameObject, new Vector3(5, 0, 0), true, false, 0.1f);
        //    have.o_List.Add(moveby);
        //    moveby = new MoveBy(gameObject, new Vector3(-2.5f, 0, 0), true, false, 0.1f);
        //    have.o_List.Add(moveby);
        //}

    }

    public void SetAlpha()
    {
        _spriteAlpha = 0;
    }

    void SetFrame()
    {
        if(_NowState=="attack")
        {
            for (int i = 0; i < _BuffList.Count; i++)
            {
                if (_BuffList[i]._BuffType == 1)
                {
                    if (_BuffList[i]._MotionChangeNum != 0)
                        _NowState = "attack_special_" + _BuffList[i]._MotionChangeNum.ToString();
                    if(_BuffList[i]._MotionChangeNum == 2)
                    {
                        //수탄
                        Vector3[] pos = { new Vector3(-300, 100), new Vector3(-250, 140), new Vector3(-200, 180), new Vector3(-150, 200), new Vector3(-100, 240), };
                        for(int s=0;s<pos.Length;s++)
                        {
                            if(_targetObject!=null)
                            {
                                GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._Parent, GameMng.Data._TargetObjList._WaterBullet);
                                float radi = Mathf.Atan2(_targetObject.transform.localPosition.y - obj.transform.localPosition.y,
                                    _targetObject.transform.localPosition.x - obj.transform.localPosition.x);
                                //Debug.Log(radi * Mathf.Rad2Deg);
                                obj.GetComponent<Skill_TargettingProjectiles>()._init(GetComponent<Unit>(), _targetObject, transform.localPosition + pos[s], 1, 0, 1, StaticDataMng._WaterSkill_High_First[StaticDataMng._SkillLevel_High_9 - 1], true, 9);
                            }
                        }
                    }
                }
            }
        }
        if (_Rating == 4 && _NowState == "attack")
            gameObject.GetComponent<UISprite>().spriteName = _ObjName + "_" + _NowState + "_" + _directionFrame + "_" + _AttackMotionKind.ToString() + "_" + _nowFrame;
        else
            gameObject.GetComponent<UISprite>().spriteName = _ObjName + "_" + _NowState + "_" + _directionFrame + "_" + _nowFrame;
        _MyCollider.radius = _HitRange-10.0f;
        //_MyCollider.offset = _FootPos;
    }

    void SetDirection(float radi)
    {
        radi *= Mathf.Rad2Deg;
        //Debug.Log(radi);
        if (radi > 45 && radi <= 135)
            _directionFrame = "up";
        else if ((radi > 135 && radi <= 180)||(radi<=-135))
            _directionFrame = "left";
        else if (radi<=-45&&radi>=-135)
            _directionFrame = "down";//임시
        else
            _directionFrame = "right";
    }

    int ReturnSign(float num)
    {
        if (num < 0.0f)
            return -1;
        else
            return 1;
    }

    public void ForHero_SetGroundBarrior(float time)
    {
        StartCoroutine(SetGroundBarrior(time));
    }
    IEnumerator SetGroundBarrior(float time)
    {
        yield return new WaitForSeconds(time);

        //Debug.Log("On");
        _OneInvincibleShield = true;

        _GroundBarrior.SetActive(true);
    }

    public void SetCantTarget_False(float time)
    {
        StartCoroutine(SetCantTarget(time, false));
    }

    IEnumerator SetCantTarget(float time,bool value)
    {
        yield return new WaitForSeconds(time);

        _CantTarget = value;
    }

    public void Break_OneInvincibleShield()
    {
        _OneInvincibleShield = false;
        _GroundBarrior.SetActive(false);
        GameObject obj = NGUITools.AddChild(gameObject, GameMng.Data._EffectAnimation._GroundBarriorBreak);
       // obj.transform.localPosition = GameMng.Data._GameDate._HeroUnit._FootPos;
    }
}

public struct HitCount
{
    public float _time;
    public int _dmg;

    public HitCount(float t, int d)
    {
        _time = t;
        _dmg = d;
    }
}