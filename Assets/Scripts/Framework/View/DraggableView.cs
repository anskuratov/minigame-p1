using System;

namespace P1.Framework
{
	public abstract class DraggableView : View,
		IDraggable
	{
		public event Action OnDragStarted;
		public event Action OnDragEnded;
		public event Action<IPointer> OnDragged;

		public bool Disabled { get; set; }

		public void StartDrag()
		{
			HandleStartDrag();
			OnDragStarted?.Invoke();
		}

		public void EndDrag()
		{
			HandleEndDrag();
			OnDragEnded?.Invoke();
		}

		public void Drag(IPointer pointer)
		{
			HandleDrag(pointer);
			OnDragged?.Invoke(pointer);
		}

		protected virtual void HandleStartDrag()
		{
		}

		protected virtual void HandleEndDrag()
		{
		}

		protected virtual void HandleDrag(IPointer pointer)
		{
		}
	}
}