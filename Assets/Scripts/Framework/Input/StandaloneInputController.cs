using UnityEngine;

namespace P1.Framework
{
	public class StandaloneInputController : BaseInputController
	{
		private IDraggable _currentDraggable;

		public StandaloneInputController(IUpdater updater) : base(updater)
		{
		}

		protected override void HandleUpdate(double deltaTime)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
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
			else if (Input.GetKeyUp(KeyCode.Mouse0))
			{
				_currentDraggable?.EndDrag();
				_currentDraggable = null;
			}

			if (Input.GetKey(KeyCode.Mouse0))
			{
				if (_currentDraggable?.Disabled ?? false)
				{
					_currentDraggable = null;
				}
				else
				{
					InputPointer.Position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					_currentDraggable?.Drag(InputPointer);
				}
			}
		}
	}
}