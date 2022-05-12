using System.Collections.Generic;
using UnityEngine;

namespace P1.Framework
{
	public abstract class BaseUpdater : MonoBehaviour,
		IUpdater
	{
		protected readonly List<IUpdatable> Updatables = new(4);

		public void Add(IUpdatable updatable)
		{
			if (Updatables.Contains(updatable) == false)
			{
				Updatables.Add(updatable);
			}
		}

		public void Remove(IUpdatable updatable)
		{
			if (Updatables.Contains(updatable))
			{
				Updatables.Remove(updatable);
			}
		}
	}
}