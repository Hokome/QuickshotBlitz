using QuickshotBlitz.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace QuickshotBlitz
{
    public class ContextMenu : MonoBehaviour
    {
        [SerializeField] private SliderContextMenuElement _sliderPrefab;
        [SerializeField] private ButtonContextMenuElement _buttonPrefab;

        public void Flush()
        {
            gameObject.SetActive(false);
            transform.DestroyChildren();
        }

        public void Begin()
        {
            transform.DestroyChildren();
            Vector2 anchoredPosition = Mouse.current.position.ReadValue();

            transform.position = anchoredPosition;
            gameObject.SetActive(true);
        }
        public SliderContextMenuElement AddSlider()
        {
            return Instantiate(_sliderPrefab, transform);
        }
        public ButtonContextMenuElement AddButton()
        {
            return Instantiate(_buttonPrefab, transform);
        }
    }
}
