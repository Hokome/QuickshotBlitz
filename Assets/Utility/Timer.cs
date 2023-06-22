using System;
using System.Collections;
using UnityEngine;

namespace QuickshotBlitz
{
    /// <summary>
    /// Class providing useful timing functions as well as a custom inspector.
    /// </summary>
    [Serializable]
    public struct Timer
    {
        public float duration;
        public float StartTime { get; private set; }
        public Timer(float duration)
        {
            this.duration = duration;
            StartTime = float.NegativeInfinity;
            LastCoroutine = null;
        }

        /// <summary>
        /// How much time passed since the timer started.
        /// </summary>
        public float TimeElapsed => Time.time - StartTime;
        /// <summary>
        /// How much is left before the timer finishes.
        /// </summary>
        public float TimeLeft => duration - TimeElapsed;
        /// <summary>
        /// How much time passed since the timer started, divided by the duration. Equal to 1 when timer just finished
        /// </summary>
        public float TimeElapsedRatio => TimeElapsed / duration;
        /// <summary>
        /// How much time is left before the timer finishes, divided by the duration. Equal to 0 when timer just finished.
        /// </summary>
        public float TimeLeftRatio => TimeLeft / duration;

        /// <summary>
        /// Check if the timer was started and not reset.
        /// </summary>
        public bool HasStarted => StartTime > 0f;
        /// <summary>
        /// Checks if the timer supposedly finished. This will not check if the timer was started in the first place.
        /// To do that, check <see cref="HasStarted"/> before using this, or use <see cref="StartedAndFinished"/> instead.
        /// </summary>
        public bool HasFinished => TimeElapsed >= duration;
        /// <summary>
        /// Checks if the timer was started and has finished.
        /// </summary>
        public bool StartedAndFinished => HasStarted && HasFinished;

        public void Start() => StartTime = Time.time;

        public Coroutine LastCoroutine { get; private set; }
        /// <summary>
        /// Starts a coroutine that calls the provided action when the timer's duration has passed. It is not synchronized with the timer itself, it just uses its duration.
        /// </summary>
        /// <param name="owner">MonoBehaviour to call the coroutine on</param>
        /// <param name="callback">Callback to execute when coroutine finishes</param>
        /// <returns>A reference to the coroutine</returns>
        public Coroutine StartCoroutine(MonoBehaviour owner, Action callback)
        {
            LastCoroutine = owner.StartCoroutine(Coroutine(callback));
            return LastCoroutine;
        }

        //public void StopCoroutine(MonoBehaviour mb)
        //{
        //	if (LastCoroutine != null)
        //		mb.StopCoroutine(LastCoroutine);
        //}

        /// <summary>
        /// Resets the timer. After reset, <see cref="HasStarted"/> will always be false but <see cref="HasFinished"/> will always be true.
        /// </summary>
        public void Reset() => StartTime = float.NegativeInfinity;

        private IEnumerator Coroutine(Action callback)
        {
            yield return this;
            callback?.Invoke();
        }

        /// <summary>
        /// Uses the timer's duration to make a <see cref="YieldInstruction"/>. In that case <see cref="WaitForSeconds"/>
        /// </summary>
        public static implicit operator WaitForSeconds(Timer t) => new(t.duration);

        /// <summary>
        /// Uses the timer's duration to make a <see cref="YieldInstruction"/>. In that case <see cref="WaitForSecondsRealtime"/>
        /// </summary>
        public static explicit operator WaitForSecondsRealtime(Timer t) => new(t.duration);
    }
}
