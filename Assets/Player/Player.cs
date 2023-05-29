using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using InputContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace QuickshotBlitz
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rb;
        private Vector2 _moveInput;

        private void Start()
        {
            GameManager.Inst.Player = this;
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = _moveInput * _speed;
        }

        /// <summary>
        /// This should only be used by <see cref="PlayerInput"/> events
        /// </summary>
        public void SetMoveInput(InputContext ctx)
        {
            _moveInput = ctx.ReadValue<Vector2>();
        }
    }
}
