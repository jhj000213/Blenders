using UnityEngine;
using System.Collections;

public class BossDead_Action : MonoBehaviour {

    void Start()
    {
        SetTimeScaleEffect();
    }

    void Update()
    {
        TimeScaleUpdate();
    }
	
    public void SetTimeScaleEffect()
    {
        Time.timeScale = 0.01f;
    }
    void TimeScaleUpdate()
    {
        Time.timeScale += Time.timeScale/25;

        if (Time.timeScale >= 1.0f)
        {
            Time.timeScale = 1.0f;
            Destroy(gameObject);
        }

    }
}
