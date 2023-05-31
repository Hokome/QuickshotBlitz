using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickshotBlitz
{

    [CreateAssetMenu(fileName = "Level Initializer", menuName = "Level Initializer", order = 1)]
    public class LevelInitializer : ScriptableObject
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Camera _cameraPrefab;
        [SerializeField] private CinemachineVirtualCamera _playerCameraPrefab;

        public void Initialize()
        {
            Instantiate(_cameraPrefab);

            var cam = Instantiate(_playerCameraPrefab);
            var player = Instantiate(_playerPrefab);

            cam.Follow = player.transform;
            player.VirtualCamera = cam;
        }
    }
}
