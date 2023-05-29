using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuickshotBlitz
{
	public interface ISingleton<T> where T : Object, ISingleton<T>
	{
		private static T _inst;
		public static T Inst
		{
			get
			{
				if (Exists) return _inst;
				Debug.LogError($"No instance of the singleton type {typeof(T)} has been registered.");
				return null;
			}
			set
			{
				if (Exists)
				{
					Debug.LogWarning($"Singleton for {typeof(T)} already exists.");
					Object.Destroy(value);
					return;
				}
				_inst = value;
			}
		}
		public static bool Exists => _inst != null;
	}
}
