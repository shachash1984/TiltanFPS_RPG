using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Skill))]
public class SkillDrawer : PropertyDrawer {
    
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        EditorGUIUtility.labelWidth = 50f;

        if(property.objectReferenceValue == null)
        {
            EditorGUI.PropertyField(position, property);
        }
        else
        {
            SerializedObject SO = new SerializedObject(property.objectReferenceValue);

            
            SerializedProperty skillType = SO.FindProperty("skillType");
            SerializedProperty value = SO.FindProperty("value");
            SerializedProperty level = SO.FindProperty("level");

            Rect skillTypePosition = new Rect(position.x, position.y, position.width / 3, position.height);
            Rect valuePosition = new Rect(position.x + position.width / 3, position.y, position.width / 3, position.height);
            //skillType = EditorGUI.EnumPopup(skillTypePosition, skillType.);
            value.intValue = EditorGUI.IntField(valuePosition, "Value: ", value.intValue);
            SO.ApplyModifiedProperties();
        }
        
    }
}
