using System;

namespace P1.Framework
{
	public interface IClickable
	{
		event Action OnClicked;

		void Click();
	}
}