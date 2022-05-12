using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class SmartphoneInputController : BaseInputController
	{
		public SmartphoneInputController(IUpdater updater, Camera camera) : base(updater, camera)
		{
		}

		protected override void HandleUpdate(double deltaTime)
		{
		}
	}
}