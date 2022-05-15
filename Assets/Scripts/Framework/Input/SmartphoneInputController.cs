using UnityEngine;

namespace P1.Framework
{
	public class SmartphoneInputController : BaseInputController
	{
		public SmartphoneInputController(IUpdater updater) : base(updater)
		{
		}

		protected override void HandleUpdate(double deltaTime)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				Start();
			}
			else if (Input.GetTouch(0).phase == TouchPhase.Canceled)
			{
				Stop();
			}

			if (Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Interact();
			}
		}
	}
}