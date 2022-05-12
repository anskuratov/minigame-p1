using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class InputControllerFactory : IFactory<IInputController>
	{
		private readonly IUpdater _updater;
		private readonly Camera _camera;

		public InputControllerFactory(IUpdater updater, Camera camera)
		{
			_updater = updater;
			_camera = camera;
		}

		public IInputController Create()
		{
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
			return new SmartphoneInputController(_updater, _camera);
#else
			return new StandaloneInputController(_updater, _camera);
#endif
		}
	}
}