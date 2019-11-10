using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[AddComponentMenu("TTransform")]
[CustomPropertyDrawer(typeof(Transform))]
public class TTransform : PropertyDrawer {

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        //Drawing label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        //Keep children unindented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        //Calculate Rects
        var amountRect = new Rect(position.x, position.y, 30, position.height);
        var unitRect = new Rect(position.x + 35, position.y, 50, position.height);
        var nameRect = new Rect(position.x + 90, position.y, position.width - 90, position.height);

        //Draw fields

        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative("position"), GUIContent.none);
        //EditorGUI.PropertyField(unitRect, property.FindPropertyRelative("rotation"), GUIContent.none);
        //EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("lossyScale"), GUIContent.none);

        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();
    }
}
