using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickshotBlitz
{
    /// <summary>
    /// Component for everything that can kill things when touching them
    /// </summary>
    public class KillTouch : MonoBehaviour
    {
        [SerializeField] private LayerMask _killMask;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_killMask.ContainsLayer(collision.gameObject.layer))
            {
                if (collision.TryGetComponent(out IKillable killable))
                {
                    killable.Kill();
                }
            }
        }
    }

    public interface IKillable
    {
        void Kill();
    }
}
