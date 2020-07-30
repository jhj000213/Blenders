using UnityEngine;
using System.Collections;

public class RandomRotate : MonoBehaviour {

	void Start () 
    {
        gameObject.transform.localEulerAngles = new Vector3(0, 0, Random.Range(0, 360.0f));
	}
}
