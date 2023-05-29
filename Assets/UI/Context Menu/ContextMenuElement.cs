using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuickshotBlitz.UI
{
    [RequireComponent(typeof(LayoutElement))]
    public abstract class ContextMenuElement : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;

        public string Label
        {
            get => _label.text;
            set => _label.text = value;
        }
    }
}
