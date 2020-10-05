/*
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ProbabilityGameTagPool))]
public class CustomProbabilityGameTagPoolInspector : Editor
{
    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        base.OnInspectorGUI();

        var probabilityItemPool = (ProbabilityGameTagPool) target;
        Undo.RecordObject(target, "Changed Area Of Effect");

        ProbInspector(probabilityItemPool);
        Undo.RecordObject(target, "Changed Area Of Effect");

    }

    private static void ProbInspector(ProbabilityGameTagPool probabilityItemPool)
    {
        var toAdd = new PObject<string>();
        toAdd.prob = new Probability();
        if (GUILayout.Button("Add"))
        {
            probabilityItemPool.items.Add(toAdd);
        }

        List<int> itemsToRemove = new List<int>();
        int min = 0;
        int sum = 0;
        int place = 0;
        foreach (var item in probabilityItemPool.items)
        {
            EditorGUILayout.BeginHorizontal();
            item.prob.minRange = min;
            item.prob.maxRange = min + item.prob.probability;

            if (item.prob.maxRange > probabilityItemPool.outOf)
            {
                item.prob.probability = Math.Max(0, probabilityItemPool.outOf - min);
                item.prob.maxRange = min + item.prob.probability;
            }

            min = item.prob.maxRange;
            sum += item.prob.probability;
            item.item = EditorGUILayout.TextField(item.item, GUILayout.MaxWidth(100));
            item.prob.probability = (int) EditorGUILayout.Slider(item.prob.probability, 0, probabilityItemPool.outOf);

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
}
*/
