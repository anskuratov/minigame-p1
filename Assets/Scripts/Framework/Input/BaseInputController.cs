using UnityEngine;

namespace P1.Framework
{
	public abstract class BaseInputController : IInputController
	{
		private readonly InputPointer _inputPointer;

		private IDraggable _currentDraggable;

		protected BaseInputController(IUpdater updater)
		{
			_inputPointer = new InputPointer();
			updater.Add(this);
		}

		public void Update(double deltaTime)
		{
			HandleUpdate(deltaTime);
		}

		protected abstract void HandleUpdate(double deltaTime);

		protected void Start()
		{
			if (RaycastUtils.TryRaycast(out var transform))
			{
				var clickable = transform.GetComponent<IClickable>();
				clickable?.Click();

				var draggable = transform.GetComponent<IDraggable>();
				if (draggable != null)
				{
					_currentDraggable = draggable;
					_currentDraggable.StartDrag();
				}
			}
		}

		protected void Stop()
		{
			_currentDraggable?.EndDrag();
			_currentDraggable = null;
		}

		protected void Interact()
		{
			if (_currentDraggable?.Disabled ?? false)
			{
				_currentDraggable = null;
			}
			else
			{
				_inputPointer.Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				_currentDraggable?.Drag(_inputPointer);
			}
		}
	}
}