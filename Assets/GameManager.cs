using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickshotBlitz
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public Player Player { get; set; }

        [SerializeField] private PlayerSpawnPoint _defaultSpawnPoint;
        [SerializeField] private LevelInitializer _levelInitializer;
        public PlayerSpawnPoint DefaultSpawnPoint => _defaultSpawnPoint;

        private void Start()
        {
            _levelInitializer.Initialize();
        }
    }
}
