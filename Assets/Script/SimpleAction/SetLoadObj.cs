using UnityEngine;
using System.Collections;

public class SetLoadObj : MonoBehaviour {

    public GameObject obj;
	// Use this for initialization
	void Awake () 
    {
        DontDestroyOnLoad(obj);

        StaticDataMng._LoadRoot = obj;
	}
	
}
