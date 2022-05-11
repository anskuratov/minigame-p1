using System.Collections.Generic;
using P1.Framework;
using UnityEngine;

namespace P1.Core
{
	public class CircleSceneView : BaseView
	{
		[SerializeField] private SpriteRenderer _spriteRenderer;

		public SpriteRenderer SpriteRenderer => _spriteRenderer;
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
		}

		private void SetColorByNumber(int number)
		{
			var remainder = number % Divider;

			if (RemainderToHexColor.TryGetValue(remainder, out var hexColor)
				&& ColorUtility.TryParseHtmlString(hexColor.ToLower(), out var color))
			{
				View.SpriteRenderer.color = color;
			}
			else
			{
				View.SpriteRenderer.color= Color.black;
			}
		}
	}
}