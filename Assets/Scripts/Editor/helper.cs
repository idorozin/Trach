using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ccc))]
public class helper : Editor
{
    private ccc Cur;

    private void OnEnable()
    {
        ccc Cur = (ccc)target;
    }

    public override void OnInspectorGUI()
    {
        
        base.OnInspectorGUI();
        ccc Cur = (ccc)target;

        if (GUILayout.Button("create"))
        {
            for (int i = 0; i < Cur.amount; i++)
            {
                Debug.Log(Cur.lastPos);
                GameObject go = Instantiate(Cur.prefab);
                go.transform.parent = Cur.parent.transform;

                go.transform.localPosition = Cur.lastPos;


                Cur.lastPos = new Vector3(Cur.lastPos.x, Cur.lastPos.y + Cur.extra, Cur.lastPos.z);
            }
        }
    }
}
