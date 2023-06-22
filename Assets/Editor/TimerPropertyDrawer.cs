using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QuickshotBlitz.Editor
{
    [CustomPropertyDrawer(typeof(Timer))]
    public class TimerPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            var prop = new PropertyDrawHelper.PropInfo(property, "duration", "Duration", false);
            var helper = new PropertyDrawHelper(prop);
            helper.labelWidth = 60f;
            helper.spacing = 0f;
            helper.Draw(position);
        }
    }
}
