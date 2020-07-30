using UnityEngine;
using System.Collections;

public class SetDepth : MonoBehaviour {

    public bool _haveParent;
    public UI2DSprite _Sprite;

    public bool _Effect;
    public bool _HerosBack;
    public bool _HerosFront;

    public bool _PosToDepth;
    void Start()
    {
        _Sprite = GetComponent<UI2DSprite>();
    }
	void Update () 
    {
	    if(_haveParent)
            _Sprite.depth = 1299 - (int)transform.parent.localPosition.y;

        if(_Effect)
        {
            if (_HerosBack)
                _Sprite.depth = GameMng.Data._GameDate._HeroUnit._Depth - 1;
            else if(_HerosFront)
                _Sprite.depth = GameMng.Data._GameDate._HeroUnit._Depth + 1;
        }

        if(_PosToDepth)
            GetComponent<UI2DSprite>().depth = 1300 - (int)transform.parent.localPosition.y;
	}
}