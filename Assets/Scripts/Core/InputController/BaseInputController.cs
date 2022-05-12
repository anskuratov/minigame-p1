using P1.Framework;

namespace P1.Core
{
	public abstract class BaseInputController : IInputController
	{
		protected readonly InputPointer InputPointer;

		protected BaseInputController(IUpdater updater)
		{
			InputPointer = new InputPointer();
			updater.Add(this);
		}

		public void Update(double deltaTime)
		{
			HandleUpdate(deltaTime);
		}

		protected abstract void HandleUpdate(double deltaTime);
	}
}