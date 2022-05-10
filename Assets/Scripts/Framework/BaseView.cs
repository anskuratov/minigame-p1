using UnityEngine;

namespace P1.Framework
{
	public class BaseView : MonoBehaviour
	{
		internal void SetScale(Vector3 vector)
		{
			transform.localScale = vector;
		}

		internal void SetPosition(Vector3 vector)
		{
			transform.localPosition = vector;
		}

		internal void SetActive(bool value)
		{
			gameObject.SetActive(value);
		}
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

		protected void SetScale(Vector3 vector)
		{
			if (View != null)
			{
				View.SetScale(vector);
			}
		}

		protected void SetPosition(Vector3 vector)
		{
			if (View != null)
			{
				View.SetPosition(vector);
			}
		}

		protected void SetActive(bool value)
		{
			if (View != null
				&& View.gameObject.activeSelf != value)
			{
				View.SetActive(value);
			}
		}
	}
}