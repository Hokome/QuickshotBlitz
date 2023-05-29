using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace QuickshotBlitz.UI
{
    public class SliderContextMenuElement : ContextMenuElement
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _sliderValueText;

        public void UpdateValueText(float value) => _sliderValueText.text = value.ToString();

        public void SetRange(Range range) => SetRange(range.min, range.max);
        public void SetRange(float max) => SetRange(0f, max);
        public void SetRange(float min, float max)
        {
            _slider.minValue = min;
            _slider.maxValue = max;
        }

        public void AddListener(Action<float> action) => _slider.onValueChanged.AddListener(v => action(v));
        public void RemoveListener(Action<float> action) => _slider.onValueChanged.RemoveListener(v => action(v));
    }
}
