using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public abstract class BaseInputController : IInputController
	{
		protected InputPointer InputPointer;
		protected Camera Camera;

		protected BaseInputController(IUpdater updater, Camera camera)
		{
			InputPointer = new InputPointer();
			Camera = camera;
			updater.Add(this);
		}

		public void Update(double deltaTime)
		{
			HandleUpdate(deltaTime);
		}

		protected abstract void HandleUpdate(double deltaTime);
	}
}