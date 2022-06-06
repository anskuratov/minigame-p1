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
			if (Input.touches.Length > 0)
			{
				if (Input.GetTouch(0).phase == TouchPhase.Began)
				{
					Start();
					Interact();
				}
				else if (Input.GetTouch(0).phase == TouchPhase.Ended)
				{
					Stop();
				}
				else if (Input.GetTouch(0).phase == TouchPhase.Moved)
				{
					Interact();
				}
			}
		}
	}
}