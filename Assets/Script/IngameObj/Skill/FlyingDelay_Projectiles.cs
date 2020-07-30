using UnityEngine;
using System.Collections;

public class FlyingDelay_Projectiles : MonoBehaviour {

    public float _delayTime;
    public bool _Targetting;

    public float _backspeed;
    public float _shootspeed;


    void Update()
    {
        _delayTime -= Time.smoothDeltaTime;
        float speed;
        if (_delayTime <= 0.0f)
            speed = _shootspeed;
        else
            speed = -_backspeed;

        if (_Targetting)
            GetComponent<Skill_TargettingProjectiles>().fSpeed = speed;
        else
            GetComponent<Skill_Projectiles>().fSpeed = speed;
    }
}
