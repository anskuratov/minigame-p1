using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class StandaloneInputController : BaseInputController
	{
		private IDraggable _currentDraggable;

		public StandaloneInputController(IUpdater updater, Camera camera) : base(updater, camera)
		{
		}

		protected override void HandleUpdate(double deltaTime)
		{
			InputPointer.Position = Camera.ScreenToWorldPoint(Input.mousePosition);

			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				if (TryRaycast(out var transform))
				{
					var clickable = transform.GetComponent<IClickable>();
					if (clickable != null)
					{
						clickable.Click();
					}

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
				_currentDraggable?.Drag(InputPointer);
			}
		}

		private bool TryRaycast(out Transform raycastTransform)
		{
			var returnValue = false;
			raycastTransform = default;

			var collider = Physics2D.OverlapPoint(Camera.ScreenToWorldPoint(Input.mousePosition));

			if (collider)
			{
				raycastTransform = collider.transform;
				returnValue = true;
			}

			return returnValue;
		}
	}
}