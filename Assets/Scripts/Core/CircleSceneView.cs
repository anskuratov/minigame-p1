using System;
using System.Collections.Generic;
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
		private const int Divider = 9;

		private static readonly Dictionary<int, string> RemainderToHexColor = new()
		{
			{ 1, "#2A3A9C" },
			{ 2, "#ADE4FF" },
			{ 3, "#FFA96E" },
			{ 4, "#7682CC" },
			{ 5, "#D49B87" },
			{ 6, "#53D492" },
			{ 7, "#9C6703" },
			{ 8, "#A83B7E" }
		};

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
			SetColorByNumber(initData.Circle.Number);

			View.OnDragStarted += OnDragStarted;
			View.OnDragEnded += OnDragEnded;
			View.OnDragged += OnDragged;
		}

		private void SetColorByNumber(int number)
		{
			var remainder = number % Divider;

			if (RemainderToHexColor.TryGetValue(remainder, out var hexColor)
				&& ColorUtility.TryParseHtmlString(hexColor.ToLower(), out var color))
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