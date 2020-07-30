using UnityEngine;
using System.Collections;

public class BgMoveOnOff : MonoBehaviour {


	void Update () {
        if (GameMng.Data._MoveBg)
            GetComponent<Animator>().enabled = true;
        else
            GetComponent<Animator>().enabled = false;
	
	}
}
