using P1.Framework;

namespace P1.Core
{
	public class InputControllerFactory : IFactory<IInputController>
	{
		private readonly IUpdater _updater;

		public InputControllerFactory(IUpdater updater)
		{
			_updater = updater;
		}

		public IInputController Create()
		{
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
			return new SmartphoneInputController(_updater);
#else
			return new StandaloneInputController(_updater);
#endif
		}
	}
}