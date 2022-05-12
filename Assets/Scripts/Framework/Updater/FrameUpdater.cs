using UnityEngine;

namespace P1.Framework
{
	public class FrameUpdater : BaseUpdater
	{
		public void Update()
		{
			foreach (var updatable in Updatables)
			{
				updatable.Update(Time.deltaTime);
			}
		}
	}
}