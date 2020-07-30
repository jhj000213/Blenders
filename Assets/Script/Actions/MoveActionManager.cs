using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveActionManager : MonoBehaviour
{
    public float ttt = 0.0f;

    private static MoveActionManager instance = null;
	
	public static MoveActionManager MoveActionDate
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType(typeof(MoveActionManager)) as MoveActionManager;
                if (instance == null)
                {
                    Debug.Log("no instance");
                }
            }
            return instance;
        }
    }

    public List<HaveList> n_list = new List<HaveList>();
	void Update () 
    {
        for (int l = 0; l < n_list.Count; l++)
        {
            HaveList list = n_list[l];
            for (int i = 0; i < list.o_List.Count; i++)
            {
                ttt += Time.smoothDeltaTime;
                Action action = list.o_List[i];
                if (action.n_update(Time.smoothDeltaTime) == true)
                    list.o_List.Remove(action);
                break;
            }
        }
            
       
	}
}
