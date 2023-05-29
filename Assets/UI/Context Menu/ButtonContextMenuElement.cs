using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuickshotBlitz.UI
{
    public class ButtonContextMenuElement : ContextMenuElement
    {
        [SerializeField] private Button _button;
        public void AddListener(Action action) => _button.onClick.AddListener(() => action());
        public void RemoveListener(Action action) => _button.onClick.RemoveListener(() => action());
    }
}
