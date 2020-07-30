using UnityEngine;
using System.Collections;

public class MoveFoward : MonoBehaviour {

    public float _speed;

    void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.smoothDeltaTime);
    }
}
