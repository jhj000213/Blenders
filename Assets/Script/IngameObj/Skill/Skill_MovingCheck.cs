using UnityEngine;
using System.Collections;

public class Skill_MovingCheck : MonoBehaviour {

    
	void Update()
    {
        if (GameMng.Data._MoveBg)
            transform.localPosition -= new Vector3(252 * Time.smoothDeltaTime,0 );
    }
}
