/*using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(ProbabilityGameObjectPool)),CanEditMultipleObjects]
public class CustomProbabilityGameTagPoolInspectorgo : Editor
{
     SerializedProperty items;

 
    protected virtual void OnEnable () {
        items = this.serializedObject.FindProperty ("items");

    }
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Undo.RecordObject(target , "izisk");

        var probabilityItemPool = (ProbabilityGameObjectPool) target;


        ProbInspector(probabilityItemPool);

    }

    private  void ProbInspector(ProbabilityGameObjectPool probabilityItemPool)
    {


        var toAdd = new PObject<GameObject>();
        if (GUILayout.Button("Add"))
        {
            probabilityItemPool.items.Add(toAdd);
        }

        List<int> itemsToRemove = new List<int>();
        int min = 0;
        int sum = 0;
        int place = 0;
        EditorGUI.BeginChangeCheck();

        foreach (var item in probabilityItemPool.items)
        {
            EditorGUILayout.BeginHorizontal();
            item.minRange = min;
            item.maxRange = min + item.probability;

            if (item.maxRange > probabilityItemPool.outOf)
            {
                item.probability = Math.Max(0, probabilityItemPool.outOf - min);
                item.maxRange = min + item.probability;
            }

            min = item.maxRange;
            sum += item.probability;
            item.item = (GameObject)EditorGUILayout.ObjectField(item.item,typeof(GameObject),true);
            item.probability = (int) EditorGUILayout.Slider(item.probability, 0, probabilityItemPool.outOf);

            if (GUILayout.Button("X"))
            {
                itemsToRemove.Add(place);
            }

            place += 1;
            EditorGUILayout.EndHorizontal();
        }

        foreach (var remove in itemsToRemove)
        {
            probabilityItemPool.items.RemoveAt(remove);
        }
  
        EditorGUILayout.LabelField("%" + sum);
    }
}*/