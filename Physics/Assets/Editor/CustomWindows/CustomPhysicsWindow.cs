using UnityEngine;
using System;
using System.Collections;
using UnityEditor;

[Serializable]
public class CustomPhysicsWindow : EditorWindow {
    [SerializeField]
    private Vector3 gravity = new Vector3(0, -9.81f, 0);

    [SerializeField]
    private Vector3 windVelocity = new Vector3(0, 0, 0);

    [SerializeField]
    private float airDensity = 1.225f;


    [MenuItem("Edit/Project Settings/Custom Physics")]
    public static void ShowWindow() {
        EditorWindow.GetWindow(typeof(CustomPhysicsWindow));
    }

    void OnGUI() {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        gravity = EditorGUILayout.Vector3Field("Gravity", gravity);
        EditorPrefs.SetFloat("gravx", gravity.x);
        EditorPrefs.SetFloat("gravy", gravity.y);
        EditorPrefs.SetFloat("gravz", gravity.z);

        windVelocity = EditorGUILayout.Vector3Field("Wind velocity", windVelocity);
        EditorPrefs.SetFloat("windx", windVelocity.x);
        EditorPrefs.SetFloat("windy", windVelocity.y);
        EditorPrefs.SetFloat("windz", windVelocity.z);

        airDensity = EditorGUILayout.FloatField("Float field", airDensity);
        EditorPrefs.SetFloat("airDensity", airDensity);
    }
}
