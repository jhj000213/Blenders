using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayEffectSound : MonoBehaviour {

    public AudioClip _Audio;
    public float _Volume;

    void Start()
    {
        if (_Volume == 0.0f)
            _Volume = 1.0f;
        if(StaticDataMng._SoundOn==1)
        {
            if (SceneManager.GetActiveScene().name == "GameScene")
            {
                if (GameMng.Data._EffectSoundListObj.transform.childCount <= 29)
                {
                    GameObject obj = NGUITools.AddChild(GameMng.Data._EffectSoundListObj, GameMng.Data._DummySoundObj);
                    obj.GetComponent<RemoveSelfTimer>().DestroyTime = _Audio.length;

                    GameMng.Data._GameDate._SoundEffectList.Add(true);
                    AudioSource.PlayClipAtPoint(_Audio, Vector2.zero,_Volume);
                }
            }
            else
            {
                AudioSource.PlayClipAtPoint(_Audio, Vector2.zero, _Volume);
            }
        }
    }

}
