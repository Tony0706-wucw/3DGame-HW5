using UnityEngine;
using UnityEditor;

namespace HitUFO{
[CustomEditor(typeof(UFO))]
public class SetGui : Editor //继承editor类
{
    public override void OnInspectorGUI()
    {
        var target = (UFO)serializedObject.targetObject; //获取对象

        EditorGUILayout.Space(); //空行
        Vector3 startPosition = EditorGUILayout.Vector3Field("StartPosition",UFO.startPosition); //文本，数值域
        UFO.startPosition = startPosition;

        EditorGUILayout.Space();
        Vector3 startSpeed = EditorGUILayout.Vector3Field("StartSpeed",UFO.startSpeed);
        UFO.startSpeed = startSpeed;

        EditorGUILayout.Space();
        Vector3 localScale = EditorGUILayout.Vector3Field("LocalScale",UFO.localScale);
        UFO.localScale = startPosition;        
    }
}
}
