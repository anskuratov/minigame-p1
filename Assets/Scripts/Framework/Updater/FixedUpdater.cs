using UnityEngine;

namespace P1.Framework
{
	public class FixedUpdater : BaseUpdater
	{
		public void FixedUpdate()
		{
			foreach (var updatable in Updatables)
			{
				updatable.Update(Time.fixedDeltaTime);
			}
		}
	}
}