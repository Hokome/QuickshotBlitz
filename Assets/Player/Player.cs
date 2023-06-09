using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using InputContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace QuickshotBlitz
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IKillable
    {
        [SerializeField] private float _speed;

        public PlayerSpawnPoint SpawnPoint { get; set; }
        public CinemachineVirtualCamera VirtualCamera { get; set; }

        private Rigidbody2D _rb;
        private Vector2 _moveInput;

        private void Start()
        {
            GameManager.Inst.Player = this;
            SpawnPoint = GameManager.Inst.DefaultSpawnPoint;
            transform.position = SpawnPoint.transform.position;
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

        /// <summary>
        /// Makes the player respawn at the appropriate point
        /// </summary>
        public void Kill()
        {
            transform.position = SpawnPoint.transform.position;
            _rb.velocity = Vector2.zero;
        }
    }
}
