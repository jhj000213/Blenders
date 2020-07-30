using UnityEngine;
using System.Collections;

public class TouchMng : MonoBehaviour {

    public GameObject _UIParent;
    public GameObject _TouchEffect;
    public PublicSoundData _SoundData;


    public GameObject _GameOffPopup;
    public GameObject _PausePopup;

    public StoryActionMng _ActionMng;
    public StoryTellingMng _StoryMng;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(_ActionMng._GameScene)
            {
                if (_PausePopup.activeSelf == false)
                {
                    GameObject eff = NGUITools.AddChild(_UIParent, _TouchEffect);
                    eff.transform.localPosition = new Vector2(Input.mousePosition.x * (1280.0f / Screen.width), Input.mousePosition.y * (720.0f / Screen.height));
                }
            }
            else
            {
                GameObject eff = NGUITools.AddChild(_UIParent, _TouchEffect);
                eff.transform.localPosition = new Vector2(Input.mousePosition.x * (1280.0f / Screen.width), Input.mousePosition.y * (720.0f / Screen.height));
                
            }
            if (_StoryMng._oneLineEnd)
                _StoryMng.SetCharArr();
            else
                _StoryMng._skip = true;
            
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_ActionMng._GameScene)
            {
                if (Time.timeScale == 0.0f)
                    SetResume();
                else
                    SetPause();
            }
            else
            {
                _GameOffPopup.SetActive(!_GameOffPopup.activeSelf);
            }
        }
    }
    public void OnHyperSkill()
    {
        GameMng.Data._HyperSkillMng.UseHyperSkill();
        
    }

    public void SetPause()
    {
        AudioSource.PlayClipAtPoint(_SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
        Time.timeScale = 0.0f;
        _PausePopup.SetActive(true);
    }

    public void SetResume()
    {
        AudioSource.PlayClipAtPoint(_SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
        Time.timeScale = 1.0f;
        _PausePopup.SetActive(false);
    }

    public void GameOffpopupOff()
    {
        AudioSource.PlayClipAtPoint(_SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
        _GameOffPopup.SetActive(false);
    }
    public void GameOff()
    {
        Application.Quit();
    }
}
