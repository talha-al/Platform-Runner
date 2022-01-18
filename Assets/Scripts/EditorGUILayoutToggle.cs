using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorGUILayoutToggle : UnityEditor.EditorWindow
{
    [MenuItem("Editor/Settings")]
    static void Init()
    {
        EditorGUILayoutToggle window = (EditorGUILayoutToggle)EditorWindow.GetWindow(typeof(EditorGUILayoutToggle), true, "Settings");
        window.Show();
    }

    void OnGUI()
    {
        if (GUILayout.Button("Clear PlayerPrefs")) PlayerPrefs.DeleteAll();
        if (GUILayout.Button("Close")) this.Close();
    }
}
