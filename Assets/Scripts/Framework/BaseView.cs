using UnityEngine;

namespace P1.Framework
{
	public class BaseView : MonoBehaviour
	{
	}

	public abstract class BaseViewController<TView, TInitData> : IInitializable<TInitData>
		where TView : BaseView
		where TInitData : struct
	{
		protected TView View { get; private set; }

		protected abstract void HandleInit(TInitData initData);

		public void Init(TInitData initData)
		{
			HandleInit(initData);
		}

		public void SetView(TView view)
		{
			View = view;
		}
	}
}