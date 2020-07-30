using UnityEngine;
using System.Collections;

public class RemoveSelfTimer : MonoBehaviour {
    public float DestroyTime;
    public bool _CallEffect;
    public GameObject _Effect;
    public bool _Parent_Parent;
    public GameObject _EffectParent;
    public bool _setPos;
    public Vector2 _cPos;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(DestroyTime);

        if(_CallEffect)
        {
            if(_Parent_Parent)
            {
                GameObject obj = NGUITools.AddChild(GameMng.Data._GameDate._Parent, _Effect);
                if (_setPos)
                    obj.transform.localPosition = _cPos;
                else
                    obj.transform.localPosition = transform.localPosition;
            }
            else
            {
                GameObject obj = NGUITools.AddChild(_EffectParent, _Effect);
                if (_setPos)
                    obj.transform.localPosition = _cPos;
                else
                    obj.transform.localPosition = transform.localPosition;
            }
            
        }
        Destroy(gameObject);
    }
}