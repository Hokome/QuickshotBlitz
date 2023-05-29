using UnityEngine;

namespace QuickshotBlitz
{
    public abstract class MonoSingleton<T> : MonoBehaviour, ISingleton<T> where T : MonoSingleton<T>
    {
        /// <summary>
        /// Instance of the singleton class. To check if the instance exists, use <see cref="Exists"/>.
        /// </summary>
        public static T Inst => ISingleton<T>.Inst;
        public static bool Exists => ISingleton<T>.Exists;
        protected virtual void Awake() => ISingleton<T>.Inst = (T)this;
    }
}
