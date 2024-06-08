using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]
public class LevelCreator : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Level level = (Level)target;

        if (GUILayout.Button("Create  Empty Level"))
        {
            level.CreateLevelEmpty();
        }

        if (GUILayout.Button("StartBlock"))
        {
            level.StartBlock();
        }

        GUILayout.BeginHorizontal();

        if (GUILayout.Button(" Block1"))
        {
            level.block1();
        }
        if (GUILayout.Button("Block2"))
        {
            level.block2();
        }
        

        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Block3"))
        {
            level.block3();
        }

        if (GUILayout.Button("Block4"))
        {
            level.block4();
        }
        if (GUILayout.Button("Block5"))
        {
            level.block5();
        }

        GUILayout.EndHorizontal();
        if (GUILayout.Button("Finish Line!"))
        {
            level.endblock();
        }
    }
}
