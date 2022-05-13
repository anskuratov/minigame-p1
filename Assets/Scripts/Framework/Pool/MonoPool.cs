using System.Collections.Generic;
using UnityEngine;

namespace P1.Framework
{
	public class MonoPool<T> : IPool<T>
		where T : MonoBehaviour, IReusable
	{
		private readonly T _prefab;
		private readonly Transform _instancesParent;
		private readonly Stack<T> _releasedInstances;

		public MonoPool(T prefab, Transform instancesParent)
		{
			_prefab = prefab;
			_instancesParent = instancesParent;
			_releasedInstances = new Stack<T>(4);
		}

		public T Get()
		{
			T returnValue;

			if (_releasedInstances.Count > 0)
			{
				returnValue = _releasedInstances.Pop();
			}
			else
			{
				returnValue = Object.Instantiate(_prefab, _instancesParent);
			}

			return returnValue;
		}

		public void Put(T reusable)
		{
			reusable.Release();
			_releasedInstances.Push(reusable);
		}
	}
}