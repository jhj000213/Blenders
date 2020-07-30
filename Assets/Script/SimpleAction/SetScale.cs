using UnityEngine;
using System.Collections;

public class SetScale : MonoBehaviour {

    public float _Scale;
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(_Scale, _Scale, 1);
	
	}
}
