using UnityEngine;
using System.Collections;

public class SetDepthHpBar : MonoBehaviour {

    public int plus;
	void Update () 
    {
        GetComponent<UISprite>().depth = transform.parent.parent.GetComponent<Unit>()._Depth + plus;
	}
}
