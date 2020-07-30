using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class SceneChangeMng : MonoBehaviour {

    public bool _SaveMngOn;
    public DataSaveMng _SaveMng;

    public PopupNumMng _UIMng;
    public GameObject _Parent;
    public GameObject _FadeIn;
    public int _TitleScene = 1;
    public int _CampScene = 2;
    public int _GameScene = 3;

    public string _RightGrass = "동쪽 태양들판";
    public string _LeftGrass = "서쪽 태양들판";
    public string _FireForest = "불타는 숲";
    public string _SnowMountain = "설산";
    public string _DestroyVillage = "민가";
    public string _Castle = "선스피어";
    public string _Cave = "아라드라";
    public string _Port = "에이즈네브 항구";
    public string _Ship = "해상 위의 격전";
    public string _HideoUpVillage = "북부 민가";
    public string _HideoDownVillage = "남부 민가";
    public string _HideoSnowMountain = "히데오 산맥";


    public void SceneChange(int num)
    {
        
        Time.timeScale = 1.0f;
        if (num == 4)
        {
            if (StaticDataMng._StoryNum == 1)
            {
                GameObject obj = NGUITools.AddChild(_Parent, _FadeIn);
                StartCoroutine(SceneChangeDelay(1.5f, 3));
            }
            else
            {
                GameObject obj = NGUITools.AddChild(_Parent, _FadeIn);
                StartCoroutine(SceneChangeDelay(1.5f, 2));
            }

        }
        else if (StaticDataMng._StoryGoGameScene)
        {
            StaticDataMng._StoryGoGameScene = false;
            GameObject obj = NGUITools.AddChild(_Parent, _FadeIn);
            StartCoroutine(SceneChangeDelay(1.5f, 3));
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "BasecampScene")
            {
                if (StaticDataMng._PormationList.Count >= 7)
                {
                    GameObject obj = NGUITools.AddChild(_Parent, _FadeIn);
                    StartCoroutine(SceneChangeDelay(1.5f, num));
                }
                else
                    _UIMng._NoPormationOn = 1;
            }
            else
            {
                GameObject obj = NGUITools.AddChild(_Parent, _FadeIn);
                StartCoroutine(SceneChangeDelay(1.5f, num));
            }
        }
    }

    IEnumerator SceneChangeDelay(float time, int num)
    {
        yield return new WaitForSeconds(time);
        if (_SaveMngOn)
            _SaveMng.Saving();
        if(StaticDataMng._StoryOn)
            SceneManager.LoadScene(StaticDataMng._StoryScene);
        else
        {
            if (num == 1)
                SceneManager.LoadScene("TitleScene");
            else if (num == 2)
                SceneManager.LoadScene("BasecampScene");
            else if (num == 3)
            {
                    SceneManager.LoadScene("GameScene");
            }
                
        }
    }

    public void SetStageName(string name)
    {
            StaticDataMng._SelectStageName = name;
            if (SceneManager.GetActiveScene().name == "BasecampScene")
                _UIMng.SetMobList();
    }
}
