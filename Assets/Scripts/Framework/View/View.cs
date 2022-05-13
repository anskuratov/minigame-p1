using UnityEngine;

namespace P1.Framework
{
	public class View : MonoBehaviour
	{
		public void SetScale(Vector3 vector)
		{
			transform.localScale = vector;
		}

		public void SetPosition(Vector3 vector)
		{
			transform.localPosition = vector;
		}

		public void SetActive(bool value)
		{
			gameObject.SetActive(value);
		}
	}

	public abstract class BaseViewController<TView>
		where TView : View
	{
		protected TView View { get; private set; }

		protected virtual void HandleRefresh()
		{
		}

		public void Refresh()
		{
			HandleRefresh();
		}

		public void SetView(TView view)
		{
			View = view;
		}

		public void SetScale(Vector3 vector)
		{
			if (View != null)
			{
				View.SetScale(vector);
			}
		}

		public void SetPosition(Vector3 vector)
		{
			if (View != null)
			{
				View.SetPosition(vector);
			}
		}

		public void SetActive(bool value)
		{
			if (View != null
				&& View.gameObject.activeSelf != value)
			{
				View.SetActive(value);
			}
		}
	}

	public abstract class ViewController<TView> : BaseViewController<TView>,
		IInitializable
		where TView : View
	{
		protected abstract void HandleInit();

		public void Init()
		{
			HandleInit();
		}
	}

	public abstract class ViewController<TView, TInitData> : BaseViewController<TView>,
		IInitializable<TInitData>
		where TView : View
		where TInitData : struct
	{
		protected abstract void HandleInit(TInitData initData);

		public void Init(TInitData initData)
		{
			HandleInit(initData);
		}
	}
}