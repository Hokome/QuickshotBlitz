using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InputContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace QuickshotBlitz
{
    [RequireComponent(typeof(Player))]
    public class Dash : MonoBehaviour
    {
        [SerializeField] private Timer _cooldown;
        [SerializeField] private float _startVelocity;
        [SerializeField] private Timer _duration;

        private Player _player;

        private void Start()
        {
            _player = GetComponent<Player>();
        }

        private void FixedUpdate()
        {

        }

        public void InputDash(InputContext ctx)
        {
            if (!ctx.performed) return;
            if (!_cooldown.HasFinished) return;
        }
    }
}
