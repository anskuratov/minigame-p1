using System;
using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class CircleSceneView : DraggableView
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;
		[SerializeField] private LineRenderer _lineRenderer;

		public SpriteRenderer SpriteRenderer => _spriteRenderer;
		public LineRenderer LineRenderer => _lineRenderer;

		public event Action OnConnected;

		public void Connect()
		{
			OnConnected?.Invoke();
		}

		// TODO: Это должна быть модель, доступная как из View так и из контроллера
		public int Number { get; set; }
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

		private int _number;
		private bool _isConnected;

		protected override void HandleInit(InitData initData)
		{
			_number = initData.Circle.Number;
			View.Number = initData.Circle.Number;

			SetPosition(initData.Circle.Position);
			SetColor();

			View.OnConnected += OnConnected;
			View.OnDragStarted += OnDragStarted;
			View.OnDragEnded += OnDragEnded;
			View.OnDragged += OnDragged;
		}

		private void SetColor()
		{
			if (ColorUtils.TryGetCircleColor(_number, out var color))
			{
				View.SpriteRenderer.color = color;
				View.LineRenderer.startColor = color;
				View.LineRenderer.endColor = color;
			}
			else
			{
				View.SpriteRenderer.color = Color.black;
			}
		}

		private void OnConnected()
		{
			View.OnConnected -= OnConnected;
			View.OnDragStarted -= OnDragStarted;
			View.OnDragEnded -= OnDragEnded;
			View.OnDragged -= OnDragged;
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

			if (RaycastUtils.TryRaycast(out var transform))
			{
				var circleSceneView = transform.GetComponent<CircleSceneView>();

				if (circleSceneView != null
					&& View != circleSceneView
					&& View.Number == circleSceneView.Number)
				{
					View.Connect();
					circleSceneView.Connect();

					View.LineRenderer.SetPosition(1, circleSceneView.transform.localPosition);
				}
			}
		}
	}
}