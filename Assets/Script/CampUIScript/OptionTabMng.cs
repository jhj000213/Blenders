using UnityEngine;
using System.Collections;

public class OptionTabMng : MonoBehaviour {

    public bool _OnOptionTab = false;
    public GameObject _OptionTab;
    public GameObject _Arrow;
    public UISprite _SpeakerSprite;
    public UISprite _VibSprite;

    public GameObject _HelpPopup;
    public UILabel _HelpTabNumLabel;
    public GameObject[] _TabList;
    public int _HelpTabNum;
    public GameObject _BackButton;
    public GameObject _NextButton;
    public GameObject _EditorPopup;

    public PublicSoundData _SoundData;

    void Start()
    {
        _HelpTabNum = 1;
    }
    void Update()
    {
        if (StaticDataMng._SoundOn == 1)
            _SpeakerSprite.spriteName = "soundicon_on";
        else
            _SpeakerSprite.spriteName = "soundicon_off";

        if (StaticDataMng._SoundOn == 1)
            _VibSprite.spriteName = "vibonicon";
        else
            _VibSprite.spriteName = "vibofficon";

        _HelpTabNumLabel.text = _HelpTabNum.ToString();
        for (int i = 0; i < 3; i++)
        {
            _TabList[i].SetActive(false);
        }
        _TabList[_HelpTabNum - 1].SetActive(true);
        if (_HelpTabNum == 1)
        {

            _NextButton.SetActive(true);
            _BackButton.SetActive(false);
        }
        else if (_HelpTabNum == 2)
        {
            _NextButton.SetActive(true);
            _BackButton.SetActive(true);
        }
        else if (_HelpTabNum == 3)
        {
            _NextButton.SetActive(false);
            _BackButton.SetActive(true);
        }
    }

    public void TouchArrow()
    {
        AudioSource.PlayClipAtPoint(_SoundData._ButtonTouch, Vector2.zero, StaticDataMng._SoundOn);
        _OnOptionTab = !_OnOptionTab;
        if (_OnOptionTab)
        {
            _OptionTab.GetComponent<Animator>().SetTrigger("left");
            _Arrow.transform.localEulerAngles = new Vector3(0,0,0);
        }
        else
        {
            _OptionTab.GetComponent<Animator>().SetTrigger("right");
            _Arrow.transform.localEulerAngles = new Vector3(0, 0, 180);
        }
    }

    public void TouchSpeaker()
    {
        if (StaticDataMng._SoundOn == 1)
            StaticDataMng._SoundOn = 0;
        else
            StaticDataMng._SoundOn = 1;
    }

    public void TouchVibrator()
    {
        if (StaticDataMng._VibOn == 1)
            StaticDataMng._VibOn = 0;
        else
            StaticDataMng._VibOn = 1;

        if (StaticDataMng._VibOn == 1)
            _VibSprite.spriteName = "vibonicon";
        else
            _VibSprite.spriteName = "vibofficon";

    }

    public void OnHelpTab()
    {
        _HelpPopup.SetActive(true);
        _HelpTabNum = 1;
    }

    public void OffHelpTab()
    {
        _HelpPopup.SetActive(false);

    }
    public void NextTab()
    {
        _HelpTabNum++;
    }
    public void BackTab()
    {
        _HelpTabNum--;
    }

    public void OnEditorTab()
    {
        _EditorPopup.SetActive(true);
    }

    public void OffEditorTab()
    {
        _EditorPopup.SetActive(false);

    }
}
