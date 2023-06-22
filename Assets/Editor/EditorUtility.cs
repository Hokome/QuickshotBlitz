using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace QuickshotBlitz.Editor
{
    public class PropertyDrawHelper
    {
        private PropInfo[] _propInfos;
        public float labelWidth = 45f;
        public float spacing = 2f;
        //public void SetLabels(params string[] labels)
        //{
        //    for (int i = 0; i < _propInfos.Length && i < labels.Length; i++)
        //    {
        //        _propInfos[i].label = labels[i];
        //    }
        //}

        public PropertyDrawHelper(params PropInfo[] props)
        {
            _propInfos = props;
        }

        public void Draw(Rect position)
        {
            EditorGUIUtility.labelWidth = labelWidth;

            float width = position.width / _propInfos.Length;

            // Since spacing is only in between rects, we substract 1
            width -= spacing * _propInfos.Length - 1;

            for (int i = 0; i < _propInfos.Length; i++)
            {
                Rect propRect = position;
                propRect.width -= width;
                propRect.x += i * (width + spacing);
                _propInfos[i].Draw(propRect);
            }
        }

        public struct PropInfo
        {
            public SerializedProperty prop;
            public string label;
            /// <summary>
            /// Whether the property is a reference to an <see cref="UnityEngine.Object"/> (true) or a value (false).
            /// </summary>
            public bool reference;

            public PropInfo(SerializedProperty parent, string id, string label, bool reference = false)
            {
                prop = parent.FindPropertyRelative(id);
                this.label = label;
                this.reference = reference;
            }
            public void Draw(Rect position)
            {
                if (reference)
                    EditorGUI.ObjectField(position, prop, new GUIContent(label));
                else
                    EditorGUI.PropertyField(position, prop, new GUIContent(label));
            }
        }
    }
}
