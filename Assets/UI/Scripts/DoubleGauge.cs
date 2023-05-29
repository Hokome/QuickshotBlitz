using UnityEngine;

//Originally from AssetFactory
namespace QuickshotBlitz.UI
{
    public class DoubleGauge : MonoBehaviour
    {
        [SerializeField] private float min = 0f;
        [SerializeField] private float max = 1f;
        [SerializeField] private float value = 0.2f;
        [SerializeField] private float subValue = 0.4f;
        [Header("Display")]
        [SerializeField] private Color mainColor;
        [SerializeField] private Color subIncreaseColor;
        [SerializeField] private Color subDecreaseColor;
        [SerializeField] private float animationTime;
        [Header("References")]
        [SerializeField] private SubGauge front;
        [SerializeField] private SubGauge back;

        private SubGauge _main;
        private SubGauge _sub;

        private LTDescr _anim;
        private bool _isAnimating;
        private bool _isIncreasing;
        private bool Increasing
        {
            get => _isIncreasing;
            set
            {
                _isIncreasing = value;
                if (value)
                {
                    _main = back;
                    _sub = front;
                    back.Color = subIncreaseColor;
                }
                else
                {
                    _main = front;
                    _sub = back;
                    back.Color = subDecreaseColor;
                }
            }
        }

        public float Value
        {
            get => value;
            set
            {
                float newValue = Mathf.Clamp(value, min, max);
                if (newValue == this.value) return;
                this.value = newValue;

                bool increasing = this.value > subValue;
                if (_isAnimating)
                {
                    if (Increasing != increasing)
                        ForceUpdate();
                    LeanTween.cancel(_anim.uniqueId);
                }
                Increasing = increasing;
                _main.Value = newValue;

                _isAnimating = true;
                _anim = LeanTween.value(
                    gameObject,
                    v => SubValue = v,
                    subValue,
                    value,
                    animationTime)
                    .setOnComplete(ForceUpdate);
            }
        }
        public float SubValue
        {
            get => subValue;
            set
            {
                subValue = value;
                _sub.Value = value;
            }
        }

        public float Min
        {
            get => min;
            set
            {
                min = value;
                front.Min = value;
                back.Min = value;
            }
        }
        public float Max
        {
            get => max;
            set
            {
                max = value;
                front.Max = value;
                back.Max = value;
            }
        }

        public void ForceUpdate()
        {
            if (_isAnimating)
                LeanTween.cancel(_anim.uniqueId);
            _isAnimating = false;

            subValue = value;
            front.Value = value;
            back.Value = value;
        }

        private void Start() => Init();
#if UNITY_EDITOR
        private void OnValidate() => UnityEditor.EditorApplication.delayCall += Init;
#endif
        private void Init()
        {
            if (front == null || back == null) return;
            Increasing = Value > subValue;

            front.Color = mainColor;
            front.Value = value;
            Min = min;
            Max = max;
            _main.Value = Value;
            _sub.Value = subValue;
        }
    }
}
