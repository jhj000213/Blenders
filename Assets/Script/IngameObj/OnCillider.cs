using UnityEngine;
using System.Collections;

public class OnCillider : MonoBehaviour {

    public bool _OffCollider;
    public float _onTime;
    public float _offTime;
    public bool _imfact;


    IEnumerator Start()
    {
        yield return new WaitForSeconds(_onTime);

        GetComponent<PolygonCollider2D>().enabled = true;
        if(_imfact)
            GameMng.Data._Camera.MoveCamera();

        if (_OffCollider)
            StartCoroutine(Off());
    }

    IEnumerator Off()
    {
        yield return new WaitForSeconds(_offTime);

        GetComponent<PolygonCollider2D>().enabled = false;
    }
}
