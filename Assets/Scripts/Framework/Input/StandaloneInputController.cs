using UnityEngine;

namespace P1.Framework
{
	public class StandaloneInputController : BaseInputController
	{
		public StandaloneInputController(IUpdater updater) : base(updater)
		{
		}

		protected override void HandleUpdate(double deltaTime)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				Start();
			}
			else if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				Stop();
			}

			if (Input.GetKey(KeyCode.Mouse0))
			{
				Interact();
			}
		}
	}
}