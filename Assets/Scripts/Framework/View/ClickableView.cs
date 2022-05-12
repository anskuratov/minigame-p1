using System;

namespace P1.Framework
{
	public abstract class ClickableView : BaseView,
		IClickable
	{
		public event Action OnClicked;

		public void Click()
		{
			HandleClick();
			OnClicked?.Invoke();
		}

		protected virtual void HandleClick()
		{
		}
	}
}