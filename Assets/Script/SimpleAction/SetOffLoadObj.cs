using UnityEngine;
using System.Collections;

public class SetOffLoadObj : MonoBehaviour {

    public float _DelayTime;

    public bool _SetOn;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(_DelayTime);
        StaticDataMng._LoadRoot.SetActive(_SetOn);
    }
}
