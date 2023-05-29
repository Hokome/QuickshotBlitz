using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickshotBlitz
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public Player Player { get; set; }
    }
}
