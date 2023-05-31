using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickshotBlitz
{
    public class PlayerSpawnPoint : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                Player p = collision.GetComponent<Player>();
                p.SpawnPoint = this;
            }
        }
    }
}
