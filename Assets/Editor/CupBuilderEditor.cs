using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CupView))]
public class CupBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CupView cupView = (CupView)target;

        if(GUILayout.Button("Build"))
        {
            cupView.BuildWalls();
        }
    }
}