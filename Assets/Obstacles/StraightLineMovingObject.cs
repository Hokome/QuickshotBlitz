using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickshotBlitz
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class StraightLineMovingObject : MonoBehaviour
    {
        [SerializeField] private float _speed = 1f;

        /// <summary>
        /// Cached when object is instanciated
        /// </summary>
        [SerializeField] private Vector2 _startPosition;
        /// <summary>
        /// Cached when object is instanciated
        /// </summary>
        [SerializeField] private Vector2 _endPosition;

        // This whole thing allows easy tweaking of the object's path without causing bugs during play mode
        // Right now editing path in edit mode is not supported though

        /// <summary>
        /// Global start position
        /// </summary>
#if UNITY_EDITOR
        public Vector2 StartPosition => Application.isPlaying ? _startPosition : transform.TransformPoint(_startPosition);
#else
        public Vector2 StartPosition => _startPosition;
#endif
        /// <summary>
        /// Global end position
        /// </summary>
#if UNITY_EDITOR
        public Vector2 EndPosition => Application.isPlaying ? _endPosition : transform.TransformPoint(_endPosition);
#else
        public Vector2 EndPosition => _endPosition;
#endif

        public Vector2 CurrentTargetPosition => _gointTowardsEnd ? EndPosition : StartPosition;

        /// <summary>
        /// True if going towards the end position, false if going towards the start position
        /// </summary>
        private bool _gointTowardsEnd = true;
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();

            _startPosition = transform.TransformPoint(_startPosition);
            _endPosition = transform.TransformPoint(_endPosition);

            transform.position = StartPosition;
        }

        private void FixedUpdate()
        {
            float distanceToDestination = Vector2.Distance(_rb.position, CurrentTargetPosition);

            if (distanceToDestination < 0.05f)
                _gointTowardsEnd = !_gointTowardsEnd;

            Vector2 newPos = Vector2.MoveTowards(_rb.position, CurrentTargetPosition, _speed * Time.fixedDeltaTime);
            // Using Rigidbody for cleaner collision and interpolation
            _rb.MovePosition(newPos);
        }
        private void OnDrawGizmosSelected()
        {
            Debug.DrawLine(StartPosition, EndPosition, Color.red);
            DebugEx.DrawCross(StartPosition, Color.magenta, 0.2f);
        }
    }
}
