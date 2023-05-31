using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickshotBlitz
{

    [CreateAssetMenu(fileName = "Level 0", menuName = "Level", order = 1)]
    public class Level : ScriptableObject
    {
        public static Level Current { get; set; }


    }
}
