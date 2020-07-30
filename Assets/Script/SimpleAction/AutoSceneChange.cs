using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AutoSceneChange : MonoBehaviour {

    public float _DelayTime;
    public string _SceneName;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(_DelayTime);

        SceneManager.LoadScene(_SceneName);
    }
}
