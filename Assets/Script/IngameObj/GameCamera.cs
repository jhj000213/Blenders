using UnityEngine;
using System.Collections;


public class GameCamera : MonoBehaviour {

    HaveList have;
    Vector2 _StartPos;

    void Start()
    {
        have = GetComponent<HaveList>();
        GameMng.Data.n_list.Add(have);
        _StartPos = transform.localPosition;
    }

    public void MoveCamera()
    {
        //if (StaticDataMng._VibOn==1)
        //    Handheld.Vibrate();
        if (have.o_List.Count == 0)
        {
            MoveBy moveby = new MoveBy(gameObject, new Vector3(-15, 10, 0), true, false, 0.03f);
            have.o_List.Add(moveby);
            moveby = new MoveBy(gameObject, new Vector3(10, -5, 0), true, false, 0.03f);
            have.o_List.Add(moveby);
            moveby = new MoveBy(gameObject, new Vector3(-5, 5, 0), true, false, 0.03f);
            have.o_List.Add(moveby);
            moveby = new MoveBy(gameObject, new Vector3(15, -10, 0), true, false, 0.03f);
            have.o_List.Add(moveby);
            moveby = new MoveBy(gameObject, new Vector3(-10, 5, 0), true, false, 0.03f);
            have.o_List.Add(moveby);
            moveby = new MoveBy(gameObject, new Vector3(5, -5, 0), true, false, 0.03f);
            have.o_List.Add(moveby);
        }
    }

}
