using System;
using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class CircleSceneView : BaseView, IDraggable
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private LineRenderer _lineRenderer;

		public SpriteRenderer SpriteRenderer => _spriteRenderer;
		public LineRenderer LineRenderer => _lineRenderer;

		public event Action OnDragStarted;
		public event Action OnDragEnded;
		public event Action<IPointer> OnDragged;

		public void StartDrag()
		{
			OnDragStarted?.Invoke();
		}

		public void EndDrag()
		{
			OnDragEnded?.Invoke();
		}

		public void Drag(IPointer pointer)
		{
			OnDragged?.Invoke(pointer);
		}
	}

	public class CircleSceneViewController : BaseViewController<CircleSceneView, CircleSceneViewController.InitData>
	{
		public readonly struct InitData
		{
			public readonly Circle Circle;

			public InitData(Circle circle)
			{
				Circle = circle;
			}
		}

		protected override void HandleInit(InitData initData)
		{
			SetPosition(initData.Circle.Position);
			SetColor(initData.Circle.Number);

			View.OnDragStarted += OnDragStarted;
			View.OnDragEnded += OnDragEnded;
			View.OnDragged += OnDragged;
		}

		private void SetColor(int number)
		{
			if (ColorUtils.TryGetCircleColor(number, out var color))
			{
				View.SpriteRenderer.color = color;
				View.LineRenderer.startColor = color;
				View.LineRenderer.endColor = color;
			}
			else
			{
				View.SpriteRenderer.color= Color.black;
			}
		}

		private void OnDragStarted()
		{
			View.LineRenderer.SetPosition(0, View.transform.localPosition);
		}

		private void OnDragEnded()
		{
			View.LineRenderer.SetPosition(1, View.transform.localPosition);
		}

		private void OnDragged(IPointer pointer)
		{
			View.LineRenderer.SetPosition(1, pointer.Position);
		}
	}
}