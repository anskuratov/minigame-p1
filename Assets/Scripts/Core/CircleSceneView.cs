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

			var color = ColorUtils.GetColorByNumber(initData.Circle.Number); 
			SetColor(color);
		}

		private void SetColor(Color color)
		{
			View.SpriteRenderer.color = color;
		}
	}
}